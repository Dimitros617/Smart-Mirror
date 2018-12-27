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
            this.cas = new System.Windows.Forms.Label();
            this.cas_sec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cas
            // 
            this.cas.AutoSize = true;
            this.cas.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas.ForeColor = System.Drawing.Color.White;
            this.cas.Location = new System.Drawing.Point(12, 23);
            this.cas.Name = "cas";
            this.cas.Size = new System.Drawing.Size(290, 112);
            this.cas.TabIndex = 1;
            this.cas.Text = "00:00";
            this.cas.Click += new System.EventHandler(this.cas_Click);
            // 
            // cas_sec
            // 
            this.cas_sec.AutoSize = true;
            this.cas_sec.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas_sec.ForeColor = System.Drawing.Color.White;
            this.cas_sec.Location = new System.Drawing.Point(271, 68);
            this.cas_sec.Name = "cas_sec";
            this.cas_sec.Size = new System.Drawing.Size(78, 56);
            this.cas_sec.TabIndex = 2;
            this.cas_sec.Text = "00";
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cas_sec);
            this.Controls.Add(this.cas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_UI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cas;
        private System.Windows.Forms.Label cas_sec;
    }
}