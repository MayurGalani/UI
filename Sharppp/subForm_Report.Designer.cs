namespace SHARP_ACCOUNTING
{
    partial class subForm_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subForm_Report));
            this.pdf_viewer1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdf_viewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // pdf_viewer1
            // 
            this.pdf_viewer1.Enabled = true;
            this.pdf_viewer1.Location = new System.Drawing.Point(31, 53);
            this.pdf_viewer1.Name = "pdf_viewer1";
            this.pdf_viewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdf_viewer1.OcxState")));
            this.pdf_viewer1.Size = new System.Drawing.Size(945, 387);
            this.pdf_viewer1.TabIndex = 354;
            // 
            // subForm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 492);
            this.Controls.Add(this.pdf_viewer1);
            this.Name = "subForm_Report";
            this.Text = "subForm_Report";
            this.Load += new System.EventHandler(this.subForm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdf_viewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF pdf_viewer1;
    }
}