namespace SHARP_ACCOUNTING
{
    partial class SaleInvoice2
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
            this.components = new System.ComponentModel.Container();
            this.salesreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AP2DataSet = new SHARP_ACCOUNTING.AP2DataSet();
            this.salesreportTableAdapter = new SHARP_ACCOUNTING.AP2DataSetTableAdapters.salesreportTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new SHARP_ACCOUNTING.CrystalReport1();
            this.lblconame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblto = new System.Windows.Forms.Label();
            this.CrystalReport21 = new SHARP_ACCOUNTING.CrystalReport2();
            this.SalesReportFinal1 = new SHARP_ACCOUNTING.SalesReportFinal();
            ((System.ComponentModel.ISupportInitialize)(this.salesreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AP2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // salesreportBindingSource
            // 
            this.salesreportBindingSource.DataMember = "salesreport";
            this.salesreportBindingSource.DataSource = this.AP2DataSet;
            // 
            // AP2DataSet
            // 
            this.AP2DataSet.DataSetName = "AP2DataSet";
            this.AP2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesreportTableAdapter
            // 
            this.salesreportTableAdapter.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 93);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.SalesReportFinal1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1012, 319);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // lblconame
            // 
            this.lblconame.AutoSize = true;
            this.lblconame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconame.Location = new System.Drawing.Point(405, 9);
            this.lblconame.Name = "lblconame";
            this.lblconame.Size = new System.Drawing.Size(0, 20);
            this.lblconame.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "From :";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfrom.Location = new System.Drawing.Point(85, 48);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(0, 20);
            this.lblfrom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(691, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "To :";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblto.Location = new System.Drawing.Point(766, 59);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(0, 20);
            this.lblto.TabIndex = 2;
            // 
            // SaleInvoice2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 412);
            this.Controls.Add(this.lblto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblfrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblconame);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "SaleInvoice2";
            this.Text = "SaleInvoice2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SaleInvoice2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AP2DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource salesreportBindingSource;
        private AP2DataSet AP2DataSet;
        private AP2DataSetTableAdapters.salesreportTableAdapter salesreportTableAdapter;
        private CrystalReport1 CrystalReport11;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lblconame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblto;
        private CrystalReport2 CrystalReport21;
        private SalesReportFinal SalesReportFinal1;
    }
}