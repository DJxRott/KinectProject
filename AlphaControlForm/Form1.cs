
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using Microsoft.Gestures.Stock.Gestures;
using WindowsInput;
using WindowsInput.Native;

namespace UIControl
{
    public partial class AlphaForm : Form
    {
        public string RutaArch = "C:\\Users\\mitch\\OneDrive\\Documents\\Visual Studio Projects\\KinectProject\\AlphaControlForm\\Resources\\";

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _Letter_A;
        private static Gesture _Letter_B;
        private static Gesture _Letter_C;
        private static Gesture _Letter_D;
        private static Gesture _Letter_E;
        private static Gesture _Letter_F;
        private static Gesture _Letter_G;
        private static Gesture _Letter_H;
        private static Gesture _Letter_I;
        private static Gesture _Letter_J;
        private static Gesture _Letter_K;
        private static Gesture _Letter_L;
        private static Gesture _Letter_M;
        private static Gesture _Letter_N;
        private static Gesture _Letter_O;
        private static Gesture _Letter_P;
        private static Gesture _Letter_Q;
        private static Gesture _Letter_R;
        private static Gesture _Letter_S;
        private static Gesture _Letter_T;
        private static Gesture _Letter_U;
        private static Gesture _Letter_V;
        private static Gesture _Letter_W;
        private static Gesture _Letter_X;
        private static Gesture _Letter_Y;
        private static Gesture _Letter_Z;


        public AlphaForm()
        {
            InitializeComponent();
            InitializeGestures();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Music Control!";

            /////////////////////////////////////////////////// Mouse Enter Event/////////////////////////////////////////////////////////////////////////
            BT_A.MouseEnter += new EventHandler(BT_A_MouseEnter);
            BT_B.MouseEnter += new EventHandler(BT_B_MouseEnter);
            BT_C.MouseEnter += new EventHandler(BT_C_MouseEnter);
            BT_D.MouseEnter += new EventHandler(BT_D_MouseEnter);
            BT_E.MouseEnter += new EventHandler(BT_E_MouseEnter);
            BT_F.MouseEnter += new EventHandler(BT_F_MouseEnter);
            BT_G.MouseEnter += new EventHandler(BT_G_MouseEnter);
            BT_H.MouseEnter += new EventHandler(BT_H_MouseEnter);
            BT_I.MouseEnter += new EventHandler(BT_I_MouseEnter);
            BT_J.MouseEnter += new EventHandler(BT_J_MouseEnter);
            BT_K.MouseEnter += new EventHandler(BT_K_MouseEnter);
            BT_L.MouseEnter += new EventHandler(BT_L_MouseEnter);
            BT_M.MouseEnter += new EventHandler(BT_M_MouseEnter);
            BT_N.MouseEnter += new EventHandler(BT_N_MouseEnter);
            BT_O.MouseEnter += new EventHandler(BT_O_MouseEnter);
            BT_P.MouseEnter += new EventHandler(BT_P_MouseEnter);
            BT_Q.MouseEnter += new EventHandler(BT_Q_MouseEnter);
            BT_R.MouseEnter += new EventHandler(BT_R_MouseEnter);
            BT_S.MouseEnter += new EventHandler(BT_S_MouseEnter);
            BT_T.MouseEnter += new EventHandler(BT_T_MouseEnter);
            BT_U.MouseEnter += new EventHandler(BT_U_MouseEnter);
            BT_V.MouseEnter += new EventHandler(BT_V_MouseEnter);
            BT_W.MouseEnter += new EventHandler(BT_W_MouseEnter);
            BT_X.MouseEnter += new EventHandler(BT_X_MouseEnter);
            BT_Y.MouseEnter += new EventHandler(BT_Y_MouseEnter);
            BT_Z.MouseEnter += new EventHandler(BT_Z_MouseEnter);

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
             await RegLetter_A();
             await RegLetter_B();
             await RegLetter_C();
             await RegLetter_D();
             await RegLetter_E();
             await RegLetter_F();
             await RegLetter_G();
             await RegLetter_H();
             await RegLetter_I();
             await RegLetter_J();
             await RegLetter_K();
             await RegLetter_L();
             await RegLetter_M();
             await RegLetter_N();
             await RegLetter_O();
             await RegLetter_P();
             await RegLetter_Q();
             await RegLetter_R();
             await RegLetter_S();
             await RegLetter_T();
             await RegLetter_U();
             await RegLetter_V();
             await RegLetter_W();
             await RegLetter_X();
             await RegLetter_Y();
            await RegLetter_Z();
        }
        
        private static async Task RegLetter_A()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded, PoseDirection.Down),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Index),
                                              new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_A = new Gesture("A", iddle);
            _Letter_A.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);
            InputSimulator sim = new InputSimulator();
            _Letter_A.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_A, isGlobal: true);
        }

        private static async Task RegLetter_B()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(Finger.Thumb, FingerFlexion.Folded, PoseDirection.Right),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                            new FingertipDistanceRelation(Finger.Ring, RelativeDistance.Touching, Finger.Pinky));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_B = new Gesture("B", hold);
            _Letter_B.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);
            InputSimulator sim = new InputSimulator();
            _Letter_B.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_B, isGlobal: true);
        }

        private static async Task RegLetter_C()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_C = new Gesture("C", fist);
            _Letter_C.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);
            InputSimulator sim = new InputSimulator();
            _Letter_C.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_C);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus


            await _gesturesService.RegisterGesture(_Letter_C, isGlobal: true);

        }

        private static async Task RegLetter_D()
        {
            // Start with defining the first pose, ...
            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Left),
                new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, new[] { Finger.Middle, Finger.Ring }),
                new FingerPose(Finger.Thumb, FingerFlexion.Folded));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_D = new Gesture("D", Open);
            _Letter_D.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);
            InputSimulator sim = new InputSimulator();
            _Letter_D.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_D);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_D, isGlobal: true);
        }

        private static async Task RegLetter_E()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, PoseDirection.Down),
                                            new FingerPose(Finger.Thumb, FingerFlexion.FoldedTucked),
                                            new FingertipDistanceRelation(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, RelativeDistance.Touching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Below, Finger.Middle));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_E = new Gesture("E", fist);
            _Letter_E.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);
            InputSimulator sim = new InputSimulator();
            _Letter_E.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_E);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_E, isGlobal: true);
        }

        private static async Task RegLetter_F()
        {


            var Ok = new HandPose("Oks", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Folded, PoseDirection.Undefined),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Thumb), new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                             new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_F = new Gesture("F", Ok);
            _Letter_F.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            InputSimulator sim = new InputSimulator();
            _Letter_F.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_F);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_F, isGlobal: true);
        }

        private static async Task RegLetter_G()
        {


            var RockOn = new HandPose("Rock", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                             new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Left),
                                             new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_G = new Gesture("G", RockOn);
            _Letter_G.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);
            InputSimulator sim = new InputSimulator();
            _Letter_G.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_G);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_G, isGlobal: true);
        }

        private static async Task RegLetter_H()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Left),
                                              new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                              new FingerPose(new[] { Finger.Ring, Finger.Pinky }, FingerFlexion.Folded));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_H = new Gesture("H", iddle);
            _Letter_H.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);
            InputSimulator sim = new InputSimulator();
            _Letter_H.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_H);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_H, isGlobal: true);
        }

        private static async Task RegLetter_I()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Folded),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Index),
                                              new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Left, Finger.Index),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Middle),
                                              new FingerPose(Finger.Pinky, FingerFlexion.Open, PoseDirection.Up));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_I = new Gesture("I", iddle);
            _Letter_I.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow); 
            InputSimulator sim = new InputSimulator();
            _Letter_I.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_I);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_I, isGlobal: true);
        }

        private static async Task RegLetter_J()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Pinky, FingerFlexion.Open, PoseDirection.Up));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_J = new Gesture("J", iddle);
            _Letter_J.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkCyan);
            InputSimulator sim = new InputSimulator();
            _Letter_J.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_J);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_J, isGlobal: true);
        }

        private static async Task RegLetter_K()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                                new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                                                new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Right),
                                                new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky, }, FingerFlexion.Folded));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_K = new Gesture("K", fist);
            _Letter_K.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);
            InputSimulator sim = new InputSimulator();
            _Letter_K.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_K);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_K, isGlobal: true);
        }

        private static async Task RegLetter_L()
        {
            // Start with defining the first pose, ...
            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded, PoseDirection.Down),
                                            new FingerPose(Finger.Index, FingerFlexion.OpenStretched, PoseDirection.Up),
                                            new FingerPose(Finger.Thumb, FingerFlexion.OpenStretched, PoseDirection.Left));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_L = new Gesture("L", Open);
            _Letter_L.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);
            InputSimulator sim = new InputSimulator();
            _Letter_L.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_L);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_L, isGlobal: true);
        }

        private static async Task RegLetter_M()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                            new FingerPose(new[] { Finger.Index, Finger.Ring, Finger.Middle }, FingerFlexion.OpenStretched, PoseDirection.Down),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipDistanceRelation(Finger.Ring, RelativeDistance.NotTouching, Finger.Pinky));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_M = new Gesture("M", fist);
            _Letter_M.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);
            InputSimulator sim = new InputSimulator();
            _Letter_M.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_M);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_M, isGlobal: true);
        }

        private static async Task RegLetter_N()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Down),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Left, Finger.Middle),
                                            new FingerPose(new[] { Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_N = new Gesture("N", fist);
            _Letter_N.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            InputSimulator sim = new InputSimulator();
            _Letter_N.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_N);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_N, isGlobal: true);
        }

        private static async Task RegLetter_O()
        {


            var RockOn = new HandPose("Rock", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky, Finger.Thumb, Finger.Index }, FingerFlexion.Open),
                                             new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, new[] { Finger.Index, Finger.Middle }));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_O = new Gesture("O", RockOn);
            _Letter_O.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);
            InputSimulator sim = new InputSimulator();
            _Letter_O.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_O);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_O, isGlobal: true);
        }

        private static async Task RegLetter_P()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Folded, PoseDirection.Undefined),
                                                 new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Thumb),
                                                 new FingertipPlacementRelation(Finger.Index, RelativePlacement.Below, Finger.Thumb),
                                                 new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                                 new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Down));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_P = new Gesture("P", iddle);
            _Letter_P.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);
            InputSimulator sim = new InputSimulator();
            _Letter_P.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_P);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_P, isGlobal: true);
        }

        private static async Task RegLetter_Q()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new PalmPose(new AnyHandContext(), PoseDirection.Down),
                                            new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Down),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Index),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_Q = new Gesture("Q", hold);
            _Letter_Q.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);
            InputSimulator sim = new InputSimulator();
            _Letter_Q.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_Q);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Q, isGlobal: true);
        }

        private static async Task RegLetter_R()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Thumb }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(Finger.Middle, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Pinky, Finger.Ring }, FingerFlexion.Folded, PoseDirection.Down),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Below, Finger.Index));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_R = new Gesture("R", fist);
            _Letter_R.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);
            InputSimulator sim = new InputSimulator();
            _Letter_R.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_R);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_R, isGlobal: true);
        }

        private static async Task RegLetter_S()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                              new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Forward));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_S = new Gesture("S", iddle);
            _Letter_S.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);
            InputSimulator sim = new InputSimulator();
            _Letter_S.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_S);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_S, isGlobal: true);
        }

        private static async Task RegLetter_T()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Left),
                                            new FingerPose(Finger.Pinky, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Thumb }, FingerFlexion.Folded));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_T = new Gesture("T", fist);
            _Letter_T.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);
            InputSimulator sim = new InputSimulator();
            _Letter_T.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_T);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_T, isGlobal: true);
        }

        private static async Task RegLetter_U()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingerPose(Finger.Thumb, PoseDirection.Right),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Left, Finger.Middle));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_U = new Gesture("U", fist);
            _Letter_U.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            InputSimulator sim = new InputSimulator();
            _Letter_U.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_U);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_U, isGlobal: true);
        }

        private static async Task RegLetter_V()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.OpenStretched, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Middle),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.InFront, Finger.Ring));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_V = new Gesture("V", fist);
            _Letter_V.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);
            InputSimulator sim = new InputSimulator();
            _Letter_V.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_V);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_V, isGlobal: true);
        }

        private static async Task RegLetter_W()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Middle),
                                            new FingertipDistanceRelation(Finger.Middle, RelativeDistance.NotTouching, Finger.Ring),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.InFront, Finger.Pinky));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_W = new Gesture("W", fist);
            _Letter_W.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Magenta);
            InputSimulator sim = new InputSimulator();
            _Letter_W.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_W);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_W, isGlobal: true);
        }

        private static async Task RegLetter_X()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                            new FingerPose(new[] { Finger.Pinky, Finger.Middle, Finger.Ring }, FingerFlexion.Folded),
                                            new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Middle)
                                            );


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_X = new Gesture("X", fist);
            _Letter_X.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Green);
            InputSimulator sim = new InputSimulator();
            _Letter_X.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_X);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_X, isGlobal: true);
        }

        private static async Task RegLetter_Y()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Index }, FingerFlexion.Folded),
                                            new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Left),
                                            new FingerPose(Finger.Pinky, FingerFlexion.Open, PoseDirection.Right));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_Y = new Gesture("Y", fist);
            _Letter_Y.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkGreen);
            InputSimulator sim = new InputSimulator();
            _Letter_Y.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_Y);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Y, isGlobal: true);
        }

        private static async Task RegLetter_Z()
        {
            // Start with defining the first pose, ...
            var Fox = new HandPose("zeta", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                       new FingerPose(new[] { Finger.Middle, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Left),
                       new FingerPose(new[] { Finger.Ring, Finger.Thumb, Finger.Index }, FingerFlexion.Folded));




            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate


            _Letter_Z = new Gesture("Z", Fox);
            _Letter_Z.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkGreen);
            InputSimulator sim = new InputSimulator();
            _Letter_Z.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VK_Z);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Z, isGlobal: true);
        }

        private static void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Letra: ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);
            Console.ResetColor();

        }
        


        //////////////////////////////////////////////Mouse Enter Funciones////////////////////////////////////////////////////////////////////


        private void BT_A_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_A.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("A");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n La punta del dedo Pulgar debe \r\n Ir un poco mas arriba que\r\n Los demas dedos.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_B_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_B.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("B");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_C_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_C.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("C");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_D_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_D.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("D");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar y el dedo Medio \r\n Deben hacer un circulo entre ellos.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_E_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_E.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("E");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n La punta del dedo Pulgar debe \r\n Estar tocando la punta de\r\n El dedo Medio.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_F_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_F.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("F");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar y el dedo Indice \r\n Deben hacer un circulo entre ellos.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_G_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_G.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("G");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_H_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_H.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("H");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar se esconde \r\n Detras de la mano.");
            LB1.ForeColor = Color.Black;

        }
        private void BT_I_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_I.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("I");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar debe estar a la \r\n " +
                "Izquierda del dedo Indice, sin tocar \r\n Ninguno de los demas dedos.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_J_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_J.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("J");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar se esconde\r\n Detras de la mano.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_K_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_K.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("K");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_L_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_L.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("L");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_M_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_M.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("M");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_N_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_N.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("N");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_O_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_O.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("O");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar y el dedo Medio \r\n Deben hacer un circulo entre ellos.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_P_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_P.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("P");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar y el dedo Indice \r\n Se juntan haciendo un círculo.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_Q_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_Q.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("Q");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_R_MouseEnter(object sender, EventArgs e)
        {

            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_R.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("R");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar se junta con \r\n El dedo indice.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_S_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_S.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("S");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar se estira hacia\r\n Adelante mientras los demas \r\n Están cerrados.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_T_MouseEnter(object sender, EventArgs e)
        {
            LB1.ForeColor = Color.FromArgb(255, 72, 177, 37);
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_T.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("T");
            LabelLetra.ForeColor = Color.Black;
        }
        private void BT_U_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_U.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("U");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar debe estar \r\n Tocando el dedo Anular.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_V_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_V.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("V");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar debe estar en \r\n Frente de el dedo Anular y \r\n Tocandolo " +
                "en todo momento.");
            LB1.ForeColor = Color.Black;

        }
        private void BT_W_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_W.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("W");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar debe estar en \r\n Frente de el dedo Meñique y \r\n Tocandolo " +
                "en todo momento.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_X_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_X.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("X");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar debe estar \r\n Tocando el dedo Anular en todo \r\n Momento " +
                "y el dedo Indice hace\r\n La forma de un garfio.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_Y_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_Y.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("Y");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n El dedo Pulgar y el dedo Indice,\r\n Deben estar estirados\r\n Lo maximo posible.");
            LB1.ForeColor = Color.Black;
        }
        private void BT_Z_MouseEnter(object sender, EventArgs e)
        {
            this.PictureBox.Image = new Bitmap(RutaArch + "Letra_Z.gif");
            PictureBox.Refresh();
            this.LabelLetra.Location = new Point(81, 97);
            LabelLetra.Text = ("Z");
            LabelLetra.ForeColor = Color.Black;
            this.LB1.Location = new Point(478, 79);
            LB1.Text = ("Recomendaciones: \r\n Todos los dedos exepto el dedo\r\n Medio y el dedo Meñique,\r\n Deben estan escondidos.");
            LB1.ForeColor = Color.Black;
        }



    }
}
