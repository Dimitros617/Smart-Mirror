using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace WindowsFormsApp2.Properties
{
    public partial class Main_UI : Form
    {

        private int timer;
        private int NotifCounter;
        LinkedList<Label> Notifikace;


        public Main_UI()
        {
            InitializeComponent();
            Notifikace = new LinkedList<Label>();
        }

        private void Main_UI_Paint(object sender, PaintEventArgs e)
        {

            Form1_Paint(sender, e);

        }

        private void Form1_Paint(object sender, PaintEventArgs e) {

            Pen pen = new Pen(Color.White, 5);

            int yposun = 110;
            int xposun = 400;
            Point p1 = new Point(cas.Location.X, cas.Location.Y + yposun);
            Point p2 = new Point(cas.Location.X + xposun, cas.Location.Y + yposun);

            e.Graphics.DrawLine(pen, p1, p2);
        }

        private void Main_UI_Load(object sender, EventArgs e)
        {

            

            int s = Screen.PrimaryScreen.Bounds.Width;
            int v = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0);
            this.Size = new Size(s, v);

            this.cas_sec.Location = new Point(cas.Location.X+260, 68);

            //-------------- set cas

            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);

            //-------------- set pic internet connection

            Image image;

            try
            {
                if (CheckForInternetConnection())
                {
                      image = Image.FromFile(@"..\\Image\\online.png");
                   // image = Image.FromFile("online.png");
                }
                else
                {
                    image = Image.FromFile(@"..\\Image\\offline.png");
                }
                OnlineStatus.Image = image;
            }
            catch {

                Console.WriteLine("nebylo možno nalést obrázek pripojení k internetu");
                Notify("nebylo možno nalést obrázek pripojení k internetu");
            }

            

            

            Console.WriteLine("-------------NECO---------------");
            Console.WriteLine();
            Console.WriteLine(CheckForInternetConnection());

            timer1.Start();
            this.Refresh();
        }

        private void cas_Click(object sender, EventArgs e){

            this.Close();

        }

        private bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void cas_sec_Click(object sender, EventArgs e){
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);
            cas_sec.Refresh();

            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            cas.Refresh();


            if (Notifikace.Count != 0)

                try
                {
                    foreach (Label label in Notifikace)
                    {

                        if (label.TabIndex == 0)
                        {
                            if (label.Location.Y > -20)
                                label.Location = new Point(label.Location.X, label.Location.Y - 1);
                            else
                                Notifikace.Remove(label);
                        }
                        else
                        {

                            label.TabIndex--;

                        }

                    }
                }
                catch {
                   // Notify("Chyba při notifikaci");
                }
        }

        private void OnlineStatus_Click(object sender, EventArgs e)
        {

        }

        private void NotifLabel_Click(object sender, EventArgs e)
        {

        }

        private void Notify(String s) {

            int locx = Screen.PrimaryScreen.Bounds.Width/2;
            int locy = Notifikace.Count == 0 ? 20 : Notifikace.ElementAt(0).Location.Y + 20;

            Label label = new Label();
            label.Location = new System.Drawing.Point(locx, locy);
            label.Name = "label";
            label.Text = s;
            label.AutoSize = true;
            label.ForeColor = System.Drawing.Color.White;
            label.TabIndex = 300;
            label.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label as Control);
            Notifikace.AddFirst(label);

        }


    }
}
