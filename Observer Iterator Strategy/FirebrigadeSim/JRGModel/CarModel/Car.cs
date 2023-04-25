using FirebrigadeSim.JRGModel.CarModel.CarState;
using FirebrigadeSim.Point;
using System.Drawing;

namespace FirebrigadeSim.JRGModel.CarModel
{
    public class Car
    {
        private Point2D location;

        private string name;

        private JRG homeStation;

        private bool available = true;

        private ICarState state = new OnHold();

        public ICarState State { get => state; set => state = value; }
        public string Name { get => name; set => name = value; }
        public bool Available { get => available; set => available = value; }
        public Point2D Location { get => location; set => location = value; }
        public JRG HomeStation { get => homeStation; set => homeStation = value; }

        public Car(JRG homeStation)
        {
            this.location = homeStation.Location;
            this.homeStation=homeStation;
        }
    }
}
