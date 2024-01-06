namespace UIControl
{
    partial class KinectProject
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BMediaControl = new System.Windows.Forms.Button();
            BBulbControl = new System.Windows.Forms.Button();
            BAlphabetControl = new System.Windows.Forms.Button();
            BSlideControl = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // BMediaControl
            // 
            BMediaControl.BackColor = System.Drawing.Color.FromArgb(163, 73, 164);
            BMediaControl.BackgroundImage = Properties.Resources.music_dial_sin_fondo_1;
            BMediaControl.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            BMediaControl.FlatAppearance.BorderSize = 0;
            BMediaControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BMediaControl.Location = new System.Drawing.Point(0, 0);
            BMediaControl.Name = "BMediaControl";
            BMediaControl.Size = new System.Drawing.Size(94, 29);
            BMediaControl.TabIndex = 2;
            BMediaControl.Text = "Media Control";
            BMediaControl.UseVisualStyleBackColor = false;
            BMediaControl.Click += BMediaControl_Click;
            // 
            // BBulbControl
            // 
            BBulbControl.BackColor = System.Drawing.Color.FromArgb(114, 137, 217);
            BBulbControl.BackgroundImage = Properties.Resources.bombillo_dial_sin_fondo;
            BBulbControl.FlatAppearance.BorderSize = 0;
            BBulbControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BBulbControl.Location = new System.Drawing.Point(150, 0);
            BBulbControl.Name = "BBulbControl";
            BBulbControl.Size = new System.Drawing.Size(94, 29);
            BBulbControl.TabIndex = 3;
            BBulbControl.Text = "Lightbulb Control";
            BBulbControl.UseVisualStyleBackColor = false;
            // 
            // BAlphabetControl
            // 
            BAlphabetControl.BackColor = System.Drawing.Color.FromArgb(34, 177, 76);
            BAlphabetControl.BackgroundImage = Properties.Resources.sena_dial_sin_fondo;
            BAlphabetControl.FlatAppearance.BorderSize = 0;
            BAlphabetControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BAlphabetControl.Location = new System.Drawing.Point(0, 150);
            BAlphabetControl.Name = "BAlphabetControl";
            BAlphabetControl.Size = new System.Drawing.Size(94, 29);
            BAlphabetControl.TabIndex = 4;
            BAlphabetControl.Text = "Alphabet Control";
            BAlphabetControl.UseVisualStyleBackColor = false;
            // 
            // BSlideControl
            // 
            BSlideControl.BackColor = System.Drawing.Color.FromArgb(237, 28, 36);
            BSlideControl.BackgroundImage = Properties.Resources.pdf_dial_sin_fondo;
            BSlideControl.FlatAppearance.BorderSize = 0;
            BSlideControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BSlideControl.Location = new System.Drawing.Point(0, 0);
            BSlideControl.Name = "BSlideControl";
            BSlideControl.Size = new System.Drawing.Size(94, 29);
            BSlideControl.TabIndex = 5;
            BSlideControl.Text = "Slideshow Control";
            BSlideControl.UseVisualStyleBackColor = false;
            BSlideControl.Click += BSlideControl_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(239, 228, 176);
            panel1.Controls.Add(BAlphabetControl);
            panel1.Controls.Add(BSlideControl);
            panel1.Controls.Add(BMediaControl);
            panel1.Controls.Add(BBulbControl);
            panel1.Location = new System.Drawing.Point(22, 31);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(400, 300);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(231, 214, 135);
            label1.Font = new System.Drawing.Font("Dubai Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(40, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(297, 40);
            label1.TabIndex = 7;
            label1.Text = "Kinect Control All in one!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(231, 214, 135);
            label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(65, 73);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(247, 69);
            label2.TabIndex = 8;
            label2.Text = "Pon el mouse sobre cualquier \r\nboton para obtener \r\ninformacion sobre la aplicacion";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(231, 214, 135);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Location = new System.Drawing.Point(360, 31);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(375, 300);
            panel2.TabIndex = 10;
            // 
            // KinectProject
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            BackgroundImage = Properties.Resources.YellowTriForce;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(764, 420);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "KinectProject";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Kinect Project";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button BMediaControl;
        private System.Windows.Forms.Button BBulbControl;
        private System.Windows.Forms.Button BAlphabetControl;
        private System.Windows.Forms.Button BSlideControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}
