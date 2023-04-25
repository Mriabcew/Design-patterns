using Calculator.Memento;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN
{
    public class RPN
    {
        //infix -> input
        private static RPN _instance;
        private string input;
        private string[] functions = { "sin", "cos" };
        private string[] operators = { "+", "-", "*", "/" };
        Queue<string> kolejka = new Queue<string>();
        private string _state;
       
        private RPN() {
            input = "";
            _state = "";
            
        }

        

        public static RPN GetInstance()
        {
            if(_instance == null)
            {
                _instance = new RPN();
            }
            return _instance;
        }

        public string State { get => _state;}
       

        public void solve()
        {
            this.ShutingYard();
            this.Evaluate();
        }

        public void setInput(string input)
        { this.input = input; }

        private int Precedence(string token)
        {
            return token switch
            {                
                "sin" => 4,
                "cos" => 4,
                "*" => 3,
                "/" => 3,
                "+" => 2,
                "-" => 2,
                _ => 0
            };
        }

        private double Evaluate(double v1,double v2,string token) 
        {
            return token switch
            {
                "+" => v1 + v2,
                "-" => v1 - v2,
                "*" => v1 * v2,
                "/" => v1 / v2,
                _ => 0
            };
        }

        private double Evaluate(double value, string token)
        {
            return token switch
            {
                "sin" => Math.Sin(value),
                "cos" => Math.Cos(value),
                _ => 0
            };
        }

        private string Associativity(string token)
        {
            return token == "^" ? "Right" : "Left";
        }

        private bool IsLeftAssociated(string token)
        {
            return Associativity(token) == "Left";
        }

        private bool IsRightAssociated(string token)
        {
            return Associativity(token) == "Right";
        }

        private bool IsGreaterPrecedence(string token1, string token2)
        {
            return Precedence(token1) >= Precedence(token2);
        }

        private bool isNumber(string s)
        {
            return double.TryParse(s, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out double result);
        }

        private bool isFunction(string s)
        {
            return functions.Contains(s);
        }

        private bool isOperator(string s)
        {
            return operators.Contains(s);
        }

        private bool isLeftBracket(string s)
        {
            return s == "(";
        }

        private bool isRightBracket(string s)
        {
            return s == ")";
        }

        private void ShutingYard()
        {
           
            string[] temp = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stos = new Stack<string> ();
            

            foreach (string s in temp)
            {
                if (isNumber(s))
                {
                    kolejka.Enqueue(s);
                    continue;
                }

                if (isLeftBracket(s) || isFunction(s))
                {
                    stos.Push(s);
                    continue;
                }

                if (isRightBracket(s))
                {
                    while (!isLeftBracket(stos.Peek()))
                    {
                        kolejka.Enqueue(stos.Pop());
                    }

                    stos.Pop();
                    continue;
                }
                while(stos.Any() && IsGreaterPrecedence(stos.Peek(),s) && IsLeftAssociated(s))
                {
                    kolejka.Enqueue(stos.Pop());
                }

                stos.Push(s);
            }

            while(stos.Count() > 0)
            {
                kolejka.Enqueue(stos.Pop());
            }
        }

        private void Evaluate()
        {
            var stosWynik = new Stack<double>();

            while(kolejka.Any())
            {
                var token = kolejka.Dequeue();
                
                if(isNumber(token))
                {
                    stosWynik.Push(double.Parse(token, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US")));
                    continue;
                }

                if(isOperator(token))
                {
                    var v1 = stosWynik.Pop();
                    var v2 = stosWynik.Pop();
                    var output = Evaluate(v2, v1, token);
                    stosWynik.Push(output);
                    continue;
                }

                if(isFunction(token))
                {
                    var value = stosWynik.Pop();
                    var result = Evaluate(value, token);
                    stosWynik.Push(result);
                }

            }
            _state = stosWynik.Pop().ToString();
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        public void Restore(IMemento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception();
            }

            this._state = memento.getState();
        }
    }
}
