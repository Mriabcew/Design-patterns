using System.Drawing;
using System.Collections;
using FirebrigadeSim.JRGModel.CarModel;
using System;
using FirebrigadeSim.Point;
using FirebrigadeSim.JRGModel.CarModel.CarState;

namespace FirebrigadeSim.JRGModel
{
    public class JRG
    {
        private Point2D location;

        private string name;

        private List<Car> carList = new List<Car>();

        public JRG(Point2D location, string name)
        {
            this.location = location;
            this.name = name;

            for (int i = 0; i < 6; i++)
            {
                Car temp = new Car(this);
                temp.Name = i+"-"+this.name;
                carList.Add(temp);
            }
        }

        public Point2D Location { get => location; set => location = value; }
        public string Name { get => name; set => name = value; }

        public int getAvailableCars()
        {
            int result = 0;
            foreach (Car car in carList)
            {
                if(car.Available)
                    result++;
            }

            return result;
        }

        public bool hasAvailableCars()
        {
            if(getAvailableCars() > 0) 
                return true;
            return false;
        }

        public Car dispathCar(Point2D location)
        {
            foreach (Car car in carList)
            {
                if (car.Available)
                {
                    car.State = new OnTheWay();
                    car.Available = false;
                    car.Location = location;
                    return car;
                }
            }
            return null;
        }
    }
}
