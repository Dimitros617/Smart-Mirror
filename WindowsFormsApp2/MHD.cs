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
        public DateTime NextTimeTram;
        public List<int> JizdniRadTram = new List<int>();

        public int Posun = 5; // posun casu min za kolik min mám hledat spoj

        public MHD(Boolean b)
        {

            if (b && lastUpdate != DateTime.Now.Day)
                onlineUpdate();
            else
                offlineUpdate();

            UpdateNextSpoj(JizdniRadTram, ref NextTimeTram);
        }


        private void offlineUpdate()
        {

        }

        /**
         * Metoda stáhne data z internetu´, naparsuje je a vytvoří Pole Listů typu int
         **/
        private void onlineUpdate()
        {
            lastUpdate = DateTime.Now.Day;

            string[] data;
            using (WebClient client = new WebClient())
            {
                try
                {
                    data = (client.DownloadString("http://jizdnirady.pmdp.cz/DZJR_dynamic.aspx?isShort=True&passport=6&point=1&lineName=4").Split(new[] { "<td class=\"hour\">" }, StringSplitOptions.None));

                }
                catch (Exception)
                {

                    throw new Exception("Nebylo možno stáhnout rady tramvaji") ;
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

            SaveOffline();
        }

        /**
         * Metoda naství gloubální proměnou budto NextTimeTram nebo NextTimeBus podle vstupní hodnoty NExt Spoj
         * Vstupní proměná list je jizdrni rad Budu nebo 
         **/
        public void UpdateNextSpoj(List<int> list,ref DateTime NextSpoj) {

            if (list.Count == 0) {
                throw new System.ArgumentException("Jízdní řády nejsou načteny prosím nejdříve proveďte update");
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

        public void SaveOffline() {

            string path = @"..\\Cash\\mhd.txt";
            TextWriter tw = new StreamWriter(path);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            foreach (int t in JizdniRadTram)
            {
                tw.Write(t + ";");
            }
            


            tw.Close();

        }

    }
}
