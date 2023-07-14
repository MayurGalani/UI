namespace SHARP_ACCOUNTING
{
    partial class Previousitems
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
            this.Label1 = new System.Windows.Forms.Label();
            this.PreviousItemDG = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousItemDG)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("cour Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(212, 32);
            this.Label1.TabIndex = 88;
            this.Label1.Text = "Previous Stock";
            // 
            // PreviousItemDG
            // 
            this.PreviousItemDG.AllowUserToAddRows = false;
            this.PreviousItemDG.AllowUserToDeleteRows = false;
            this.PreviousItemDG.AllowUserToOrderColumns = true;
            this.PreviousItemDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.PreviousItemDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviousItemDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5});
            this.PreviousItemDG.Location = new System.Drawing.Point(12, 50);
            this.PreviousItemDG.Name = "PreviousItemDG";
            this.PreviousItemDG.Size = new System.Drawing.Size(490, 343);
            this.PreviousItemDG.TabIndex = 86;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Item_Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Quantity";
            this.Column5.Name = "Column5";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(302, 12);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(200, 32);
            this.Button1.TabIndex = 87;
            this.Button1.Text = "Save Item Quantity";
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // Previousitems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 412);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PreviousItemDG);
            this.Controls.Add(this.Button1);
            this.Name = "Previousitems";
            this.Text = "Previousitems";
            ((System.ComponentModel.ISupportInitialize)(this.PreviousItemDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView PreviousItemDG;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.Button Button1;
    }
}