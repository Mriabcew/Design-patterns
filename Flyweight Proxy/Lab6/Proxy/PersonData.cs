using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Proxy
{
    internal class PersonData : IPersonData
    {
        public string capitalise(string text)
        { 
            return char.ToUpper(text[0]) + text.Substring(1).ToLowerInvariant();
        }
    }
}
