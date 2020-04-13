using System;
using System.Windows.Forms;

namespace _200433782A2
{
    public partial class Calculator : Form
    {
        private String savedValue = "";

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        // Handles key presses
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            String mainText = mainDisplay.Text;
            String addedText = "";

            if (mainDisplay.Text.Equals("0"))
            {
                mainText = "";
            }

            if (e.KeyCode == Keys.D0)
            {
                addedText += "0";
            }
            else if (e.KeyCode == Keys.D1)
            {
                addedText += "1";
            }
            else if (e.KeyCode == Keys.D2)
            {
                addedText += "2";
            }
            else if (e.KeyCode == Keys.D3)
            {
                addedText += "3";
            }
            else if (e.KeyCode == Keys.D4)
            {
                addedText += "4";
            }
            else if (e.KeyCode == Keys.D5)
            {
                addedText += "5";
            }
            else if (e.KeyCode == Keys.D6)
            {
                addedText += "6";
            }
            else if (e.KeyCode == Keys.D7)
            {
                addedText += "7";
            }
            else if (e.KeyCode == Keys.D8)
            {
                addedText += "8";
            }
            else if (e.KeyCode == Keys.D9)
            {
                addedText += "9";
            }
            else if (e.KeyCode == Keys.D9)
            {
                addedText += "9";
            }
            else if (e.KeyCode == Keys.Decimal)
            {
                addedText += ".";
            }
            else if (e.KeyCode == Keys.Divide)
            {
                
            }
            else if (e.KeyCode == Keys.Multiply)
            {

            }
            else if (e.KeyCode == Keys.Subtract)
            {

            }
            else if (e.KeyCode == Keys.Add)
            {

            }
            else if (e.KeyCode == Keys.Enter)
            {

            }
            else if (e.KeyCode == Keys.Escape)
            {
                mainText = "0";
            }
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (!mainText.Equals("0"))
                {
                    mainText = mainText.Remove(mainText.Length - 1, 1);
                }
            }


            mainDisplay.Text = mainText + addedText;
        }
    }
}
