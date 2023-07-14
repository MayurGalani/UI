namespace SHARP_ACCOUNTING
{
    partial class Previous_Balance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.tbdebtot = new System.Windows.Forms.TextBox();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcretot = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousBalDG = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousBalDG)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 398);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(125, 13);
            this.Label2.TabIndex = 92;
            this.Label2.Text = "Opening Stock @ Period";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("cour Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(2, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(134, 32);
            this.Label1.TabIndex = 91;
            this.Label1.Text = "@ Period";
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(180, 7);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(133, 32);
            this.Button2.TabIndex = 90;
            this.Button2.Text = "Check Total";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Visible = false;
            // 
            // tbdebtot
            // 
            this.tbdebtot.Location = new System.Drawing.Point(575, 395);
            this.tbdebtot.Name = "tbdebtot";
            this.tbdebtot.ReadOnly = true;
            this.tbdebtot.Size = new System.Drawing.Size(82, 20);
            this.tbdebtot.TabIndex = 89;
            this.tbdebtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Credit";
            this.Column5.Name = "Column5";
            // 
            // tbcretot
            // 
            this.tbcretot.Location = new System.Drawing.Point(672, 395);
            this.tbcretot.Name = "tbcretot";
            this.tbcretot.ReadOnly = true;
            this.tbcretot.Size = new System.Drawing.Size(82, 20);
            this.tbcretot.TabIndex = 88;
            this.tbcretot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(562, 7);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(195, 32);
            this.Button1.TabIndex = 86;
            this.Button1.Text = "Save Balances";
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // Column6
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.HeaderText = "Debit";
            this.Column6.Name = "Column6";
            // 
            // PreviousBalDG
            // 
            this.PreviousBalDG.AllowUserToAddRows = false;
            this.PreviousBalDG.AllowUserToDeleteRows = false;
            this.PreviousBalDG.AllowUserToOrderColumns = true;
            this.PreviousBalDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.PreviousBalDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviousBalDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column6,
            this.Column5});
            this.PreviousBalDG.Location = new System.Drawing.Point(2, 45);
            this.PreviousBalDG.Name = "PreviousBalDG";
            this.PreviousBalDG.Size = new System.Drawing.Size(755, 343);
            this.PreviousBalDG.TabIndex = 87;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sub_Acc";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Acc_Desc";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Parent_Acc";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(145, 395);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(122, 20);
            this.TextBox1.TabIndex = 93;
            this.TextBox1.Text = "0";
            // 
            // Previous_Balance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 433);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.tbdebtot);
            this.Controls.Add(this.tbcretot);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.PreviousBalDG);
            this.Controls.Add(this.TextBox1);
            this.Name = "Previous_Balance";
            this.Text = "Previous_Balance";
            ((System.ComponentModel.ISupportInitialize)(this.PreviousBalDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TextBox tbdebtot;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.TextBox tbcretot;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridView PreviousBalDG;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.TextBox TextBox1;
    }
}