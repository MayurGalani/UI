namespace SHARP_ACCOUNTING
{
    partial class Startup
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
            this.Nik = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCompanyNN = new System.Windows.Forms.ListView();
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_create_new_company = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Nik
            // 
            this.Nik.Text = "Nik";
            this.Nik.Width = 120;
            // 
            // lvCompanyNN
            // 
            this.lvCompanyNN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvCompanyNN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nik,
            this.ColumnHeader2,
            this.columnHeader3});
            this.lvCompanyNN.Font = new System.Drawing.Font("Bell MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCompanyNN.FullRowSelect = true;
            this.lvCompanyNN.GridLines = true;
            this.lvCompanyNN.Location = new System.Drawing.Point(292, 14);
            this.lvCompanyNN.Name = "lvCompanyNN";
            this.lvCompanyNN.Size = new System.Drawing.Size(697, 305);
            this.lvCompanyNN.TabIndex = 0;
            this.lvCompanyNN.UseCompatibleStateImageBehavior = false;
            this.lvCompanyNN.View = System.Windows.Forms.View.Details;
            this.lvCompanyNN.Visible = false;
            this.lvCompanyNN.Click += new System.EventHandler(this.lvCompanyNN_Click);
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "                            Company Name";
            this.ColumnHeader2.Width = 510;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Drive";
            // 
            // btn_create_new_company
            // 
            this.btn_create_new_company.Location = new System.Drawing.Point(567, 663);
            this.btn_create_new_company.Name = "btn_create_new_company";
            this.btn_create_new_company.Size = new System.Drawing.Size(194, 37);
            this.btn_create_new_company.TabIndex = 1;
            this.btn_create_new_company.Text = "Create New Company";
            this.btn_create_new_company.UseVisualStyleBackColor = true;
            this.btn_create_new_company.Click += new System.EventHandler(this.btn_create_new_company_Click);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SHARP_ACCOUNTING.Properties.Resources.IMAGE_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.lvCompanyNN);
            this.Controls.Add(this.btn_create_new_company);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Selection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Startup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Startup_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Startup_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ColumnHeader Nik;
        internal System.Windows.Forms.ListView lvCompanyNN;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Button btn_create_new_company;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}