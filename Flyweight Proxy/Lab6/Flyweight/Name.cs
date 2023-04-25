using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Flyweight
{
    public class Name:IName
    {
        private string name;

        public Name(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
    }
}
