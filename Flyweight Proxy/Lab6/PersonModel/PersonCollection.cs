using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.PersonModel
{
    public class PersonCollection
    {
        private List<Person> personCollection;

        public PersonCollection()
        {
            personCollection = new List<Person>();
        }

        public List<Person> _PersonCollection { get => personCollection; set => personCollection = value; }

        public void getListFromFile()
        {
            string[] lines = File.ReadAllLines("data.dat");
            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                personCollection.Add(new(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]), data[5], int.Parse(data[6]), double.Parse(data[7]), double.Parse(data[8]), data[9]));
            }
        }


    }
}
