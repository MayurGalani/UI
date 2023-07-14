namespace SHARP_ACCOUNTING
{
    partial class QRCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtQRCode = new System.Windows.Forms.TextBox();
            this.btnBarCode = new System.Windows.Forms.Button();
            this.btnQRCode = new System.Windows.Forms.Button();
            this.pbCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bar Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "QR Code";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(70, 309);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(265, 20);
            this.txtBarCode.TabIndex = 2;
            // 
            // txtQRCode
            // 
            this.txtQRCode.Location = new System.Drawing.Point(70, 336);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(265, 20);
            this.txtQRCode.TabIndex = 3;
            // 
            // btnBarCode
            // 
            this.btnBarCode.Location = new System.Drawing.Point(341, 307);
            this.btnBarCode.Name = "btnBarCode";
            this.btnBarCode.Size = new System.Drawing.Size(75, 23);
            this.btnBarCode.TabIndex = 4;
            this.btnBarCode.Text = "Bar Code";
            this.btnBarCode.UseVisualStyleBackColor = true;
            this.btnBarCode.Click += new System.EventHandler(this.btnBarCode_Click);
            // 
            // btnQRCode
            // 
            this.btnQRCode.Location = new System.Drawing.Point(341, 334);
            this.btnQRCode.Name = "btnQRCode";
            this.btnQRCode.Size = new System.Drawing.Size(75, 23);
            this.btnQRCode.TabIndex = 5;
            this.btnQRCode.Text = "QR Code";
            this.btnQRCode.UseVisualStyleBackColor = true;
            this.btnQRCode.Click += new System.EventHandler(this.btnQRCode_Click);
            // 
            // pbCode
            // 
            this.pbCode.BackColor = System.Drawing.SystemColors.Window;
            this.pbCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCode.Location = new System.Drawing.Point(16, 13);
            this.pbCode.Name = "pbCode";
            this.pbCode.Size = new System.Drawing.Size(400, 288);
            this.pbCode.TabIndex = 6;
            this.pbCode.TabStop = false;
            // 
            // QRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 394);
            this.Controls.Add(this.pbCode);
            this.Controls.Add(this.btnQRCode);
            this.Controls.Add(this.btnBarCode);
            this.Controls.Add(this.txtQRCode);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QRCode";
            this.Text = "QRCode";
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Button btnBarCode;
        private System.Windows.Forms.Button btnQRCode;
        private System.Windows.Forms.PictureBox pbCode;
    }
}