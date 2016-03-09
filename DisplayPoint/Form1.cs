using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // just make the window big enough to fit this graph...
            this.Width = 1200;
            this.Height = 700;

            // add 5 so the bars fit properly
            //int x = 640; // the position of the X axis, max y value
            //int y = 10; // the position of the Y axis

            int y = 640; // the position of the X axis, max y value
            int x = 10; // the position of the Y axis
            int zoomSize = 23;

            Bitmap bmp = new Bitmap(1100, 650);
            Graphics g = Graphics.FromImage(bmp);

            //g.DrawLine(new Pen(Color.Red, 2), 10, 10, 10, 640);
            //g.DrawLine(new Pen(Color.Red, 2), 10, 640, 300, 640);
            //// let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            //g.DrawString("X", new Font("Calibri", 12), new SolidBrush(Color.Black), y + 30, x - 20);

            // make point in shape rectangle
            //g.FillEllipse(Brushes.Black, x + 30, y - 20, 5, 5);
            //g.FillEllipse(Brushes.Black, x + 5, y - 5, 5, 5);
            //g.FillEllipse(Brushes.Black, x + 100, y - 100, 5, 5);
            //g.FillEllipse(Brushes.Black, x + 20, y - 20, 5, 5);
            //g.FillEllipse(Brushes.Black, x + 0, y - 0, 5, 5);

            ////make point in shape circle
            //g.FillEllipse(Brushes.Black, y + 50, x - 20, 7, 7);
            //g.FillEllipse(Brushes.Black, y, x, 7, 7);
            //g.FillEllipse(Brushes.Black, y + 100, x - 20, 7, 7);

            // get point from file
            string directory = @"D:\data_all_terbaru\data_location_v2_coordinate.txt";
            List<Coordinate> lCoordinate = new List<Coordinate>();
            lCoordinate = Displayer.getCoordinateFromFile(directory);
            float xMin = lCoordinate.OrderBy(c => c.x).First().x;
            float xMax = lCoordinate.OrderByDescending(c => c.x).First().x;
            float yMin = lCoordinate.OrderBy(c => c.y).First().y;
            float yMax = lCoordinate.OrderByDescending(c => c.y).First().y;

            Console.WriteLine(xMin);
            Console.WriteLine(xMax);
            Console.WriteLine(yMin);
            Console.WriteLine(yMax);
            
            // set point on bmp
            //g = Displayer.getPointedgraphics(g, lCoordinate, zoomSize, x, y);
            string directoryCluster = @"D:\data_location_cluster.txt";
            g = Displayer.getColorPointedgraphics(g, directoryCluster, lCoordinate, zoomSize, x, y);

            //foreach (var coordinate in lCoordinate)
            //{
            //    // rumus: {titik awal x + (coor x + xMin + tambahan titik awal) * jarak lebar}, {titik awal x + (coor y - yMin + tambahan titik awal) * jarak tinggi}
            //    //g.FillEllipse(Brushes.Black, (float)y + (float)((coordinate.x + xMin + 20) * 70), (float)x - (float)((coordinate.y - yMin + 10) * 10), 7, 7);
            //    //Console.WriteLine((float)y + (float)((coordinate.x + xMin + 20) * 70));
            //    g.FillEllipse(Brushes.Black, (float)x + (float)((coordinate.x - 95) * zoomSize), (float)y - (float)((coordinate.y + 11.08) * zoomSize), 5, 5);
            //}

            //g.FillEllipse(Brushes.Red, (float)y + (float)((-5 + xMin + 20) * 70), (float)x - (float)((95 - yMin + 10) * 10), 7, 7);

            // draw border maps
            float x1 = (float)x + (float)((95 - 95) * zoomSize);
            float y1 = (float)y - (float)((6 + 11.08) * zoomSize);
            float x2 = (float)x + (float)((141.45 - 95) * zoomSize);
            float y2 = (float)y - (float)((-11.08 + 11.08) * zoomSize);
            Console.WriteLine(x1);
            Console.WriteLine(y1);
            Console.WriteLine(x2);
            Console.WriteLine(y2);
            g.DrawLine(new Pen(Color.Black, 2), x1, y1, x2, y1);
            g.DrawLine(new Pen(Color.Black, 2), x2, y1, x2, y2);
            g.DrawLine(new Pen(Color.Black, 2), x2, y2, x1, y2);
            g.DrawLine(new Pen(Color.Black, 2), x1, y2, x1, y1);

            // make line maps
            for (int i = 0; i > -11.08; i-=10)
            {
                g.DrawLine(new Pen(Color.Black, 1), (float)x + (float)((95 - 95) * zoomSize), (float)y - (float)((i + 11.08) * zoomSize), (float)x + (float)((141.45 - 95) * zoomSize), (float)y - (float)((i + 11.08) * zoomSize));
            }

            for (int i = 100; i < 141.45; i += 10)
            {
                g.DrawLine(new Pen(Color.Black, 1), (float)x + (float)((i - 95) * zoomSize), (float)y - (float)((6 + 11.08) * zoomSize), (float)x + (float)((i - 95) * zoomSize), (float)y - (float)((-11.08 + 11.08) * zoomSize));
            }

            // display bmp (point image) in picture box
            PictureBox display = new PictureBox();
            display.Width = 1100;
            display.Height = 650;
            this.Controls.Add(display);
            display.Image = bmp;
        }
    }
}
