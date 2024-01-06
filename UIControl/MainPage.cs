using Microsoft.Gestures;
using Microsoft.Gestures.Endpoint;
using System.Threading;
using System.Drawing;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace UIControl
{
    public partial class KinectProject : Form
    {

        private static GesturesServiceEndpoint _gesturesService;
        private static Gesture _One;
        private static KinectProject _instance;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kinect Project Test";
            /////////////////////////////////////Boton Musica////////////////////////////////////////////////
            System.Drawing.Drawing2D.GraphicsPath TrianglePath = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] pTPoints = { new Point(150, 150), new Point(300, 0), new Point(0, 0) };
            TrianglePath.AddLines(pTPoints);
            BMediaControl.Size = new System.Drawing.Size(300, 150);
            BMediaControl.Region = new Region(TrianglePath);
            TrianglePath.Dispose();
            BMediaControl.MouseEnter += new EventHandler(BMediaControl_MouseEnter);
            BMediaControl.MouseLeave += new EventHandler(BMediaControl_MouseLeave);

            /////////////////////////////////////Boton Bombillo////////////////////////////////////////////////
            System.Drawing.Drawing2D.GraphicsPath TrianglePath2 = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] pTPoints2 = { new Point(150, 300), new Point(150, 0), new Point(0, 150) };
            TrianglePath2.AddLines(pTPoints2);
            BBulbControl.Size = new System.Drawing.Size(150, 300);
            BBulbControl.Region = new Region(TrianglePath2);
            TrianglePath2.Dispose();
            BBulbControl.MouseEnter += new EventHandler(BBulbControl_MouseEnter);
            BBulbControl.MouseLeave += new EventHandler(BBulbControl_MouseLeave);

            /////////////////////////////////////Boton Lenguaje Seña////////////////////////////////////////////////
            System.Drawing.Drawing2D.GraphicsPath TrianglePath3 = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] pTPoints3 = { new Point(150, 0), new Point(300, 150), new Point(0, 150) };
            TrianglePath3.AddLines(pTPoints3);
            BAlphabetControl.Size = new System.Drawing.Size(300, 150);
            BAlphabetControl.Region = new Region(TrianglePath3);
            TrianglePath3.Dispose();
            BAlphabetControl.MouseEnter += new EventHandler(BAlphabetControl_MouseEnter);
            BAlphabetControl.MouseLeave += new EventHandler(BAlphabetControl_MouseLeave);

            /////////////////////////////////////Boton Slides////////////////////////////////////////////////
            System.Drawing.Drawing2D.GraphicsPath TrianglePath4 = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] pTPoints4 = { new Point(0, 300), new Point(150, 150), new Point(0, 0) };
            TrianglePath4.AddLines(pTPoints4);
            BSlideControl.Size = new System.Drawing.Size(150, 300);
            BSlideControl.Region = new Region(TrianglePath4);
            TrianglePath4.Dispose();
            BSlideControl.MouseEnter += new EventHandler(BSlideControl_MouseEnter);
            BSlideControl.MouseLeave += new EventHandler(BSlideControl_MouseLeave);

        }

        public KinectProject()
        {
            _instance = this;
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitializeGestures();
        }


        private async Task InitializeGestures()
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

        public static async Task RegisterOneGesture()
        {
            // Start with defining the first pose, ...
            var Iddle = new HandPose("iddle", new FingerPose(new AllFingersContext(), FingerFlexion.OpenStretched),
                                              new PalmPose(new AnyHandContext(), PoseDirection.Backward));

            var hold = new HandPose("Hold", new FingerPose(Finger.Index, FingerFlexion.Open, PoseDirection.Up),
                                            new FingerPose(new[] { Finger.Thumb, Finger.Middle, Finger.Ring, Finger.Pinky }, FingerFlexion.Folded),
                                            new PalmPose(new AnyHandContext(), PoseDirection.Backward));


            //Instance for non-specific method

            // ... finally define the gesture using the hand pose objects defined above forming a simple state machine: hold -> rotate
            _One = new Gesture("One", Iddle, hold);
            _One.Triggered += (s, e) => _instance.Executor(s, e);
            //_One.Triggered += (s, e) => OnGestureDetected(s, e, ConsoleColor.DarkRed);

            // Step 3: Register the gesture             
            // Registering the like gesture _globally_ (i.e. isGlobal:true), by global registration we mean this gesture will be 
            // detected even it was initiated not by this application or if the this application isn't in focus
            await _gesturesService.RegisterGesture(_One, isGlobal: true);
        }


        private void BMediaControl_MouseEnter(object sender, EventArgs e)
        {
            this.label1.Location = new Point(100, 11);
            label1.Text = "Media Control";
            this.label2.Location = new Point(11, 73);
            label2.Text = "Integra gestos programados en tu sistema \r\npara tener el control total de funciones \r\nmultimedia en tu computadora," +
                " permitiéndote\r\nreproducir, pausar, detener, subir y bajar \r\nvolumen de cualquier tipo de media que esté \r\nen reproducción," +
                " ya sea vídeos en línea, \r\nreproductores de música o cualquier tipo de \r\nmedio audiovisual.";

        }

        private void BMediaControl_MouseLeave(object sender, EventArgs e)
        {
            Leave_F();
        }

        private void BSlideControl_MouseEnter(object sender, EventArgs e)
        {
            this.label1.Location = new Point(70, 11);
            label1.Text = "PowerPoint Control";
            this.label2.Location = new Point(11, 91);
            label2.Text = "Utiliza diferentes movimientos y gestos para\r\nrealizar interacciones con aplicaciones " +
                "de\r\npresentación de diapositivas, tales como Prezi\r\no PowerPoint. Esto incluye la integración " +
                "de\r\ncomandos simples para avanzar y retroceder\r\ndiapositivas, así como para controlar el nivel\r\nde " +
                "zoom dentro de cada diapositiva.";
        }

        private void BSlideControl_MouseLeave(object sender, EventArgs e)
        {
            Leave_F();
        }

        private void BBulbControl_MouseEnter(object sender, EventArgs e)
        {
            this.label1.Location = new Point(85, 11);
            label1.Text = "Lightbulb Control";
            this.label2.Location = new Point(11, 91);
            label2.Text = "Usando gestos programados utiliza \r\nconexiones con APIs de domótica para \r\ncontrolar " +
                "bombillos inteligentes, permitiendo \r\nencender y apagar de forma remota cada \r\nuno, además de alterar " +
                "a voluntad los colores \r\ny el brillo que mostrarán los que esten \r\nconectados a la misma red.";

        }

        private void BBulbControl_MouseLeave(object sender, EventArgs e)
        {
            Leave_F();
        }

        private void BAlphabetControl_MouseEnter(object sender, EventArgs e)
        {
            this.label1.Location = new Point(90, 11);
            label1.Text = "Alphabet Control";
            this.label2.Location = new Point(11, 91);
            label2.Text = "Por medio de gestos que corresponden al \r\nabecedario del lenguaje de señas americano " +
                "\r\n(con ligeras modificaciones) permite el uso de \r\nun teclado virtual simulado que se pueda " +
                "\r\nutilizar en cualquier otra aplicación dentro del \r\ncomputador.";
        }

        private void BAlphabetControl_MouseLeave(object sender, EventArgs e)
        {
            Leave_F();
        }

        private void Leave_F()
        {
            this.label1.Location = new Point(40, 11);
            label1.Text = "Kinect Control All in one!";
            this.label2.Location = new Point(65, 73);
            label2.Text = "Pon el mouse sobre cualquier \r\nboton para obtener \r\ninformacion sobre la aplicacion";

        }

        private void OnGestureDetected(object sender, GestureSegmentTriggeredEventArgs args, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gesture detected! : ");
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(args.GestureSegment.Name);

            Console.ResetColor();

        }



        private void Executor(object sender, GestureSegmentTriggeredEventArgs args)
        {

            /*string rutaArchivoExe = @"C:\Users\mitch\OneDri ve\Documents\Visual Studio Projects\KinectProject\MusicControl\bin\Debug\netcoreapp3.1\MusicControl.exe"; // Reemplaza con la ruta completa de tu archivo .bat

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

                GestureComparator = (args.GestureSegment.Name);
            */
        }

        private void BMediaControl_Click(object sender, EventArgs e)
        {
            KMusicForm F1 = new KMusicForm();
            F1.Show();
        }

        private void BSlideControl_Click(object sender, EventArgs e)
        {
            PPForm F4 = new PPForm();
            F4.Show();
        }
    }



}


