using System;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Drawing;


namespace UIControl
{
    public partial class ControlBForm : Form
    {

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _rotateHSGestureR;
        private static Gesture _rotateHSGestureL;
        private static Gesture _LikeGesture;
        private static Gesture _DisLikeGesture;
        private static Gesture _DoceGesture;
        private static Gesture _CrownGesture;

        //Variables
        private static int Color = 0;
        private static int Brightness = 100;
        private static int Toggle = 1;
        private static int FirstTime = 0;
        private static string rutaArchivoBat = @""; // Reemplaza con la ruta completa de tu archivo .bat
        private static string ColorChange = "";
        private static string BrightnessChange = "";

        public ControlBForm()
        {

            InitializeComponent();
            InitializeGestures();
            
        }
        private void Form1_load(object sender, EventArgs e)
        {
            this.Text = "Bulb Control!";
        }
        


        private async void InitializeGestures()
        {
            // One can optionally pass the hostname/IP address where the gestures service is hosted
            var gesturesServiceHostName = "localhost";
            await RegisterGestures(gesturesServiceHostName);
        }

        private static async Task RegisterGestures(string gesturesServiceHostName)
        {
            // Step 1: Connect to Microsoft Gestures service            
            _gesturesService = GesturesServiceEndpointFactory.Create(gesturesServiceHostName);
            await _gesturesService.ConnectAsync();

            // Step 2: Define bunch of custom Gestures, each detection of the gesture will emit some message into the console
            await RegisterHandShakeRightGesture();
            await RegisterHandShakeLeftGesture();
            await RegisterLikeGesture();
            await RegisterDisLikeGesture();
            await RegisterDoceGesture();
            await RegisterCrownGesture();
        }

        private static async Task RegisterHandShakeRightGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new AllFingersContext(), FingerFlexion.Open, PoseDirection.Forward),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Left));
            // ... define the second pose, ...
            var right = new HandPose("Right", new FingerPose(new AllFingersContext(), FingerFlexion.Open),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, PoseDirection.Right),
                                              new FingerPose(Finger.Thumb, PoseDirection.Up),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Forward));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _rotateHSGestureR = new Gesture("HandshakeRight", front, right);
            _rotateHSGestureR.Triggered += (s, e) => Executor(s, e, ConsoleColor.Yellow);

            InputSimulator sim = new InputSimulator();
            _rotateHSGestureR.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_8);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_rotateHSGestureR, isGlobal: true);
        }

        //Anterior Diapositiva
        private static async Task RegisterHandShakeLeftGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new AllFingersContext(), FingerFlexion.Open, PoseDirection.Forward),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Left));
            // ... define the second pose, ...
            var left = new HandPose("Left", new FingerPose(new AllFingersContext(), FingerFlexion.Open),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, PoseDirection.Left),
                                            new FingerPose(Finger.Thumb, PoseDirection.Up),
                                            new PalmPose(new AnyHandContext(), PoseDirection.Backward));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _rotateHSGestureL = new Gesture("HandshakeLeft", front, left);
            _rotateHSGestureL.Triggered += (s, e) => Executor(s, e, ConsoleColor.DarkYellow);
            InputSimulator sim = new InputSimulator();
            _rotateHSGestureL.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_8);



            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_rotateHSGestureL, isGlobal: true);
        }

        private static async Task RegisterDoceGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new AllFingersContext(), FingerFlexion.Open, PoseDirection.Up),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Forward));
            // ... define the second pose, ...
            var left = new HandPose("Left", new FingerPose(new[] { Finger.Index, Finger.Thumb, Finger.Pinky }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Pinky),
                                            new FingerPose(new[] {Finger.Middle, Finger.Ring}, FingerFlexion.Open, PoseDirection.Up ),
                                            new PalmPose(new AnyHandContext(), PoseDirection.Forward));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _DoceGesture = new Gesture("Doce", front, left);
            _DoceGesture.Triggered += (s, e) => Executor(s, e, ConsoleColor.DarkYellow);

            InputSimulator sim = new InputSimulator();
            _DoceGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_3);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_DoceGesture, isGlobal: true);
        }

        private static async Task RegisterCrownGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new AllFingersContext(), FingerFlexion.Open, PoseDirection.Up),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Forward));
            // ... define the second pose, ...
            var left = new HandPose("Left", new FingerPose(new[] { Finger.Middle, Finger.Thumb, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Index, Finger.Ring }, FingerFlexion.Open, PoseDirection.Forward),
                                            new PalmPose(new AnyHandContext(), PoseDirection.Forward));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _CrownGesture = new Gesture("Crown", front, left);
            _CrownGesture.Triggered += (s, e) => Executor(s, e, ConsoleColor.DarkYellow);
            InputSimulator sim = new InputSimulator();
            _CrownGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_3);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_CrownGesture, isGlobal: true);
        }

        private static async Task RegisterLikeGesture()
        {
            // Start with defining the first pose, ...
            var like = new HandPose("Like", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Left));
            // ... define the second pose, ...
            var right = new HandPose("Right", new FingerPose(new AllFingersContext(), FingerFlexion.Folded),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Left)) ;

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _LikeGesture = new Gesture("LikeG", right, like);
            _LikeGesture.Triggered += (s, e) => Executor(s, e, ConsoleColor.Yellow);
            InputSimulator sim = new InputSimulator();
            _LikeGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_7);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_LikeGesture, isGlobal: true);
        }

        private static async Task RegisterDisLikeGesture()
        {
            // Start with defining the first pose, ...
            var like = new HandPose("Like", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Down),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Right));
            // ... define the second pose, ...
            var right = new HandPose("Right", new FingerPose(new AllFingersContext(), FingerFlexion.Folded),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Right));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _DisLikeGesture = new Gesture("DisLikeG", right, like);
            _DisLikeGesture.Triggered += (s, e) => Executor(s, e, ConsoleColor.Yellow);

            InputSimulator sim = new InputSimulator();
            _DisLikeGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_9);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_DisLikeGesture, isGlobal: true);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D8)
            {
                if(Brightness == 100)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_100.jpg");
                    PBBrillo.Refresh();
                }
                if (Brightness == 80)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_80.jpg");
                    PBBrillo.Refresh();
                }
                if (Brightness == 60)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_60.jpg");
                    PBBrillo.Refresh();
                }
                if (Brightness == 40)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_40.jpg");
                    PBBrillo.Refresh();
                }
                if (Brightness == 20)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_20.jpg");
                    PBBrillo.Refresh();
                }
                if (Brightness == 0)
                {
                    this.PBBrillo.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\Brightness_0.jpg");
                    PBBrillo.Refresh();
                }

                if(BrightnessChange == "Yes" || ColorChange == "Yes")
                {
                    this.PBActua.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ChangesNS.jpg");
                    PBActua.Refresh();
                }

                //C:\Users\mitch\source\repos\DJxRott\KinectProject\UIControl\Resources
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.D7)
            {
                if (Toggle == 1)
                {
                    this.PBoxOnOff.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ON.png");
                    PBoxOnOff.Refresh();
                }
                else if (Toggle == 0)
                {
                    this.PBoxOnOff.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\OFF.png");
                    PBoxOnOff.Refresh();
                }
               
                //C:\Users\mitch\source\repos\DJxRott\KinectProject\UIControl\Resources
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.D3)
            {

                if (Color == 0)
                {
                    this.PBColor.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ColorW.jpg");
                    PBColor.Refresh();
                }
                if (Color == 1)
                {
                    this.PBColor.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ColorR.jpg");
                    PBColor.Refresh();
                }
                if (Color == 2)
                {
                    this.PBColor.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ColorG.jpg");
                    PBColor.Refresh();
                }
                if (Color == 3)
                {
                    this.PBColor.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ColorB.jpg");
                    PBColor.Refresh();
                }
                if (Color == 4)
                {
                    this.PBColor.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ColorM.jpg");
                    PBColor.Refresh();
                }//ColorM

                if (BrightnessChange == "Yes" || ColorChange == "Yes")
                {
                    this.PBActua.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\ChangesNS.jpg");
                    PBActua.Refresh();
                }

                //C:\Users\mitch\source\repos\DJxRott\KinectProject\UIControl\Resources
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


            if (e.KeyCode == Keys.D9)
            {
                    this.PBActua.Image = new Bitmap("C:\\Users\\mitch\\source\\repos\\DJxRott\\KinectProject\\BulbControlForm\\Resources\\gud.jpg");
                    PBActua.Refresh();
            }
            
        }

        static void Executor(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {

            ///////////////////////////////////////// Brillo ////////////////////////////////////////////////
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process
            {
                StartInfo = processInfo
            };

            ///////////////////////////////////////// Color ////////////////////////////////////////////////

            ProcessStartInfo processInfo2 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process2 = new Process
            {
                StartInfo = processInfo2
            };

            

            if (FirstTime == 0)
            {
                string rutaArchivoBat3 = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorWhite.cmd";


                //////Color Blanco///////
                process2.Start();
                process2.StandardInput.WriteLine($"\"{rutaArchivoBat3}\"");
                process2.Close();
                
                ///////Brillo al 100%////////////////
                rutaArchivoBat3 = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness100.cmd";
                process.Start();
                process.StandardInput.WriteLine($"\"{rutaArchivoBat3}\"");
                process.Close();
                FirstTime++;
            }

            if (args.GestureSegment.Name == "HandshakeLeft")
            {
                Brightness -= 20;
                if (Brightness < 0)
                {
                    Brightness = 0;
                }
                

                BrightnessChange = "Yes";
            }

            else if (args.GestureSegment.Name == "HandshakeRight")
            {
                Brightness += 20;
                if (Brightness > 100)
                {
                    Brightness = 100;
                    Console.Write("Brillo al 100%");
                }
                
                BrightnessChange = "Yes";
            }


            if (args.GestureSegment.Name == "Doce")
             {

                Color++;
                if (Color == 5)
                {
                    Color = 0;
                }
                

                ColorChange = "Yes";

            }

            if (args.GestureSegment.Name == "LikeG")
            {
                string rutaArchivoBat2 = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Toggle.cmd";
                process2.Start();
                process2.StandardInput.WriteLine($"\"{rutaArchivoBat2}\"");
                process2.Close();
                if (Toggle == 0)
                {
                    Toggle++;
                } 
                else if (Toggle == 0)
                {
                    Toggle--;
                }
                else if (Toggle != 0 || Toggle != 1)
                {
                    Toggle = 0;
                }
            }


             if (args.GestureSegment.Name == "DisLikeG")
            {
                ///////////////////Brillo///////////////
                
                if (BrightnessChange == "Yes")
                {
                    if (Brightness == 100)
                    {
                        //Gesto RotateLeft Bajar el Brillo a 80%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness100.cmd";
                        Console.Write("Brillo al 100%");
                    }
                    else if (Brightness == 80)
                    {
                        //Gesto RotateLeft Bajar el Brillo a 80%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness80.cmd";
                        Console.Write("Brillo al 80%");
                    }
                    else if (Brightness == 60)
                    {
                        //Gesto RotateLeft Bajar el Brillo a 60%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness60.cmd";
                        Console.Write("Brillo al 60%");
                    }
                    else if (Brightness == 40)
                    {
                        //Gesto RotateLeft Para Bajar el Brillo a 40%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness40.cmd";
                        Console.Write("Brillo al 40%");
                    }
                    else if (Brightness == 20)
                    {
                        //Gesto RotateLeft Para Bajar el Brillo a 20%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness20.cmd";
                        Console.Write("Brillo al 20%");
                    }
                    else if (Brightness == 0)
                    {
                        //Gesto RotateLeft Bajar el Brillo a 0%
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness0.cmd";
                        Console.Write("Brillo al 0%");
                    }
                    BrightnessChange = "No";
                    process.Start();
                    process.StandardInput.WriteLine($"\"{rutaArchivoBat}\"");
                    process.Close();
                }

                if(ColorChange == "Yes")
                {
                    if (Color == 0)
                    {
                        //Gesto One Para Cambiar el color del bombillo a Blanco
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorWhite.cmd";
                    }
                    if (Color == 1)
                    {
                        //Gesto One Para Cambiar el color del bombillo a Rojo "R"
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorRed.cmd";
                    }
                    if (Color == 2)
                    {
                        //Gesto One Para Cambiar el color del bombillo a Verde "G"
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorGreen.cmd";
                    }
                    if (Color == 3)
                    {
                        //Gesto One Para Cambiar el color del bombillo a Azul "B"
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorBlue.cmd";
                    }
                    if (Color == 4)
                    {
                        //Gesto One Para Cambiar el color del bombillo a Morado "M"
                        rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorPurple.cmd";
                    }
                    ColorChange = "No";
                    process.Start();
                    process.StandardInput.WriteLine($"\"{rutaArchivoBat}\"");
                    process.Close();
                }

                
            }

            if (args.GestureSegment.Name == "Crown")
            {
                string rutaArchivoBat2 = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ColorWhite.cmd";
                process2.Start();
                process2.StandardInput.WriteLine($"\"{rutaArchivoBat2}\"");
                process2.Close();
                Color = 0;
            }
        }
    }
}
