using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ADODB;
using ADOX;
using System.Data.OleDb;
using System.Configuration;


namespace SHARP_ACCOUNTING
{
    public partial class comattach : Form
    {
        //private OleDbConnection bookConn;
        //private OleDbCommand oleDbCmd = new OleDbCommand();
        //private String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\EtaYuy\Documents\book.mdb;Persist Security Info=False";
        string m_new_nik;
        string mtbname, new_data_file, new_company_folder, fileName;
        string start_period, end_period, temp_start_period, temp_end_period;
        string temp_word;
        string new_company_location;
        ADOX.Catalog cat = new ADOX.Catalog();
        ADOX.Table table = new ADOX.Table();

        public comattach()
        {
            //bookConn = new OleDbConnection(connParam);
            InitializeComponent();
        }

        private void new_company_creation_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
            Application.Exit();
            //MainForm main = new MainForm();
            //main.Show();           
            //this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            create_company_details_text_file();
            //System.Windows.Forms.Application.Exit();
            objPleaseWait.Close();
            System.Environment.Exit(1);
        }

        public void create_company_details_text_file()
        {
            new_company_folder = (comdrive.Text + "acc\\").ToUpper();
            if (comname.Text.Contains(" "))
            {
                int aaa = comname.Text.IndexOf(" ");
                m_new_nik = (comname.Text.Substring(0, 1) + comname.Text.Substring(aaa - 1, 1) + "1").ToUpper();
            }
            else
                m_new_nik = (comname.Text.Substring(0, 1) + comname.Text.Substring(comname.Text.Length - 1, 1) + "1").ToUpper();
            //m_new_nik = "AP3";
            new_data_file = (new_company_folder + m_new_nik.ToUpper() + ".txt").ToUpper();
            if (File.Exists(new_data_file))
            {
                for (int i = 2; i < 20; i++)
                {
                    if (comname.Text.Contains(" "))
                    {
                        int aaa = comname.Text.IndexOf(" ");
                        m_new_nik = comname.Text.Substring(0, 1) + comname.Text.Substring(aaa - 1, 1) + Convert.ToString(i);
                    }
                    else
                        m_new_nik = comname.Text.Substring(0, 1) + comname.Text.Substring(comname.Text.Length - 1, 1) + Convert.ToString(i);
                    new_data_file = (new_company_folder + m_new_nik.ToUpper() + ".txt").ToUpper();
                    if (!File.Exists(new_data_file))
                    {
                        i = 20;
                    }
                }
            }

            create_new_company_text_file();
            CreateNewAccessDatabase(new_company_folder);
            MessageBox.Show("File Created Successfully");
        }

        private void create_new_company_text_file()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new_data_file.ToString());
            sb.AppendLine(comname.Text.ToUpper());
            sb.AppendLine(comadd1.Text.ToUpper());
            sb.AppendLine(comadd2.Text.ToUpper());
            //sb.AppendLine(comadd3.Text.ToUpper());
            sb.AppendLine(comcity.Text.ToUpper());
            sb.AppendLine(comstate.Text.ToUpper());
            sb.AppendLine(compin.Text.ToUpper());
            sb.AppendLine(comph1.Text.ToUpper());
            sb.AppendLine(comph2.Text.ToUpper());
            sb.AppendLine(commob.Text.ToUpper());
            sb.AppendLine(commob2.Text.ToUpper());
            sb.AppendLine(comemail.Text.ToUpper());
            sb.AppendLine(comowner.Text.ToUpper());
            sb.AppendLine(compan.Text.ToUpper());
            sb.AppendLine(comsrc1.Text.ToUpper());
            sb.AppendLine(comsrc2.Text.ToUpper());
            sb.AppendLine(comsrc3.Text.ToUpper());
            sb.AppendLine(combst.Text.ToUpper());
            sb.AppendLine(comvat.Text.ToUpper());
            sb.AppendLine(comlbt.Text.ToUpper());
            sb.AppendLine(comitacc.Text.ToUpper());
            sb.AppendLine(comaccno.Text.ToUpper());
            sb.AppendLine(comcomments.Text.ToUpper());
            sb.AppendLine(comdob.Text.ToUpper());
            sb.AppendLine(comstatus.Text.ToUpper());
            sb.AppendLine("N");
            //sb.AppendLine(combacc.Text.ToUpper());
            sb.AppendLine(comcst.Text.ToUpper());
            sb.AppendLine(comcsttin.Text.ToUpper());
            sb.AppendLine(comwebsite.Text.ToUpper());
            sb.AppendLine(comifc.Text.ToUpper());
            sb.AppendLine(combank.Text.ToUpper());
            //sb.AppendLine(tb_company_sale_form_type.Text.Trim());
            sb.AppendLine("4");
            sb.AppendLine("");
            sb.AppendLine("Y");
            sb.AppendLine("");
            sb.AppendLine("Arial Narrow, 9.75pt");
            sb.AppendLine("5");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Y");
            sb.AppendLine("");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("Y");
            sb.AppendLine("");
            sb.AppendLine("");
            System.IO.Directory.CreateDirectory(new_company_folder);
            TextWriter writer = new StreamWriter(new_data_file);
            writer.WriteLine(sb);
            writer.Flush();
            writer.Close();

        }

        public bool CreateNewAccessDatabase(string new_company_folder)
        {
            ConnectionWithSQL.file_type = "Access";
            System.IO.Directory.CreateDirectory(new_company_folder + m_new_nik);
            System.IO.Directory.CreateDirectory(new_company_folder + m_new_nik + "\\reports");
            System.IO.Directory.CreateDirectory(new_company_folder + m_new_nik + "\\images");
            System.IO.Directory.CreateDirectory(new_company_folder + m_new_nik + "\\excel Reports");
            System.IO.Directory.CreateDirectory(new_company_folder + m_new_nik + "\\scanned_images");
            bool result = false;

            fileName = new_company_folder + m_new_nik;
            new_company_location = new_company_folder + m_new_nik + "\\" + m_new_nik + ".mdb";
            //ConnectionWithSQL.file_type = "Access";

            try
            {
                if (ConnectionWithSQL.file_type == "Access")
                {
                    cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + new_company_location + "; Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=sharp_mdb;");
                    //cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + new_company_location + "; Jet OLEDB:Engine Type=5;");
                    create_table_in_mdb_for_access();
                    update_mdb_table_with_compulsory_repords();
                    result = true;
                    ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                    if (con != null)
                        con.Close();
                }
                else
                {
                    //ConnectionWithSQL.command.CommandText = "CREATE DATABASE " + m_new_nik + " ON  (NAME = " + m_new_nik + "_dat,  FILENAME = '" + fileName + '\\' + m_new_nik + ".mdf', SIZE = 10,  MAXSIZE = 50,  FILEGROWTH = 5 )  LOG ON  ( NAME = '" + new_company_folder + m_new_nik + '\\' + m_new_nik + "_log',  FILENAME = '" + new_company_folder + m_new_nik + '\\' + m_new_nik + ".ldf', SIZE = 5MB,  MAXSIZE = 25MB, FILEGROWTH = 5MB ) ; ";

                    ConnectionWithSQL.command.CommandText = "CREATE DATABASE " + m_new_nik + " ON  (NAME = " + m_new_nik + "_dat,  FILENAME = '" + fileName + '\\' + m_new_nik + ".mdf')  LOG ON  ( NAME = '" + new_company_folder + m_new_nik + '\\' + m_new_nik + "_log',  FILENAME = '" + new_company_folder + m_new_nik + '\\' + m_new_nik + ".ldf') ; ";
                    ConnectionWithSQL.connection.Open();
                    try
                    {
                        ConnectionWithSQL.command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ConnectionWithSQL.connection.Close();
                    //ConnectionWithSQL.connection2.ConnectionString = "data source = .; integrated security = true; initial catalog = " + m_new_nik;
                    ConnectionWithSQL.connection2.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString() + m_new_nik; //Kunal
                    ConnectionWithSQL.command2.Connection = ConnectionWithSQL.connection2;
                    ConnectionWithSQL.command2.CommandText = "use " + m_new_nik;
                    ConnectionWithSQL.connection2.Open();
                    ConnectionWithSQL.command2.ExecuteNonQuery();
                    ConnectionWithSQL.connection2.Close();
                    create_table_in_mdb_for_sql();
                    update_table_with_compulsory_repords();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            cat = null;
            return result;
        }

        #region MDB methods
        private void create_table_in_mdb_for_access()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=sharp_mdb;Data Source=" + new_company_location;
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB;Data Source=" + new_company_location;
            //ConnectionWithSQL.mtextfilename = mDRIVE + ":\\" + "acc\\table_structure.txt";
            //ConnectionWithSQL.mtextfilename = mDRIVE + ":\\" + "visual studio\\projects\\sharp\\table_structure.txt";
            //ConnectionWithSQL.mtextfilename = mDRIVE + ":\\" + "visual studio\\projects\\sharp\\table_structure_for_acess.txt";
            //ConnectionWithAccess.mtextfilename = @"..\..\table_structure_access.txt";//C:\\Projects\\Sanjay Ailani\\18 April 2017\\sharp\\table_structure_access.txt";
            ConnectionWithAccess.mtextfilename = ConnectionWithAccess.setup_drive + "sharp\\table_structure.txt";//C:\\Projects\\Sanjay Ailani\\18 April 2017\\sharp\\table_structure_access.txt";
            ConnectionWithAccess.connection = conn;
            ConnectionWithAccess.connection2 = conn;
            var lines = File.ReadAllLines(ConnectionWithAccess.mtextfilename);
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] != null)
                {
                    temp_word = lines[i];
                    if (temp_word.Substring(0, 4) == "ADD_")
                    {
                        string struction_sintex, query;
                        mtbname = m_new_nik + temp_word;
                        mtbname = mtbname.Replace("ADD", "");
                        struction_sintex = lines[i + 1];
                        temp_word = null;
                        var cellArray = struction_sintex.Split(new[] { ';' });
                        for (int j = 0; j < cellArray.Length; j++)
                        {
                            temp_word = temp_word + cellArray[j].Trim() + ",";
                        }
                        struction_sintex = temp_word.Substring(0, temp_word.Length - 1);
                        struction_sintex = struction_sintex.Replace("bigint", "long");
                        conn.Open();
                        query = "create table " + mtbname + "(" + struction_sintex + ")";
                        OleDbCommand cmmd = new OleDbCommand("", conn);
                        cmmd.CommandText = query;
                        if (conn.State == ConnectionState.Open)
                        {
                            try
                            {
                                cmmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (OleDbException ex)
                            {
                                conn.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                }
            }
        }

        public void update_mdb_table_with_compulsory_repords()
        {
            mtbname = m_new_nik + "_0001";
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1001' , '@@@', '@@@', 'FACTORY BUILDING ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y,[desc]) values('3', '1001' , 'PUR','@@@',  'FACTORY PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1002' , '@@@', '@@@' 'MOTOR CAR ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y,[desc]) values('3', '1002' ,'PUR','@@@', 'MOTOR CAR PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1003' , '@@@', '@@@' 'MACHINERY ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '1003' , 'PUR','@@@', 'MACHINERY PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1004' , '@@@', '@@@' 'FURNITURE & FIXTURES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '1004' , 'PUR','@@@', 'FURNITURE & FIXTURES PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1005' , '@@@', '@@@' 'HOUSE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '1005' , 'PUR','@@@', 'HOUSE PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1006' ,  '@@@','@@@','RENT RECEIVIABLE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1007' , '@@@', '@@@' 'TELEPHONE DEPOSITS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009L1' , '@@@', '@@@' 'LOAN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009ON' , '@@@', 'OCEAN PARK')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009PF' , '@@@', '@@@' 'PPF')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009HF' ,  '@@@','@@@','HUF')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009S1' ,  '@@@','@@@','SHARE IN HAND')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009SA' ,  '@@@','@@@','SEEMA HOLIDAY HOME')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009SR' ,  '@@@','@@@','SHARE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009VC' ,  '@@@','@@@','VCR')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2001' ,  '@@@','@@@','OPENING STOCK')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2002' ,  '@@@','@@@','SUNDRY DEBTORS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2003' ,  '@@@','@@@','ADVANCED RECEIVED FROM PARTIES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2004' ,  '@@@','@@@','ADVANCES PAID TO SUPPLIERS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2010' ,  '@@@','@@@','CASH IN HAND')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2011' ,  '@@@','@@@','BANK OF BARODA')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '2011' , 'CCF','@@@', 'CASH CREDIT FACILITY')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3000' ,  '@@@','@@@','OLD CAPITAL ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3001' ,  '@@@','@@@','CAPITAL ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'DRA','@@@', 'DRAWINGS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'ITP','@@@', 'INCOME TAX PAYMENT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'LIP','@@@', 'LIFE INSURANCE PREMIUM')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'LCR','@@@', 'LIC RETURN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'MCM','@@@', 'MEDICLAIM')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'NSC','@@@', 'NSC / BANK INTEREST')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'SI1','@@@', 'SALARY INCOME FROM FIRM')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'NI1','@@@', 'NET INCOME FROM FIRM')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3001' , 'II1','@@@', 'INTEREST INCOME')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3002' , 'NSC','@@@', 'LESS DEDUCTION NSC / BANK')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '3002' , 'SI1','@@@', 'LESS STANDERED DEDUCTION')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3500' ,  '@@@','LOANS GIVEN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3501' ,  '@@@','@@@','LOANS TAKEN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3555' ,  '@@@','@@@','LOANS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3502' ,  '@@@','@@@','LOAN FROM L.I.C.')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3503' ,  '@@@','@@@','SALES TAX PAYABLE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3504' ,  '@@@','@@@','RENT PAYABLE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3505' ,  '@@@','@@@','HIRE CHARGES PAYABLE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3600' ,  '@@@','@@@','Taxes and Duties')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '4002' ,  '@@@','@@@','SUNDRY CREDITORS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '5000' ,  '@@@','@@@','CLOSING STOCK')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6000' ,  '@@@','@@@','SALES ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6000R1' ,  '@@@','@@@','REPAIR CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '65DIS' ,  '@@@','@@@','DISCOUNT & COMMISSION')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '65RENT' ,  '@@@','@@@','RENT RECEIVABLE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6700' ,  '@@@','@@@','Job Work')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7000' ,  '@@@','@@@','PURCHASE ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70ELE' ,  '@@@','@@@','ELECTRICITY CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70MHR' ,  '@@@','@@@','MACHINERY HIRE CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70MRC' ,  '@@@','@@@','MACHINERY REPAIR CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70STP' ,  '@@@','@@@','SALES TAX PAYMENT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70TC' ,  '@@@','@@@','TRANSPORT CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70WS' ,  '@@@','@@@','WAGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7001',  '@@@','@@@','SALES RETURN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '719999',  '@@@','@@@','GROSS PROFIT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '74' ,  '@@@','@@@','MUNCIPAL TAXES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75' ,  '@@@','@@@','EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75BKC' ,  '@@@','@@@','BANK COMMISSION ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75BKI' ,  '@@@','@@@','BANK INTEREST')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75CONV' ,  '@@@','@@@','CONVEYANCE EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75CONS' ,  '@@@','@@@','CONSUMABLE STORES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DEP' , '@@@', '@@@' 'DEPRECIATION ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DIE' ,  '@@@','@@@','DIE REPAIRS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DIS' ,  '@@@','@@@','DISCOUNT ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75HIR' ,  '@@@','@@@','HIRE CHARGES OF MACHINERY')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75LAB' ,  '@@@','@@@','LABOUR CHARGES FOR REPAIRS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75MAC' ,  '@@@','@@@','MACHINERY REPAIRS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75MUN' ,  '@@@','@@@','MUNCIPAL TAXES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PRI' ,  '@@@','@@@','PRINTING & STATIONARY')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PET' ,  '@@@','@@@','PETROL EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PRO' ,  '@@@','@@@','PROFESSIONAL & CONSULTANCY CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75REN' ,  '@@@','@@@','RENT ACCOUNT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75SAL' ,  '@@@','@@@','SALARY EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75SUN' ,  '@@@','@@@','SUNDRY EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75TEL' ,  '@@@','@@@','TELEPHONE EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75TRA' ,  '@@@','@@@','TRANSPORT CHARGES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75VEH' ,  '@@@','@@@','VEHICLE EXPENSES')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7998' ,  '@@@','@@@','NET PROFIT')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7999' ,  '@@@','@@@','CASH WITHDRAW / DEPOISTS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '7999' , 'DEP','@@@', 'CASH DEPOSITS')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '7999' , 'WIT','@@@', 'CASH WITHDRAWN')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8001' , 'NSC','@@@', 'NSC/BANK INTEREST')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8002' , 'NSC','@@@', 'DEDUCTION FROM NSC')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8003' , 'SI1','@@@', 'SALARY INCOME XX1')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8004' , 'XX1','@@@', 'LESS STANDERED DEDUCTION')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8005' ,  '@@@','@@@','NET PROFIT FROM FIRM')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8006' ,  '@@@','@@@','MINOR INCOME CLUBBED')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8006' , 'XX1','@@@', 'XX1 (MINOR)')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8006' , 'XX2','@@@', 'XX2 (MINOR)')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8007' , 'XX1','@@@', 'LESS DEDUCTION XX1')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8007' , 'XX2','@@@', 'LESS DEDUCTION XX2')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8008' , 'IT1','@@@', 'INTEREST INCOME')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8009' ,  '@@@','@@@','TAX PAYABLE')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8010' ,  '@@@','@@@','20%')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8010' , 'LIC','@@@', 'LIC')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8010' , 'PPF','@@@', 'PPF')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8010' , 'N1','@@@', 'NSC 1')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8010' , 'N2','@@@', 'NSC 2')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n, s_a, d_y,[desc]) values('3', '8010' , 'N3','@@@', 'NSC3')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8011' ,  '@@@','LESS TDS')";
            connectMDBAndUseQuery();
            //ConnectionWithAccess.query = "update " + mtbname + " set s_a = '@@@' WHERE s_a = ''";
            //connectAndUseQuery();
            //ConnectionWithAccess.query = "update " + mtbname + " set d_y = '@@@' WHERE d_y = ''";
            //connectAndUseQuery();

            mtbname = m_new_nik + "_0021";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 1, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2002','@@@','@@@')";
            connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0022";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 2, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'4002','@@@','@@@')";
            connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0023";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 3, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2011','@@@','@@@')";
            connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0024";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y,mess) values ('A', 4, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2010','@@@','@@@','2002')";
            connectMDBAndUseQuery();
            //ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y,mess) values ('A', 20, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2010','@@@','@@@','2002')";
            //connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0025";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d) values ('A', 5, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "')";
            connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0030";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 30, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2002','@@@','@@@')";
            mtbname = m_new_nik + "_0006";
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 1, 00, 'IInd Sale')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 2, 13.5, '13.5% Vat Tax')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 3, 6.5, '6.5% Vat Tax')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 4, 2, 'C FORM + 02% TAX')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 5, 0, 'Import No Tax')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 6, 12.5, '12.5% Vat Tax')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 1, 13.5, '13.5% Vat Tax')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 2, 02, 'C FORM + 02% TAX')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 3, 00, 'Resale / IInd Sale')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 4, 00, 'U.R.D.')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 5, 00, 'FORM 15')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 6, 12.5, '12.5% Vat Tax')";
            connectMDBAndUseQuery();
            start_period = (Convert.ToString(comper1.Text)).Substring(0, ((Convert.ToString(comper1.Text)).Length) - 2) + Convert.ToString(Convert.ToInt32((Convert.ToString(comper1.Text)).Substring(((Convert.ToString(comper1.Text)).Length) - 2, 2)) - 1);
            end_period = (Convert.ToString(comper2.Text)).Substring(0, ((Convert.ToString(comper2.Text)).Length) - 2) + Convert.ToString(Convert.ToInt32((Convert.ToString(comper2.Text)).Substring(((Convert.ToString(comper2.Text)).Length) - 2, 2)) - 1);
            mtbname = m_new_nik + "_0050";
            //ConnectionWithAccess.query = "insert into " + mtbname + " (prd, [start], [end]) values('@', 04/01/2015 , 03/31/2016)";
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd, [start], [end]) values('@', '" + Convert.ToDateTime(start_period) + "' , '" + Convert.ToDateTime(end_period) + "')";
            connectMDBAndUseQuery();
            ConnectionWithAccess.query = "insert into " + mtbname + " (prd, [start], [end]) values('A','" + Convert.ToDateTime(comper1.Text) + "' , '" + Convert.ToDateTime(comper2.Text) + "')";
            //ConnectionWithAccess.query = "insert into " + mtbname + " (prd, [start], [end]) values('A', 04/01/2016 , 03/31/2017)";
            connectMDBAndUseQuery();
            mtbname = m_new_nik + "_0052";
            ConnectionWithAccess.query = "insert into " + mtbname + " ([F1], [F2], [F3]) values('admin', 'admin', 'YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY')";
            connectMDBAndUseQuery();
        }

        public void connectMDBAndUseQuery()
        {
            ConnectionWithAccess.command2.CommandText = ConnectionWithAccess.query;
            ConnectionWithAccess.connection2.Open();
            try
            {
                ConnectionWithAccess.command2.Connection = ConnectionWithAccess.connection2;
                ConnectionWithAccess.command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnectionWithAccess.connection2.Close();
            }
        }
        #endregion

        private void create_table_in_mdb_for_sql()
        {
            string mDRIVE = "F";
            //ConnectionWithSQL.mtextfilename = mDRIVE + ":\\" + "acc\\table_structure.txt";
            //ConnectionWithSQL.mtextfilename = mDRIVE + ":\\" + "visual studio\\projects\\sharp\\table_structure.txt";
            ConnectionWithSQL.mtextfilename = mDRIVE + ":\\ACC\\table_structure.txt";
            var lines = File.ReadAllLines(ConnectionWithSQL.mtextfilename);
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] != null)
                {
                    temp_word = lines[i];
                    if (temp_word.Substring(0, 4) == "ADD_")
                    {
                        string struction_sintex, query;
                        mtbname = m_new_nik + temp_word;
                        struction_sintex = lines[i + 1];
                        temp_word = null;
                        var cellArray = struction_sintex.Split(new[] { ';' });
                        for (int j = 0; j < cellArray.Length; j++)
                        {
                            temp_word = temp_word + cellArray[j].Trim() + ",";
                        }
                        struction_sintex = temp_word.Substring(0, temp_word.Length - 1);
                        query = "create table " + mtbname + "(" + struction_sintex + ")";
                        ConnectionWithSQL.query = query;
                        connectAndUseQuery();
                    }
                }
            }
        }

        public void update_table_with_compulsory_repords()
        {
            mtbname = m_new_nik + "_0001";
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y, [desc]) values('3', '1001' , '@@@', '@@@' , 'FACTORY BUILDING ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '1001' , 'PUR', '@@@' , 'FACTORY PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1002' ,  '@@@', '@@@' ,'MOTOR CAR ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y,[desc]) values('3', '1002' ,'PUR', '@@@' , 'MOTOR CAR PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1003' ,  '@@@', '@@@' ,'MACHINERY ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '1003' , 'PUR', '@@@' , 'MACHINERY PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1004' ,  '@@@', '@@@' ,'FURNITURE & FIXTURES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '1004' , 'PUR', '@@@' , 'FURNITURE & FIXTURES PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1005' ,  '@@@', '@@@' ,'HOUSE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '1005' , 'PUR', '@@@' , 'HOUSE PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1006' ,  '@@@', '@@@' ,'RENT RECEIVIABLE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1007' ,  '@@@', '@@@' ,'TELEPHONE DEPOSITS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009L1' ,  '@@@', '@@@' ,'LOAN')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009ON' ,  '@@@', '@@@' ,'OCEAN PARK')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009PF' ,  '@@@', '@@@' ,'PPF')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009HF' ,  '@@@', '@@@' ,'HUF')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009S1' ,  '@@@', '@@@' ,'SHARE IN HAND')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009SA' ,  '@@@', '@@@' ,'SEEMA HOLIDAY HOME')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009SR' ,  '@@@', '@@@' ,'SHARE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '1009VC' ,'@@@', '@@@' , 'VCR')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2001' , '@@@', '@@@' ,'OPENING STOCK')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2002' , '@@@', '@@@' ,'SUNDRY DEBTORS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2003' , '@@@', '@@@' ,'ADVANCED RECEIVED FROM PARTIES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2004' , '@@@', '@@@' ,'ADVANCES PAID TO SUPPLIERS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2010' , '@@@', '@@@' ,'CASH IN HAND')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '2011' , '@@@', '@@@' ,'BANK OF BARODA')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '2011' , 'CCF', '@@@' , 'CASH CREDIT FACILITY')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3000' , '@@@', '@@@' ,'OLD CAPITAL ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3001' , '@@@', '@@@' ,'CAPITAL ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'DRA', '@@@' , 'DRAWINGS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'ITP', '@@@' , 'INCOME TAX PAYMENT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'LIP', '@@@' , 'LIFE INSURANCE PREMIUM')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'LCR', '@@@' , 'LIC RETURN')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'MCM', '@@@' , 'MEDICLAIM')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'NSC', '@@@' , 'NSC / BANK INTEREST')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'SI1', '@@@' , 'SALARY INCOME FROM FIRM')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'NI1', '@@@' , 'NET INCOME FROM FIRM')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3001' , 'II1', '@@@' , 'INTEREST INCOME')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3002' , 'NSC', '@@@' , 'LESS DEDUCTION NSC / BANK')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '3002' , 'SI1', '@@@' , 'LESS STANDERED DEDUCTION')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3500' ,'@@@', '@@@' , 'LOANS GIVEN')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3501' , '@@@', '@@@' ,'LOANS TAKEN')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3555' ,  '@@@','@@@','LOANS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3502' , '@@@', '@@@' ,'LOAN FROM L.I.C.')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3503' , '@@@', '@@@' ,'SALES TAX PAYABLE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3504' ,'@@@', '@@@' , 'RENT PAYABLE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3505' , '@@@', '@@@' ,'HIRE CHARGES PAYABLE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '3600' , '@@@', '@@@' ,'Taxes and Duties')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '4002' , '@@@', '@@@' ,'SUNDRY CREDITORS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '5000' , '@@@', '@@@' ,'CLOSING STOCK')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6000' , '@@@', '@@@' ,'SALES ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6000R1' ,'@@@', '@@@' , 'REPAIR CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '65DIS' , '@@@', '@@@' ,'DISCOUNT & COMMISSION')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '65RENT' , '@@@', '@@@' ,'RENT RECEIVABLE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '6700' , '@@@', '@@@' ,'Job Work')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7000' ,'@@@', '@@@' , 'PURCHASE ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70ELE' , '@@@', '@@@' ,'ELECTRICITY CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70MHR' , '@@@', '@@@' ,'MACHINERY HIRE CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70MRC' , '@@@','MACHINERY REPAIR CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70STP' , '@@@','SALES TAX PAYMENT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70TC' ,'@@@', 'TRANSPORT CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '70WS' , '@@@', '@@@' ,'WAGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '74' ,'@@@', '@@@' , 'MUNCIPAL TAXES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75' , '@@@', '@@@' ,'EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75BKC' , '@@@', '@@@' ,'BANK COMMISSION ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75BKI' ,'@@@', '@@@' , 'BANK INTEREST')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75CONV' , '@@@', '@@@' ,'CONVEYANCE EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75CONS' , '@@@', '@@@' ,'CONSUMABLE STORES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DEP' ,'@@@', '@@@' , 'DEPRECIATION ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DIE' ,'@@@', '@@@' , 'DIE REPAIRS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75DIS' , '@@@', '@@@' ,'DISCOUNT ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75HIR' ,'@@@', '@@@' , 'HIRE CHARGES OF MACHINERY')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75LAB' ,'@@@', '@@@' , 'LABOUR CHARGES FOR REPAIRS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75MAC' , '@@@', '@@@' ,'MACHINERY REPAIRS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75MUN' , '@@@', '@@@' ,'MUNCIPAL TAXES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PRI' , '@@@', '@@@' ,'PRINTING & STATIONARY')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PET' , '@@@', '@@@' ,'PETROL EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75PRO' ,'@@@', '@@@' , 'PROFESSIONAL & CONSULTANCY CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75REN' ,'@@@', '@@@' , 'RENT ACCOUNT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75SAL' , '@@@', '@@@' ,'SALARY EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75SUN' ,'@@@', '@@@' , 'SUNDRY EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75TEL' ,'@@@', '@@@' , 'TELEPHONE EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75TRA' , '@@@', '@@@' ,'TRANSPORT CHARGES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '75VEH' , '@@@', '@@@' ,'VEHICLE EXPENSES')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7998' , '@@@', '@@@' ,'NET PROFIT')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '7999' , '@@@','CASH WITHDRAW / DEPOISTS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '7999' , 'DEP', '@@@' , 'CASH DEPOSITS')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '7999' , 'WIT', '@@@' , 'CASH WITHDRAWN')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8001' , 'NSC', '@@@' , 'NSC/BANK INTEREST')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8002' , 'NSC', '@@@' , 'DEDUCTION FROM NSC')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8003' , 'SI1', '@@@' , 'SALARY INCOME XX1')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8004' , 'XX1', '@@@' , 'LESS STANDERED DEDUCTION')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8005' , '@@@', '@@@' ,'NET PROFIT FROM FIRM')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8006' ,'@@@', '@@@' , 'MINOR INCOME CLUBBED')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8006' , 'XX1', '@@@' , 'XX1 (MINOR)')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8006' , 'XX2', '@@@' , 'XX2 (MINOR)')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8007' , 'XX1', '@@@' , 'LESS DEDUCTION XX1')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8007' , 'XX2', '@@@' , 'LESS DEDUCTION XX2')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8008' , 'IT1', '@@@' , 'INTEREST INCOME')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,d_y,[desc]) values('3', '8009' ,'@@@', '@@@' , '@@@' , 'TAX PAYABLE')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8010' , '@@@', '@@@' ,'20%')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8010' , 'LIC', '@@@' , 'LIC')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8010' , 'PPF', '@@@' , 'PPF')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8010' , 'N1', '@@@' , 'NSC 1')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8010' , 'N2', '@@@' , 'NSC 2')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n, s_a,d_y, [desc]) values('3', '8010' , 'N3', '@@@' , 'NSC3')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (r_c, a_n,s_a,d_y,[desc]) values('3', '8011' , '@@@', '@@@' ,'LESS TDS')";
            connectAndUseQuery();

            mtbname = m_new_nik + "_0021";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 1, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2002', '@@@','@@@')";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0022";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 2, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'4002', '@@@','@@@')";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0023";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 3, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2011', '@@@','@@@')";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0024";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y,mess) values ('A', 4, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2010', '@@@','@@@','2002')";
            connectAndUseQuery();
            //ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y,mess) values ('A', 20, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2010', '@@@','@@@','2002')";
            //connectAndUseQuery();
            mtbname = m_new_nik + "_0025";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d) values ('A', 5, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "')";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0030";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd,d_c,b_t,d_n,d_d,a_n,s_a,d_y) values ('A', 30, '1',999999, '" + Convert.ToDateTime("01/01/1901") + "' ,'2002', '@@@', '@@@')";
            mtbname = m_new_nik + "_0006";
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 1, 00, 'IInd Sale')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 2, 13.5, '13.5% Vat Tax')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 3, 6.5, '6.5% Vat Tax')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 4, 2, 'C FORM + 02% TAX')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 5, 0, 'Import No Tax')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (1, 6, 12.5, '12.5% Vat Tax')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 1, 13.5, '13.5% Vat Tax')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 2, 02, 'C FORM + 02% TAX')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 3, 00, 'Resale / IInd Sale')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 4, 00, 'U.R.D.')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 5, 00, 'FORM 15')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (d_c,tx_code,tax_rate,[desc]) values (2, 6, 12.5, '12.5% Vat Tax')";
            connectAndUseQuery();
            start_period = (Convert.ToString(comper1.Text)).Substring(0, ((Convert.ToString(comper1.Text)).Length) - 2) + Convert.ToString(Convert.ToInt32((Convert.ToString(comper1.Text)).Substring(((Convert.ToString(comper1.Text)).Length) - 2, 2)) - 1);
            end_period = (Convert.ToString(comper2.Text)).Substring(0, ((Convert.ToString(comper2.Text)).Length) - 2) + Convert.ToString(Convert.ToInt32((Convert.ToString(comper2.Text)).Substring(((Convert.ToString(comper2.Text)).Length) - 2, 2)) - 1);
            mtbname = m_new_nik + "_0050";
            //ConnectionWithSQL.query = "insert into " + mtbname + " (prd, [start], [end]) values('@', 04/01/2015 , 03/31/2016)";
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd, [start], [end]) values('@', '" + Convert.ToDateTime(start_period) + "' , '" + Convert.ToDateTime(end_period) + "')";
            connectAndUseQuery();
            ConnectionWithSQL.query = "insert into " + mtbname + " (prd, [start], [end]) values('A','" + Convert.ToDateTime(comper1.Text) + "' , '" + Convert.ToDateTime(comper2.Text) + "')";
            //ConnectionWithSQL.query = "insert into " + mtbname + " (prd, [start], [end]) values('A', 04/01/2016 , 03/31/2017)";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0052";
            ConnectionWithSQL.query = "insert into " + mtbname + " ([F1], [F2], [F3]) values('admin', 'admin', 'YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY')";
            connectAndUseQuery();
            mtbname = m_new_nik + "_0001";
            ConnectionWithAccess.query = "update " + mtbname + " set s_a = '@@@' WHERE s_a = ''";
            connectAndUseQuery();
            ConnectionWithAccess.query = "update " + mtbname + " set d_y = '@@@' WHERE d_y = ''";
            connectAndUseQuery();
        }

        public void connectAndUseQuery()
        {
            ConnectionWithSQL.command2.CommandText = ConnectionWithSQL.query;
            ConnectionWithSQL.connection2.Open();
            try
            {
                ConnectionWithSQL.command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ConnectionWithSQL.connection2.Close();
        }

        private void new_company_creation_form_Load(object sender, EventArgs e)
        {
            //allnik = new ArrayList();
            ComboBox ddldrives = new ComboBox();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo mdrive in drives)
            {
                comdrive.Items.Add(Convert.ToString(mdrive));
            }
            comdrive.SelectedIndex = comdrive.Items.Count - 1;
            //+DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + ".pdf";

            start_period = ("01/04/" + (DateTime.Now.Year).ToString());
            end_period = ("31/03/" + (Convert.ToInt32((DateTime.Now.Year).ToString()) + 1));
            comper1.Value = Convert.ToDateTime(start_period);
            comper2.Value = Convert.ToDateTime(end_period);
        }

    }
}
