using FirebrigadeSim.JRGModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.Strategy
{
    public interface IStrategy
    {
        void execute(JRGCollection collection, int currentTime);

        bool isFinished();
    }
}
