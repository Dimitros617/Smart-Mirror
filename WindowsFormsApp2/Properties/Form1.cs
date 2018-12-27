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
            
        }

        private void cas_Click(object sender, EventArgs e)
        {

        }
    }
}
