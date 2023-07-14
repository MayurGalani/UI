using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=loginform;Uid=root;Pwd=;";
        MySqlCommand command;
        MySqlDataReader mdr;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnLogin_Click (object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string selectQuery = "SELECT * FROM loginform.userinfo WHERE Username = '" + txtusername.Text + "' AND Password = '" + txtPassWord.Text + "';";

                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    string MyConnection2 = "datasource=127.0.0.1;username=root;password=" ;
                    string Query = "UPDATE loginform.userinfo SET LastLogin='' WHERE Username='" + txtusername.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();

                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Form3 frm3 = new Form3();
                    frm3.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Login Information! Try again.");
                }
                connection.Close();
            }
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccountForm frm3 = new CreateAccountForm();
            frm3.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
