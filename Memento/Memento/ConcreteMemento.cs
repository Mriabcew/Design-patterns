using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Memento
{
    public class ConcreteMemento:IMemento
    {
        private string _state;
        
        public ConcreteMemento(string state)
        { this._state = state; }


        public string getState()
        {
            return _state;
        }
    }
}
