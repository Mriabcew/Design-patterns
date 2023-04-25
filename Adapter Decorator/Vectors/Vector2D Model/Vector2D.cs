using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Vector2D_Model
{
    public class Vector2D : IVector
    {
        protected double x;
        protected double y;

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double abs()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double cdot(IVector vector)
        {
            return x * vector.getComponents()[0] + y * vector.getComponents()[1];
        }

        public double[] getComponents()
        {
            double[] components = {x,y};
            return components;
        }
    }
}
