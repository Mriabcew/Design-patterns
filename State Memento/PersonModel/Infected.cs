using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.PersonModel
{
    internal class Infected : State
    {
        public void Behaviour(Person person,Person person2)
        {
            if(person.InfectionTicks >= person.InfectionMaxTicks)
                person.State = new Immune();
        }
    }
}
