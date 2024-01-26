using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

namespace UIControl
{
    public partial class PPForm : Form
    {

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _PointGestureR;
        private static Gesture _PointGestureL;
        private static Gesture _ZoomInGesture;
        private static Gesture _ZoomOutGesture;
        private static Gesture _ZoomToFitGesture;

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Power Ponint Control!";
        }

        public PPForm()
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
            await RegisterPointRightGesture();//Anterior Diapositiva
            await RegisterPointLeftGesture();//Siguiente Diapositiva
            await RegisterZoomInGesture();//Acercar Diapositiva
            await RegisterZoomOutGesture();//Alejar Diapositiva
            await RegisterZoomToFitGesture();//Ajustar Zoom

        }


        private static async Task RegisterPointRightGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Index, PoseDirection.Forward));
            // ... define the second pose, ...
            var right = new HandPose("Right", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up),
                                              new FingerPose(Finger.Index, PoseDirection.Right));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _PointGestureR = new Gesture("PointRight", front, right);
            InputSimulator sim = new InputSimulator();
            _PointGestureR.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.LEFT);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_PointGestureR, isGlobal: true);
        }

        //Anterior Diapositiva
        private static async Task RegisterPointLeftGesture()
        {
            // Start with defining the first pose, ...
            var front = new HandPose("Front", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky, Finger.Thumb }, FingerFlexion.Folded),
                                              new FingerPose(Finger.Index, PoseDirection.Forward));
            // ... define the second pose, ...
            var left = new HandPose("Left", new FingerPose(new[] { Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new FingerPose(Finger.Thumb, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(Finger.Index, PoseDirection.Left));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _PointGestureL = new Gesture("PointLeft", front, left);
            InputSimulator sim = new InputSimulator();
            _PointGestureL.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_PointGestureL, isGlobal: true);
        }

        private static async Task RegisterZoomInGesture()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Pinky, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Ring, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Ring));
            // ... define the second pose, ...
            var zoomin = new HandPose("Zoom", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Pinky, Finger.Middle }, FingerFlexion.Open, PoseDirection.Left),
                                            new FingerPose(new[] { Finger.Ring, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Ring));

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _ZoomInGesture = new Gesture("ZoomIn", hold, zoomin);
            InputSimulator sim = new InputSimulator();
            _ZoomInGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_ZoomInGesture, isGlobal: true);
        }

        private static async Task RegisterZoomOutGesture()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Pinky, Finger.Middle }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Ring, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Ring));
            // ... define the second pose, ...
            var zoomout = new HandPose("Zoom", new PalmPose(new AnyHandContext(), PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Pinky, Finger.Middle }, FingerFlexion.Open, PoseDirection.Right),
                                            new FingerPose(new[] { Finger.Ring, Finger.Thumb }, FingerFlexion.Folded),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Ring));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _ZoomOutGesture = new Gesture("ZoomOut", hold, zoomout);
            InputSimulator sim = new InputSimulator();
            _ZoomOutGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_ZoomOutGesture, isGlobal: true);
        }


        private static async Task RegisterZoomToFitGesture()
        {
            // Start with defining the first pose, ...
            var hold = new HandPose("Hold", new FingerPose(new[] { Finger.Thumb, Finger.Ring, Finger.Middle }, FingerFlexion.Open, PoseDirection.Forward),
                                            new FingerPose(new[] { Finger.Index, Finger.Pinky }, FingerFlexion.Open, PoseDirection.Up),
                                            new FingertipDistanceRelation(Finger.Thumb, RelativeDistance.Touching, Finger.Middle));


            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _ZoomToFitGesture = new Gesture("ZoomFit", hold);
            InputSimulator sim = new InputSimulator();
            _ZoomToFitGesture.Triggered += (s, e) => sim.Keyboard.KeyPress(VirtualKeyCode.LCONTROL, VirtualKeyCode.MENU, VirtualKeyCode.VK_O);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_ZoomToFitGesture, isGlobal: true);
        }

    }

}
