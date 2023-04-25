using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.MementoModel
{
    public interface IMemento
    {
        List<PersonModel.Person> getState();
    }
}
