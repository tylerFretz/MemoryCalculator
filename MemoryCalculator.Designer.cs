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
