using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.AreaModel
{
    public class Area
    {
        private double minX;
        private double minY;
        private double maxX;
        private double maxY;

        public Area(double minX, double minY, double maxX, double maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public double MinX { get => minX; set => minX = value; }
        public double MinY { get => minY; set => minY = value; }
        public double MaxX { get => maxX; set => maxX = value; }
        public double MaxY { get => maxY; set => maxY = value; }
    }
}
