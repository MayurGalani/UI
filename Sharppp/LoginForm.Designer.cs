namespace SHARP_ACCOUNTING
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lbl_invalid_password = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblmessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_invalid_password
            // 
            this.lbl_invalid_password.AutoSize = true;
            this.lbl_invalid_password.BackColor = System.Drawing.Color.MidnightBlue;
            this.lbl_invalid_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invalid_password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_invalid_password.Location = new System.Drawing.Point(63, 209);
            this.lbl_invalid_password.Name = "lbl_invalid_password";
            this.lbl_invalid_password.Size = new System.Drawing.Size(239, 24);
            this.lbl_invalid_password.TabIndex = 23;
            this.lbl_invalid_password.Text = "Invalid Login Credentials";
            this.lbl_invalid_password.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.AutoEllipsis = true;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(316, 132);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(70, 23);
            this.Cancel.TabIndex = 22;
            this.Cancel.Text = "&Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OK
            // 
            this.OK.AutoEllipsis = true;
            this.OK.Location = new System.Drawing.Point(213, 132);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(70, 23);
            this.OK.TabIndex = 21;
            this.OK.Text = "&OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(213, 97);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(173, 20);
            this.PasswordTextBox.TabIndex = 20;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(213, 43);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(173, 20);
            this.UsernameTextBox.TabIndex = 18;
            this.UsernameTextBox.Visible = false;
            this.UsernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextBox_KeyPress);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoEllipsis = true;
            this.PasswordLabel.Location = new System.Drawing.Point(210, 71);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(176, 23);
            this.PasswordLabel.TabIndex = 19;
            this.PasswordLabel.Text = "&Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoEllipsis = true;
            this.UsernameLabel.Location = new System.Drawing.Point(210, 17);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(176, 23);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "&User name";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsernameLabel.Visible = false;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(28, 17);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(165, 149);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 17;
            this.LogoPictureBox.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(69, 179);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 19);
            this.progressBar1.TabIndex = 24;
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.Location = new System.Drawing.Point(193, 209);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(0, 13);
            this.lblmessage.TabIndex = 25;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(414, 239);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_invalid_password);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_invalid_password;
        internal System.Windows.Forms.Button Cancel;
        internal System.Windows.Forms.Button OK;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        internal System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.PictureBox LogoPictureBox;
        public System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.Timer timer1;
    }
}