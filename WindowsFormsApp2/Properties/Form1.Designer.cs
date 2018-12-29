namespace WindowsFormsApp2.Properties
{
    partial class Main_UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_UI));
            this.cas = new System.Windows.Forms.Label();
            this.cas_sec = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OnlineStatus = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NotifLabel = new System.Windows.Forms.Label();
            this.DateMonth = new System.Windows.Forms.Label();
            this.DateDayOfWeek = new System.Windows.Forms.Label();
            this.TempLabel = new System.Windows.Forms.Label();
            this.WeatherPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vitrLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vlhkostLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tlakLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mestoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cas
            // 
            this.cas.AutoSize = true;
            this.cas.BackColor = System.Drawing.Color.Transparent;
            this.cas.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas.ForeColor = System.Drawing.Color.White;
            this.cas.Location = new System.Drawing.Point(12, 23);
            this.cas.Margin = new System.Windows.Forms.Padding(0);
            this.cas.Name = "cas";
            this.cas.Size = new System.Drawing.Size(290, 112);
            this.cas.TabIndex = 1;
            this.cas.Text = "00:00";
            this.cas.Click += new System.EventHandler(this.cas_Click);
            // 
            // cas_sec
            // 
            this.cas_sec.AutoSize = true;
            this.cas_sec.BackColor = System.Drawing.Color.Transparent;
            this.cas_sec.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas_sec.ForeColor = System.Drawing.Color.White;
            this.cas_sec.Location = new System.Drawing.Point(276, 34);
            this.cas_sec.Name = "cas_sec";
            this.cas_sec.Size = new System.Drawing.Size(79, 58);
            this.cas_sec.TabIndex = 2;
            this.cas_sec.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OnlineStatus
            // 
            this.OnlineStatus.BackColor = System.Drawing.Color.Transparent;
            this.OnlineStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OnlineStatus.ErrorImage = null;
            this.OnlineStatus.Location = new System.Drawing.Point(32, 185);
            this.OnlineStatus.Name = "OnlineStatus";
            this.OnlineStatus.Size = new System.Drawing.Size(50, 48);
            this.OnlineStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OnlineStatus.TabIndex = 3;
            this.OnlineStatus.TabStop = false;
            this.OnlineStatus.Click += new System.EventHandler(this.OnlineStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // NotifLabel
            // 
            this.NotifLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NotifLabel.AutoSize = true;
            this.NotifLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NotifLabel.ForeColor = System.Drawing.Color.White;
            this.NotifLabel.Location = new System.Drawing.Point(355, 9);
            this.NotifLabel.Name = "NotifLabel";
            this.NotifLabel.Size = new System.Drawing.Size(0, 17);
            this.NotifLabel.TabIndex = 5;
            this.NotifLabel.Click += new System.EventHandler(this.NotifLabel_Click);
            // 
            // DateMonth
            // 
            this.DateMonth.AutoSize = true;
            this.DateMonth.BackColor = System.Drawing.Color.Transparent;
            this.DateMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.DateMonth.ForeColor = System.Drawing.Color.White;
            this.DateMonth.Location = new System.Drawing.Point(25, 144);
            this.DateMonth.Name = "DateMonth";
            this.DateMonth.Size = new System.Drawing.Size(189, 39);
            this.DateMonth.TabIndex = 7;
            this.DateMonth.Text = "25. LEDNA";
            this.DateMonth.Click += new System.EventHandler(this.DateMonth_Click);
            // 
            // DateDayOfWeek
            // 
            this.DateDayOfWeek.AutoSize = true;
            this.DateDayOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.DateDayOfWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DateDayOfWeek.ForeColor = System.Drawing.Color.White;
            this.DateDayOfWeek.Location = new System.Drawing.Point(88, 185);
            this.DateDayOfWeek.Name = "DateDayOfWeek";
            this.DateDayOfWeek.Size = new System.Drawing.Size(93, 25);
            this.DateDayOfWeek.TabIndex = 8;
            this.DateDayOfWeek.Text = "STŘEDA";
            this.DateDayOfWeek.Click += new System.EventHandler(this.DateDayOfWeek_Click);
            // 
            // TempLabel
            // 
            this.TempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TempLabel.AutoSize = true;
            this.TempLabel.BackColor = System.Drawing.Color.Transparent;
            this.TempLabel.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TempLabel.ForeColor = System.Drawing.Color.White;
            this.TempLabel.Location = new System.Drawing.Point(510, 23);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(139, 112);
            this.TempLabel.TabIndex = 9;
            this.TempLabel.Text = "0°";
            this.TempLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.TempLabel.Click += new System.EventHandler(this.TempLabel_Click);
            // 
            // WeatherPic
            // 
            this.WeatherPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WeatherPic.BackColor = System.Drawing.Color.Transparent;
            this.WeatherPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WeatherPic.ErrorImage = null;
            this.WeatherPic.Location = new System.Drawing.Point(655, 27);
            this.WeatherPic.Margin = new System.Windows.Forms.Padding(0);
            this.WeatherPic.Name = "WeatherPic";
            this.WeatherPic.Size = new System.Drawing.Size(80, 80);
            this.WeatherPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WeatherPic.TabIndex = 10;
            this.WeatherPic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(455, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // vitrLabel
            // 
            this.vitrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vitrLabel.AutoSize = true;
            this.vitrLabel.BackColor = System.Drawing.Color.Transparent;
            this.vitrLabel.Font = new System.Drawing.Font("Century Gothic", 19F);
            this.vitrLabel.ForeColor = System.Drawing.Color.White;
            this.vitrLabel.Location = new System.Drawing.Point(486, 144);
            this.vitrLabel.Name = "vitrLabel";
            this.vitrLabel.Size = new System.Drawing.Size(50, 32);
            this.vitrLabel.TabIndex = 12;
            this.vitrLabel.Text = "8,2";
            this.vitrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vitrLabel.Click += new System.EventHandler(this.vitrLabel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(531, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "m/s";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(639, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // vlhkostLabel
            // 
            this.vlhkostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vlhkostLabel.AutoSize = true;
            this.vlhkostLabel.BackColor = System.Drawing.Color.Transparent;
            this.vlhkostLabel.Font = new System.Drawing.Font("Century Gothic", 19F);
            this.vlhkostLabel.ForeColor = System.Drawing.Color.White;
            this.vlhkostLabel.Location = new System.Drawing.Point(600, 143);
            this.vlhkostLabel.Name = "vlhkostLabel";
            this.vlhkostLabel.Size = new System.Drawing.Size(43, 32);
            this.vlhkostLabel.TabIndex = 15;
            this.vlhkostLabel.Text = "62";
            this.vlhkostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vlhkostLabel.Click += new System.EventHandler(this.vlhkostLabel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(576, 143);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(764, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "mPh";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tlakLabel
            // 
            this.tlakLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tlakLabel.AutoSize = true;
            this.tlakLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlakLabel.Font = new System.Drawing.Font("Century Gothic", 19F);
            this.tlakLabel.ForeColor = System.Drawing.Color.White;
            this.tlakLabel.Location = new System.Drawing.Point(702, 144);
            this.tlakLabel.Name = "tlakLabel";
            this.tlakLabel.Size = new System.Drawing.Size(71, 32);
            this.tlakLabel.TabIndex = 18;
            this.tlakLabel.Text = "1024";
            this.tlakLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlakLabel.Click += new System.EventHandler(this.tlakLabel_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(677, 144);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(553, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 42);
            this.label7.TabIndex = 20;
            this.label7.Text = "|";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.CausesValidation = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(652, 134);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 42);
            this.label8.TabIndex = 21;
            this.label8.Text = "|";
            // 
            // mestoLabel
            // 
            this.mestoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mestoLabel.AutoSize = true;
            this.mestoLabel.BackColor = System.Drawing.Color.Transparent;
            this.mestoLabel.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mestoLabel.ForeColor = System.Drawing.Color.Gray;
            this.mestoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mestoLabel.Location = new System.Drawing.Point(691, 185);
            this.mestoLabel.Name = "mestoLabel";
            this.mestoLabel.Size = new System.Drawing.Size(97, 31);
            this.mestoLabel.TabIndex = 22;
            this.mestoLabel.Text = "MĚSTO";
            this.mestoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mestoLabel.Click += new System.EventHandler(this.mestoLabel_Click);
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mestoLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tlakLabel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vlhkostLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vitrLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WeatherPic);
            this.Controls.Add(this.TempLabel);
            this.Controls.Add(this.DateDayOfWeek);
            this.Controls.Add(this.DateMonth);
            this.Controls.Add(this.NotifLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OnlineStatus);
            this.Controls.Add(this.cas_sec);
            this.Controls.Add(this.cas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_UI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_UI_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.OnlineStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cas;
        private System.Windows.Forms.Label cas_sec;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox OnlineStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NotifLabel;
        private System.Windows.Forms.Label DateMonth;
        private System.Windows.Forms.Label DateDayOfWeek;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.PictureBox WeatherPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label vitrLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vlhkostLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tlakLabel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label mestoLabel;
    }
}