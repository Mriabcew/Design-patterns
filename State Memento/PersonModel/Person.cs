using SimulationV2.Vectors;
using System;

namespace SimulationV2.PersonModel
{
    public class Person
    {
        //position and move
        private double x;
        private double y;
        private double maxX;
        private double maxY;
        private int dir;

       
        private State _state;
        private Random random;
        //person fields
        private int infectionMaxTicks;
        private int infectionTicks = 0;
        private bool haveSymptoms;
        private int closeToInfectedWithSympthoms = 0;
        private int closeToInfectedWithoutSympthoms = 0;

        private bool infected;
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public bool Infected { get => this.infected; set => this.infected = value; }
        public int InfectionTicks { get => infectionTicks; set => infectionTicks = value; }
        public int InfectionMaxTicks { get => infectionMaxTicks; set => infectionMaxTicks = value; }
        public State State { get => _state; set => _state = value; }
        public int CloseToInfectedWithSympthoms { get => closeToInfectedWithSympthoms; set => closeToInfectedWithSympthoms = value; }
        public bool HaveSymptoms { get => haveSymptoms; set => haveSymptoms = value; }
        public int CloseToInfectedWithoutSympthoms { get => closeToInfectedWithoutSympthoms; set => closeToInfectedWithoutSympthoms = value; }

        public Person(int maxX, int maxY, State state, Random random)
        {
            this.x = random.Next(10, maxX);
            this.y = random.Next(10, maxY);
            this.maxX = maxX;
            this.maxY = maxY;
            this._state = state;
            this.random = random;
            InfectionMaxTicks = random.Next(250) + 500;
            haveSymptoms = (random.Next(int.MaxValue) < random.Next(int.MaxValue / 2));
            dir = random.Next(8);
        }

        //new commer Constructor
        public Person(int maxX, int maxY, Random random, bool randomImmune)
        {
            int dir = random.Next(8);
            this.maxX = maxX;
            this.maxY = maxY;
            InfectionMaxTicks = random.Next(250) + 500;
            haveSymptoms = (random.Next(int.MaxValue) < random.Next(int.MaxValue / 2));
            this.random = random;
            switch (dir)
            {
                case 0:
                    x = random.Next(1, maxX - 1);
                    y = 1;
                    break;
                case 1:
                    x = maxX - 1;
                    y = 1;
                    break;
                case 2:
                    x = maxX - 1;
                    y = random.Next(1, maxY - 1);
                    break;
                case 3:
                    x = maxX - 1;
                    y = maxY - 1;
                    break;
                case 4:
                    x = random.Next(1, maxX - 1);
                    y = maxY - 1;
                    break;
                case 5:
                    x = 1;
                    y = maxY - 1;
                    break;
                case 6:
                    x = 1;
                    y = random.Next(1, maxY - 1);
                    break;
                case 7:
                    x = 1;
                    y = 1;
                    break;
            }
            if (randomImmune)
            {
                int temp = random.Next(10);
                if (temp <= 2)
                    _state = new Infected();
                else if (temp > 2 && temp < 5)
                    _state = new Immune();
                else
                    _state = new Healty();
            }
            else
            {
                int temp = random.Next(10);
                 if (temp <= 2)
                    _state = new Infected();
                else
                    _state = new Healty();
            }
        }

        private IVector speed()
        {
            double x = random.NextDouble() / 10;
            double y = random.NextDouble() / 10;
            return new Vector2D(x, y);
        }
        public void move()
        {
            if(random.Next(100) < 10)
                dir = direction();
            switch (dir)
            {
                case 0:
                    y += speed().getComponents()[1];
                    break;
                case 1:
                    x += speed().getComponents()[0];
                    y += speed().getComponents()[1];
                    break;
                case 2:
                    x += speed().getComponents()[1];
                    break;
                case 3:
                    x += speed().getComponents()[0];
                    y -= speed().getComponents()[1];
                    break;
                case 4:
                    y -= speed().getComponents()[1];
                    break;
                case 5:
                    x -= speed().getComponents()[0];
                    y -= speed().getComponents()[1];
                    break;
                case 6:
                    x -= speed().getComponents()[0];
                    break;
                case 7:
                    x -= speed().getComponents()[0];
                    y += speed().getComponents()[1];
                    break;
            } 
        }

        private int direction()
        {
            return random.Next(8);
        }

        private double distance(Person person)
        {
            return Math.Sqrt((x - person.x) * (x - person.x) + (y-person.y) * (y - person.y));
        }

        public void checkStatus(Person person)
        {
            if (person.haveSymptoms)
            {    if (this.distance(person) <= 2 && (person.State.GetType() == typeof(Infected)))
                {
                    this.closeToInfectedWithSympthoms++;
                    return;
                }
                else
                {
                    this.closeToInfectedWithSympthoms = 0;
                    return;
                }
            }

            else if (!person.haveSymptoms)
            {
                if (this.distance(person) <= 2 && (person.State.GetType() == typeof(Infected)))
                {
                    this.closeToInfectedWithSympthoms++;
                    return;
                }
                else
                {
                    this.closeToInfectedWithSympthoms = 0;
                    return;
                }
            }
        }

        public void Behaviour(Person person)
        {
            _state.Behaviour(this,person);
        }

        public bool outOfBorder(Random random)
        {
            if(x < 0 || y < 0 || x > maxX || y>maxY)
            {
                if (random.NextDouble() >= 0.5)
                {
                    if (this.x > maxX)
                    {
                        this.x = maxX - 1;
                    }
                    if (this.y > maxY)
                    {
                        this.y = maxY - 1;
                    }
                    if (this.x < 0)
                    {
                        this.x = 1;
                    }
                    if(this.y <0)
                    {
                        this.y = 1;
                    }
                   
                    return false;
                }
                else
                {
                    return true;   
                }
            }
            else
            {
                return false;
            }
        }
    }
}
