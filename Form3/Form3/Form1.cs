using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form3
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=127.0.0.1;Initial Catalog=Accounts;Integrated Security=True";
        private DataTable dataTable = new DataTable();
        private DataGridView dataGridView = new DataGridView();

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load_1;

            // Create the LoadData button
            Button loadDataButton = new Button();
            loadDataButton.Text = "LoadData";
            EventHandler LoadDataButton_Click = null;
            loadDataButton.Click += LoadDataButton_Click;

            // Create the DataGridView
            dataGridView.Dock = DockStyle.Fill;

            // Add the controls to the form
            Controls.Add(loadDataButton);
            Controls.Add(dataGridView);
        }


        private void ExecuteNonQuery(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private DataTable ExecuteQuery(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Step 1: Create the database
            string createDatabaseQuery = "CREATE DATABASE Accounts";
            ExecuteNonQuery("master", createDatabaseQuery);

            // Step 2: Switch to the new database
            connectionString = "Data Source=127.0.0.1;Initial Catalog=Accounts;Integrated Security=True";

            // Step 3: Create the table
            string createTableQuery = "CREATE TABLE ap2_0050 (PRD INT, D_C VARCHAR(50), B_T VARCHAR(50), D_N VARCHAR(50), D_D DATE, A_N VARCHAR(50), S_A DECIMAL(18, 2))";
            ExecuteNonQuery(connectionString, createTableQuery);

            // Step 4: Import data into the table
            string insertQuery = "INSERT INTO ap2_0050 (PRD, D_C, B_T, D_N, D_D, A_N, S_A) " +
                            "VALUES " +
                            "('A', 5, 1, NULL, '1999-03-31', '1003', 'GT1'), " +
                            "('A', 5, 2, NULL, '1999-03-31', '4002', 'KF1'), " +
                            "('A', 5, 3, NULL, '1999-03-31', '4002', 'MZ1'), " +
                            "('A', 5, 4, NULL, '1999-03-31', '75DIS', '@@@')";
            ExecuteNonQuery(connectionString, insertQuery);

            // Step 5: Load data into the DataGridView
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            string selectQuery = "SELECT * FROM ap2_0025";
            dataTable = ExecuteQuery(connectionString, selectQuery);

            // Update the DataGridView's data source
            dataGridView.DataSource = dataTable;
        }
    }
    }


