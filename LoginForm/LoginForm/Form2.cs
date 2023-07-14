using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CreateAccountForm : Form
    {
        MySqlConnection MySqlConnection = new MySqlConnection("datasource = 127.0.0.1; username = root; password =  ");
       
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassWord.Text != txtCPassWord.Text)
            {
                MessageBox.Show("Password doesn't match!", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtFName.Text) || string.IsNullOrEmpty(txtLName.Text) || string.IsNullOrEmpty(cboGender.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtPassWord.Text) || string.IsNullOrEmpty(txtCPassWord.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            else
            {
                MySqlConnection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Username = '" + txtFName.Text + "'", MySqlConnection),
                cmd2 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Email = @UserEmail", MySqlConnection);

                cmd1.Parameters.AddWithValue("@UserName", txtusername.Text);
                cmd2.Parameters.AddWithValue("@UserEmail", txtEmail.Text);

                bool userExists = false, mailExists = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email not available!");


                if (!(userExists || mailExists))
                {

                    string iquery = "INSERT INTO loginform.userinfo(`FirstName`,`LastName`,`Gender`,`Email`,`Username`, `Password`) VALUES ('" + txtFName.Text + "', '" + txtLName.Text + "', '" + cboGender.Text + "', '" + txtEmail.Text + "', '" + txtusername.Text + "', '" + txtPassWord.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, MySqlConnection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Account Successfully Created!");

                }

                MySqlConnection.Close();
            }


        }

        private void btnBacktoLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
        }
    }
}
