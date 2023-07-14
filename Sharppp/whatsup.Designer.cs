namespace SHARP_ACCOUNTING
{
    partial class whatsup
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
            this.btn_send_whatsup_message = new System.Windows.Forms.Button();
            this.lbl_whatsup_msg_to = new System.Windows.Forms.Label();
            this.tb_whatsup_msg_to = new System.Windows.Forms.TextBox();
            this.tb_whatsup_msg_content = new System.Windows.Forms.TextBox();
            this.lbl_whatsup_msg_content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_send_whatsup_message
            // 
            this.btn_send_whatsup_message.Location = new System.Drawing.Point(63, 54);
            this.btn_send_whatsup_message.Name = "btn_send_whatsup_message";
            this.btn_send_whatsup_message.Size = new System.Drawing.Size(258, 95);
            this.btn_send_whatsup_message.TabIndex = 0;
            this.btn_send_whatsup_message.Text = "Send Message";
            this.btn_send_whatsup_message.UseVisualStyleBackColor = true;
            this.btn_send_whatsup_message.Click += new System.EventHandler(this.btn_send_whatsup_message_Click);
            // 
            // lbl_whatsup_msg_to
            // 
            this.lbl_whatsup_msg_to.AutoSize = true;
            this.lbl_whatsup_msg_to.Location = new System.Drawing.Point(359, 95);
            this.lbl_whatsup_msg_to.Name = "lbl_whatsup_msg_to";
            this.lbl_whatsup_msg_to.Size = new System.Drawing.Size(94, 13);
            this.lbl_whatsup_msg_to.TabIndex = 1;
            this.lbl_whatsup_msg_to.Text = "Send Message To";
            // 
            // tb_whatsup_msg_to
            // 
            this.tb_whatsup_msg_to.Location = new System.Drawing.Point(482, 92);
            this.tb_whatsup_msg_to.Name = "tb_whatsup_msg_to";
            this.tb_whatsup_msg_to.Size = new System.Drawing.Size(166, 20);
            this.tb_whatsup_msg_to.TabIndex = 2;
            // 
            // tb_whatsup_msg_content
            // 
            this.tb_whatsup_msg_content.Location = new System.Drawing.Point(482, 133);
            this.tb_whatsup_msg_content.Name = "tb_whatsup_msg_content";
            this.tb_whatsup_msg_content.Size = new System.Drawing.Size(166, 20);
            this.tb_whatsup_msg_content.TabIndex = 4;
            // 
            // lbl_whatsup_msg_content
            // 
            this.lbl_whatsup_msg_content.AutoSize = true;
            this.lbl_whatsup_msg_content.Location = new System.Drawing.Point(359, 136);
            this.lbl_whatsup_msg_content.Name = "lbl_whatsup_msg_content";
            this.lbl_whatsup_msg_content.Size = new System.Drawing.Size(94, 13);
            this.lbl_whatsup_msg_content.TabIndex = 3;
            this.lbl_whatsup_msg_content.Text = "Send Message To";
            // 
            // whatsup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 511);
            this.Controls.Add(this.tb_whatsup_msg_content);
            this.Controls.Add(this.lbl_whatsup_msg_content);
            this.Controls.Add(this.tb_whatsup_msg_to);
            this.Controls.Add(this.lbl_whatsup_msg_to);
            this.Controls.Add(this.btn_send_whatsup_message);
            this.Name = "whatsup";
            this.Text = "whatsup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send_whatsup_message;
        private System.Windows.Forms.Label lbl_whatsup_msg_to;
        private System.Windows.Forms.TextBox tb_whatsup_msg_to;
        private System.Windows.Forms.TextBox tb_whatsup_msg_content;
        private System.Windows.Forms.Label lbl_whatsup_msg_content;
    }
}