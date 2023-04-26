using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace _1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.degree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.degree_MouseDown);
            this.degree.MouseLeave += new System.EventHandler(this.degree_MouseLeave);


        }
        Stack expression = new Stack();
        Stack<string> helpExpression = new Stack<string>();
        private void degree_MouseDown(object sender, EventArgs e)
        {
            degree.BackColor = SystemColors.ControlDark;
        }
        private void degree_MouseLeave(object sender, EventArgs e)
        {
            degree.BackColor = SystemColors.Control;
        }
        int priority(string operation)
        {
            switch (operation)
            {
                case "-":
                    return 1;
                    break;
                case "+":
                    return 1;
                    break;
                case "×":
                    return 2;
                    break;
                case "÷":
                    return 2;
                    break;
                case "√":
                    return 3;
                    break;
                case "^":
                    return 3;
                    break;
                case "%":
                    return 3;
                    break;
                case "(":
                    return 0;
                    break;
                case ")":
                    return 4;
                    break;
            }
            return 0;
        }
        int it = 0;
        string chislo = "";
        private void comma_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
            chislo = textBox1.Text;
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "7";
                    oper = false;
                }
                else
                    textBox1.Text += "7";

                chislo = textBox1.Text;
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "8";
                    oper = false;
                }
                else
                    textBox1.Text += "8";
                chislo = textBox1.Text;
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "9";
                    oper = false;
                }
                else
                    textBox1.Text += "9";

                chislo = textBox1.Text;
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "4";
                    oper = false;
                }
                else
                    textBox1.Text += "4";
                chislo = textBox1.Text;
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "5";
                    oper = false;
                }
                else
                    textBox1.Text += "5";
                chislo = textBox1.Text;
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "6";
                    oper = false;
                }
                else
                    textBox1.Text += "6";

                chislo = textBox1.Text;
            }
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "1";
                    oper = false;
                }
                else
                    textBox1.Text += "1";
                chislo = textBox1.Text;
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "2";
                    oper = false;
                }
                else
                    textBox1.Text += "2";

                chislo = textBox1.Text;
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "3";
                    oper = false;
                }
                else
                    textBox1.Text += "3";
                chislo = textBox1.Text;
            }
        }

        private void zero_Click(object sender, EventArgs e)
        {
            if(numberOf == false)
            {
                if (oper == true && !textBox1.Text.EndsWith(","))
                {
                    textBox1.Text = "0";
                    oper = false;
                }
                else
                    textBox1.Text += "0";

                chislo = textBox1.Text;
            }
        }
        bool open = false;
        private void leftBracket_Click(object sender, EventArgs e)
        {
            expression.Push(chislo);
            helpExpression.Push("(");
            textBox1.Text += "(";
            it++;
            open = true;
        }

        private void right_Bracket_Click(object sender, EventArgs e)
        {

            if (open)
            {
                expression.Push(Double.Parse(chislo));
                while (helpExpression.Peek() != "(")
                { expression.Push(helpExpression.Pop()); }
                helpExpression.Pop();
                textBox1.Text += ")";
                it++;
                open = false;
            }
        }
        bool oper = false;
        private void plus_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(chislo) || numberOf)
            {
                if (!string.IsNullOrEmpty(chislo))
                    expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("+"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("+");
                textBox2.Text += textBox1.Text + "+";
                oper = true;
                chislo = "";
            }
        }
        private void minus_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(chislo) || numberOf)
            {
                if (!string.IsNullOrEmpty(chislo))
                    expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("-"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("-");
                textBox2.Text += textBox1.Text + "-";
                numberOf = false;
                oper = true;
                chislo = "";
            }
        }

        private void obliqueCross_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(chislo) || numberOf)
            {
                if (!string.IsNullOrEmpty(chislo))
                    expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("×"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("×");
                textBox2.Text += textBox1.Text + "×";
                numberOf = false;
                oper = true;
                chislo = "";
            }

        }
        
        private void division_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chislo) || numberOf)
            {
                if(!string.IsNullOrEmpty(chislo))
                    expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("÷"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("÷");
                textBox2.Text += textBox1.Text + "÷";
                oper = true;
                numberOf = false;
                chislo = "";
            }

        }
        bool numberOf = false;
        private void percent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chislo) )
            {
                expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("%"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("%");
                textBox2.Text += textBox1.Text + "%";
                //oper = true;
                numberOf = true;
                chislo = "";
            }
        }
        
        private void degree_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chislo) || numberOf)
            {
                if (!string.IsNullOrEmpty(chislo))
                    expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("^"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("^");
                textBox2.Text += textBox1.Text + "^";
                numberOf = false;
                oper = true;
                chislo = "";
            }
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chislo))
            {
                expression.Push(chislo);
                if (helpExpression.Count() != 0)
                {
                    if (priority(helpExpression.Peek()) > priority("√"))
                    {
                        expression.Push(helpExpression.Pop());
                    }
                }
                helpExpression.Push("√");
                textBox2.Text += textBox1.Text + "√";
                numberOf = true;
                chislo = "";
            }
        }
        
        private void equals_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(chislo))
                textBox2.Text += Convert.ToString(Double.Parse(chislo));
            expression.Push(Convert.ToString(Double.Parse(chislo)));
            while (textBox2.Text.Count(f => (f == '(')) != textBox2.Text.Count(f => (f == ')')))
            {
                textBox2.Text += ")";
            }
            textBox1.Text += "=";
            textBox2.Text += "=";

            while (helpExpression.Count() != 0)
            {
                expression.Push(helpExpression.Pop());
            }
            textBox1.Text = "";
            Stack revExpression = new Stack();
            while(expression.Count != 0)
                revExpression.Push(expression.Pop());
            foreach (string i in revExpression)
            {
                textBox1.Text += i.ToString();

            }
                
            
            textBox1.Text += "=" + result(revExpression);
        }
        double result(Stack stack)
        {
            Stack<double> helpStack = new Stack<double>();
            foreach (string c in stack)
            {
                if(double.TryParse(c,out double n))
                    helpStack.Push(Convert.ToDouble(c));
                else if(c == "+")
                {
                    double a = helpStack.Pop();
                    double b = helpStack.Pop();
                    helpStack.Push(a + b);
                }
                else if (c == "-")
                {
                    double a = helpStack.Pop();
                    double b = helpStack.Pop();
                    helpStack.Push(b-a);
                }
                else if (c == "×")
                {
                    double a = helpStack.Pop();
                    double b = helpStack.Pop();
                    helpStack.Push(a * b);
                }
                else if (c == "÷")
                {
                    double a = helpStack.Pop();
                    double b = helpStack.Pop();
                    helpStack.Push(b/a);
                }
                else if (c == "√")
                {
                    double a = helpStack.Pop();
                    helpStack.Push(Math.Sqrt(a));
                }
                else if (c == "%") 
                {
                    double a = helpStack.Pop();
                    helpStack.Push(a/100.0);
                }
                else if (c == "^")
                {
                    double a = helpStack.Pop();
                    double b = helpStack.Pop();
                    helpStack.Push(Math.Pow(b,a));
                }
            }
            return helpStack.Pop();
        }
        private void AC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void BS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            if (!string.IsNullOrEmpty(textBox2.Text))
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            if (oper == true)
            {
                oper = false;
            }
            //else if (textBox1.Text.EndsWith(""))
        }
    }
}
