using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Policy;


namespace UIControl
{
    public partial class Form1 : Form
    {

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _One;
        private static Gesture _rotateGestureL;
        private static Gesture _dropTheMicGesture;
        private static Gesture _likeGesture;
        private static Gesture _OpenPalmGesture;
        private static Gesture _OkGesture;
        private static Gesture _RockGesture;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kinect Project Test";

        }

        public Form1()
        {
            InitializeComponent();
            InitializeGestures();
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
            await RegisterOneGesture();

        }
        private static async Task RegisterOneGesture()
        {
            // Start with defining the first pose, ...
            var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var hold = new HandPose("Hold", new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Thumb, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new PalmPose(new AnyHandContext(), PoseDirection.Forward));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _One = new Gesture("One", hold, Iddle);
            _One.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            _One.Triggered += (s, e) => Executor(s, e, ConsoleColor.DarkRed);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_One, isGlobal: true);
        }





        private static void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gesture detected! : ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);

            Console.ResetColor();
        }

        static void Executor(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {
            string rutaArchivoExe = @"C:\Users\mitch\OneDrive\Documents\Visual Studio Projects\KinectProject\MusicControl\bin\Debug\netcoreapp3.1\MusicControl.exe"; // Reemplaza con la ruta completa de tu archivo .bat


            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = rutaArchivoExe,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            };

                Process process = new Process
                {
                    StartInfo = processInfo
                };

                process.Start();
                StreamReader reader = process.StandardOutput;
                string salida = reader.ReadToEnd();
                Console.WriteLine(salida);

                process.WaitForExit();




            //process.Close();

            // Puedes mostrar un mensaje cuando el proceso haya terminado
            /*Console.WriteLine("Proceso .bat completado.");
            Console.Clear();
            */
            }
        }



}

    
