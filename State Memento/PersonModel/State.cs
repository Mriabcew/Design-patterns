using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV2.PersonModel
{
    public interface State
    {
        void Behaviour(Person person,Person person2);
    }
}
