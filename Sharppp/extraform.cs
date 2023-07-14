using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARP_ACCOUNTING
{
    public partial class extraform : Form
    {
        ConnectionWithSQL ConnectionCommand = new ConnectionWithSQL();
      
        public extraform()
        {
            InitializeComponent();
        }

        public void extraform_Load(object sender, EventArgs e)
        {
          //  ConnectionWithSQL.connection.ConnectionString = "data source = RV509; integrated security = true; initial catalog = ap2";         
          //  ConnectionWithSQL.command.Connection = ConnectionWithSQL.connection;

            //fillgrid("select prd, start, [end] from " + ConnectionWithSQL.tablename[50] + " order by prd desc", dataGridView1 );
            if (ConnectionWithSQL.extra_form_use == "Printing")
            {
                lbl_extra_form1.Visible = true;
                tb_extra_form1.Visible = true;
                btn_extra_form1.Visible = true;
                ClientSize = new System.Drawing.Size(400, 300);
                this.Location = new System.Drawing.Point(200, 100);
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Printing";
            }
        }

        public static void fillgrid(string query)
        {
            ConnectionWithSQL.command.CommandText = query;
            ConnectionWithSQL.connection.Open();
            DataGridView gdv = new DataGridView(); 

            int i=0;
            DataTable dt = new DataTable ();
           
            try
            {
              ConnectionWithSQL.datareader = ConnectionWithSQL.command.ExecuteReader();
              string colname;
                
              for(i = 0; i< ConnectionWithSQL.datareader.FieldCount; i++)
              {
                colname = ConnectionWithSQL.datareader.GetName(i);
                 // gdv.Columns.Add(colname, colname);
                dt.Columns.Add(colname);
                dt.Columns[i].ReadOnly = true;
              }

              while (ConnectionWithSQL.datareader.Read())
              {
                  DataRow ddr = dt.NewRow();

                  for (i = 0; i < ConnectionWithSQL.datareader.FieldCount; i++)
                  {
                      ddr[i] = ConnectionWithSQL.datareader[i];                      
                  }
                  dt.Rows.Add(ddr);
              }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            gdv.DataSource = dt;
            ConnectionWithSQL.connection.Close();

            //this.Controls.Add(gdv);
        }

        public static void fillgrid(string query, DataGridView gdv)
        {
            ConnectionWithSQL.command.CommandText = query;
            ConnectionWithSQL.connection.Open();
            
            int i = 0;
            DataTable dt = new DataTable();

            try
            {
                ConnectionWithSQL.datareader = ConnectionWithSQL.command.ExecuteReader();
                string colname;

                for (i = 0; i < ConnectionWithSQL.datareader.FieldCount; i++)
                {
                    colname = ConnectionWithSQL.datareader.GetName(i);
                    // gdv.Columns.Add(colname, colname);
                    dt.Columns.Add(colname);
                    dt.Columns[i].ReadOnly = true;
                }

                while (ConnectionWithSQL.datareader.Read())
                {
                    DataRow ddr = dt.NewRow();

                    for (i = 0; i < ConnectionWithSQL.datareader.FieldCount; i++)
                    {
                        ddr[i] = ConnectionWithSQL.datareader[i];
                    }
                    dt.Rows.Add(ddr);
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            gdv.DataSource = dt;
            ConnectionWithSQL.connection.Close();

            //this.Controls.Add(gdv);
        }

        private void AccountListDG_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           ConnectionWithSQL.mprd = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
           ConnectionWithSQL.msdate = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
           ConnectionWithSQL.medate = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
           dataGridView1.Visible = false;        
           //ToolStripStatusPeriod.Text = Convert.ToString(ConnectionWithSQL.mprd) + "  " + Convert.ToString(ConnectionWithSQL.msdate).Substring(0, 10) + "  " + Convert.ToString(ConnectionWithSQL.medate).Substring(0, 10);                    
        }

        private void btn_extra_form1_Click(object sender, EventArgs e)
        {
            if (ConnectionWithSQL.extra_form_use == "Printing")
            {

            }
        }
    }
}
