using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.Vectors
{
    public interface IVector
    {
        double abs();
        double cdot(IVector vector);
        double[] getComponents();
    }
}
