using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel.CarModel.CarState
{
    public class OnTheWay : ICarState
    {
        public void next(Car car)
        {
            car.State = new OnMission();
        }

        public void previous(Car car)
        {
            car.State = new OnHold();
        }
    }
}