using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NEw
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlCommand command; 
        public Form1()
        {
            InitializeComponent();
             string mysqlCon = "server=127.0.0.1; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            string createDatabaseQuery = "CREATE DATABASE Database22";
            MySqlCommand command = new MySqlCommand(createDatabaseQuery, mySqlConnection);
            

            string createTableQuery = "CREATE TABLE mytablee(Name VARCHAR(50), Surname VARCHAR(50), PhoneNo INT, ID INT)";
            MySqlCommand mycommand = new MySqlCommand(createTableQuery, mySqlConnection);
            mySqlConnection.Open();
            command.ExecuteNonQuery();
            mySqlConnection.Close() ;

            string query = "INSERT INTO mytablee (Name, Surname, PhoneNo, ID) VALUES ('Mayur', 'Galani', '987654320', 1)"; ;
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e, connection);
        }

        private void button1_Click(object sender, EventArgs e, SqlConnection MySqlConnnection)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=Accounts; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();

                                

                

                string query = "INSERT INTO mytablee (Name, Surname, PhoneNo, ID) VALUES ('Mayur', 'Galani', '987654320', 1)"; ;
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                MessageBox.Show("Data inserted successfully");

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
