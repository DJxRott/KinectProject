﻿using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
//InputSiulator libraries for Virtual Keys

namespace SighLanguage
{
    class Program
    {

        //Gestures Variables
        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _rotateGestureR;
        private static Gesture _rotateGestureL;
        private static Gesture _dropTheMicGesture;
        private static Gesture _likeGesture;
        private static Gesture _OpenPalmGesture;
        private static Gesture _OkGesture;
        private static Gesture _RockGesture;




        static void Main(string[] args)
        {
            Console.Title = "GesturesServiceStatus[Initializing]";
            Console.WriteLine("press 'esc' to exit");

            // One can optionally pass the hostname/IP address where the gestures service is hosted
            var gesturesServiceHostName = !args.Any() ? "localhost" : args[0];
            RegisterGestures(gesturesServiceHostName).Wait();
            Thread.Sleep(999999999);//agregado para que no se cierre la ventana de comandos
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
            await RegisterRotateRightGesture();
            await RegisterRotateLeftGesture();
            await RegisterDropTheMicGesture();
            await RegisterCloseOpenGesture();
            await RegisterLikeGesture();
            await RegisterOkGesture();
            await RegisterRockOnGesture();
        }

        private static async Task RegisterRotateRightGesture()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
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

        private static async Task RegisterRotateLeftGesture()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb),
                                            new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb));
            // ... define the second pose, ...
            var rotate = new HandPose("Rotate", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
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

        private static async Task RegisterDropTheMicGesture()
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
            _dropTheMicGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_STOP);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_STOP);

            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_dropTheMicGesture, isGlobal: true);
        }

        private static async Task RegisterCloseOpenGesture()
        {
            // Start with defining the first pose, ...
            var Close = new HandPose("Close", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                                      new FingerPose(new AllFingersContext(), FingerFlexion.Open),
                                                      new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Middle),
                                                      new FingertipDistanceRelation(Finger.Middle, RelativeDistance.Touching, Finger.Ring),
                                                      new FingertipDistanceRelation(Finger.Ring, RelativeDistance.Touching, Finger.Pinky));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _OpenPalmGesture = new Gesture("PlayGesture", Open, Close);
            _OpenPalmGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkBlue);
            InputSimulator sim = new InputSimulator();
            _OpenPalmGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_OpenPalmGesture, isGlobal: true);
        }

        private static async Task RegisterLikeGesture()
        {
            // Our starting pose is a fist 
            var fist = new HandPose("Fist", new PalmPose(new AnyHandContext(), PoseDirection.Left | PoseDirection.Right),
                                            new FingerPose(new AllFingersContext(), FingerFlexion.Folded));



            // In the final pose the thumb flexion will open in the "up" direction
            var like = new HandPose("Like", new PalmPose(new AnyHandContext(), PoseDirection.Left | PoseDirection.Right),
                                            new FingerPose(new[] { Finger.Index, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: fist -> Like
            _likeGesture = new Gesture("LikeGesture", fist, like);
            _likeGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Red);
            InputSimulator sim = new InputSimulator();
            _likeGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);


            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_likeGesture, isGlobal: true);
        }

        private static async Task RegisterOkGesture()
        {
            var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var Ok = new HandPose("Oks", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Folded, PoseDirection.Undefined),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching, Finger.Thumb),
                                             new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Middle),
                                             new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Open));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _OkGesture = new Gesture("OkGesture", Iddle, Ok);
            _OkGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);
            InputSimulator sim = new InputSimulator();
            _OkGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PREV_TRACK);


            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_OkGesture, isGlobal: true);
        }

        private static async Task RegisterRockOnGesture()
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
    }


}
