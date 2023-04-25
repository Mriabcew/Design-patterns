using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Vector2D_Model;

namespace Vectors.Vector3D_Model
{
    internal class Vector3DInheritance : Vector2D
    {
        private double z;

        public Vector3DInheritance(double x, double y,double z) : base(x,y)
        {
            this.z = z;
        }
        public double abs()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public double cdot(IVector vector)
        {
            throw new NotImplementedException();
        }

        public double[] getComponents()
        {
            double[] components = { x, y, z };
            return components;
        }

        //Iloczyn wektorowy
        Vector3DInheritance cross(IVector param)
        {
            double[] a = this.getComponents();
            double[] b = param.getComponents();
            return new Vector3DInheritance(a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]);

        }

        public IVector getSrcV()
        {
            IVector vector = new Vector2D(x, y);
            return vector;
        }
    }
}
