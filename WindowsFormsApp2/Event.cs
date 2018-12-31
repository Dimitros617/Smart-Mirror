using System;

namespace WindowsFormsApp2
{
    class Event
    {

        public String nazev = null; // název který zadám do kalendáře
        public String ucebna = null; // kolonka umístění lokace
        public DateTime start; // datum a čas kdy event začíná
        public DateTime konec; // datum a čas kdy event končí
        public int check = 0; // 0 = nezařazeno | 1 = již proběhlo | 2 = právě probíhá | 3 = teprve proběhne


        /**
         * Konstruktor si naparsuje data předaná z kalendáře o jednom eventu a nastaví globální proměné
         * String s = stream neparsovaných dat z netu informace o jednom eventu
         **/
        public Event(string s) {

            String[] pom = s.Split('"');

            for (int i = 0; i < pom.Length; i++)
            {
                if (pom[i].Equals("summary")) nazev = pom[i + 2];
                if (pom[i].Equals("location")) ucebna = pom[i + 2];
                if (pom[i].Equals("start")) start = getDate(pom[i + 4]);
                if (pom[i].Equals("end")) konec = getDate(pom[i + 4]);

            }

        }

        public Event(string naz, string loc, string st, string kon) {

            nazev = naz;
            ucebna = loc;
            start = getDate(st);
            konec = getDate(kon);

        }

        /**
         * String s  = datum a čas ve formátu : "2019-01-08T11:30:00+01:00"
         * Metoda vrací DateTime ve formátu RRRR MM DD HH MM SS
         **/
        private DateTime getDate(string s) {


            int rok = Convert.ToInt32(s.Substring(0, 4));
            int mesic = Convert.ToInt32(s.Substring(5, 2));
            int den = Convert.ToInt32(s.Substring(8, 2));
            int hodina = Convert.ToInt32(s.Substring(11, 2));
            int minuta = Convert.ToInt32(s.Substring(14, 2));

            return new DateTime(rok, mesic, den, hodina, minuta, 0);

        }

    }
}
