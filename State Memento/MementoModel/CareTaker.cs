using SimulationV2.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.MementoModel
{
    public class CareTaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private PersonsCollection personCollection = null;
        

        public CareTaker(PersonsCollection personCollection)
        {
            this.personCollection = personCollection;
        }

        public void Backup()
        {
            this._mementos.Add(this.personCollection.Save());
        }

        public void Undo()
        {
            if(this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            try
            {
                this.personCollection.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
    }
}
