namespace UIControl
{
    partial class KMusicForm
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            pictureBox6 = new System.Windows.Forms.PictureBox();
            LSubirVol = new System.Windows.Forms.Label();
            LMediaPlayPause = new System.Windows.Forms.Label();
            LMute = new System.Windows.Forms.Label();
            LBajarVol = new System.Windows.Forms.Label();
            LNextTr = new System.Windows.Forms.Label();
            LPrevTr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = MusicControlForm.Properties.Resources.Volume_Down;
            pictureBox1.Location = new System.Drawing.Point(63, 290);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(163, 163);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.White;
            pictureBox2.Image = MusicControlForm.Properties.Resources.Volume_Up;
            pictureBox2.Location = new System.Drawing.Point(781, 290);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(163, 163);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = MusicControlForm.Properties.Resources.Drop_the_Mic;
            pictureBox3.Location = new System.Drawing.Point(425, 290);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(163, 163);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = MusicControlForm.Properties.Resources.Media_Next_Track;
            pictureBox4.Location = new System.Drawing.Point(781, 40);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(163, 163);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = MusicControlForm.Properties.Resources.Rock_On;
            pictureBox5.Location = new System.Drawing.Point(425, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(163, 163);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = MusicControlForm.Properties.Resources.Media_Prev_Track;
            pictureBox6.Location = new System.Drawing.Point(63, 40);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(163, 163);
            pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            // 
            // LSubirVol
            // 
            LSubirVol.AutoSize = true;
            LSubirVol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            LSubirVol.Location = new System.Drawing.Point(812, 473);
            LSubirVol.Name = "LSubirVol";
            LSubirVol.Size = new System.Drawing.Size(105, 20);
            LSubirVol.TabIndex = 6;
            LSubirVol.Text = "Subir Volumen";
            // 
            // LMediaPlayPause
            // 
            LMediaPlayPause.AutoSize = true;
            LMediaPlayPause.Location = new System.Drawing.Point(436, 218);
            LMediaPlayPause.Name = "LMediaPlayPause";
            LMediaPlayPause.Size = new System.Drawing.Size(138, 20);
            LMediaPlayPause.TabIndex = 7;
            LMediaPlayPause.Text = "Reproducir / Pausar";
            // 
            // LMute
            // 
            LMute.AutoSize = true;
            LMute.Location = new System.Drawing.Point(463, 473);
            LMute.Name = "LMute";
            LMute.Size = new System.Drawing.Size(83, 20);
            LMute.TabIndex = 8;
            LMute.Text = "Enmudecer";
            // 
            // LBajarVol
            // 
            LBajarVol.AutoSize = true;
            LBajarVol.Location = new System.Drawing.Point(92, 473);
            LBajarVol.Name = "LBajarVol";
            LBajarVol.Size = new System.Drawing.Size(105, 20);
            LBajarVol.TabIndex = 9;
            LBajarVol.Text = "Bajar Volumen";
            // 
            // LNextTr
            // 
            LNextTr.AutoSize = true;
            LNextTr.Location = new System.Drawing.Point(825, 218);
            LNextTr.Name = "LNextTr";
            LNextTr.Size = new System.Drawing.Size(71, 20);
            LNextTr.TabIndex = 10;
            LNextTr.Text = "Siguiente";
            // 
            // LPrevTr
            // 
            LPrevTr.AutoSize = true;
            LPrevTr.Location = new System.Drawing.Point(102, 218);
            LPrevTr.Name = "LPrevTr";
            LPrevTr.Size = new System.Drawing.Size(63, 20);
            LPrevTr.TabIndex = 11;
            LPrevTr.Text = "Anterior";
            // 
            // KMusicForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = MusicControlForm.Properties.Resources.PurpleMusic;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1006, 529);
            Controls.Add(LPrevTr);
            Controls.Add(LNextTr);
            Controls.Add(LBajarVol);
            Controls.Add(LMute);
            Controls.Add(LMediaPlayPause);
            Controls.Add(LSubirVol);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Name = "KMusicForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " ";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label LSubirVol;
        private System.Windows.Forms.Label LMediaPlayPause;
        private System.Windows.Forms.Label LMute;
        private System.Windows.Forms.Label LBajarVol;
        private System.Windows.Forms.Label LNextTr;
        private System.Windows.Forms.Label LPrevTr;
    }
}
