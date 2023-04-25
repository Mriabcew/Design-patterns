using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel.CarModel.CarState
{
    public interface ICarState
    {
        void next(Car car);

        void previous(Car car);
    }
}
