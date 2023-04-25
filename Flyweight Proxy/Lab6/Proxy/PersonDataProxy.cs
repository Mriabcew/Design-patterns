using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Proxy
{
    public class PersonDataProxy : IPersonData
    {
        private IPersonData _data = new PersonData();
        public string capitalise(string text)
        {
            return _data.capitalise(text);
        }
    }
}
