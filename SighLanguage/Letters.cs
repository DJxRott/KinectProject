using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using Microsoft.Gestures.Stock.HandMotions;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace SighLanguage
{
    class Program
    {
        private static int detectionCount = 0;
        //Gestures Variables
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


        static void Main(string[] args)
        {
            Console.Title = "GesturesServiceStatus[Initializing]";
            Console.WriteLine("press 'esc' to exit");

            // One can optionally pass the hostname/IP address where the gestures service is hosted
            var gesturesServiceHostName = !args.Any() ? "localhost" : args[0];
            RegisterGestures(gesturesServiceHostName).Wait();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static async Task RegisterGestures(string gesturesServiceHostName)
        {
            // Step 1: Connect to Microsoft Gestures service            
            _gesturesService = GesturesServiceEndpointFactory.Create(gesturesServiceHostName);
            _gesturesService.StatusChanged += (s, arg) => Console.Title = $"GesturesServiceStatus [{arg.Status}]";
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
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Forward) ,
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded, PoseDirection.Down),
                                              new FingertipDistanceRelation( Finger.Thumb, RelativeDistance.NotTouching, Finger.Index),
                                              new FingerPose(Finger.Thumb,FingerFlexion.Open, PoseDirection.Up));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_A = new Gesture("A", iddle);
            _Letter_A.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);


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
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_B, isGlobal: true);
        }

        private static async Task RegLetter_C()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring,Finger.Pinky }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_C = new Gesture("C", fist);
            _Letter_C.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus

            
            await _gesturesService.RegisterGesture(_Letter_C, isGlobal: true);
            
        }

        private static async Task RegLetter_D()
        {
            // Start with defining the first pose, ...
            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Left) ,
                new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching,new[] { Finger.Middle, Finger.Ring }),
                new FingerPose(Finger.Thumb, FingerFlexion.Folded));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_D = new Gesture("D", Open);
            _Letter_D.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);

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
                                            new FingerPose(Finger.Thumb,FingerFlexion.FoldedTucked),
                                            new FingertipDistanceRelation(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, RelativeDistance.Touching, Finger.Thumb ),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Below, Finger.Middle));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_E = new Gesture("E", fist);
            _Letter_E.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_E, isGlobal: true);
        }

        private static async Task RegLetter_F()
        {
            

            var Ok = new HandPose("Oks", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Folded, PoseDirection.Undefined),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Thumb),
                                             new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                             new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_F = new Gesture("F", Ok);
            _Letter_F.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_F, isGlobal: true);
        }

        private static async Task RegLetter_G()
        {


            var RockOn = new HandPose("Rock", new PalmPose( new AnyHandContext(), PoseDirection.Backward), 
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                             new FingerPose( Finger.Index, FingerFlexion.Open, PoseDirection.Left),
                                             new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_G = new Gesture("G", RockOn);
            _Letter_G.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_G, isGlobal: true);
        }

        private static async Task RegLetter_H()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Backward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle}, FingerFlexion.Open, PoseDirection.Left),
                                              new FingertipDistanceRelation( Finger.Index, RelativeDistance.Touching, Finger.Middle) ,
                                              new FingerPose(new[] {  Finger.Ring, Finger.Pinky }, FingerFlexion.Folded ));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_H = new Gesture("H", iddle);
            _Letter_H.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_H, isGlobal: true);
        } 

        private static async Task RegLetter_I()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Folded, PoseDirection.Down),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Index),
                                              new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Left, Finger.Index),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching,new[] { Finger.Ring, Finger.Middle }) ,
                                              new FingerPose( Finger.Pinky , FingerFlexion.Open, PoseDirection.Up));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_I = new Gesture("I", iddle);
            _Letter_I.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_I, isGlobal: true);
        }

        private static async Task RegLetter_J()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                              new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring }, FingerFlexion.Folded),
                                              new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching ,new[] { Finger.Ring, Finger.Middle }),
                                              new FingerPose(Finger.Pinky, FingerFlexion.OpenStretched, PoseDirection.Up) );

            var move = new HandMotion("Down", new PalmMotion(VerticalMotionSegment.Downward));
          

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_J = new Gesture("J", iddle, move);
            _Letter_J.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkCyan);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_J, isGlobal: true);
        }

        private static async Task RegLetter_K()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Thumb }, FingerFlexion.Open, PoseDirection.Up),
                                                new FingerPose(Finger.Thumb, PoseDirection.Up),
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Middle) );

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_K = new Gesture("K", fist);
            _Letter_K.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_K, isGlobal: true);
        }

        private static async Task RegLetter_L()
        {
            // Start with defining the first pose, ...
            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                            new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded, PoseDirection.Down ),
                                            new FingerPose(Finger.Index, FingerFlexion.OpenStretched, PoseDirection.Up),
                                            new FingerPose(Finger.Thumb, FingerFlexion.OpenStretched, PoseDirection.Left));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_L = new Gesture("L", Open);
            _Letter_L.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);

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
                                            new FingerPose(new[] { Finger.Index, Finger.Ring, Finger.Middle }, FingerFlexion.OpenStretched, PoseDirection.Down ),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipDistanceRelation(Finger.Ring, RelativeDistance.NotTouching, Finger.Pinky));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_M = new Gesture("M", fist);
            _Letter_M.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);


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
                                            new FingertipDistanceRelation(Finger.Middle, RelativeDistance.NotTouching, Finger.Ring),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingerPose(new[] {  Finger.Ring, Finger.Pinky }, FingerFlexion.Folded ));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_N = new Gesture("N", fist);
            _Letter_N.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_N, isGlobal: true);
        }

        private static async Task RegLetter_O()
        {


            var RockOn = new HandPose("Rock", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky, Finger.Thumb, Finger.Index }, FingerFlexion.Open),
                                             new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, new[] { Finger.Index, Finger.Middle } ));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_O = new Gesture("O", RockOn);
            _Letter_O.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_O, isGlobal: true);
        }

        private static async Task RegLetter_P()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle" , new PalmPose(new AnyHandContext(), PoseDirection.Down),
                                               new FingerPose( Finger.Index, FingerFlexion.Open, PoseDirection.Forward ),
                                               new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Forward),
                                               new FingerPose(Finger.Middle, FingerFlexion.Open, PoseDirection.Down) );

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_P = new Gesture("P", iddle);
            _Letter_P.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_P, isGlobal: true);
        }

        private static async Task RegLetter_Q()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new PalmPose(new AnyHandContext(), PoseDirection.Down),
                                            new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Down ),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Index),
                                            new FingerPose(new[] {Finger.Middle, Finger.Ring, Finger.Pinky} , FingerFlexion.Folded ));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_Q = new Gesture("Q", hold);
            _Letter_Q.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkYellow);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Q, isGlobal: true);
        }

        private static async Task RegLetter_R()
        {
            // Our starting pose is a full fist pointing down and/or forward
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                                new FingerPose(new[] { Finger.Ring, Finger.Thumb, Finger.Pinky }, FingerFlexion.Folded),
                                                new FingerPose(Finger.Thumb, PoseDirection.Right),
                                                new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up  ),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.InFront, Finger.Middle),
                                                new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.InFront, Finger.Ring));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> spread
            _Letter_R = new Gesture("R", fist);
            _Letter_R.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Blue);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_R, isGlobal: true);
        }

        private static async Task RegLetter_S()
        {
            // Start with defining the first pose, ...
            var iddle = new HandPose("Iddle", new FingerPose(new AnyFingerContext(), FingerFlexion.FoldedTucked),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                              new FingertipPlacementRelation( Finger.Thumb, RelativePlacement.InFront, Finger.Middle));

            var move = new HandPose("Left", new PalmPose(new AnyHandContext(), PoseDirection.Left),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.InFront, Finger.Index),
                                            new FingerPose(new AnyFingerContext(), FingerFlexion.Folded));



            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_S = new Gesture("S", iddle, move);
            _Letter_S.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);
            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_S, isGlobal: true);
        }

        private static async Task RegLetter_T()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Thumb }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Pinky, Finger.Middle, Finger.Ring }, FingerFlexion.Folded, PoseDirection.Down),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Middle));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_T = new Gesture("T", fist);
            _Letter_T.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_T, isGlobal: true);
        }

        private static async Task RegLetter_U()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.NotTouching, Finger.Pinky),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Left, Finger.Middle),
                                            new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.Left, Finger.Ring));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_U = new Gesture("U", fist);
            _Letter_U.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);


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


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_W, isGlobal: true);
        }

        private static async Task RegLetter_X()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                            new FingerPose(new[] { Finger.Pinky, Finger.Middle, Finger.Ring }, FingerFlexion.Folded, PoseDirection.Down),
                                            new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Middle)
                                            );


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _Letter_X = new Gesture("X", fist);
            _Letter_X.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Green);


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


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Y, isGlobal: true);
        }

        private static async Task RegLetter_Z()
        {
            // Start with defining the first pose, ...
            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                       new FingerPose(new[] { Finger.Pinky, Finger.Middle, Finger.Thumb, Finger.Ring}, FingerFlexion.Folded ) ,
                       new FingertipPlacementRelation(Finger.Thumb, RelativePlacement.InFront, new[] { Finger.Ring, Finger.Middle }),
                       new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up));

            var Move = new HandMotion("R_DLD_R", new PalmMotion(VerticalMotionSegment.Right),
                                                new PalmMotion(VerticalMotionSegment.DiagonalLeftDownward),
                                                new PalmMotion(VerticalMotionSegment.Right));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _Letter_Z = new Gesture("Z", Open);
            _Letter_Z.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_Letter_Z, isGlobal: true);
        }

 

        private static void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {

            
            detectionCount++;
            Console.WriteLine(detectionCount);

            if (detectionCount % 4 == 0)
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Letra: ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);
            Console.ResetColor();

                detectionCount = 0; // Reiniciar el contador a 0 después de cada 10 detecciones
            }



        }
    }


}
