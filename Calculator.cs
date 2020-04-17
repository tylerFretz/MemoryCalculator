using System;
using System.Windows.Forms;
using System.Data;

namespace _200433782A2
{
    public partial class Calculator : Form
    {

        protected const String defaultState = "0";
        protected const String divideByZeroErrorMsg = "Cannot divide by zero";
        protected const String syntaxErrorMsg = "Syntax error";

        public Calculator()
        {
            InitializeComponent();
        }


        /*
         * --------------------------------------------------------------------------------------------------------------------------
         * Key presses
         * --------------------------------------------------------------------------------------------------------------------------
         */

        protected void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            String addedText = "";
            bool toBeCleared = false;
            KeysConverter converter = new KeysConverter();


            // Clear display so that new display != 0 + addedText
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "";
            }

            // So text does not extend past display length
            if (mainDisplay.Text.Length > 24)
            {
                e.SuppressKeyPress = true;
            }


            //
            // Else-ifs for each valid input
            //

            // Opening bracket
            else if (e.KeyCode == Keys.D9 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                addedText = "(";
            }

            // Closing bracket
            else if (e.KeyCode == Keys.D0 && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                if (!mainDisplay.Text.Equals(defaultState))
                {
                    addedText = ")";
                }
            }

            // 0
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                addedText = "0";
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
                else if (mainDisplay.Text.Equals("")) 
                {           
                  addedText = "0."; 
                }
                else
                {
                    addedText = ".";
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
                    addedText = "/";
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
                    addedText = "*";
                }
            }

            // TODO: put in parenthesis if double negative
            // Subtraction
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                if (mainDisplay.Text.EndsWith("-"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    addedText = "-";
                }
            }

            // Addition
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus && (e.Modifiers == Keys.RShiftKey || e.Modifiers == Keys.Shift))
            {
                if (mainDisplay.Text.EndsWith("+"))
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    addedText = "+";
                }
            }

            // Enter or Equals
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus)
            {
                toBeCleared = true;
                addedText = Calculate();
            }
            
            // Escape
            else if (e.KeyCode == Keys.Escape)
            {
                mainDisplay.Text = defaultState;
            }


            // Backspace   ...no idea why the Enter key is triggering this
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (mainDisplay.Text.Length <= 1)
                {
                    mainDisplay.Text = defaultState;
                    toBeCleared = false;
                }
                else
                {
                    mainDisplay.Text = mainDisplay.Text.Remove(mainDisplay.Text.Length - 1);
                }
            }

            // Don't allow unused key presses
            else
            {
                e.SuppressKeyPress = true;
            }

            // Clear display if preforming calculation 
            if (toBeCleared)
            {
                mainDisplay.Text = "";
            }

            mainDisplay.Text += addedText;
        }


        /*
         * --------------------------------------------------------------------------------------------------------------------------
         * Button clicks
         * --------------------------------------------------------------------------------------------------------------------------
         */



        // Button 0
        protected void Btn0_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "0";
            }
            else
            {
                mainDisplay.Text += "0";
            }
        }

        // Button 1
        protected void Btn1_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "1";
            }
            else
            {
                mainDisplay.Text += "1";
            }
        }

        // Button 2
        protected void Btn2_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "2";
            }
            else
            {
                mainDisplay.Text += "2";
            }
        }

        // Button 3
        protected void Btn3_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "3";
            }
            else
            {
                mainDisplay.Text += "3";
            }
        }

        // Button 4
        protected void Btn4_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "4";
            }
            else
            {
                mainDisplay.Text += "4";
            }
        }

        // Button 5
        protected void Btn5_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "5";
            }
            else
            {
                mainDisplay.Text += "5";
            }
        }

        // Button 6
        protected void Btn6_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "6";
            }
            else
            {
                mainDisplay.Text += "6";
            }
        }

        // Button 7
        protected void Btn7_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState) || mainDisplay.Text.Equals(divideByZeroErrorMsg) || mainDisplay.Text.Equals(syntaxErrorMsg))
            {
                mainDisplay.Text = "7";
            }
            else
            {
                mainDisplay.Text += "7";
            }
        }

        // Button 8
        protected void Btn8_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState))
            {
                mainDisplay.Text = "8";
            }
            else
            {
                mainDisplay.Text += "8";
            }
        }

        // Button 9
        protected void Btn9_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Equals(defaultState))
            {
                mainDisplay.Text = "9";
            }
            else
            {
                mainDisplay.Text += "9";
            }
        }

        // Button reciprocal
        protected void BtnReciprocal_Click(object sender, EventArgs e)
        {
            Reciprocal();
        }

        // Button invert sign
        protected void BtnPlusNeg_Click(object sender, EventArgs e)
        {
            PlusNeg();
        }

        // Button square root
        protected void BtnSqrt_Click(object sender, EventArgs e)
        {
            Sqrt();
        }

        // Button Equals
        protected void BtnEquals_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = Calculate();
        }

        // Button clear
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = defaultState;
        }

        // Button back
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (mainDisplay.Text.Length <= 1)
            {
                mainDisplay.Text = defaultState;
            }
            else
            {
                mainDisplay.Text = mainDisplay.Text.Remove(mainDisplay.Text.Length - 1);
            }
        }

        // Button opening bracket
        protected void BtnLBracket_Click(object sender, EventArgs e)
        {
            mainDisplay.Text += "(";
        }

        // Button closing bracket
        protected void BtnRBracket_Click(object sender, EventArgs e)
        {
            mainDisplay.Text += ")";
        }

        // Button decimal
        protected void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.Contains("."))
            {
                mainDisplay.Text += ".";
            }
        }

        // Button divide
        protected void BtnDivide_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.EndsWith("/"))
            {
                mainDisplay.Text += "/";
            }
        }

        // Button multiply
        protected void BtnMultiply_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.EndsWith("*"))
            {
                mainDisplay.Text += "*";
            }
        }

        // Button subtract
        protected void BtnSubtract_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.EndsWith("-"))
            {
                mainDisplay.Text += "-";
            }
        }

        // Button add
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.EndsWith("+"))
            {
                mainDisplay.Text += "+";
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------
         * Functions
         * --------------------------------------------------------------------------------------------------------------------------
         */
      
        protected void Sqrt()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = Math.Sqrt(currentValue);
            mainDisplay.Text = newValue.ToString();
        }

        protected void Reciprocal()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = 1 / currentValue;
            mainDisplay.Text = newValue.ToString();
        }

        protected void PlusNeg()
        {
            Double.TryParse(mainDisplay.Text, out double currentValue);
            Double newValue = currentValue - (currentValue * 2);
            mainDisplay.Text = newValue.ToString();
        }

        protected Boolean LimitDecimals()
        {
            String[] numbers = mainDisplay.Text.Split();
            return false;
        }


        // Uses DataTable's compute method to parse mainDisplay String and calculate value
        protected String Calculate()
        {
            DataTable table = new DataTable();
            string newDisplay;

            try
            {
                object newValue = table.Compute(mainDisplay.Text, "");

                // 2146435072 is hashcode for infinity symbol
                if (newValue.GetHashCode() == 2146435072)
                {
                    newDisplay = divideByZeroErrorMsg;
                }
                else
                {
                    newDisplay = newValue.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                newDisplay = syntaxErrorMsg;
            }
            catch (DivideByZeroException)
            {
                newDisplay = divideByZeroErrorMsg;
            }

            return newDisplay;
        }
    }
}