using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using WindowsInput;
using WindowsInput.Native;


namespace UIControl
{
    public partial class KMusicForm : Form
    {

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _rotateGestureR; //Subir Volumen
        private static Gesture _rotateGestureL; //Bajar Volumen
        private static Gesture _dropTheMicGesture; //Mute Volumen
        private static Gesture _RotateRMedia; //Media Next
        private static Gesture _RotateLMedia; //Media Back
        private static Gesture _RockGesture; //Play/Pause

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Music Control!";
        }

        public KMusicForm()
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
            await RegisterRotateRightGesture();
            await RegisterRotateLeftGesture();
            await RegisterDropTheMicGesture();
            await RegisterRotateRMedia();
            await RegisterRotateLMedia();
            await RegisterRockOnGesture();
        }

        private static async Task RegisterRotateRightGesture()//Subir Volumen
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Right, Finger.Thumb));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _rotateGestureR = new Gesture("RotateRight", hold, rotate);
            _rotateGestureR.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);
            InputSimulator sim = new InputSimulator();
            _rotateGestureR.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP, VirtualKeyCode.VOLUME_UP, VirtualKeyCode.VOLUME_UP);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_rotateGestureR, isGlobal: true);
        }

        private static async Task RegisterRotateLeftGesture()//Bajar Volumen
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Left, Finger.Thumb));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _rotateGestureL = new Gesture("RotateLeft", hold, rotate);
            _rotateGestureL.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);
            InputSimulator sim = new InputSimulator();
            _rotateGestureL.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_DOWN, VirtualKeyCode.VOLUME_DOWN, VirtualKeyCode.VOLUME_DOWN);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_rotateGestureL, isGlobal: true);
        }

        private static async Task RegisterDropTheMicGesture()//Vol Mute
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Down),
                                                new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Folded));
            // Final pose is when the hand is "open" i.e. spread
            var spread = new HandPose("Spread", new PalmPose(new AnyHandContext(), PoseDirection.Down),
                                                new FingerPose(new[] { Finger.Thumb, Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Open));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _dropTheMicGesture = new Gesture("DropTheMic", fist, spread);
            _dropTheMicGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);
            InputSimulator sim = new InputSimulator();
            _dropTheMicGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_STOP);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_dropTheMicGesture, isGlobal: true);
        }

        private static async Task RegisterRotateRMedia()//Media Next
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open),
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Right, Finger.Thumb));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _RotateRMedia = new Gesture("RotateRMedia", hold, rotate);
            _RotateRMedia.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);
            InputSimulator sim = new InputSimulator();
            _RotateRMedia.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_RotateRMedia, isGlobal: true);
        }

        private static async Task RegisterRotateLMedia()//Media Prev
        {
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open),
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Left, Finger.Thumb));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _RotateLMedia = new Gesture("RotateLMedia", hold, rotate);
            _RotateLMedia.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            InputSimulator sim = new InputSimulator();
            _RotateLMedia.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PREV_TRACK);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_RotateLMedia, isGlobal: true);
        }

        private static async Task RegisterRockOnGesture()//Play/Pause
        {
            var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var RockOn = new HandPose("Rock", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Thumb }, FingerFlexion.Folded),
                                             new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                             new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Ring),
                                             new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                             new FingerPose(new[] { Finger.Index, Finger.Pinky }, FingerFlexion.Open));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _RockGesture = new Gesture("RockOnGesture", Iddle, RockOn);
            _RockGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);
            InputSimulator sim = new InputSimulator();
            _RockGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_RockGesture, isGlobal: true);
        }


        private static void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gesture detected! : ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);

            Console.ResetColor();
        }


        /*static void Executor(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
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

        }*/
    }



}


