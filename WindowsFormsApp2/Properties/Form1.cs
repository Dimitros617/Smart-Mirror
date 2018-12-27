using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Properties
{
    public partial class Main_UI : Form
    {
        public Main_UI()
        {
            InitializeComponent();
        }

        private void Main_UI_Load(object sender, EventArgs e)
        {
            int s = Screen.PrimaryScreen.Bounds.Width;
            int v = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0);
            this.Size = new Size(s, v);

            this.cas_sec.Location = new Point(cas.Location.X+260, 68);


                //-------------- set cas

                string time = String.Format("{0:t}", DateTime.Now);

                cas.Text = time;
                cas_sec.Text = string.Format("{0:00}", DateTime.Now.Second);

                //--------------

                Console.WriteLine("-------------NECO---------------");
                Console.WriteLine();
                Console.WriteLine(CheckForInternetConnection());

                cas.Refresh();

        }

        private void cas_Click(object sender, EventArgs e)
        {
            
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void cas_sec_Click(object sender, EventArgs e)
        {

        }

        public void set_cas_sec(String s) {

            cas_sec.Text = s;
        }

        public void set_cas(String s)
        {

            cas.Text = s;
        }
    }
}
