using System;
using System.Windows.Forms;
using System.Data;

namespace _200433782A2
{
    public partial class Calculator : Form
    {


        public Calculator()
        {
            InitializeComponent();
        }


        // Handles key presses
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {

            String addedText = "";

            KeysConverter converter = new KeysConverter();

            // if you want to do a switch based on key string
            String key = converter.ConvertToString(e.KeyCode);

            // 
            if (mainDisplay.Text.Equals("0"))
            {
                mainDisplay.Text = "";
            }


            // So text does not extend past display length
            if (mainDisplay.Text.Length > 24)
            {
                e.SuppressKeyPress = true;
            }

            // Opening bracket
            else if (e.KeyCode == Keys.D9 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                addedText = "(";
            }

            // Closing bracket
            else if (e.KeyCode == Keys.D0 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                addedText = ")";
            }

            // 0
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                if (mainDisplay.Text.Equals("0"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    addedText = "0";
                }
            }

            // 1
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                addedText = "1";
            }

            // 2
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                addedText = "2";
            }

            // 3
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                addedText = "3";
            }

            // 4
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                addedText = "4";
            }

            // 5
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                addedText = "5";
            }

            // 6
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                addedText = "6";
            }

            // 7
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                addedText = "7";
            }

            // 8
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                addedText = "8";
            }

            // 9
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                addedText = "9";
            }

            //TODO: fix multiple decimals
            // Decimal
            else if (e.KeyCode == Keys.Decimal || converter.ConvertToString(e.KeyCode).Equals("."))
            {
                if (mainDisplay.Text.Contains("."))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (mainDisplay.Text.Equals(""))
                    {
                        mainDisplay.Text = "0.";
                    }
                    else
                    {
                        addedText = ".";
                    }
                }
            }

            // Division
            else if (e.KeyCode == Keys.Divide)
            {
                if (mainDisplay.Text.EndsWith("/"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (mainDisplay.Text.Equals(""))
                    {
                        addedText = "0/";
                    }
                    else
                    {
                        addedText = "/";
                    }
                }
            }

            // Multiplication
            else if (e.KeyCode == Keys.Multiply)
            {
                if (mainDisplay.Text.EndsWith("*"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (mainDisplay.Text.Equals(""))
                    {
                        addedText = "0*";
                    }
                    else
                    {
                        addedText = "*";
                    }
                }
            }

            // TODO: put in parenthesis if double negative
            // Subtraction
            else if (e.KeyCode == Keys.Subtract)
            {
                if (mainDisplay.Text.EndsWith("-"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (mainDisplay.Text.Equals(""))
                    {
                        addedText = "0-";
                    }
                    else
                    {
                        addedText = "-";
                    }
                }
            }

            // Addition
            else if (e.KeyCode == Keys.Add || converter.ConvertToString(e.KeyCode).Equals("+") ||
                e.KeyCode == Keys.Oemplus && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                if (mainDisplay.Text.EndsWith("+"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (mainDisplay.Text.Equals(""))
                    {
                        addedText = "0+";
                    }
                    else
                    {
                        addedText = "+";
                    }
                }
            }

            // Enter or Equals
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus)
            {
                Calculate();
            }

            // Escape
            else if (e.KeyCode == Keys.Escape)
            {
                mainDisplay.Text = "0";
            }


            // Backspace
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                if (mainDisplay.Text.Length <= 1)
                {
                    mainDisplay.Text = "0";
                }
                else
                {
                    mainDisplay.Text = mainDisplay.Text.Remove(mainDisplay.Text.Length - 1);
                }
            }

            mainDisplay.Text += addedText;
        }

       


        private void Sqrt()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = Math.Sqrt(currentValue);
            mainDisplay.Text = newValue.ToString();
        }

        private void Reciprocal()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = 1 / currentValue;
            mainDisplay.Text = newValue.ToString();
        }

        private void PlusNeg()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = currentValue - (currentValue * 2);
            mainDisplay.Text = newValue.ToString();
        }


        //TODO: probably should actually do this
        private void Calculate()
        {
            DataTable table = new DataTable();
            object newValue = table.Compute(mainDisplay.Text, "");
            mainDisplay.Text = newValue.ToString();
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            Reciprocal();
        }

        private void btnPlusNeg_Click(object sender, EventArgs e)
        {
            PlusNeg();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            Sqrt();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = "0";
        }
    }
}
