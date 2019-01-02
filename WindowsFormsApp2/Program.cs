using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form load = new Loading();

            load.Show();
            Task wait = Task.Delay(1000);
            wait.Wait();

            Form form = new Main_UI(load);
            Application.Run(form);

        }
    }
}
