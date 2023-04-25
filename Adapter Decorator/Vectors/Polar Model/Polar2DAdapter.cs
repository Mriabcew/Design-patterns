using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Polar_Model
{
    internal class Polar2DAdapter : IVector,IPolar2D
    {
        private Vector2D_Model.Vector2D srcVector;

        public Polar2DAdapter(Vector2D_Model.Vector2D srcVector)
        {
            this.srcVector = srcVector;
        }

        public double abs()
        {
            return this.srcVector.abs();
        }

        public double cdot(IVector vector)
        {
            return this.srcVector.cdot(vector);
        }

        public double getAngle()
        {
            return (180 / Math.PI) * (Math.Atan(srcVector.getComponents()[1] / srcVector.getComponents()[0]));
        }

        public double[] getComponents()
        {
            return this.srcVector.getComponents();
        }
    }
}
