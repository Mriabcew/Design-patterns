using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel.CarModel.CarState
{
    public class OnMission : ICarState
    {
        //#TODO Dopisac nie wiem jeszcze co :)
        public void next(Car car)
        {
            
        }

        public void previous(Car car)
        {
            car.State = new OnTheWay();
        }
    }
}
