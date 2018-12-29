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
using System.Drawing.Imaging;

namespace WindowsFormsApp2.Properties
{
    public partial class Main_UI : Form
    {

        private int timer;
        private int NotifCounter;
        LinkedList<Label> Notifikace;
        private double lastConnection;
        private Boolean lastConnectionBoolean;
        private String[] mesice = new String[12] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        private String[] dnyEn = new String[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] dnyCz = new String[7] { "Pondělí", "Úterý", "Středa", "Čtvrtek", "Pátek", "Sobota", "Neděle" };
        WeatherData TeplotaData;

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
                TeplotaData = new WeatherData("Most");
            }
            catch
            {
                Notify("Nastala chyba při načítání počasí");
                
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

            lastConnection = 100.0;
            
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
            DateMonth.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1];
            DateDayOfWeek.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            //--- Temperature

            if (DateTime.Now.Minute % 5 == 0) // každých 5 min se pokusit o obnovení dat počasí
                try
                {
                    TeplotaData.CheckWeather();
                }
                catch
                {
                    Notify("Nastala chyba při načítání dat počasí Opětovný pokus za 5 min");
                }

                TempLabel.Text = "" + (int)(double.Parse(TeplotaData.temp.Replace('.', ',')) - 273.16) + "°";
                WeatherPic.Image = Image.FromFile(@"..\\Image\\Weather\\" + TeplotaData.icon + ".png");

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
            Boolean connection;

            try
            {
                if (CheckForInternetConnection())
                {
                        image = Image.FromFile(@"..\\Image\\online.png");
                        connection = true;
                   

                }
                else
                {
                        image = Image.FromFile(@"..\\Image\\offline.png");
                        connection = false;
              
                }



                OnlineStatus.Image = image;
                
            }
            catch
            {

                Console.WriteLine("nebylo možno nalést obrázek pripojení k internetu");
                Notify("nebylo možno nalést obrázek pripojení k internetu");
            }

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
    }

    }


