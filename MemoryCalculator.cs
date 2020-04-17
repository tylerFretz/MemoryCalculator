using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _200433782A2
{

    /// <summary>
    ///     Extends base calculator with added ability to store a value in memory 
    /// </summary>
    public partial class MemoryCalculator : _200433782A2.Calculator
    {
        private String memoryValue = "";

        public MemoryCalculator()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Clears the saved value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMC_Click(object sender, EventArgs e)
        {
            memoryValue = "";
            memoryDisplay.Text = "";
        }

        /// <summary>
        ///     Displays the saved value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMR_Click(object sender, EventArgs e)
        {
            if (!memoryValue.Equals(""))
            {
                mainDisplay.Text = memoryValue;
            }
        }

        /// <summary>
        ///     Saves the value of the current display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///     Adds saved value to current display value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
