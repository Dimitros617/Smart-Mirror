using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WindowsFormsApp2
{
    class Calendar
    {
        private string path = @"..\\Cash\\calendar.txt"; // adresa cash souboru pro kalendar

        public List<Event> Dcalendar;
        public List<Event> Mcalendar;

        public List<Event> DcalendarToday;
        public List<Event> McalendarToday;

        private int lastOnlineUpdate;

        public Calendar(Boolean b)
        {
            Dcalendar = new List<Event>();
            Mcalendar = new List<Event>();

            DcalendarToday = new List<Event>();
            McalendarToday = new List<Event>();

            UpdateCalendar(b);
        }

        /**
         * Metoda potřebuje vstupní parametr true nebo false podle toho zda je k dyspozici připojení k internetu
         * Metoda vrací chybu v případě že nešlo načíst data z internetu
         **/
        public void UpdateCalendar(Boolean b)
        {

            if (lastOnlineUpdate != DateTime.Now.Hour)
            {
                try
                {
                    LoadFromCash();

                }
                catch
                {
                    lastOnlineUpdate = DateTime.Now.Hour - 1;
                    if (!b)
                        throw new Exception("Neexistuje cash a není připojení k internetu nelze načíst informace o kalendáři");
                }

                if (b)
                {
                    try
                    {
                        OnlineUpdateCalendar();

                    }
                    catch
                    {

                        try
                        {
                            LoadFromCash();

                        }
                        catch
                        {

                            throw new Exception("Neexistuje cash a nastala chyba při připojení k internetu nelze načíst informace o kalendáři");
                        }
                    }
                }
                else
                {
                    LoadFromCash();

                }

                SetTodayCalendar("D");
                SetTodayCalendar("M");
            }
        }

        /**
         * Metoda stáhne data z internetu a předá je třídě event která si data naparsuje
         * vrací chybu v případě že nelze stáhnout data z intrnetu
         **/
        private void OnlineUpdateCalendar()
        {
            string CalendarAPI = "AIzaSyBtwsOiCij3QZSD3uSD5aZumuM5iUOXk94";

            string DcalendarAdress = "3nhndn9h6n41qgoo6m52ib4uoo@group.calendar.google.com";
            string McalendarAdress = "riasj7pgslq5q1idpqkapf4f14@group.calendar.google.com";

            string[] DcalendarData;
            string[] McalendarData;


            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    DcalendarData = (client.DownloadString("https://www.googleapis.com/calendar/v3/calendars/" + DcalendarAdress + "/events?key=" + CalendarAPI)).Split(new[] { "kind" }, StringSplitOptions.None);
                    McalendarData = (client.DownloadString("https://www.googleapis.com/calendar/v3/calendars/" + McalendarAdress + "/events?key=" + CalendarAPI)).Split(new[] { "kind" }, StringSplitOptions.None);
                    lastOnlineUpdate = DateTime.Now.Hour;
                }
            }
            catch
            {
                throw new Exception("Nastal problém při stahovaní kalendáře");
            }


            DcalendarData[0] = null;
            DcalendarData[1] = null;
            McalendarData[0] = null;
            McalendarData[1] = null;

            foreach (string s in DcalendarData)
            {
                if (s != null)
                    Dcalendar.Add(new Event(s));

            }
            DcalendarData = null;

            foreach (string s in McalendarData)
            {
                if (s != null)
                    Mcalendar.Add(new Event(s));

            }

            McalendarData = null;

            GC.Collect();

            SaveOffline();


        }

        /**
         * Metoda vytvoří list eventů pouze pro dnešní den
         * Vstup String s = "D" = Dominik | "M" = Milan
         **/
        private void SetTodayCalendar(String s)
        {

            List<Event> list;
            List<Event> pom = new List<Event>();

            int aaa = DateTime.Now.Day;
            int bbb = DateTime.Now.Month;


            if (s.ToLower().Equals("d"))
            {
                if (Dcalendar.Count == 0)
                    UpdateCalendar(true);

                list = Dcalendar;
            }
            else
            {
                if (Mcalendar.Count == 0)
                    UpdateCalendar(true);

                list = Mcalendar;
            }


            foreach (Event e in list)
            {
                if (e.start.Day == aaa && e.start.Month == bbb)
                {
                    pom.Add(e);
                }
            }

            if (s.ToLower().Equals("d"))
            {
                DcalendarToday = pom;
            }
            else
            {
                McalendarToday = pom;
            }


        }

        /**
         * Metoda nasaví pro všechny eventy dnes vniřní prom check viz tam
         * Markne eventy na časovou osu
         **/
        public void UpdateMarkEvent(String s)
        {

            List<Event> pom;

            if (DcalendarToday.Count == 0)
                SetTodayCalendar(s);


            if (s.ToLower().Equals("d"))
            {
                pom = DcalendarToday;
            }
            else
            {
                pom = McalendarToday;
            }

            for (int i = 0; i < pom.Count; i++)
            {
                if ((DateTime.Now.Hour * 60 + DateTime.Now.Minute) < (pom[i].start.Hour * 60 + pom[i].start.Minute))
                    pom[i].check = 3;
                if ((DateTime.Now.Hour * 60 + DateTime.Now.Minute) > (pom[i].konec.Hour * 60 + pom[i].konec.Minute))
                    pom[i].check = 1;
                else
                    pom[i].check = 2;
            }

        }

        /**
         * Metoda uloží celé kalendáře do souboru
         **/
        private void SaveOffline()
        {

            TextWriter tw = new StreamWriter(path, false, Encoding.UTF8);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            tw.WriteLine(lastOnlineUpdate);

            for (int i = 0; i < Dcalendar.Count; i++)
            {
                tw.Write(Dcalendar[i].nazev + ";");
                tw.Write(Dcalendar[i].ucebna + ";");
                tw.Write(Dcalendar[i].start.Year + "-" + Dcalendar[i].start.Month + "-" + Dcalendar[i].start.Day + "-" + Dcalendar[i].start.Hour + "-" + Dcalendar[i].start.Minute + ";");
                tw.WriteLine(Dcalendar[i].konec.Year + "-" + Dcalendar[i].konec.Month + "-" + Dcalendar[i].konec.Day + "-" + Dcalendar[i].konec.Hour + "-" + Dcalendar[i].konec.Minute + ";");


            }

            tw.WriteLine("-");

            for (int i = 0; i < Mcalendar.Count; i++)
            {
                tw.Write(Mcalendar[i].nazev + ";");
                tw.Write(Mcalendar[i].ucebna + ";");
                tw.Write(Mcalendar[i].start.Year + "-" + Dcalendar[i].start.Month + "-" + Dcalendar[i].start.Day + "-" + Dcalendar[i].start.Hour + "-" + Dcalendar[i].start.Minute + ";");
                tw.WriteLine(Mcalendar[i].konec.Year + "-" + Dcalendar[i].konec.Month + "-" + Dcalendar[i].konec.Day + "-" + Dcalendar[i].konec.Hour + "-" + Dcalendar[i].konec.Minute + ";");


            }
            tw.WriteLine("-");
            tw.Close();
        }


        private void LoadFromCash()
        {
            if (!File.Exists(path))
            {
                throw new Exception("Soubor z daty kalendáře neexistuje");
            }
            else
            {
                TextReader reader = File.OpenText(path);
                lastOnlineUpdate = Int32.Parse(reader.ReadLine());

                string s = reader.ReadLine().Trim();
                while (!s.Equals("-"))
                {
                    string[] pom = s.Split(';');
                    Dcalendar.Add(new Event(pom[0],pom[1],pom[2],pom[3]));

                    s = reader.ReadLine().Trim();
                }

                s = reader.ReadLine().Trim();
                while (!s.Equals("-"))
                {
                    string[] pom = s.Split(';');
                    Mcalendar.Add(new Event(pom[0], pom[1], pom[2], pom[3]));

                    s = reader.ReadLine().Trim();
                }


            }

        }
    }
}
