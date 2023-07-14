namespace SHARP_ACCOUNTING
{
    partial class PleaseWait
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
            this.lblWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.Location = new System.Drawing.Point(84, 38);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(238, 24);
            this.lblWait.TabIndex = 0;
            this.lblWait.Text = "Please Wait Loading Data...";
            // 
            // PleaseWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 107);
            this.Controls.Add(this.lblWait);
            this.Name = "PleaseWait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PleaseWait";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWait;
    }
}