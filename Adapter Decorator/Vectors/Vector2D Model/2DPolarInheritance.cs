using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Vector2D_Model
{
    public class _2DPolarInheritance : Vector2D
    {
        public _2DPolarInheritance(double x,double y) : base(x, y) { }
        public double getAngle()
        {
            return (180 / Math.PI) * (Math.Atan(y/x));
        }
    }
}
