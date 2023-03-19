/*

using System;
using System.Threading.Tasks;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Linq;

using Microsoft.Gestures.Stock.Gestures;
using Microsoft.Gestures.Stock.HandPoses;


namespace KinectProject
{
    
    class Program
    {
        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _rotateGestureR;
        private static Gesture _rotateGestureL;
        private static Gesture _rewindGesture;

        private static Gesture _OpenPalmGesture;
        private static Gesture _OkGesture;




        static void Main(string[] args)
        {

            Console.Title = "GesturesServiceStatus[Initializing]";
            Console.WriteLine("Execute one of the following gestures: Like, Drop-the-Mic, Rotate-Right, Rotatw-left ! press 'ctrl+c' to exit");

            // One can optionally pass the hostname/IP address where the gestures service is hosted
            var gesturesServiceHostName = !args.Any() ? "localhost" : args[0];
            RegisterGestures(gesturesServiceHostName).Wait();
            Console.ReadKey();

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
            await RegisterOkGesture();
            await RegisterRewindGesture();
            await RegisterOpenPalmGesture();
            
        }

        private static async Task RegisterOpenPalmGesture()
        {
            // Start with defining the first pose, ...
            var Close = new HandPose("Close", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var Open = new HandPose("Open", new PalmPose(new AnyHandContext() ,PoseDirection.Undefined),
                                                      new FingerPose(new AllFingersContext(), FingerFlexion.Open));

            
            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _OpenPalmGesture = new Gesture("PlayGesture", Close, Open);
            _OpenPalmGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Yellow);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_OpenPalmGesture, isGlobal: true);
        }

        private static async Task RegisterOkGesture()
        {
            var Ok = new HandPose("Oks", new FingerPose(new[] { Finger.Thumb }, FingerFlexion.Folded, PoseDirection.Left),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.Touching , Finger.Thumb),
                                             new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                             new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Middle),
                                             new FingertipDistanceRelation(Finger.Middle, RelativeDistance.NotTouching, Finger.Ring),
                                             new FingertipDistanceRelation(Finger.Ring, RelativeDistance.NotTouching, Finger.Pinky));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _OkGesture = new Gesture("OkGesture", Ok);
            _OkGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.White);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_OkGesture, isGlobal: true);
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
            _rotateGestureL.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkMagenta);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_rotateGestureL, isGlobal: true);
        }

        
        private static async Task RegisterRewindGesture()
        {

            // Step 2: Define the RewindGesture gesture as follows:
            //  ┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐
            //  │          │    │          │    │          │    │          │    │          │    │          │    │          │ 
            //  │   Idle   │ -> │  Spread  │ -> │  Pause   │ -> │  Rewind  │ -> │KeepRewind│ -> │ Release  │ -> │   Idle   │ 
            //  │          │    │(unpinch) │    │ (pinch)  │    │  (left)  │    │ (pinch)  │    │(unpinch) │    │          │ 
            //  └──────────┘    └──────────┘    └────┬─────┘    └──────────┘    └──────────┘    └──────────┘    └──────────┘
            //                                       │                                               ^
            //                                       └───────────────────────────────────────────────┘
            //
            // Whenever the gesture returns to the Idle state, playback will resume
            //

            var spreadPose = GeneratePinchPose("Spread", true);
            var pausePose = GeneratePinchPose("Pause");

            var rewindMotion = new HandMotion("Rewind", new PalmMotion(VerticalMotionSegment.Left));


            var keepRewindingPose = GeneratePinchPose("KeepRewind");
            var releasePose = GeneratePinchPose("Release", true);

            var Open = new HandPose("Open", new PalmPose(new AnyHandContext(), PoseDirection.Undefined),
                                                      new FingerPose(new AllFingersContext(), FingerFlexion.Open));

            HandPose GeneratePinchPose(string name, bool pinchSpread = false)
            {

                var pinchingFingers = new[] { Finger.Thumb, Finger.Index };
                var openFingersContext = pinchSpread ? new AllFingersContext(pinchingFingers) as FingersContext : new AnyFingerContext(pinchingFingers) as FingersContext;
                return new HandPose(name, new FingerPose(openFingersContext, FingerFlexion.Open),
                                          new FingertipDistanceRelation(pinchingFingers, pinchSpread ? RelativeDistance.NotTouching : RelativeDistance.Touching),
                                          new FingertipDistanceRelation(pinchingFingers, RelativeDistance.NotTouching, Finger.Middle));


            }

            // Then define the gesture by concatenating the previous objects to form a simple state machine
            _rewindGesture = new Gesture("RewindGesture", spreadPose, pausePose, rewindMotion, keepRewindingPose, releasePose);
            // Detect if the user releases the pinch-grab hold in order to resume the playback
            _rewindGesture.AddSubPath(pausePose, releasePose, Open);

            _rewindGesture.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.Green);

            // Step 3: Register the gesture (When window focus is lost (gained) the service will automatically unregister (register) the gesture)
            //         To manually control the gesture registration, pass 'isGlobal: true' parameter in the function call below

            await _gesturesService.RegisterGesture(_rewindGesture, isGlobal: true);
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
*/