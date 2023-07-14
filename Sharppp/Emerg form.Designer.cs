namespace SHARP_ACCOUNTING
{
    partial class Emerg_form
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
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(77, 60);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(399, 23);
            this.ProgressBar1.TabIndex = 1;
            // 
            // Emerg_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 145);
            this.Controls.Add(this.ProgressBar1);
            this.Name = "Emerg_form";
            this.Text = "Emerg_form";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar ProgressBar1;
    }
}