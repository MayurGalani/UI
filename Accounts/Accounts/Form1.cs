using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /* OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\AP2\\AP2.mdb");
             if (conn.State == ConnectionState.Closed)
             {
                 conn.Open();
             }
             OleDbCommand cmd = new OleDbCommand("SELECT * FROM [ap2-0021]", conn);
             OleDbDataAdapter da = new OleDbDataAdapter();
             da.SelectCommand = cmd;
             DataTable dt = new DataTable();
             dt.Clear();
             da.Fill(dt);
             dataGridView1.DataSource = dt;
             conn.Close();
            */
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString();// "Data Source=MAYUR\\SQLEXPRESS; Initial Catalog=student;integrated Security=SSPI;";


            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT TOP 5 * FROM dbo.stu";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable customerTable = new DataTable("Top5Customers");
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(customerTable);
                    _con.Close();

                }
            }
        }
    }
}
           
