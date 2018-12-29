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
using System.Collections;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApp2.Properties
{
    public partial class Main_UI : Form
    {

        private int timer;
        private int NotifCounter;
        LinkedList<Label> Notifikace;
        private Boolean lastConnectionBoolean;
        private String[] mesice = new String[12] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        private String[] dnyEn = new String[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] dnyCz = new String[7] { "PONDĚLÍ", "ÚTERÝ", "STŘEDA", "ČTVRTEK", "PÁTEK", "SOBOTA", "NEDĚLE" };
        WeatherData TeplotaData;
        private int TeplotaLastUpdate;

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

            Pen pen = new Pen(Color.White, 2);

            int yposun = 110;
            int xposun = 400;
            Point p1 = new Point(cas.Location.X + 20, cas.Location.Y + yposun);
            Point p2 = new Point(cas.Location.X + xposun, cas.Location.Y + yposun);

          //  e.Graphics.DrawLine(pen, p1, p2);
        }

        private void Main_UI_Load(object sender, EventArgs e)
        {
         
            int s = Screen.PrimaryScreen.Bounds.Width;
            int v = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0);
            this.Size = new Size(s, v);

            this.cas_sec.Location = new Point(cas.Location.X+260, cas.Location.Y + 10);

            //-------------- set cas a datum

            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);

            DateMonth.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month-1];
            DateDayOfWeek.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            //-------------- set Teplota


            try
            {
                TeplotaData = new WeatherData();
                TempLabel.Visible = true;
                WeatherPic.Visible = true;
                vlhkostLabel.Visible = true;
                vitrLabel.Visible = true;
                tlakLabel.Visible = true;
                mestoLabel.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label8.Visible = true;

                TempLabel.Text = "" + (int)(double.Parse(TeplotaData.temp.Replace('.', ','))) + "°";
                WeatherPic.Image = Image.FromFile(@"..\\Image\\Weather\\" + TeplotaData.icon + ".png");
                vitrLabel.Text = TeplotaData.windSpeed;
                vlhkostLabel.Text = TeplotaData.vlhkost;
                tlakLabel.Text = TeplotaData.tlak;
                TeplotaLastUpdate = DateTime.Now.Minute ;
                mestoLabel.Text = TeplotaData.mesto.ToUpper();
            }
            catch
            {
                Notify("Nastala chyba při načítání počasí");
                TempLabel.Visible = false;
                WeatherPic.Visible = false;
                vlhkostLabel.Visible = false;
                vitrLabel.Visible = false;
                tlakLabel.Visible = false;
                mestoLabel.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

            }
            


            

            //-------------- set pic internet connection

            Image image;

            try
            {
                if (CheckForInternetConnection())
                {
                    lastConnectionBoolean = true;
                    image = Image.FromFile(@"..\\Image\\online.png");    
                }
                else
                {
                    lastConnectionBoolean = false;
                    image = Image.FromFile(@"..\\Image\\offline.png");
                }

                OnlineStatus.Image = image;
            }
            catch {

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
            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            DateMonth.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1].ToUpper();
            DateDayOfWeek.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            //--- Temperature

            if ((DateTime.Now.Minute - TeplotaLastUpdate) >= 5 && lastConnectionBoolean || (DateTime.Now.Minute - TeplotaLastUpdate) < 0 && lastConnectionBoolean)
            { // každých 5 min se pokusit o obnovení dat počasí
                try
                {
                    TeplotaData.CheckWeather();
                    TempLabel.Visible = true;
                    WeatherPic.Visible = true;
                    vlhkostLabel.Visible = true;
                    vitrLabel.Visible = true;
                    tlakLabel.Visible = true;
                    mestoLabel.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label5.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;

                    TempLabel.Text = "" + (int)(double.Parse(TeplotaData.temp.Replace('.', ','))) + "°";
                    WeatherPic.Image = Image.FromFile(@"..\\Image\\Weather\\" + TeplotaData.icon + ".png");
                    vitrLabel.Text = TeplotaData.windSpeed;
                    vlhkostLabel.Text = TeplotaData.vlhkost;
                    tlakLabel.Text = TeplotaData.tlak;
                    mestoLabel.Text = TeplotaData.mesto;

                    TeplotaLastUpdate = DateTime.Now.Minute;
                    Notify("Počasí bylo úspěšně aktualizováno");
                }
                catch
                {
                    Notify("Nastala chyba při načítání dat počasí Opětovný pokus za 10 min");
                    TempLabel.Text = "";
                    TempLabel.Visible = false;
                    WeatherPic.Visible = false;
                    vlhkostLabel.Visible = false;
                    vitrLabel.Visible = false;
                    tlakLabel.Visible = false;
                    mestoLabel.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                }
            }


            //--- Notifikace

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

            //--- Internet connection

            Image image;

            Boolean connection = lastConnectionBoolean;

            try
            {
                if (CheckForInternetConnection())
                {
                        image = Image.FromFile(@"..\\Image\\online.png");
                        lastConnectionBoolean = true;
                   

                }
                else
                {
                        image = Image.FromFile(@"..\\Image\\offline.png");
                        lastConnectionBoolean = false;
              
                }



                OnlineStatus.Image = image;
                
            }
            catch
            {

                Console.WriteLine("nebylo možno nalést obrázek pripojení k internetu");
                Notify("nebylo možno nalést obrázek pripojení k internetu");
            }

            if (!connection && lastConnectionBoolean || connection && !lastConnectionBoolean)
                Notify("Došlo ke změně stavu sítě");

            this.Refresh();
        }

        private void OnlineStatus_Click(object sender, EventArgs e)
        {

        }

        private void NotifLabel_Click(object sender, EventArgs e)
        {

        }

        private void Notify(String s) {

            Console.WriteLine(s);

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

        private void DateDayOfWeek_Click(object sender, EventArgs e)
        {

        }

        private void DateMonth_Click(object sender, EventArgs e)
        {

        }

        private int IndexOf(String[] arr, String value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        private void TempLabel_Click(object sender, EventArgs e)
        {

        }

        private void vitrLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void vlhkostLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tlakLabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void mestoLabel_Click(object sender, EventArgs e)
        {

        }


    }

}


