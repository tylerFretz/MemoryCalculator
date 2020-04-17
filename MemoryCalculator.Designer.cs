namespace _200433782A2
{
    partial class MemoryCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            // 
            // btnMC
            // 
            this.btnMC.Click += new System.EventHandler(this.BtnMC_Click);
            // 
            // btnMR
            // 
            this.btnMR.Click += new System.EventHandler(this.BtnMR_Click);
            // 
            // btnMS
            // 
            this.btnMS.Click += new System.EventHandler(this.BtnMS_Click);
            // 
            // btnMPlus
            // 
            this.btnMPlus.Click += new System.EventHandler(this.BtnMPlus_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(255, 100);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Location = new System.Drawing.Point(255, 152);
            // 
            // btnAdd
            // 
            this.btnAdd.Size = new System.Drawing.Size(43, 48);
            // 
            // btnSqrt
            // 
            this.btnSqrt.Location = new System.Drawing.Point(210, 100);
            // 
            // btnReciprocal
            // 
            this.btnReciprocal.Location = new System.Drawing.Point(210, 151);
            // 
            // btnLBracket
            // 
            this.btnLBracket.ForeColor = System.Drawing.Color.SteelBlue;
            // 
            // btnRBracket
            // 
            this.btnRBracket.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnRBracket.Location = new System.Drawing.Point(255, 52);
            // 
            // MemoryCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(310, 308);
            this.Name = "MemoryCalculator";
            this.Text = "Memory Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
