using FirebrigadeSim.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrigadeSim.JRGModel
{
    public class JRGCollection
    {


        private ArrayList collection;

        private JRGCollectionIterator iterator;

        private ArrayList observers;

        public JRGCollection()
        {
            collection= new ArrayList();
            iterator = new JRGCollectionIterator(collection);
            observers= new ArrayList();
        }

        public void addObserver(JRGObserver observer)
        {
            this.observers.Add(observer);
        }

        public void removeObserver(JRGObserver observer)
        {
            this.observers.Remove(observer);
        }
        public void notifyObserver(JRGObserver observer)
        {
            foreach (JRGObserver o in this.observers)
            {
                if (observer.Equals(o))
                {
                    o.update(collection);
                }
            }
        }
        public void notifyAllObservers()
        {
            foreach (JRGObserver observer in observers)
            {
                observer.update(collection);
            }
        }

        public void initWithExampleData()
        {
            this.collection.Add(new JRG(new Point2D(50.06169301271226, 19.942911981595177), "JRG-1"));
            this.collection.Add(new JRG(new Point2D(50.03623002406624, 19.93604552707475), "JRG-2"));
            this.collection.Add(new JRG(new Point2D(50.077868726327374, 19.88834986248958), "JRG-3"));
            this.collection.Add(new JRG(new Point2D(50.04041966920447, 20.00659834727217), "JRG-4"));
            this.collection.Add(new JRG(new Point2D(50.09463154171579, 19.920252681677756), "JRG-5"));
            this.collection.Add(new JRG(new Point2D(50.01887450391904, 20.0154993329485), "JRG-6"));
            this.collection.Add(new JRG(new Point2D(50.097033254021554, 19.977098787166128), "JRG-7"));
            this.collection.Add(new JRG(new Point2D(50.079675317880316, 20.03276520388141), "JRG Szkoly Aspirantow PSP"));
            this.collection.Add(new JRG(new Point2D(49.96851229628329, 19.79945199826149), "JRG Skawina"));
            this.collection.Add(new JRG(new Point2D(50.073550936041904, 19.785869714172794), "LSP Balice"));
        }

        public string findClosestAvailableJRG(Point2D alarmLocation)
        {
            double distance = -1;
            string closest = "";
            double temp;

            foreach(JRG jrg in this.collection)
            {
                if(distance == -1 && jrg.hasAvailableCars())
                {
                    distance = Point2D.distance(alarmLocation, jrg.Location);
                    closest = jrg.Name;
                    continue;
                }

                temp = Point2D.distance(alarmLocation, jrg.Location);
                if(temp<distance && jrg.hasAvailableCars())
                {
                    distance = temp;
                    closest = jrg.Name;
                }
            }
            return closest;
        }

        public JRG getJRGByName(string name) 
        { foreach(JRG jrg in this.collection) 
            {
                if(jrg.Name.Equals(name))
                    return jrg; 
            }
            return null; 
        }

        public override string ToString()
        {
            string s="";
            foreach (JRG jrg in collection)
            {
                s+=jrg.ToString() + "\n";
            }
            return s;
        }

    }
}
