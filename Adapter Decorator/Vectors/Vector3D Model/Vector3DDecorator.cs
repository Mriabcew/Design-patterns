using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;
namespace Vectors.Vector3D_Model
{
    internal class Vector3DDecorator : IVector
    {
        protected IVector srcVector;
        protected double z;

        public Vector3DDecorator(IVector srcVector, double z)
        {
            this.srcVector = srcVector;
            this.z = z;
        }

        public double abs()
        {
            double[] temp = srcVector.getComponents();
            return Math.Sqrt(temp[0] * temp[0] + temp[1] * temp[1] + temp[2] * temp[2]);
        }

        public double cdot(IVector vector)
        {
            int i = 0;
            foreach(double a in vector.getComponents())
            {
                i++;
            }
            if(i>2)
                return srcVector.cdot(vector) + vector.getComponents()[2] * z;
            else
            {
                return srcVector.cdot(vector) + 0 * z;
            }
        }

        public double[] getComponents()
        {
            double[] vector = { srcVector.getComponents()[0], srcVector.getComponents()[1], z };
            return vector;
        }

        public IVector getSrcV()
        {
            return srcVector;
        }

        public Vector3DDecorator cross(IVector param)
        {
            Vector3DDecorator c;
            double[] a = this.getComponents();
            double[] b = param.getComponents();
            IVector x = new Vector2D_Model.Vector2D(a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2]);
            return new Vector3DDecorator(x,a[0] * b[1] - a[1] * b[0]);
        
        }
    }
}
