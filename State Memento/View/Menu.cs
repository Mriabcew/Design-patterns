using SimulationV2.MementoModel;
using SimulationV2.PersonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationV2.View
{
    public partial class Menu : Form
    {
        MainFrame mainFrame;
        PersonsCollection personsColletion;
        bool rngImmune = false;
        CareTaker caretaker;
        public Menu()
        {
            personsColletion = new PersonsCollection();
            caretaker = new CareTaker(personsColletion);
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int startPop = int.Parse(textBox1.Text);
            int maxX = int.Parse(textBox2.Text);
            int maxY = int.Parse(textBox3.Text);
            mainFrame = new MainFrame(personsColletion,startPop,maxX,maxY,rngImmune);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            mainFrame.timer.Stop();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            mainFrame.timer.Start();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("tworze pamiatek");
            caretaker.Backup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Przywracam");
            caretaker.Undo();
        }

        private void randomImmune_CheckedChanged(object sender, EventArgs e)
        {
            rngImmune = true;
        }
    }
}
