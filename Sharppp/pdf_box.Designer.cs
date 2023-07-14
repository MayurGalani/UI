namespace SHARP_ACCOUNTING
{
    partial class pdf_box
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pdf_box));
            this.utilities_pdfviewer = new AxAcroPDFLib.AxAcroPDF();
            this.btn_invoice_pdf_generator = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.utilities_pdfviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // utilities_pdfviewer
            // 
            this.utilities_pdfviewer.Enabled = true;
            this.utilities_pdfviewer.Location = new System.Drawing.Point(40, 80);
            this.utilities_pdfviewer.Name = "utilities_pdfviewer";
            this.utilities_pdfviewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("utilities_pdfviewer.OcxState")));
            this.utilities_pdfviewer.Size = new System.Drawing.Size(1250, 500);
            this.utilities_pdfviewer.TabIndex = 354;
            this.utilities_pdfviewer.Visible = false;
            // 
            // btn_invoice_pdf_generator
            // 
            this.btn_invoice_pdf_generator.Location = new System.Drawing.Point(64, 25);
            this.btn_invoice_pdf_generator.Name = "btn_invoice_pdf_generator";
            this.btn_invoice_pdf_generator.Size = new System.Drawing.Size(134, 44);
            this.btn_invoice_pdf_generator.TabIndex = 355;
            this.btn_invoice_pdf_generator.Text = "Invoice Pdf Generator";
            this.btn_invoice_pdf_generator.UseVisualStyleBackColor = true;
            this.btn_invoice_pdf_generator.Click += new System.EventHandler(this.btn_invoice_pdf_generator_Click);
            // 
            // pdf_box
            // 
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.btn_invoice_pdf_generator);
            this.Controls.Add(this.utilities_pdfviewer);
            this.Name = "pdf_box";
            this.Text = "Invoice Pdf Designer";
            ((System.ComponentModel.ISupportInitialize)(this.utilities_pdfviewer)).EndInit();
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pdf_box));
        //    this.button1 = new System.Windows.Forms.Button();
        //    this.pdf_invoice = new AxAcroPDFLib.AxAcroPDF();
        //    this.textBox1 = new System.Windows.Forms.TextBox();
        //    this.textBox2 = new System.Windows.Forms.TextBox();
        //    this.textBox3 = new System.Windows.Forms.TextBox();
        //    this.textBox4 = new System.Windows.Forms.TextBox();
        //    ((System.ComponentModel.ISupportInitialize)(this.pdf_invoice)).BeginInit();
        //    this.SuspendLayout();
        //    // 
        //    // button1
        //    // 
        //    this.button1.Location = new System.Drawing.Point(12, 12);
        //    this.button1.Name = "button1";
        //    this.button1.Size = new System.Drawing.Size(75, 23);
        //    this.button1.TabIndex = 0;
        //    this.button1.Text = "PDF";
        //    this.button1.UseVisualStyleBackColor = true;
        //    this.button1.Click += new System.EventHandler(this.button1_Click);
        //    // 
        //    // pdf_invoice
        //    // 
        //    this.pdf_invoice.Enabled = true;
        //    this.pdf_invoice.Location = new System.Drawing.Point(12, 41);
        //    this.pdf_invoice.Name = "pdf_invoice";
        //    this.pdf_invoice.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdf_invoice.OcxState")));
        //    this.pdf_invoice.Size = new System.Drawing.Size(995, 444);
        //    this.pdf_invoice.TabIndex = 354;
        //    // 
        //    // textBox1
        //    // 
        //    this.textBox1.Location = new System.Drawing.Point(117, 14);
        //    this.textBox1.Name = "textBox1";
        //    this.textBox1.Size = new System.Drawing.Size(66, 20);
        //    this.textBox1.TabIndex = 355;
        //    this.textBox1.Text = "0";
        //    // 
        //    // textBox2
        //    // 
        //    this.textBox2.Location = new System.Drawing.Point(216, 15);
        //    this.textBox2.Name = "textBox2";
        //    this.textBox2.Size = new System.Drawing.Size(66, 20);
        //    this.textBox2.TabIndex = 356;
        //    this.textBox2.Text = "0";
        //    // 
        //    // textBox3
        //    // 
        //    this.textBox3.Location = new System.Drawing.Point(322, 14);
        //    this.textBox3.Name = "textBox3";
        //    this.textBox3.Size = new System.Drawing.Size(66, 20);
        //    this.textBox3.TabIndex = 357;
        //    this.textBox3.Text = "480";
        //    // 
        //    // textBox4
        //    // 
        //    this.textBox4.Location = new System.Drawing.Point(427, 15);
        //    this.textBox4.Name = "textBox4";
        //    this.textBox4.Size = new System.Drawing.Size(66, 20);
        //    this.textBox4.TabIndex = 358;
        //    this.textBox4.Text = "600";
        //    // 
        //    // pdf_box
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(1055, 497);
        //    this.Controls.Add(this.textBox4);
        //    this.Controls.Add(this.textBox3);
        //    this.Controls.Add(this.textBox2);
        //    this.Controls.Add(this.textBox1);
        //    this.Controls.Add(this.pdf_invoice);
        //    this.Controls.Add(this.button1);
        //    this.Name = "pdf_box";
        //    this.Text = "pdf_box";
        //    ((System.ComponentModel.ISupportInitialize)(this.pdf_invoice)).EndInit();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

        #endregion

        private System.Windows.Forms.Button button1;
        private AxAcroPDFLib.AxAcroPDF pdf_invoice;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}