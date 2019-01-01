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

        LinkedList<Label> Notifikace; // pole noticikací 
        private Boolean lastConnectionBoolean; // hodnota zda při posledním tiku bylo aktivní připojení k internetu
        private String[] mesice = new String[12] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        private String[] dnyEn = new String[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] dnyCz = new String[7] { "PONDĚLÍ", "ÚTERÝ", "STŘEDA", "ČTVRTEK", "PÁTEK", "SOBOTA", "NEDĚLE" };
        WeatherData TeplotaData; // instance dat o počasí
        private int TeplotaLastUpdate; // v kolika minutách byl naposledy aktualizováno počasí

        private int lastGraphicUpdate;
        public Boolean draw = true;

        Point ds;
        Point dk;

        Point ms;
        Point mk;


        Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        public Main_UI()
        {
            InitializeComponent();
            Notifikace = new LinkedList<Label>();

        }

        /**
         *  Nevyužitá metoda malovátka čar
         * 
         **/
        private void Main_UI_Paint(object sender, PaintEventArgs e)
        {

            DoubleBuffered = true;
            if (draw)
            {
                e.Graphics.DrawImage(bm, 0, 0);
                drawBackground(e);
                // draw = false;
            }
            else
            {
                e.Graphics.DrawImage(bm, 0, 0);
            }
        }


        private void drawBackground(PaintEventArgs e)
        {

            ds = new Point(DateDayOfWeek.Location.X, DateDayOfWeek.Location.Y + 100);
            dk = new Point(DateDayOfWeek.Location.X, Screen.PrimaryScreen.Bounds.Height - 150);

            ms = new Point(Screen.PrimaryScreen.Bounds.Width - DateDayOfWeek.Location.X, DateDayOfWeek.Location.Y + 100);
            mk = new Point(Screen.PrimaryScreen.Bounds.Width - DateDayOfWeek.Location.X, Screen.PrimaryScreen.Bounds.Height - 150);


            var semiBlack = Color.FromArgb(128, Color.White);
            Brush transparentWhiteB = new SolidBrush(Color.FromArgb(128, 255, 255, 255));

            Pen transparentWhite = new Pen(semiBlack, 3); // transparentní černá


            //e.Graphics.DrawEllipse(BigLine, ds.X, dk.Y, 20, 20);
            e.Graphics.DrawLine(transparentWhite, ds, dk); // moje cara
            e.Graphics.DrawLine(transparentWhite, ms, mk); // milanovo cara
            e.Graphics.FillEllipse(transparentWhiteB, new Rectangle(ds.X - 5, dk.Y - 5, 10, 10)); // spodni muj bili puntik
            e.Graphics.FillEllipse(transparentWhiteB, new Rectangle(ds.X - 10, dk.Y - 10, 20, 20)); // spodni muj bili tranparent
            e.Graphics.FillEllipse(transparentWhiteB, new Rectangle(ms.X - 5, mk.Y - 5, 10, 10));// spodni milanovo bili puntik
            e.Graphics.FillEllipse(transparentWhiteB, new Rectangle(ms.X - 10, mk.Y - 10, 20, 20));// spodni milanovo bili tranparent


        }


        private void Main_UI_Load(object sender, EventArgs e)
        {

            draw = true;
            lastGraphicUpdate = DateTime.Now.Minute;

            int s = Screen.PrimaryScreen.Bounds.Width;
            int v = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0); // nastavení okna aby začínalo v levo nahoře
            this.Size = new Size(s, v); // roztáhnout velikost okna na max

            this.cas_sec.Location = new Point(cas.Location.X + 260, cas.Location.Y + 10); // nastavit pozici labelu casu

            //-------------- set cas a datum | nastavení hodnot všech labelu ohledne času

            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);

            DateMonth.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1];
            DateDayOfWeek.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            //-------------- set Teplota


            TeplotaData = new WeatherData(this); // vytvoření instance dat teploty

            if (TeplotaData.temp != null)
            {
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

                //--- Nastavení hodnot všech labelu
                TempLabel.Text = "" + (int)(double.Parse(TeplotaData.temp.Replace('.', ','))) + "°";
                WeatherPic.Image = Image.FromFile(@"..\\Image\\Weather\\" + TeplotaData.icon + ".png");
                vitrLabel.Text = TeplotaData.windSpeed;
                vlhkostLabel.Text = TeplotaData.vlhkost;
                tlakLabel.Text = TeplotaData.tlak;
                TeplotaLastUpdate = DateTime.Now.Minute;
                mestoLabel.Text = TeplotaData.mesto.ToUpper();


            }
            else // v případě chyby při získávání dat o počasí se vyhodí notifikace a viz níže
            {

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


            //-------------- Nastavení obrázku stavu připojení k internetu

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
            catch
            {

                Notify("nebylo možno nalést obrázek pripojení k internetu");
            }

            //------------- Vykreslení grafiky pro kalendář



            timer1.Start(); // zapnutí časovače pro aktualizovaní okna každých 10 ms
            this.Refresh(); // obnovení okna
        }

        /**
         * Při kliknutí na čas se aplikace zavře
         **/
        private void cas_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        /**
         * Metoda vrací TRUE nebo FALSE podle toho zda je aktivní připojení k internetu
         **/
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

        private void cas_sec_Click(object sender, EventArgs e)
        {
        }

        /**
         * Hlavní metoda co všechno aktualizuje každých 10 ms
         **/
        private void timer1_Tick(object sender, EventArgs e) // hlavní timer
        {
            if (lastGraphicUpdate != DateTime.Now.Minute)
                draw = true;

            //--- nastavení všech hodnot ohledně času a data
            cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);
            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute); ;
            DateMonth.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1].ToUpper();
            DateDayOfWeek.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            //--- Temperature


            TeplotaData.UpdateWeather(); // hlavní aktualizační metoda která se pousí obnovit data o počasí 

            if (TeplotaData.temp != null)
            {
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

                //--- inicializace a obnovení všech hodnot o počasí
                TempLabel.Text = "" + (int)(double.Parse(TeplotaData.temp.Replace('.', ','))) + "°";
                WeatherPic.Image = Image.FromFile(@"..\\Image\\Weather\\" + TeplotaData.icon + ".png");
                vitrLabel.Text = TeplotaData.windSpeed;
                vlhkostLabel.Text = TeplotaData.vlhkost;
                tlakLabel.Text = TeplotaData.tlak;
                mestoLabel.Text = TeplotaData.mesto;

                TeplotaLastUpdate = DateTime.Now.Minute; // přepsat čas poslední aktualizace

            }
            else // případ kdy není možno aktualizovat data z internetu
            {

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



            //--- Notifikace vykreslování notifikací

            if (Notifikace.Count != 0) // pokud jsou k dyspozici notifikace na vypasání
                try
                {
                    foreach (Label label in Notifikace) // for cyklem provedeme akci u každé notifikace
                    {

                        if (label.TabIndex == 0) // hodnota TabIndex určuje timer jak dlouho má aktualizace zůstat než zmizí
                        {
                            if (label.Location.Y > -20) //pokud timer TabIndex vyprchá začne se přesouvat label mimo obrazovku 
                                label.Location = new Point(label.Location.X, label.Location.Y - 1);
                            else
                                Notifikace.Remove(label); // po přesunu mimo obrazovku se notifikace vymaže
                        }
                        else
                        {

                            label.TabIndex--; // inkrementace timeru všech notifikací

                        }

                    }
                }
                catch
                { // neznámý důvod vyhazuje u všech notifikací chybu ano prasácké ošetření neznámé chyby
                  // Notify("Chyba při notifikaci");
                }

            //--- Internet connection

            Image image;

            Boolean connection = lastConnectionBoolean; // uložení stavu posledního stavu internetu

            try // try je zde z důvodů chyby při načtení obrázků
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



                OnlineStatus.Image = image; // nastavení obrázku

            }
            catch
            {

                Console.WriteLine("nebylo možno nalést obrázek pripojení k internetu");
                Notify("nebylo možno nalést obrázek pripojení k internetu");
            }

            //pokud se poslední stav neshoduje s aktuální došlo ke změně stavu připojení
            if (!connection && lastConnectionBoolean || connection && !lastConnectionBoolean)
                Notify("Došlo ke změně stavu sítě");

            //--- Update grafiky pro kalendář



            this.Refresh();// hlavní refresh celého formu
        }

        private void OnlineStatus_Click(object sender, EventArgs e)
        {

        }

        private void NotifLabel_Click(object sender, EventArgs e)
        {

        }

        /**
         * Hlavní metoda pro notifikace
         **/
        public void Notify(String s)
        {

            Console.WriteLine(s); // vypsání notifikace do konzole

            int locx = Screen.PrimaryScreen.Bounds.Width / 2; // nastavení pozice notifikace na střed
            int locy = Notifikace.Count == 0 ? 20 : Notifikace.ElementAt(0).Location.Y + 20; // vypočítání Y pozice všech notifikací aby další byla pod předchozí

            Label label = new Label();
            label.Location = new System.Drawing.Point(locx, locy);
            label.Name = "label";
            label.Text = s;
            label.AutoSize = true;
            label.ForeColor = System.Drawing.Color.White;
            label.TabIndex = 300;
            label.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label as Control); // vykreslení notifikace
            Notifikace.AddFirst(label); // přidání notifikace do pole

        }

        private void DateDayOfWeek_Click(object sender, EventArgs e)
        {

        }

        private void DateMonth_Click(object sender, EventArgs e)
        {

        }

        /**
         * Metoda vrací na základě vstupního pole a hledaného stríngu index na v poli na kterém se string nachází
         **/
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


