namespace SHARP_ACCOUNTING
{
    partial class preview
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
            this.Button1 = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(721, 362);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(93, 23);
            this.Button1.TabIndex = 90;
            this.Button1.Text = "Send Email";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(493, 362);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tbEmail.MaxLength = 255;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(200, 22);
            this.tbEmail.TabIndex = 89;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(406, 365);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 16);
            this.lblEmail.TabIndex = 88;
            this.lblEmail.Text = "E-Mail Add.:";
            // 
            // tbDesc
            // 
            this.tbDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDesc.Location = new System.Drawing.Point(182, 362);
            this.tbDesc.Margin = new System.Windows.Forms.Padding(2);
            this.tbDesc.MaxLength = 34;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(200, 22);
            this.tbDesc.TabIndex = 87;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(85, 365);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(92, 16);
            this.lblDesc.TabIndex = 86;
            this.lblDesc.Text = "Accout Name:";
            // 
            // preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 746);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.lblDesc);
            this.Name = "preview";
            this.Text = "preview";
            this.Load += new System.EventHandler(this.preview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox tbEmail;
        internal System.Windows.Forms.Label lblEmail;
        internal System.Windows.Forms.TextBox tbDesc;
        internal System.Windows.Forms.Label lblDesc;
    }
}