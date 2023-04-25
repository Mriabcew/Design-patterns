using SimulationV2.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.MementoModel
{
    internal class ConcreteMemento : IMemento
    {
        private readonly List<Person> save = new List<Person>();

        public ConcreteMemento(List<Person> list)
        {
            this.save = list;
        }

        public List<Person> getState()
        {
            return save;
        }
    }
}
