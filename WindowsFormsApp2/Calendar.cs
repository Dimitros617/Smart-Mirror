using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Calendar
    {
        string CalendarAPI = "AIzaSyBtwsOiCij3QZSD3uSD5aZumuM5iUOXk94";

        string DcalendarAdress = "3nhndn9h6n41qgoo6m52ib4uoo@group.calendar.google.com";
        string McalendarAdress = "";

        string[] DcalendarData;
        string[] McalendarData;

        public List<Event> Dcalendar;
        public List<Event> Mcalendar;

        public List<Event> DcalendarToday;
        public List<Event> McalendarToday;

        public Calendar()
        {
            Dcalendar = new List<Event>();
            Mcalendar = new List<Event>();

            DcalendarToday = new List<Event>();
            McalendarToday = new List<Event>();

            UpdateCalendar();
        }
        
        /**
         * Metoda stáhne data z internetu a předá je třídě event která si data naparsuje
         **/
        public void UpdateCalendar()
        {

            using (WebClient client = new WebClient())
            {

                DcalendarData = (client.DownloadString("https://www.googleapis.com/calendar/v3/calendars/" + DcalendarAdress + "/events?key=" + CalendarAPI)).Split(new[] { "kind" }, StringSplitOptions.None);
                // McalendarData = (client.DownloadString("https://www.googleapis.com/calendar/v3/calendars/" + McalendarAdress + "/events?key=" + CalendarAPI)).Split(new[] { "kind" }, StringSplitOptions.None);

            }

            DcalendarData[0] = null;
            DcalendarData[1] = null;
            //McalendarData[0] = null;
            //McalendarData[1] = null;

            foreach (string s in DcalendarData)
            {
                if (s != null)
                    Dcalendar.Add(new Event(s));

            }

            /* 
             foreach (string s in McalendarData)
             {
                 if (s != null)
                     Mcalendar.Add(new Event(s));

             }
             */
            SetTodayCalendar("D");
            //SetTodayCalendar("M");
        }

        /**
         * Metoda vytvoří list eventů pouze pro dnešní den
         * Vstup String s = "D" = Dominik | "M" = Milan
         **/
        private void SetTodayCalendar(String s)
        {

            List<Event> list;
            List<Event> pom = new List<Event>();

            if (s.ToLower().Equals("d"))
            {
                if (Dcalendar.Count == 0)
                    UpdateCalendar();

                list = Dcalendar;
            }
            else
            {
                if (Mcalendar.Count == 0)
                    UpdateCalendar();

                list = Mcalendar;
            }


            foreach (Event e in list)
            {
                if (e.start.Day == DateTime.Now.Day && e.start.Month == DateTime.Now.Month)
                    pom.Add(e);
            }

            if (s.ToLower().Equals("d"))
            {
                DcalendarToday = pom;
            }
            else {
                McalendarToday = pom;
            }

            UpdateMarkEvent(s);
        }

        /**
         * Metoda nasaví pro všechny eventy dnes vniřní prom check viz tam
         * Markne eventy na časovou osu
         **/
        public void UpdateMarkEvent(String s) {

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

    }
}
