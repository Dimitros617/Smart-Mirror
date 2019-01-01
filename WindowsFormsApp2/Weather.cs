using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp2.Properties
{

    class WeatherData
    {
        private Main_UI form;

        public string mesto;
        private int lastOnlineUpdate = -1;

        private int updateTime = 5; // po kolika minutách se bude počasí aktualizovat 0 < x < 30

        //private const string APIKEY = "410463b3935acea56c8171825dbb4440";
        private List<string> APIKEY;
        private string LocalAPI = "2b0d3bd2a41e54c22b4f1d551969ce66"; // api klíš pro získávání polohy na záladě IP adresy

        string[] weatherData;


        public string temp;
        public string vlhkost;
        public string tlak;
        public string obloha;
        public string windSpeed;
        public string windDegrees;
        public string vychod;
        public string zapad;
        public string icon;

        /**
         * 
         * Konstruktor nastaví polohu město
         * aktualizuje počasí 
         * 
         * Více Api klíčů kontroluje chyby kdyby jeden z nich nefungoval
         **/
        public WeatherData(Main_UI f)
        {
            form = f;

            APIKEY = new List<string>();
            APIKEY.Add("9fab2bfceccef749a5781142d869ef68");
            APIKEY.Add("410463b3935acea56c8171825dbb4440");
            APIKEY.Add("ea574594b9d36ab688642d5fbeab847e");
            APIKEY.Add("2bed6eb0dd723dad545805b1ed7c8750");
            APIKEY.Add("c6ccbb8d29c608a6c3179fd68a6f2fa1");


            UpdateWeather();
        }


        public void UpdateWeather()
        {

            try
            {
                if (lastOnlineUpdate == DateTime.Now.Minute - 5 || DateTime.Now.Minute == 0 || temp == null)
                {
                    getLocation();
                    CheckWeather();
                }
            }
            catch
            {

                form.Notify("Nebylo možné stáhnout nová data o počasí");
            }

        }

        /**
         * Naštení dat z netu a vytvoření splitnutého pole 
         * Zavolání metody setVar která vybere a nastaví příslušné hodnoty
         * Metoda vrací chybu pokud nelze stáhnout data z internetu
         **/
        private void CheckWeather()
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                for (int i = 0; i < APIKEY.Count; i++)
                {
                    try
                    {
                        weatherData = (client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + mesto + "&units=metric&APPID=" + APIKEY[i])).Split('"');
                        form.Notify("Počasí bylo úspěšně aktualizováno");
                        lastOnlineUpdate = DateTime.Now.Minute;
                        break;
                    }
                    catch
                    {
                        throw new Exception("Nelze načíst data o počasí");
                    }
                }


            }
            setVar(ref temp, "temp");
            setVar(ref vlhkost, "humidity");
            setVar(ref tlak, "pressure");
            setVar(ref obloha, "description");
            setVar(ref windSpeed, "speed");
            setVar(ref windDegrees, "deg");
            setVar(ref vychod, "sunrise");
            setVar(ref zapad, "sunset");
            setVar(ref icon, "icon");
        }

        /**
         * ref prom = předaný pointer na globální proměnou
         * xmlMark = hodnota atributu v xml dokumentu hodnota atributu se zapíše do prom
         * 
         * Metoda nalezne podle názvu atributu v rozsplitovaném poli stringů weatherData hodnotu kterou zapíše do předané globální proměné
         **/
        private void setVar(ref string prom, string xmlMark)
        {

            for (int i = 0; i < weatherData.Length; i++)
                if (weatherData[i].Equals(xmlMark))
                {
                    prom = weatherData[i + 1].Equals(":") ? weatherData[i + 2] : weatherData[i + 1].Substring(1, weatherData[i + 1].Length - 2);
                    break;
                }


        }


        /**
         * Metoda si najde a nastaví globální proměnou město podle lokalizace IP adresy
         **/
        private void getLocation()
        {

            string[] locationData;

            using (WebClient client = new WebClient())
            {

                string IP = new WebClient().DownloadString("http://icanhazip.com");

                locationData = (client.DownloadString("http://api.ipstack.com/" + IP + "?access_key=" + LocalAPI)).Split('"');
            }

            for (int i = 0; i < locationData.Length; i++) // pouze parsování a nalezení názvu města z rozsplitovaného stringu z netu
            {
                if (locationData[i].Equals("city"))
                {
                    mesto = locationData[i + 2];
                }
            }

        }



    }
}
