using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

class WeatherData
{

    public string mesto;

    //private const string APIKEY = "410463b3935acea56c8171825dbb4440";
    private List<string> APIKEY;
    private string LocalAPI = "2b0d3bd2a41e54c22b4f1d551969ce66";
    private string CurrentURL;

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

    public void CheckWeather()
    {
        using (WebClient client = new WebClient())
        {
            Boolean data = false;

            for (int i = 0; i < APIKEY.Count; i++)
            {
                try
                {
                    weatherData = (client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + mesto + "&units=metric&APPID=" + APIKEY[i])).Split('"');
                    data = true;
                    break;
                }
                catch
                {

                }
            }

            if(!data)
                throw new System.ArgumentException("Parameter cannot be null", "original");
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

    private void setVar(ref string prom, string xmlMark) {

        for (int i = 0; i < weatherData.Length; i++)
            if (weatherData[i].Equals(xmlMark))
            {
                prom = weatherData[i + 1].Equals(":") ? weatherData[i + 2] : weatherData[i + 1].Substring(1, weatherData[i + 1].Length - 2);
                break;
            }
        

    }

    private void getLocation() {

        using (WebClient client = new WebClient())
        {

            string IP = new WebClient().DownloadString("http://icanhazip.com"); 

            locationData = (client.DownloadString("http://api.ipstack.com/" + IP + "?access_key=" + LocalAPI )).Split('"');
        }

        for (int i = 0; i < locationData.Length; i++)
        {
            if (locationData[i].Equals("city"))
            {
                mesto = locationData[i + 2];
            }
        }

    }



}
