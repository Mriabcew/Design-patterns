using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel
{
    public class JRGObserver
    {
        private object state;

        public void update(object state)
        {
            this.state = state;
        }
    }
}
