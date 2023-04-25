using FirebrigadeSim.JRGModel;
using FirebrigadeSim.Strategy;
using System.Collections;

namespace FirebrigadeSim.Context
{
    public class JRGContext
    {
        private List<IStrategy> strategies = new List<IStrategy>();

        private JRGCollection collection;

        public JRGContext(JRGCollection collection)
        {
            this.collection = collection;
        }

        public void addStrategy(IStrategy strategy)
        {
            this.strategies.Add(strategy);
        }

        public void execute(int currentTime)
        {
            foreach (IStrategy strategy in strategies)
            {
                strategy.execute(collection, currentTime);
            }
        }

        public void cleanUp()
        {
            for (int i = 0; i < strategies.Count; i++)
            {
                if (strategies[i].isFinished())
                    strategies.RemoveAt(i);
            }
        }
    }
}
