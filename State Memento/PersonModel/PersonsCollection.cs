using SimulationV2.MementoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.PersonModel
{
    public class PersonsCollection
    {
        private List<Person> persons;
        public PersonsCollection()
        {
            persons = new List<Person>();
        }

        public void Add(Person person)
        {
            persons.Add(person);
        }
        public List<Person> getPersonsList()
        {
            return persons;
        }






        //-------------------------------------------------------
        public IMemento Save()
        {
            return new ConcreteMemento(this.persons);
        }
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this.persons = memento.getState();
        }
    }
}
