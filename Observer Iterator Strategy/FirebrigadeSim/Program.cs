using FirebrigadeSim.Point;
using FirebrigadeSim.AreaModel;
using FirebrigadeSim.JRGModel;
using FirebrigadeSim.Context;
using FirebrigadeSim.Strategy;

namespace FirebrigadeSim
{
    public class Program
    {

        static void Main(string[] args)
        {
            Area area = new Area(49.95855025648944, 19.688292482742394, 50.154564013341734, 20.02470275868903);
            JRGCollection collection = new JRGCollection();
            collection.initWithExampleData();

            JRGContext context = new JRGContext(collection);

            JRGObserver observer = new JRGObserver();

            collection.addObserver(observer);

            Random rng = new Random();

            int i = 0;

            int percentage = 40;

            Console.WriteLine("Enter - 1 sekunda do przodu");
            
            while(true)
            {
                Console.WriteLine(i + "sekunda symulacji");
                if(rng.Next(101) > 101 - percentage)
                {
                    if (rng.Next(101) >= 70) context.addStrategy(new PZStrategy(i, collection));
                    else context.addStrategy(new MZStrategy(i, collection));
                }

                context.execute(i);
                context.cleanUp();

                collection.notifyObserver(observer);

                try
                {
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e.ToString());
                }
                i++;
            }
        }
    }
}