using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayPoint
{
    class Displayer
    {
        public static List<Coordinate> getCoordinateFromFile(string directory)
        {
            List<Coordinate> lCoordinate = new List<Coordinate>();
            
            // Read the file line by line
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                string[] coordinate = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                Coordinate point = new Coordinate();
                //point.x = float.Parse(coordinate[0]);
                //point.y = float.Parse(coordinate[1]);
                point.x = float.Parse(coordinate[1]);
                point.y = float.Parse(coordinate[0]);

                // add point to list
                lCoordinate.Add(point);
            }

            return lCoordinate;
        }

        public static Graphics getPointedgraphics(Graphics g, List<Coordinate> lCoordinate, int zoomSize, int x, int y)
        {
            foreach (var coordinate in lCoordinate)
            {
                // rumus: {titik awal x + (coor x + xMin + tambahan titik awal) * jarak lebar}, {titik awal x + (coor y - yMin + tambahan titik awal) * jarak tinggi}
                //g.FillEllipse(Brushes.Black, (float)y + (float)((coordinate.x + xMin + 20) * 70), (float)x - (float)((coordinate.y - yMin + 10) * 10), 7, 7);
                //Console.WriteLine((float)y + (float)((coordinate.x + xMin + 20) * 70));
                g.FillEllipse(Brushes.Black, (float)x + (float)((coordinate.x - 95) * zoomSize), (float)y - (float)((coordinate.y + 11.08) * zoomSize), 5, 5);
            }

            return g;
        }

        public static Graphics getColorPointedgraphics(Graphics g, string directory, List<Coordinate> lCoordinate, int zoomSize, int x, int y)
        {
            string[] clusterNumber = getArrayLineFromFile(directory);

            for (int i = 0; i < lCoordinate.Count; i++)
            {
                switch(clusterNumber[i])
                {
                    case "1":
                        g.FillEllipse(Brushes.Green, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "2":
                        g.FillEllipse(Brushes.Orange, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "3":
                        g.FillEllipse(Brushes.Blue, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "4":
                        g.FillEllipse(Brushes.Purple, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "5":
                        g.FillEllipse(Brushes.Pink, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "6":
                        g.FillEllipse(Brushes.Chocolate, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "7":
                        g.FillEllipse(Brushes.SkyBlue, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    case "NOISE":
                        g.FillEllipse(Brushes.Red, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                    default:
                        g.FillEllipse(Brushes.Black, (float)x + (float)((lCoordinate.ElementAt(i).x - 95) * zoomSize), (float)y - (float)((lCoordinate.ElementAt(i).y + 11.08) * zoomSize), 5, 5);
                        break;
                }
            }

            return g;
        }

        public static string[] getArrayLineFromFile(string directory)
        {
            string[] arrLine = File.ReadAllLines(directory);

            return arrLine;
        }
    }

    class Coordinate
    {
        public float x { get; set; }
        public float y { get; set; }
    }
}
