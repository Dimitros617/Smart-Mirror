using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{



    class CalendarGraphic
    {
        private Main_UI form;
        private PaintEventArgs e;

        public CalendarGraphic(Main_UI f, PaintEventArgs e) {

            form = f;
            this.e = e;

            updateGraphic(e);
        }

        public void updateGraphic(PaintEventArgs e)
        {
            this.e = e;
            drawBackground();

        }

        public void drawBackground() {


            Pen pen = new Pen(Color.White, 2);

            Point p1 = new Point(500, 500);
            Point p2 = new Point(500, 1500);

            e.Graphics.DrawLine(pen, p1, p2);

        }
    }
}
