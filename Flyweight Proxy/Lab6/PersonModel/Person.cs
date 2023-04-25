using Lab6.Flyweight;
using Lab6.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.PersonModel
{
    public class Person
    {
        //dane wewnętrzne
        private string name;


        //dane zewnętrzne
        private string surname;
        private int latitudeDegress;
        private double latitudeMinutes;
        private double latitudeSecends;
        private string latitudeDirection;
        private int longitudeDegress;
        private double longitudeMinutes;
        private double longitudeSecends;
        private string longitudeDirection;


        public Person(string name, string surname, int latitudeDegress, double latitudeMinutes, double latitudeSecends, string latitudeDirection, int longitudeDegress, double longitudeMinutes, double longitudeSecends, string longitudeDirection)
        {
            IPersonData dataProxy = new PersonDataProxy();
            NameFactory nameFactory = NameFactory.getInstance();
            this.name = nameFactory.getName(dataProxy.capitalise(name)).getName();
            this.surname = dataProxy.capitalise(surname);
            this.latitudeDegress = latitudeDegress;
            this.latitudeMinutes = latitudeMinutes;
            this.latitudeSecends = latitudeSecends;
            this.latitudeDirection = latitudeDirection;
            this.longitudeDegress = longitudeDegress;
            this.longitudeMinutes = longitudeMinutes;
            this.longitudeSecends = longitudeSecends;
            this.longitudeDirection = longitudeDirection;
        }

        public override string ToString()
        {
            return name + " " + surname + " latitude: " + latitudeDegress + "o " + latitudeMinutes + "' " + latitudeSecends + "\"" + latitudeDirection + " longitude: " + longitudeDegress + "o " + longitudeMinutes + "' " + longitudeSecends + "\"" + longitudeDirection;
        }

        public string Print()
        {
            return name + ";" + surname + ";" + latitudeDegress + ";" + latitudeMinutes + ";" + latitudeSecends + ";" + latitudeDirection + ";" + longitudeDegress + ";" + longitudeMinutes + ";" + longitudeSecends + ";" + longitudeDirection;
        }

    }
}
