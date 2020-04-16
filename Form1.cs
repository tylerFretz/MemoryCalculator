using System;
using System.Windows.Forms;
using System.Data;

namespace _200433782A2
{
    public partial class Calculator : Form
    {

        private String mainText = "";
        private String addedText = "";

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = "0";
        }



        // Handles key presses
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();

            if (!mainDisplay.Text.Equals("0"))
            {
                mainText = mainDisplay.Text;
            }
            else
            {
                mainText = "";
            }

            if (mainText.Length > 24)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D9 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                addedText = "(";
            }
            else if (e.KeyCode == Keys.D0 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                addedText = ")";
            }
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                if (mainText.Equals("0"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    addedText = "0";
                }
            }
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                addedText = "1";
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                addedText = "2";
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                addedText = "3";
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                addedText = "4";
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                addedText = "5";
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                addedText = "6";
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                addedText = "7";
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                addedText = "8";
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                addedText = "9";
            }
            else if (e.KeyCode == Keys.Decimal|| converter.ConvertToString(e.KeyCode).Equals("."))
            {
                Decimal(e);
            }
            else if (e.KeyCode == Keys.Divide)
            {
                Division(e);
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                Multiplication(e);
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                Subtraction(e);
            }
            else if (e.KeyCode == Keys.Add || converter.ConvertToString(e.KeyCode).Equals("+"))
            {
                Addition(e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Calculate();
                MessageBox.Show("adsfsdf");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                mainText = "0";
            }
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                if (mainText.Length <= 1)
                {
                    mainText = "0";
                }
                else
                {
                    mainText = mainDisplay.Text.Remove(mainText.Length - 1);
                }
            }
            mainText += addedText;
            mainDisplay.Text = mainText;
            addedText = "";
            
        }

        //TODO: fix multiple decimals if brackets
        private void Decimal(KeyEventArgs e)
        {
            if (mainText.Contains("."))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (mainDisplay.Text.StartsWith("0"))
                {
                    mainText = "0.";
                }
                else
                {
                    addedText = ".";
                }
            }
        }

        private void Addition(KeyEventArgs e)
        {
            if (mainText.EndsWith("+"))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (mainText.Equals("0"))
                {
                    addedText = "0+";
                }
                else
                {
                    addedText = "+";
                }
            }
        }

        private void Subtraction(KeyEventArgs e)
        {
            if (mainText.EndsWith("-"))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (mainText.Equals("0"))
                {
                    addedText = "0-";
                }
                else
                {
                    addedText = "-";
                }
            }
        }

        private void Multiplication(KeyEventArgs e)
        {
            if (mainText.EndsWith("*"))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (mainText.Equals("0"))
                {
                    addedText = "0*";
                }
                else
                {
                    addedText = "*";
                }
            }
        }

        private void Division(KeyEventArgs e)
        {
            if (mainText.EndsWith("/"))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (mainText.Equals("0"))
                {
                    addedText = "0/";
                }
                else
                {
                    addedText = "/";
                }
            }
        }

        private void Sqrt()
        {
            Double.TryParse(mainText, out double currentValue);
            Double newValue = Math.Sqrt(currentValue);
            mainDisplay.Text = newValue.ToString();
        }

        private void Reciprocal()
        {
            Double.TryParse(mainText, out double currentValue);
            Double newValue = 1 / currentValue;
            mainDisplay.Text = newValue.ToString();
        }

        private void PlusNeg()
        {
            Double.TryParse(mainText, out double currentValue);
            Double newValue = currentValue - (currentValue * 2);
            mainDisplay.Text = newValue.ToString();
        }

        private void Bracket()
        {

        }

        private void Calculate()
        {
            DataTable table = new DataTable();
            object newValue = table.Compute(mainText, "");
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
    }
}
