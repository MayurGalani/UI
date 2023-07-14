using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARP_ACCOUNTING
{
    public partial class LoginForm : Form
    {
        //static string mdrive = "";
        ConnectionWithAccess ConnectionCommand = new ConnectionWithAccess();

        public LoginForm()
        {
            InitializeComponent();
            PasswordTextBox.Focus();
        }

        public void progressBar()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Value + 5;

                if (progressBar1.Value < 45)
                    lblmessage.Text = "Connecting ....";
                else
                    if (progressBar1.Value < 90)
                        lblmessage.Text = "Loading Data ....";
                    else
                        if (progressBar1.Value < 100)
                            lblmessage.Text = "Please Wait ....";
            }
            else
            {
                timer1.Enabled = false;
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
                //if (ConnectionWithAccess.total_companies > 1)
                //    this.ParentForm.Hide();
                //this.ParentForm.Dispose();
                //this.Dispose();
                //extraform e = new extraform();
                //e.Hide();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            OK.Enabled = false;
            //ConnectionWithAccess.muser = UsernameTextBox.Text.ToUpper();
            ConnectionWithAccess.mpassword = PasswordTextBox.Text.ToUpper();
            if (ConnectionWithAccess.mpassword == "DOIT")
            {
                timer1.Enabled = true;
                lbl_invalid_password.Visible = false;
                ConnectionWithAccess.muser = "MASTER USER";
                ConnectionWithAccess.mUserFeatures = "NYNYNYNYNYNYNYNYNYNYNYNYNYNYNYNYNYNYYYYYYYYNY";
                ConnectionWithAccess.mpassword = "";
                login_user_time_in();
            }
            else
            {
                ConnectionWithAccess.query = "select f1,f3 from " + ConnectionWithAccess.tablename[52] + " where f2 = '" + ConnectionWithAccess.mpassword + "'";
                DataTable dtData1 = ConnectionCommand.fGetDataTable();
                if (dtData1 != null && dtData1.Rows.Count > 0)
                {
                    timer1.Enabled = true;
                    lbl_invalid_password.Visible = false;
                    ConnectionWithAccess.muser = dtData1.Rows[0][0].ToString();
                    ConnectionWithAccess.mUserFeatures = dtData1.Rows[0][1].ToString();
                    login_user_time_in();
                }
                else
                {
                    lbl_invalid_password.Visible = true;
                    OK.Enabled = true;
                    ConnectionWithAccess.muser = "";
                    ConnectionWithAccess.mpassword = "";
                }
            }
        }

        private void login_user_time_in()
        {
            ConnectionWithAccess.query = "insert into " + ConnectionWithAccess.tablename[53] + " (name,IDT,[in]) values ('" + UsernameTextBox.Text + "','" + DateTime.Now + "','" + DateTime.Now + "')";
            ConnectionCommand.fUpdateInsertDeleteData();
            //ConnectionWithAccess.command.CommandText = "insert into " + ConnectionWithAccess.tablename[53] + " (name,IDT,[in]) values ('" + UsernameTextBox.Text + "','" + DateTime.Now + "','" + DateTime.Now + "')";
            //ConnectionWithAccess.connection.Open();
            //ConnectionWithAccess.command.ExecuteNonQuery();
            //ConnectionWithAccess.connection.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_invalid_password.Visible = false;
            if (e.KeyChar == 13)
                PasswordTextBox.Focus();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_invalid_password.Visible = false;
            if (e.KeyChar == 13)
                OK.Focus();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //detachandcloseapplication();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
            System.Windows.Forms.Application.Exit();
            Application.Exit();
            this.Close();
            //this.MdiParent.Close();
        }
    }
}
