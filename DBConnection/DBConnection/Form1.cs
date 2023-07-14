
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

namespace DBConnection
{
    public partial class Form1 : Form
    {
       static string connectionString= "server=127.0.0.1; user=root;";
       static MySqlConnection mySqlConnection;

        public Form1() 
        {
            InitializeComponent();
            
             mySqlConnection = new MySqlConnection(connectionString);
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("Connection Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private void CreateDatabaseAndTable()
        {

                mySqlConnection.Open();
               
                string createDatabaseQuery = "CREATE DATABASE IF NOT EXISTS MyDatabaseConnection";
                MySqlCommand createDatabaseCommand = new MySqlCommand(createDatabaseQuery, mySqlConnection); 
                createDatabaseCommand.ExecuteNonQuery();

                string switchDatabaseQuery = "USE MyDatabaseConnection";
                MySqlCommand switchDatabaseCommand = new MySqlCommand(switchDatabaseQuery, mySqlConnection); 
                switchDatabaseCommand.ExecuteNonQuery();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS MyTable (ID INT PRIMARY KEY, NAME VARCHAR(50))";
                MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, mySqlConnection);
                createTableCommand.ExecuteNonQuery();

                mySqlConnection.Close();  
            
        }
     private void InsertDataIntoTable()
        {
            mySqlConnection.Open();

                string insertDataQuery = "INSERT INTO MyTable (ID, NAME) VALUES(2, 'Mayur')";
                MySqlCommand insertDataCommand = new MySqlCommand(insertDataQuery, mySqlConnection);
              /*  insertDataCommand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = 1;
                insertDataCommand.Parameters.AddWithValue("@NAME", SqlDbType.VarChar).Value = "QWERTY";*/
                 insertDataCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            
        }
        private void LoadDataIntoDataGridView()
        {

            mySqlConnection.Open();

                string selectDataQuery = "SELECT * FROM MyTable";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectDataQuery, mySqlConnection);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateDatabaseAndTable();
            InsertDataIntoTable();
            LoadDataIntoDataGridView();
        }
    }
}
