namespace SHARP_ACCOUNTING
{
    partial class backup
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
            this.btn_perform_backup = new System.Windows.Forms.Button();
            this.comdrive = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_backup_full_data = new System.Windows.Forms.CheckBox();
            this.tb_company_backup_emailid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_send_backup_email = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_data_drive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_perform_backup
            // 
            this.btn_perform_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_perform_backup.Location = new System.Drawing.Point(26, 173);
            this.btn_perform_backup.Margin = new System.Windows.Forms.Padding(5);
            this.btn_perform_backup.Name = "btn_perform_backup";
            this.btn_perform_backup.Size = new System.Drawing.Size(520, 79);
            this.btn_perform_backup.TabIndex = 7;
            this.btn_perform_backup.Text = "Perform Back Up";
            this.btn_perform_backup.UseVisualStyleBackColor = true;
            this.btn_perform_backup.Click += new System.EventHandler(this.btn_perform_backup_Click);
            // 
            // comdrive
            // 
            this.comdrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comdrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comdrive.FormattingEnabled = true;
            this.comdrive.Location = new System.Drawing.Point(208, 103);
            this.comdrive.Margin = new System.Windows.Forms.Padding(5);
            this.comdrive.Name = "comdrive";
            this.comdrive.Size = new System.Drawing.Size(102, 28);
            this.comdrive.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 99;
            this.label1.Text = "Backup Drive";
            // 
            // cb_backup_full_data
            // 
            this.cb_backup_full_data.AutoSize = true;
            this.cb_backup_full_data.Location = new System.Drawing.Point(349, 41);
            this.cb_backup_full_data.Name = "cb_backup_full_data";
            this.cb_backup_full_data.Size = new System.Drawing.Size(166, 24);
            this.cb_backup_full_data.TabIndex = 100;
            this.cb_backup_full_data.Text = "Backup Full Data";
            this.cb_backup_full_data.UseVisualStyleBackColor = true;
            // 
            // tb_company_backup_emailid
            // 
            this.tb_company_backup_emailid.Location = new System.Drawing.Point(121, 274);
            this.tb_company_backup_emailid.Name = "tb_company_backup_emailid";
            this.tb_company_backup_emailid.ReadOnly = true;
            this.tb_company_backup_emailid.Size = new System.Drawing.Size(425, 26);
            this.tb_company_backup_emailid.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 102;
            this.label2.Text = "Email I.d.";
            // 
            // cb_send_backup_email
            // 
            this.cb_send_backup_email.AutoSize = true;
            this.cb_send_backup_email.Location = new System.Drawing.Point(349, 71);
            this.cb_send_backup_email.Name = "cb_send_backup_email";
            this.cb_send_backup_email.Size = new System.Drawing.Size(207, 24);
            this.cb_send_backup_email.TabIndex = 103;
            this.cb_send_backup_email.Text = "Send Backup on email";
            this.cb_send_backup_email.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 104;
            this.label3.Text = "Data Drive";
            // 
            // lbl_data_drive
            // 
            this.lbl_data_drive.AutoSize = true;
            this.lbl_data_drive.Location = new System.Drawing.Point(204, 68);
            this.lbl_data_drive.Name = "lbl_data_drive";
            this.lbl_data_drive.Size = new System.Drawing.Size(14, 20);
            this.lbl_data_drive.TabIndex = 105;
            this.lbl_data_drive.Text = " ";
            // 
            // backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 391);
            this.Controls.Add(this.lbl_data_drive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_send_backup_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_company_backup_emailid);
            this.Controls.Add(this.cb_backup_full_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comdrive);
            this.Controls.Add(this.btn_perform_backup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "backstore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_perform_backup;
        internal System.Windows.Forms.ComboBox comdrive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_backup_full_data;
        private System.Windows.Forms.TextBox tb_company_backup_emailid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_send_backup_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_data_drive;

    }
}