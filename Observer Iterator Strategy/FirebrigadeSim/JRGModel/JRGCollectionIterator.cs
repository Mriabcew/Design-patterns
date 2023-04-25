using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel
{
    public class JRGCollectionIterator
    {
        private int index;
        private ArrayList list;

        public JRGCollectionIterator(ArrayList list)
        {
            this.list = list;
        }

        public object Next()
        {
            if(index < list.Count)
            {
                return list[index++];
            }
            return null;    
        }
    }
}
