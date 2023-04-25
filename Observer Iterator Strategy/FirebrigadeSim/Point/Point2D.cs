using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.Point
{
    public class Point2D
    {
        private double x;
        private double y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Point2D()
        {
            Random rng = new Random();
            x = rng.NextDouble() * (50.154564013341734 - 49.95855025648944) + 50.154564013341734; 
            y = rng.NextDouble() * (20.02470275868903 - 19.688292482742394) + 20.02470275868903;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }


        public static double distance(Point2D a, Point2D b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public override string ToString()
        {
            return "Point2D(" + X + "," + Y + ")";
        }
    }
}
