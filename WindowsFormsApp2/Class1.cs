using System.Net;
using System.Xml;

class WeatherData
{

    private string city;

    private const string APIKEY = "9fab2bfceccef749a5781142d869ef68";
    private string CurrentURL;

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

    public WeatherData(string City)
    {
        city = City.ToLower();
        CheckWeather();
    }

    public void CheckWeather()
    {
        using (WebClient client = new WebClient())
        {
             weatherData = (client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=" + APIKEY)).Split('"');
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



}
