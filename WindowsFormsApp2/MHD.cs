using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class MHD
    {
        public int lastUpdate; // den v měsíci poseldního updatu
        public DateTime NextTimeTram; // nejbližší stihnutelný spoje
        public DateTime NextTimeBus;
        public List<int> JizdniRadTram = new List<int>();
        public List<int> JizdniRadBus = new List<int>();

        private List<string> busList = new List<string>(new string[] {"http://jizdnirady.pmdp.cz/DZJR_dynamic.aspx?isShort=True&passport=6&point=3&lineName=24", "http://jizdnirady.pmdp.cz/DZJR_dynamic.aspx?isShort=True&passport=6&point=7&lineName=30"}); // adresy vicero autobusu ze stranek PMDP
        private string tramAdress = "http://jizdnirady.pmdp.cz/DZJR_dynamic.aspx?isShort=True&passport=6&point=1&lineName=4"; // adresa ze stránek PMDP jedne tramvaje

        private string path = @"..\\Cash\\mhd.txt"; // adresa cash souboru pro MHD

        public int Posun = 5; // posun casu min za kolik min mám hledat spoj


        /**
         * Konstriktor má vstupní parametr True nebo False zda je připojení k internetu nebo ne
         * Konstruktor pak vrací chybu pokud neexstuje cash soubor a zároveň není připojení k internetu
         **/
        public MHD(Boolean b)
        {
            UpdateMHD(b);
        }

        /**
         * Metoda má vstupní parametr True nebo False zda je připojení k internetu nebo ne
         * Metoda pak vrací chybu pokud neexstuje cash soubor a zároveň není připojení k internetu
         **/
        public void UpdateMHD(Boolean b) {

            if (lastUpdate != DateTime.Now.Hour)
            {
                try
                {
                    LoadFromCash();
                }
                catch
                {
                    lastUpdate = DateTime.Now.Day - 1;
                    if (!b)
                        throw new Exception("Neexistuje cash a není připojení k internetu nelze načíst informace");
                }

                if (b)
                    onlineUpdate();
                else
                    LoadFromCash();

            }

            UpdateNextSpoj(JizdniRadTram, ref NextTimeTram);
            UpdateNextSpoj(JizdniRadBus, ref NextTimeBus);

        }

        /**
         * Metoda stáhne data z internetu´, naparsuje je a vytvoří Pole Listů typu int
         * Metoda vrací chyby při nepodaření stáhnutí dat z netu jednotlivě při každém pokusu pro tramvaj nebo autobus
         **/
        private void onlineUpdate()
        {
            lastUpdate = DateTime.Now.Day;

            string[] data;
            using (WebClient client = new WebClient())
            {
                try
                {
                    data = (client.DownloadString(tramAdress).Split(new[] { "<td class=\"hour\">" }, StringSplitOptions.None));

                }
                catch (Exception)
                {

                    throw new Exception("Nebylo možno stáhnout jizdní řády tramvají") ;
                }
            }

            for (int i = 0; i < data.Length-1; i++)
            {
                string[] data2 = data[i + 1].Split(new[] { "<td class=\"normal\">" }, StringSplitOptions.None);

                for (int j = 1; j < data2.Length; j++)
                {
                    JizdniRadTram.Add(i*60 + (Int32.Parse(data2[j].Replace("\r\n", string.Empty).Replace(" ", string.Empty).Substring(0, 2))));
                }

            }

            //--- nacitani busu

            foreach (string adresa in busList)
            {

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        data = (client.DownloadString(adresa).Split(new[] { "<td class=\"hour\">" }, StringSplitOptions.None));

                    }
                    catch (Exception)
                    {

                        throw new Exception("Nebylo možno stáhnout jízdní řády autobusů " );
                    }
                }

                for (int i = 0; i < 24; i++)
                {
                    string[] data2 = data[i + 1].Split(new[] { "<td class=\"normal\">" }, StringSplitOptions.None);

                    for (int j = 1; j < data2.Length; j++)
                    {
                        JizdniRadBus.Add(i * 60 + (Int32.Parse(data2[j].Replace("\r\n", string.Empty).Replace(" ", string.Empty).Substring(0, 2))));
                    }

                }

            }

            JizdniRadBus = (JizdniRadBus.Distinct().ToList());
            JizdniRadBus.Sort();

            SaveOffline();
        }

        /**
         * Public metoda pro redirekt na stejnosměnou metodu podle vstupního parametru string s = Tram zavolá tamvajový update atd.
         * Předává chybu v případě že nejsou načteny jízdní řády
         **/
        public void UpdateNextSpoj(string s){

            if (s.ToLower().Equals("Tram"))
                UpdateNextSpoj(JizdniRadTram,ref NextTimeTram);
            else
                UpdateNextSpoj(JizdniRadBus,ref NextTimeBus);

        }

        /**
         * Metoda naství gloubální proměnou budto NextTimeTram nebo NextTimeBus podle vstupní hodnoty NExt Spoj
         * Vstupní proměná list je jizdrni rad Budu nebo 
         **/
        private void UpdateNextSpoj(List<int> list,ref DateTime NextSpoj) {

            if (list.Count == 0) {
                throw new Exception("Jízdní řády nejsou načteny prosím nejdříve proveďte update");
            }

            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;

            if (now + Posun < list[list.Count - 1])
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (now + Posun < list[i])
                    {
                        NextSpoj = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)(list[i] / 60), list[i] % 60, 0);
                        break;
                    }
                }
            }
            else
            {
                NextSpoj = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, list[0] / 60, list[0] % 60, 0);
            }
            

        }

        /**
         * Metoda uloží stažená dat do souboru s kodovaním vzestupně seřazených dat 
         *  řádek 1 = den v měsíci poslední aktualizace
         *  řádek 2 = pole tramvajových jízdních řádů převedené na minuty od začátku dne
         *  řádek 3 = -||- autobusových řádů i vícero autobusu 
         **/
        private void SaveOffline() {

            
            TextWriter tw = new StreamWriter(path);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            tw.WriteLine(lastUpdate);
            foreach (int t in JizdniRadTram)
            {
                tw.Write(t + ";");
            }

            tw.WriteLine("");

            foreach (int t in JizdniRadBus)
            {
                tw.Write(t + ";");
            }


            tw.Close();

        }

        /**
         * Metoda načte data ze souboru a nastaví globální promé lastUpdate a nastaví pole s jízdníma řádama pro auobusy a tramvaje
         * Metoda vrací chybu pokud soubor ještě neexistuje
         **/
        private void LoadFromCash() {


            if (!File.Exists(path))
            {
                throw new Exception("Soubor z daty MHD neexistuje");
            }
            else {

                TextReader reader = File.OpenText(path);
                lastUpdate = Int32.Parse(reader.ReadLine());

                string[] pom = reader.ReadLine().Split(';');
                foreach (string s in pom)
                    JizdniRadTram.Add(Int32.Parse(s));

                string[] pomB = reader.ReadLine().Split(';');
                foreach (string s in pomB)
                    JizdniRadBus.Add(Int32.Parse(s));
            }
        }
    }
}
