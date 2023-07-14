namespace SHARP_ACCOUNTING
{
    partial class AccessKey
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMsg.Location = new System.Drawing.Point(4, 69);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(175, 17);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "No Internet Connection";
            this.lblMsg.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(282, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Location = new System.Drawing.Point(162, 23);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(100, 20);
            this.txtAccessKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Access Key:";
            // 
            // AccessKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(467, 161);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtAccessKey);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "AccessKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccessKey";
            this.Load += new System.EventHandler(this.AccessKey_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccessKey_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label label1;
    }
}