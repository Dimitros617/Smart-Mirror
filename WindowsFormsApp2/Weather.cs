using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

class WeatherData
{

    public string mesto;

    //private const string APIKEY = "410463b3935acea56c8171825dbb4440";
    private List<string> APIKEY;
    private string LocalAPI = "2b0d3bd2a41e54c22b4f1d551969ce66"; // api klíš pro získávání polohy na záladě IP adresy

    string[] weatherData;
    string[] locationData;

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
    public WeatherData()
    {
        APIKEY = new List<string>();
        APIKEY.Add("9fab2bfceccef749a5781142d869ef68");
        APIKEY.Add("410463b3935acea56c8171825dbb4440");
        APIKEY.Add("ea574594b9d36ab688642d5fbeab847e");
        APIKEY.Add("2bed6eb0dd723dad545805b1ed7c8750");
        APIKEY.Add("c6ccbb8d29c608a6c3179fd68a6f2fa1");

        getLocation();
        CheckWeather();
    }

    /**
     * Naštení dat z netu a vytvoření splitnutého pole 
     * Zavolání metody setVar která vybere a nastaví příslušné hodnoty
     * Metoda vrací chybu pokud nelze stáhnout data z internetu
     **/
    public void CheckWeather()
    {
        using (WebClient client = new WebClient())
        {
            Boolean data = false;
            client.Encoding = Encoding.UTF8;

            for (int i = 0; i < APIKEY.Count; i++)
            {
                try
                {
                    weatherData = (client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + mesto + "&units=metric&APPID=" + APIKEY[i])).Split('"');
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
    private void setVar(ref string prom, string xmlMark) {

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
    private void getLocation() {


        for (int i = 0; i < locationData.Length; i++) // pouze parsování a nalezení názvu města z rozsplitovaného stringu z netu
        {
            if (locationData[i].Equals("city"))
            {
                mesto = locationData[i + 2];
            }
        }

    }



}
