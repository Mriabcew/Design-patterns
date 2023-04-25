using Lab6.Flyweight;
using Lab6.PersonModel;
using Lab6.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.View
{
    public class ConsoleView
    {
        private NameFactory nameFactory;
        private PersonCollection personCollection;

        public ConsoleView()
        {
            nameFactory = NameFactory.getInstance();
            this.personCollection = new PersonCollection();
        }

        public void print()
        {
            int input=0;
            this.menu();
            while (input != 3)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }catch(FormatException e)
                {
                    Console.WriteLine("Podano błędne dane " + e.ToString());
                }
                switch (input)
                {
                    case 1:
                        this.newPerson();
                        this.menu();
                        break;
                    case 2:
                        personCollection._PersonCollection.Clear();
                        personCollection.getListFromFile();
                        this.printData();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Podano nieprawidłową liczbę");
                        this.menu();
                        break;
                }
            }
        }


        private void newPerson()
        {
            try
            {
                PersonDataProxy proxy = new PersonDataProxy();
                Console.WriteLine("Podaj imie zatrzymanego");
           
                string inputName = Console.ReadLine();
                string name = proxy.capitalise(inputName);

                Console.WriteLine("Podaj nazwisko zatrzymanego");
                string inputSurname = Console.ReadLine();
                string surname = proxy.capitalise(inputSurname);

           
                Console.WriteLine("Podaj szerokosc geograficzna");
                Console.WriteLine("Stopnie: ");
                int latituedDegrees = int.Parse(Console.ReadLine());
                Console.WriteLine("Minuty: ");
                double latitudeMinutes = double.Parse(Console.ReadLine());
                Console.WriteLine("Sekundy: ");
                double latitudeSecends = double.Parse(Console.ReadLine());
                Console.WriteLine("Kierunek N lub S");
                string latitudeDirection = (Console.ReadLine());
                Console.WriteLine("Podaj Długość geograficzna");
                Console.WriteLine("Stopnie: ");
                int longitudeDegress = int.Parse(Console.ReadLine());
                Console.WriteLine("Minuty: ");
                double longitudeMinutes = double.Parse(Console.ReadLine());
                Console.WriteLine("Sekundy: ");
                double longitudeSecends = double.Parse(Console.ReadLine());
                Console.WriteLine("Kierunek W lub E");
                string longitudeDirection = (Console.ReadLine());
                Person person = new Person(name, surname, latituedDegrees, latitudeMinutes, latitudeSecends, latitudeDirection, longitudeDegress, longitudeMinutes, longitudeSecends, longitudeDirection);
                this.saveToFile(person);
            }
            catch(Exception e)
            {
                Console.WriteLine("Blad podanych danych " + e.ToString());
            }
        }

        private void menu()
        {
            Console.WriteLine("------------MENU--------------");
            Console.WriteLine("1.Dodaj osobę zatrzymaną");
            Console.WriteLine("2.Wyswietl listę osób zatrzymanych");
            Console.WriteLine("3.Wyjdz");
        }

        private void printData()
        {
            
            if(personCollection._PersonCollection.Count() == 0)
            {
                Console.WriteLine("Lista pusta");
                return;
            }
            else
                foreach(Person person in personCollection._PersonCollection)
                {
                    Console.WriteLine(person.ToString());
                }   
        }

        private void saveToFile(Person person)
        {
            Console.WriteLine("Zapis");
            try
            {
                StreamWriter sw = new StreamWriter("data.dat",true);
                string line = person.Print();
                sw.WriteLine(line);
                sw.Close();
            }catch(Exception e)
            {
                Console.WriteLine("Blad zapisu " + e.ToString());
            }

        }
    }
}
