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
            this.cas = new System.Windows.Forms.Label();
            this.cas_sec = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OnlineStatus = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NotifLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineStatus)).BeginInit();
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
            this.cas_sec.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas_sec.ForeColor = System.Drawing.Color.White;
            this.cas_sec.Location = new System.Drawing.Point(271, 68);
            this.cas_sec.Name = "cas_sec";
            this.cas_sec.Size = new System.Drawing.Size(78, 56);
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
            this.OnlineStatus.BackColor = System.Drawing.Color.Black;
            this.OnlineStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OnlineStatus.Location = new System.Drawing.Point(692, 348);
            this.OnlineStatus.Name = "OnlineStatus";
            this.OnlineStatus.Size = new System.Drawing.Size(96, 90);
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
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NotifLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OnlineStatus);
            this.Controls.Add(this.cas_sec);
            this.Controls.Add(this.cas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_UI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_UI_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.OnlineStatus)).EndInit();
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
    }
}