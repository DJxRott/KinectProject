namespace UIControl
{
    partial class PPForm
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
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(641, 250);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 20);
            label1.TabIndex = 1;
            label1.Text = "-Siguiente Slide";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PowerPointCForm.Properties.Resources.PrevSlide;
            pictureBox1.Location = new System.Drawing.Point(227, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(163, 163);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(252, 250);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(106, 20);
            label2.TabIndex = 3;
            label2.Text = "-Anterior Slide";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = PowerPointCForm.Properties.Resources.ZoomFit;
            pictureBox2.Location = new System.Drawing.Point(418, 250);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(163, 163);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(399, 443);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(196, 20);
            label3.TabIndex = 5;
            label3.Text = "-Reestablecer Acercamiento";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = PowerPointCForm.Properties.Resources.ZoomIn;
            pictureBox3.Location = new System.Drawing.Point(804, 248);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(165, 165);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = PowerPointCForm.Properties.Resources.ZoomOut;
            pictureBox4.Location = new System.Drawing.Point(44, 248);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(165, 165);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(828, 441);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(102, 20);
            label4.TabIndex = 8;
            label4.Text = "-Acercar Slide";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(80, 441);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(91, 20);
            label5.TabIndex = 9;
            label5.Text = "-Alejar Slide";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = PowerPointCForm.Properties.Resources.NextSlide;
            pictureBox5.Location = new System.Drawing.Point(616, 62);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(165, 165);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // PPForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = PowerPointCForm.Properties.Resources.RedStar;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1006, 529);
            Controls.Add(pictureBox5);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "PPForm";
            Text = "Power Point Control";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}
