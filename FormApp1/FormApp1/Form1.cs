
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Form1
{
    public partial class Form1 : Form
    {
        private MySqlConnection mySqlConnection;
        private DataTable dataTable;
        private DataGridView dataGridView;
       

        public Form1(Button button1)
        {
            InitializeComponent();
            string mysqlCon = "server=127.0.0.1; user=root; database=Accounts; password=";
            mySqlConnection = new MySqlConnection(mysqlCon);
            this.button1 = button1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a DataTable
            dataTable = new DataTable("YourDataTable");

            // Add columns to the DataTable
            dataTable.Columns.Add("A_N", typeof(string));
            dataTable.Columns.Add("S_A", typeof(string));
            dataTable.Columns.Add("BANKNAME", typeof(string));
            dataTable.Columns.Add("BANKADDRESS", typeof(string));
            dataTable.Columns.Add("BANKCITY", typeof(string));
            dataTable.Columns.Add("BANKACCNO", typeof(string));
            dataTable.Columns.Add("BANKNEFT", typeof(string));

            // Add sample data rows to the DataTable
            dataTable.Rows.Add("001", "SA001", "Bank A", "Address A", "City A", "1234567890", "NEFT001");
            dataTable.Rows.Add("002", "SA002", "Bank B", "Address B", "City B", "0987654321", "NEFT002");
            dataTable.Rows.Add("003", "SA003", "Bank C", "Address C", "City C", "111222333", "NEFT003");
            dataTable.Rows.Add("004", "SA004", "Bank D", "Address D", "City D", "444555666", "NEFT004");

            // Create a DataGridView
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            // Create a Button
            button1 = new Button();
            button1.Text = "Get Data";
            button1.Click += button1_Click;

            // Add the DataGridView and Button to the form
            Controls.Add(dataGridView);
            Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection.Open();

                // Create a MySqlCommand to fetch data from the database
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM YourTable", mySqlConnection);

                // Create a MySqlDataAdapter to fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                // Clear existing data
                dataTable.Clear();

                // Fill the DataTable with the fetched data
                adapter.Fill(dataTable);

                // Set the data source of the DataGridView to the DataTable
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the database connection
                mySqlConnection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
