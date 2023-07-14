namespace SHARP_ACCOUNTING
{
    partial class waitloading
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
            this.tbwaitloading = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbwaitloading
            // 
            this.tbwaitloading.Font = new System.Drawing.Font("cour Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbwaitloading.Location = new System.Drawing.Point(61, 112);
            this.tbwaitloading.Name = "tbwaitloading";
            this.tbwaitloading.Size = new System.Drawing.Size(169, 30);
            this.tbwaitloading.TabIndex = 0;
            this.tbwaitloading.Text = "Wait Loading Data";
            // 
            // waitloading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.tbwaitloading);
            this.Name = "waitloading";
            this.Text = "waitloading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbwaitloading;
    }
}