using FirebrigadeSim.JRGModel;
using FirebrigadeSim.JRGModel.CarModel;
using FirebrigadeSim.JRGModel.CarModel.CarState;
using FirebrigadeSim.Point;
using System;
using System.Drawing;

namespace FirebrigadeSim.Strategy
{
    public class PZStrategy:IStrategy
    {
        private int startTime;
        private JRGCollection collection;
        private bool finished = false;
        private Point2D location;
        private Car c1;
        private Car c2;
        private Car c3;
        private int drivingTime;
        private int getToLocationTime;
        private int comeBackTime;
        private int missionEndTime;
        private int missionType;
        private bool falseMission;

        public PZStrategy(int startTime, JRGCollection collection)
        {
            this.startTime = startTime;
            this.collection = collection;

            init();
        }

        private void init()
        {
            Random rng = new Random();
            missionType = rng.Next(101);
            drivingTime = rng.Next(1, 3);

            if (missionType < 6)
            {
                falseMission= true;
                getToLocationTime = drivingTime + startTime;
                missionEndTime = getToLocationTime;
                comeBackTime = drivingTime + missionEndTime;
            }

            else 
            {
                falseMission = false;
                getToLocationTime = drivingTime + startTime;
                missionEndTime = rng.Next(20) + 5 + getToLocationTime;
                comeBackTime = drivingTime + missionEndTime;
            }

            location = new Point2D();

            c1 = collection.getJRGByName(collection.findClosestAvailableJRG(location)).dispathCar(location);
            c2 = collection.getJRGByName(collection.findClosestAvailableJRG(location)).dispathCar(location);
            c3 = collection.getJRGByName(collection.findClosestAvailableJRG(location)).dispathCar(location);

            c1.State = new OnTheWay();
            c1.Location = location;

            c2.State = new OnTheWay();
            c2.Location = location;

            c3.State = new OnTheWay();
            c3.Location = location;

            Console.WriteLine("Auta " + c1.Name + ", " + c2.Name + ", " + c3.Name + ": jada na zgloszenie typu MZ.");

        }

        public void execute(JRGCollection collection, int currentTime)
        {
            if(falseMission)
            {
                if(currentTime == getToLocationTime)
                {
                    c1.State = new OnTheWay();
                    c1.Location = c1.HomeStation.Location;

                    c2.State =new OnTheWay();
                    c2.Location = c2.HomeStation.Location;

                    c3.State = new OnTheWay();
                    c3.Location = c3.HomeStation.Location;

                    Console.WriteLine(c1.Name + ", " + c2.Name+ ", " + c3.Name + " - dotarly na miejsce, falszywy alarm, powrot do bazy");


                }
                else if(currentTime == comeBackTime)
                {
                    c1.State = new OnHold();
                    c1.Available= true;
                    c2.State= new OnHold();
                    c2.Available= true;
                    c3.State= new OnHold();
                    c3.Available= true;

                    finished = true;

                    Console.WriteLine(c1.Name + ", " + c2.Name +", " + c3.Name + " wrocily do bazy");
                }
            }
            else
            {
                if(currentTime == getToLocationTime)
                {
                    c1.State = new OnMission();
                    c2.State = new OnMission();
                    c3.State = new OnMission();

                    Console.WriteLine(c1.Name + ", " + c2.Name + ", " + c3.Name + " - dotarly na miejsce, potwierdzaja wezwanie, trwa akcja");
                }

                else if(currentTime == missionEndTime)
                {
                    c1.State = new OnTheWay();
                    c1.Location = c1.HomeStation.Location;
                    c2.State = new OnTheWay();
                    c2.Location = c2.HomeStation.Location;
                    c3.State = new OnTheWay();
                    c3.Location = c3.HomeStation.Location;

                    Console.WriteLine(c1.Name + ", " + c2.Name + ", " + c3.Name + " zakonczyly akcje");
                }
                else if(currentTime == comeBackTime)
                {
                    c1.State = new OnHold();
                    c1.Available= true;
                    c2.State = new OnHold();
                    c2.Available = true; 
                    c3.State = new OnHold();
                    c3.Available = true;

                    finished = true;

                    Console.WriteLine(c1.Name + ", " + c2.Name + ", " + c3.Name + "wrocily do bazy");

                }
            }

        }

        public bool isFinished()
        {
            return finished;
        }
    }
}
