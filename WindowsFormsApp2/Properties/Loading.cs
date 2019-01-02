using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Properties
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            int s = Screen.PrimaryScreen.Bounds.Width;
            int v = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(0, 0); // nastavení okna aby začínalo v levo nahoře
            this.Size = new Size(s, v); // roztáhnout velikost okna na max

            label1.Location = new Point(s/4,v/2-5);
            pictureBox1.Location = new Point(s/2, v/2 - 100);
        }
    }
}
