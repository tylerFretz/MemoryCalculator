using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _200433782A2
{
    public partial class MemoryCalculator : _200433782A2.Calculator
    {
        private String memoryValue = "";

        public MemoryCalculator()
        {
            InitializeComponent();
        }

        // Clears the saved value
        private void BtnMC_Click(object sender, EventArgs e)
        {
            memoryValue = "";
            memoryDisplay.Text = "";
        }

        // Displays the saved value
        private void BtnMR_Click(object sender, EventArgs e)
        {
            if (!memoryValue.Equals(""))
            {
                mainDisplay.Text = memoryValue;
            }
        }

        // Saves the value of the current display
        private void BtnMS_Click(object sender, EventArgs e)
        {
            String calculatedString = Calculate();

            if (double.TryParse(calculatedString, out double valueToBeSaved))
            {
                memoryValue = valueToBeSaved.ToString();
                memoryDisplay.Text = "M";
            }
            else
            {
                mainDisplay.Text = syntaxErrorMsg;
            }
        }

        // Adds saved value to current display value
        private void BtnMPlus_Click(object sender, EventArgs e)
        {
            String calculatedString = Calculate();

            if (double.TryParse(memoryValue, out double savedValue) && double.TryParse(calculatedString, out double displayValue))
            {
                double newVal = savedValue + displayValue;
                mainDisplay.Text = newVal.ToString();
            }
        }
    }
}
