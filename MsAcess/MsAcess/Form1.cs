using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Google.Protobuf.WellKnownTypes;

namespace MsAcess
{
    public partial class Form1 : Form
    {
        static String DBPath;
        static OleDbConnection conn;
         MySqlConnection mySqlConnection;

        public Form1()
        {
            InitializeComponent();
            string mysqlCon = "server=127.0.0.1; user=root;";
            mySqlConnection = new MySqlConnection(mysqlCon);
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("SQL Connection Success");
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
            DataTable userTables = null;
            DBPath = "D:\\AP2\\AP2.mdb";
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Jet OLEDB:Database Password=sharp_mdb;" + "Data Source=" + DBPath);
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            conn.Open();
            System.Windows.Forms.MessageBox.Show("Acess Connected success");
            userTables = conn.GetSchema("Tables", restrictions);
            List<string> tableNames = new List<string>();
            for (int i = 0; i < userTables.Rows.Count; i++)
                tableNames.Add(userTables.Rows[i][2].ToString());

            comboBox1.DataSource = tableNames;
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

            string createTableQuery = "CREATE TABLE IF NOT EXISTS " + comboBox1.SelectedItem + "(SR_No INT AUTO_INCREMENT,PRIMARY KEY (SR_No))";
            MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, mySqlConnection);
            createTableCommand.ExecuteNonQuery();

            checkedListBox1.CheckedItems.Cast<object>().ToList().ForEach(item =>
            {
                string AlterTableQuery;
                if (item.Equals("DESC"))
                {
                    AlterTableQuery = "ALTER TABLE " + comboBox1.SelectedItem + " ADD DESCRIPTION varchar(255)";
                }
                else
                {
                    AlterTableQuery = "ALTER TABLE " + comboBox1.SelectedItem + " ADD " + item.ToString() + " varchar(255)";
                }

                MySqlCommand AlterTableCommand = new MySqlCommand(AlterTableQuery, mySqlConnection);
                AlterTableCommand.ExecuteNonQuery();

            });

            mySqlConnection.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateDatabaseAndTable();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var table = comboBox1.SelectedItem;
            string query = "SELECT * From " + table;
            if (table.ToString() != "~TMPCLP337301")
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                checkedListBox1.Items.Clear();
                OleDbCommand cmd = new OleDbCommand("Select * from " + table, conn);

                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                List<string> ColumnNames = new List<string>();

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    checkedListBox1.Items.Add(dr.GetName(i).ToString(), CheckState.Checked);
                }

                dr.Close();
            }
        }

        

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
  




}

