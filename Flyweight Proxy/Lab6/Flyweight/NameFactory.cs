using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Flyweight
{
    public class NameFactory
    {
        private static NameFactory instance;

        private List<Name> nameList = new List<Name>();

        public static NameFactory getInstance()
        {
            if (instance == null)
            {
                instance = new NameFactory();
            }

            return instance;
        }

        public Name getName(string name)
        {
            foreach (Name n in nameList)
                if (n.getName().Equals(name))
                    return n;
            Name temp = new(name);
            nameList.Add(temp);
            return temp;

        }

        public void printNames()
        {
            foreach (Name name in nameList)
            {
                Console.WriteLine(name);
            }

        }
    }
}
