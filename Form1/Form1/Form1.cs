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

namespace Form1
{
    public partial class Form1 : Form
    {
        MyDBConnection con = new MyDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            con.Connect();
            string mysqlCon = "server=127.0.0.1; user=root; database=Accounts; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("Connection Success");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("SELECT * FROM `ap2_0025`", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
