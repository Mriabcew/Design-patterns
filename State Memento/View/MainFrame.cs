using SimulationV2.PersonModel;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimulationV2
{
    public partial class MainFrame : Form
    {
        int maxX;
        int maxY;
        int startPop;
        bool randomImmune;

        Random random;

        PersonsCollection persons;

        Graphics g;
        int iteration = 0;
        int time = 0;

        public MainFrame(int maxX, int maxY)
        {
            persons = new PersonsCollection();
            random = new Random();
            this.maxX = maxX;
            this.maxY = maxY;
            InitializeComponent();
            init();
        
        }

        public MainFrame(PersonsCollection personsCollection,int startPop, int maxX, int maxY,bool randomImmune)
        {
            this.startPop = startPop;
            this.maxX = maxX;
            this.maxY = maxY;
            this.randomImmune = randomImmune;
            persons = personsCollection;
            random = new Random();
            InitializeComponent();
            this.Size = new Size(maxX + 22, maxY+100);
            init();
        }

        private void init()
        {
            this.Show();
            if (randomImmune)
            {
                for (int i = 0; i < startPop; i++)
                {
                    Person person = null;
                    if (random.Next(10) < 2)
                    {
                         person = new Person(maxX, maxY, new Immune(), random);
                    }
                    else
                        person = new Person(maxX, maxY, new Healty(), random);
                    persons.Add(person);
                }
            }
            else
                for (int i = 0; i < startPop; i++)
                {
                    Person person = new Person(maxX, maxY, new Healty(), random);
                    persons.Add(person);
                }
            timer.Start();
        }



        private void drawPerson(Person person)
        {
            Point point = new Point((int)person.X, (int)person.Y);
            g = CreateGraphics();
            Size size = new Size(5, 5);
            Rectangle rectangle = new Rectangle(point, size);
            Pen pen = new Pen(Color.Blue, 5);
            if (person.State.GetType() == typeof(Healty))
                pen.Color = Color.Green;
            else if (person.State.GetType() == typeof(Infected))
                pen.Color = Color.Red;
            g.DrawEllipse(pen, rectangle);
            g.Dispose();
        }

        private void renderFrame()
        {
            g = CreateGraphics();
            g.Clear(Color.Black);
            foreach (Person person in persons.getPersonsList())
            {
                this.drawPerson(person);
            }
        }

        private void Logic()
        {
            for (int i = 0; i < persons.getPersonsList().Count(); i++)
            {
                for (int j = 0; j < persons.getPersonsList().Count(); j++)
                    persons.getPersonsList()[i].Behaviour(persons.getPersonsList()[j]);
            }
            for (int i = persons.getPersonsList().Count() - 1; i >= 0; i--)
            {
                persons.getPersonsList()[i].move();

                if (persons.getPersonsList()[i].outOfBorder(random))
                {
                    persons.getPersonsList().RemoveAt(i);
                }
            }
            foreach (Person person in persons.getPersonsList())
            {

                if (person.State.GetType() == typeof(Infected))
                    person.InfectionTicks++;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            iteration++;
            this.textBox1.Text = iteration.ToString();
            if (iteration % 25 == 0)
                time++;
            this.textBox2.Text = time.ToString();
            this.Logic();
            if((iteration % random.Next(1,100) == 0))
            {
                this.newCommer();
            }
            this.renderFrame();
        }

        private void newCommer()
        {
            Person newCommer = new Person(maxX, maxY,random,randomImmune);
            persons.getPersonsList().Add(newCommer);
        }

        public void stopTimer()
        {
            this.timer.Stop();
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            persons.getPersonsList().Clear();
        }
    }
}
