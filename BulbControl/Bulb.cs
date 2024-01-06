using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Threading.Tasks;
using System.Threading;


class Bulb
{
    /// <summary>
    ///////////////////////////////////////////////////////////OJO FALTA AGREGAR GESTO PARA VALIDAR EL BRILLO DEL BOMBILLO
    /// </summary>
    //Gestures Variables
    private static GesturesServiceEndpoint _gesturesService;
    private static Gesture _rotateHSGestureR;
    private static Gesture _rotateHSGestureL;
    private static Gesture _One;
    private static Gesture _Two;
    private static Gesture _Three;
    private static Gesture _Four;
    private static Gesture _Five;


    //Brightness
    private static int Brightness = 100;
    private static int FirstTime= 0;
    private static int CommandCounter = 0;//Contador para deteccion continua de letras
    private static int CC = 0;

    static void Main(string[] args)
    {



        Console.Title = "GesturesServiceStatus[Initializing]";
        Console.WriteLine("press 'esc' to exit");
        

        // One can optionally pass the hostname/IP address where the gestures service is hosted
        var gesturesServiceHostName = !args.Any() ? "localhost" : args[0];
        RegisterGestures(gesturesServiceHostName).Wait();
        Thread.Sleep(100000);//agregado para que no se cierre la ventana de comandos
        /*while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }*/
    }

    private static async Task RegisterGestures(string gesturesServiceHostName)
    {
        // Step 1: Connect to Microsoft Gestures service            
        _gesturesService = GesturesServiceEndpointFactory.Create(gesturesServiceHostName);
        _gesturesService.StatusChanged += (s, arg) => Console.Title = $"GesturesServiceStatus [{arg.Status}]";
        await _gesturesService.ConnectAsync();

        // Step 2: Define bunch of custom Gestures, each detection of the gesture will emit some message into the console
        await RegisterHandShakeRightGesture();
        await RegisterHandShakeLeftGesture();
        await RegisterOneGesture();
        await RegisterTwoGesture();
        await RegisterThreeGesture();
        await RegisterFourGesture();
        await RegisterFiveGesture();

    }

    private static async Task RegisterHandShakeRightGesture()
    {
        // Start with defining the first pose, ...
        var front = new HandPose("Front", new FingerPose(new AllFingersContext(), FingerFlexion.Open, PoseDirection.Forward),
                                          new PalmPose(new AnyHandContext(), PoseDirection.Left));
        // ... define the second pose, ...
        var right = new HandPose("Right", new FingerPose(new AllFingersContext(), FingerFlexion.Open),
                                          new FingerPose(new[] {Finger.Index, Finger.Middle, Finger.Ring,Finger.Pinky}, PoseDirection.Right ),
                                          new FingerPose(Finger.Thumb, PoseDirection.Up),
                                          new PalmPose(new AnyHandContext(), PoseDirection.Forward));

        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _rotateHSGestureR = new Gesture("HandshakeRight", front, right);
        _rotateHSGestureR.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);

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
        _rotateHSGestureL.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_rotateHSGestureL, isGlobal: true);
    }

    private static async Task RegisterOneGesture()
    {
        // Start with defining the first pose, ...
        var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

        var hold = new HandPose("Hold", new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                                        new FingerPose(new[] { Finger.Thumb, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                        new PalmPose( new AnyHandContext(), PoseDirection.Forward));
       
        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _One = new Gesture("One", Iddle, hold);
        _One.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
        _One.Triggered += (s, e) => Executor(s, e, ConsoleColor.DarkRed);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_One, isGlobal: true);
    }
    private static async Task RegisterTwoGesture()
    {
        // Start with defining the first pose, ...
        var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));


        var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up),
                                        new FingerPose(new[] { Finger.Thumb, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                        new PalmPose(new AnyHandContext(), PoseDirection.Forward));

        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _Two = new Gesture("Two", Iddle, hold);
        _Two.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Green);
        _Two.Triggered += (s, e) => Executor(s, e, ConsoleColor.Green);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_Two, isGlobal: true);
    }
    private static async Task RegisterThreeGesture()
    {
        // Start with defining the first pose, ...

        var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

        var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Open, PoseDirection.Up),
                                        new FingerPose(new[] { Finger.Thumb, Finger.Pinky }, FingerFlexion.Folded),
                                        new PalmPose(new AnyHandContext(), PoseDirection.Forward));

        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _Three = new Gesture("Three", Iddle, hold);
        _Three.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);
        _Three.Triggered += (s, e) => Executor(s, e, ConsoleColor.Blue);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_Three, isGlobal: true);
    }

    private static async Task RegisterFourGesture()
    {
        // Start with defining the first pose, ...
        var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));


        var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up),
                                        new FingerPose( Finger.Thumb, FingerFlexion.Folded),
                                        new PalmPose(new AnyHandContext(), PoseDirection.Forward));

        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _Four = new Gesture("Four",Iddle, hold);
        _Four.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.White);
        _Four.Triggered += (s, e) => Executor(s, e, ConsoleColor.White);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_Four, isGlobal: true);
    }

    private static async Task RegisterFiveGesture()
    {
        // Start with defining the first pose, ...
        var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));


        var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb, Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up),
                                        new PalmPose(new AnyHandContext(), PoseDirection.Forward));

        // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
        _Five = new Gesture("Five",Iddle, hold);
        _Five.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Magenta);
        _Five.Triggered += (s, e) => Executor(s, e, ConsoleColor.Magenta);

        // Step 3: Register the gesture             
        // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
        // detected even it was initiated not by this application or if the this application isn't in focus
        await _gesturesService.RegisterGesture(_Five, isGlobal: true);
    }


    private static void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
    {
        CommandCounter++;

        if (CommandCounter == 30)
        {

            if (args.GestureSegment.Name == "One")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Gesture detected! : ");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine(args.GestureSegment.Name);

                    Console.ResetColor();
                    CommandCounter = 0;
            
            }else if(args.GestureSegment.Name == "Two")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Gesture detected! : ");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine(args.GestureSegment.Name);

                    Console.ResetColor();
                    CommandCounter = 0;

            }
            else if (args.GestureSegment.Name == "Three")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Gesture detected! : ");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine(args.GestureSegment.Name);

                    Console.ResetColor();
                    CommandCounter = 0;
            
            }
            else if (args.GestureSegment.Name == "Four")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Gesture detected! : ");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine(args.GestureSegment.Name);

                    Console.ResetColor();
                    CommandCounter = 0;
            
            }
            else if (args.GestureSegment.Name == "Five")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Gesture detected! : ");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine(args.GestureSegment.Name);

                    Console.ResetColor();
                    CommandCounter = 0;
            
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Gesture detected! : ");
                Console.ForegroundColor = foregroundColor;
                Console.WriteLine(args.GestureSegment.Name);

                Console.ResetColor();
                CommandCounter = 0;
            }
        }

        if (args.GestureSegment.Name == "RotateRight")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gesture detected! : ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);

            Console.ResetColor();
            CommandCounter = 0;
        }
        else if (args.GestureSegment.Name == "RotateLeft")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gesture detected! : ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);

            Console.ResetColor();
            CommandCounter = 0;
        }
    }


    static void Executor(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
    {
        string rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Login.cmd"; // Reemplaza con la ruta completa de tu archivo .bat
        CC++;
        if (args.GestureSegment.Name == "HandshakeLeft")
        {
            Brightness-=20;
            if (Brightness == 80)
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
            else if(Brightness < 0)
            {
                Brightness = 0;
            }
            CC = 0;
        }

        else if (args.GestureSegment.Name == "HandshakeRight")
        {
            Brightness += 20;
            if (Brightness == 100)
            {
                //Gesto RotateRight Para Subir el Brillo a 100%
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness100.cmd";
                Console.Write("Brillo al 100%");
            }
            else if (Brightness == 80)
            {
                //Gesto RotateRight Para Subir el Brillo a 80%
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness80.cmd";
                Console.Write("Brillo al 80%");
            }
            else if (Brightness == 60)
            {
                //Gesto RotateRight Para Subir el Brillo a 60%
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness60.cmd";
                Console.Write("Brillo al 60%");
            }
            else if (Brightness == 40)
            {
                //Gesto RotateRight Para Subir el Brillo a 40%
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness40.cmd";
                Console.Write("Brillo al 40%");
            }
            else if (Brightness == 20)
            {
                //Gesto RotateRight Para Subir el Brillo a 20%
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Brightness20.cmd";
                Console.Write("Brillo al 20%");
            }
            else if (Brightness > 100)
            {
                Brightness = 100;
                Console.Write("Brillo al 100%");
            }
            CC = 0;
        }


        if (CC == 30)
        {
            if (args.GestureSegment.Name == "One")
            {

                //Gesto One Para Cambiar el color del bombillo a Rojo "R"
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ChangeColorRed.cmd";
                Brightness = 100;
                CC = 0;

            }
            else if (args.GestureSegment.Name == "Two")
            {

                //Gesto One Para Cambiar el color del bombillo a Verde "G"
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ChangeColorGreen.cmd";
                Brightness = 100;
                CC = 0;

            }
            else if (args.GestureSegment.Name == "Three")
            {

                //Gesto One Para Cambiar el color del bombillo a Azul "B"
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ChangeColorBlue.cmd";
                Brightness = 100;
                CC = 0;

            }
            else if (args.GestureSegment.Name == "Four")
            {

                //Gesto One Para Cambiar el color del bombillo a Blanco
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ChangeColorWhite.cmd";

                CC = 0;

            }
            else if (args.GestureSegment.Name == "Five")
            {

                //Gesto One Para Cambiar el color del bombillo a Morado
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\ChangeColorPurple.cmd";

                CC = 0;
            }
            if (FirstTime == 0)
            {
                rutaArchivoBat = @"C:\Users\mitch\OneDrive\Escritorio\Batch\Login.cmd"; // Reemplaza con la ruta completa de tu archivo .bat
                FirstTime++;
                CC = 0;
            }

        }
        Console.Write(CC);

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

        if (args.GestureSegment.Name != "HandshakeRight")
        {
            if (args.GestureSegment.Name != "HandshakeLeft")
            {
                process.Start();
                // Ejecuta el archivo .bat mediante el símbolo del sistema
                process.StandardInput.WriteLine($"\"{rutaArchivoBat}\"");
                //process.StandardInput.WriteLine("exit");

                process.Close();

                // Puedes mostrar un mensaje cuando el proceso haya terminado
                /*Console.WriteLine("Proceso .bat completado.");
                Console.Clear();
                */
            }
        }

    }
    
}
