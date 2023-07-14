namespace SHARP_ACCOUNTING
{
    partial class export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(export));
            this.lbl_export_email_id = new System.Windows.Forms.Label();
            this.tb_export_email_id = new System.Windows.Forms.TextBox();
            this.export_pdf_viewer = new AxAcroPDFLib.AxAcroPDF();
            this.btn_export_email = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.export_pdf_viewer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_export_email_id
            // 
            this.lbl_export_email_id.AutoSize = true;
            this.lbl_export_email_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_export_email_id.Location = new System.Drawing.Point(39, 36);
            this.lbl_export_email_id.Name = "lbl_export_email_id";
            this.lbl_export_email_id.Size = new System.Drawing.Size(93, 15);
            this.lbl_export_email_id.TabIndex = 0;
            this.lbl_export_email_id.Text = "Export to Email ";
            // 
            // tb_export_email_id
            // 
            this.tb_export_email_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_export_email_id.Location = new System.Drawing.Point(142, 33);
            this.tb_export_email_id.Name = "tb_export_email_id";
            this.tb_export_email_id.Size = new System.Drawing.Size(333, 21);
            this.tb_export_email_id.TabIndex = 1;
            // 
            // export_pdf_viewer
            // 
            this.export_pdf_viewer.Enabled = true;
            this.export_pdf_viewer.Location = new System.Drawing.Point(12, 80);
            this.export_pdf_viewer.Name = "export_pdf_viewer";
            this.export_pdf_viewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("export_pdf_viewer.OcxState")));
            this.export_pdf_viewer.Size = new System.Drawing.Size(1149, 590);
            this.export_pdf_viewer.TabIndex = 353;
            // 
            // btn_export_email
            // 
            this.btn_export_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_email.Location = new System.Drawing.Point(502, 30);
            this.btn_export_email.Name = "btn_export_email";
            this.btn_export_email.Size = new System.Drawing.Size(118, 26);
            this.btn_export_email.TabIndex = 354;
            this.btn_export_email.Text = "Send Email";
            this.btn_export_email.UseVisualStyleBackColor = true;
            this.btn_export_email.Click += new System.EventHandler(this.btn_export_email_Click);
            // 
            // export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.btn_export_email);
            this.Controls.Add(this.export_pdf_viewer);
            this.Controls.Add(this.tb_export_email_id);
            this.Controls.Add(this.lbl_export_email_id);
            this.Location = new System.Drawing.Point(600, 250);
            this.Name = "export";
            this.Text = "export";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.export_pdf_viewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_export_email_id;
        private System.Windows.Forms.TextBox tb_export_email_id;
        private AxAcroPDFLib.AxAcroPDF export_pdf_viewer;
        private System.Windows.Forms.Button btn_export_email;
    }
}