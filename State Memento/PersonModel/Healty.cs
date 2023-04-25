using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.PersonModel
{
    public class Healty : State
    {
        public void Behaviour(Person person, Person person2)
        {
            person.checkStatus(person2);
            if (person.CloseToInfectedWithSympthoms >= 75)
            {
                person.Infected = true;
                person.State = new Infected(); 
            }
            else if (person.CloseToInfectedWithoutSympthoms >= 75)
            {
                Random random = new Random();
                if (random.NextDouble() >= 0.5)
                {
                    person.Infected = true;
                    person.State = new Infected(); 
                }
            }
        }
    }
}
