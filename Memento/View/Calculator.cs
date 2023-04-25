
using Calculator.Memento;
using Calculator.RPN;
using System.Globalization;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private string input = "";
        RPN.RPN solver;
        Caretaker caretaker;
        public Calculator()
        {
            InitializeComponent();
            solver = RPN.RPN.GetInstance();
            caretaker = new Caretaker(solver);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            input += "7";
            TextBox.Text = input;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            input += "8";
            TextBox.Text = input;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            input += "9";
            TextBox.Text = input;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            input += "4";
            TextBox.Text = input;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            input += "5";
            TextBox.Text = input;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            input += "6";
            TextBox.Text = input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input += "1";
            TextBox.Text = input;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input += "2";
            TextBox.Text = input;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            input += "3";
            TextBox.Text = input;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            input += "0";
            TextBox.Text = input;
        }


        private void buttonDot_Click(object sender, EventArgs e)
        {
            input += ".";
            TextBox.Text = input;

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            try
            {
                input = input.Remove(input.Length - 1, 1);
                TextBox.Text = input;
            }catch(Exception ex)
            {
                MessageBox.Show("Brak danych do wyczyszczenia\n" + ex.ToString());
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            input = "";
            TextBox.Text = input;   
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            input += " sin ";
            TextBox.Text = input;
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            input += " cos ";
            TextBox.Text = input;
        }

        private void buttonDive_Click(object sender, EventArgs e)
        {
            input += " / ";
            TextBox.Text = input;
        }

        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            input += " * ";
            TextBox.Text = input;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            input += " - ";
            TextBox.Text = input;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            input += " + ";
            TextBox.Text = input;
        }

        private void buttonRightBracket_Click(object sender, EventArgs e)
        {
            input += " ) ";
            TextBox.Text = input;
        }

        private void buttonLeftBracket_Click(object sender, EventArgs e)
        {
            input += " ( ";
            TextBox.Text = input;
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            input += ",";
            TextBox.Text = input;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            input = input.Replace(",","");
            solver.setInput(input);
            caretaker.Backup();
            solver.solve();
            input = solver.State;
            input = this.outputFormat();
            TextBox.Text= input;
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            caretaker.Undo();
            TextBox.Text = solver.State;
        }

        private string outputFormat()
        {
            double temp = double.Parse(input);
            
            return temp.ToString("n", CultureInfo.GetCultureInfo("en-US"));
        }
    }
}