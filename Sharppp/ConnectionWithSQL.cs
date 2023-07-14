using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.ComponentModel;
//using System.Drawing;
//using System.Linq;

class ConnectionWithSQL
{
    //public static OleDbConnection connection = new OleDbConnection();
    //public static OleDbConnection connection2 = new OleDbConnection();
    //public static DataSet mDataSet = new DataSet();
    //public static OleDbCommand command = new OleDbCommand();
    //public static OleDbCommand command2 = new OleDbCommand();
    //public static OleDbDataReader datareader;

    # region declaration
    public static SqlConnection connection = new SqlConnection();
    public static SqlConnection connection2 = new SqlConnection();
    public static DataSet mDataSet = new DataSet();
    public static SqlCommand command = new SqlCommand();
    public static SqlCommand command2 = new SqlCommand();
    public static SqlDataReader datareader;
    public static SqlDataReader datareader2;
    public static SqlDataAdapter dataadapter1;

    public static string outputDate = "", prd_lock;
    public static string databasename;
    public static string[] tablename = new string[100];
    public static string[] data_from_company_file;
    public static string[] period_array;
    public static string moprd, mprd,mnew_prd, msdate, medate, ma_n, ms_a, md_y, mna_n, mns_a, md_n, mdesc, mcity, com_start_date, mtpt, mbillx2, new_s_a, delivery_desc, detach_exit, aadhar_card;
    public static string mitemtype, mitemcode, mitemdesc, r_p, b_t, macc_desc, mtax_desc, temp_prd, temp_old_prd, sales_purchase_transfer;
    public static string j1a_n, j1s_a, j2a_n, j2s_a;
    public static int md_c, mtq_cs, mwoodcase, mtx_code, mtx_desc, total_companies;
    public static double mtax_rate, gp_percent, use_sql_access;
    public static double gross_profit,closing_stock, net_profit, value1, value2, value3, value4;
    public static DateTime mDateTime;
    public static string query;
    public static string mNIK = "", mdrive, file_type, use_login_password;
    public static string mDataFile, mpdffile, df_filename;
    public static string line, report_file_location;
    public static string muser, companyName, mpassword;
    public static string coname, coadd1, coadd2, coadd3, cocity, coowner, costatus1, costatus2, covattax, copannumber, cobillformat;
    public static string copin, cooffice_phone, resi_phone, comobile1, comobile2;
    public static string coemail, coscr1, coscr2, coscr3, cobstno, cotinnum, colbtnum;
    public static string coitnumber, cointnumber2, cocoments, coownerdob, costatus;
    public static string cobankacnum, covattinnum, covatcstnum, cowebsite, cobankneft, cobankname;
    public static string accountname, accountaddress, accountcontact, accountbalance, accountemail, accountcity, accounttype;
    public static string bankname, bankaddress, bankcity, bankaccno, bankneft;
    public static string imagelocation, imagetype;
    public static string bank_a_n, cash_a_n;
    public static string mtextfilename, data_entry_working;
    public static string[] columnnamearray = new string[25];
    public static int i = 0, columncount = 0;
    public static DataTable dt = new DataTable();
    public static string message_box;
    public static string mUserFeatures;
    public static string data_drive;
    public static int[] datetemparray;
    public static string font_name, font_size;
    public static string data_type;
    public static int column_pointer, row_pointer;
    public static int asc_value, total_line_length;
    public static string temp_word, ExcelFileName;
    public static string extra_form_use, new_additional_a_n, fix_account_a_n;

    public static string[] report_columns_size;
    public static string[] report_columns_name;
    public static string[] report_column_header;
    public static string[] report_column_type;
    public static string[] tab_details;
    public static int temp_int;
    # endregion

    static ConnectionWithSQL()
    {
        //connection.ConnectionString = "data source = .; integrated security = true; initial catalog = " + ConnectionWithSQL.mNIK;
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString() + mNIK;  //Kunal
        //connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\\acc\\AP1\\Ap1.MDB";
        command.Connection = connection;
    }

    public static void ToCsV(DataGridView dGV, string filename)
    {
        string stOutput = "";

        // Export titles:
        string sHeaders = "";

        for (int j = 0; j < dGV.Columns.Count; j++)
            sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";

        stOutput += sHeaders + "\r\n";
        // Export data.

        for (int i = 0; i < dGV.RowCount; i++)
        {
            string stLine = "";
            for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
            stOutput += stLine + "\r\n";
        }

        Encoding utf16 = Encoding.GetEncoding(1254);
        byte[] output = utf16.GetBytes(stOutput);
        FileStream fs = new FileStream(filename, FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(output, 0, output.Length); //write the encoded file
        bw.Flush();
        bw.Close();
        fs.Close();
    }

    public static void export(DataGridView dataGridView1)
    {
        ExcelFileName = ConnectionWithSQL.data_drive + "acc\\" + ConnectionWithSQL.mNIK + "\\reports\\Ledger_" + mdesc + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + ".xls";  //+  DateTime.Now ;
        ToCsV(dataGridView1, ExcelFileName);
    }

    public static string convertDate(string inputDate)
    {
        string outputDate;
        outputDate = "convert(varchar(2), datepart(day, " + inputDate + ")) + '/' +  convert(varchar(2), datepart(month, " + inputDate + ")) +  '/' +  convert(varchar(4), datepart(year, " + inputDate + "))";
        return outputDate;
    }

    public ConnectionWithSQL()
    {
        //for (int i = 1; i <= 99; i++)
        //{
        //    if (i <= 9)
        //        tablename[i] = "ap2_000" + i;
        //    else
        //        tablename[i] = "ap2_00" + i;
        //}
    }

    public static void connectAndUseQuery()
    {
    if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        ConnectionWithSQL.command.CommandText = ConnectionWithSQL.query;
       
        try
        {
            ConnectionWithSQL.connection.Open();
            ConnectionWithSQL.command.ExecuteNonQuery();
            ConnectionWithSQL.connection.Close();
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
       
    }

    public static void open_executenonquery_close()
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        ConnectionWithSQL.command.CommandText = ConnectionWithSQL.query;
        ConnectionWithSQL.connection.Open();
        ConnectionWithSQL.command.ExecuteNonQuery();
        ConnectionWithSQL.connection.Close();
    }

    public void ConnectionCommandWithReader()
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        try
        {
            command.CommandText = ConnectionWithSQL.query;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                datareader.Close();
            }
            datareader = command.ExecuteReader();
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
    }

    public void ConnectionStringCode()
    {
        // connection.ConnectionString = "data source = RV509; initial catalog = " + databasename + "; integrated security = true";
        // command.Connection = connection;
    }

    public void DatabaseConnect()
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        command.CommandText = "use " + ConnectionWithSQL.databasename;
        try
        {
            ConnectionWithSQL.connection.Open();
            ConnectionWithSQL.command.ExecuteNonQuery();
            ConnectionWithSQL.connection.Close();
            command.Connection = connection;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Sorry Database Cannot be Connected");
            System.Environment.Exit(1);
            System.Windows.Forms.Application.Exit();
            Application.Exit();
        }

    }

    public void get_start_period()
    {
        //if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        command.CommandText = "select prd from " + ConnectionWithSQL.tablename[50] + " order by prd";
        connection.Open();
        datareader = command.ExecuteReader();
        if (datareader.Read())
            temp_old_prd = Convert.ToString(datareader[0]);
        connection.Close();
        command.CommandText = "select prd, start,[end] from " + ConnectionWithSQL.tablename[50] + " where prd != '" + temp_old_prd + "' order by prd";
        connection.Open();
        datareader = command.ExecuteReader();
        if (datareader.Read())
            com_start_date = Convert.ToString(datareader[1]);
        connection.Close();
    }

    public void currentperiod()
    {
        //int intError = 0;
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        //command.CommandText = "select prd, start,[end] from " + ConnectionWithSQL.tablename[50] + " where (select getdate()>= start) and (getdate() <= [end] )";
        command.CommandText = "select prd, start,[end] from " + ConnectionWithSQL.tablename[50] + " order by prd";
        connection.Open();
        try
        {
            datareader = command.ExecuteReader();
            datareader.Read();
            //com_start_date = Convert.ToString(datareader[1]);
        }
        catch
        {
            //intError = 1;
        }

        connection.Close();

        //if (intError == 1)
        //{
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        command.CommandText = "select top 1 prd, start, [end] from " + ConnectionWithSQL.tablename[50] + " order by start desc";
        connection.Open();
        datareader = command.ExecuteReader();
        datareader.Read();
        mprd = Convert.ToString(datareader[0]);
        msdate = Convert.ToString(datareader[1]);
        medate = Convert.ToString(datareader[2]);
        if (DateTime.Today <= Convert.ToDateTime(ConnectionWithSQL.medate))
        {
            ConnectionWithSQL.medate = (DateTime.Today.ToShortDateString()).ToString();
        }
        char c = Convert.ToChar(ConnectionWithSQL.mprd);
        asc_value = Convert.ToInt32(c);
        ConnectionWithSQL.moprd = Convert.ToString(Convert.ToChar(asc_value - 1));
        connection.Close();
        //}
    }

    public void insert()
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        connection.Open();
        ConnectionWithSQL.connection.Open();
        ConnectionWithSQL.command.ExecuteNonQuery();
        ConnectionWithSQL.connection.Close();
    }

    public void retrieval(ComboBox mComboBox)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        connection.Open();
        mComboBox.Items.Clear();
        command.CommandText = query;
        try
        {
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                mComboBox.Items.Add(datareader[0]);
            }
            connection.Close();
            mComboBox.SelectedIndex = 0;
            md_c = Convert.ToInt32(mComboBox.Text);
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            //MessageBox.Show("Day Book Not Found"); 
        }

        if (mComboBox.Items.Count == 1)
            mComboBox.Enabled = false;
        else
            mComboBox.Enabled = true;
        //md_c = Convert.ToInt32(mComboBox.Text);
    }

    //static void Main(string[] args)
    //{
    //    PdfDocument doc = new PdfDocument();
    //    //doc.LoadFromFile("sample.pdf");

    //    //Use the default printer to print all the pages
    //    //doc.PrintDocument.Print();

    //    //Set the printer and select the pages you want to print

    //    PrintDialog dialogPrint = new PrintDialog();
    //    dialogPrint.AllowPrintToFile = true;
    //    dialogPrint.AllowSomePages = true;
    //    dialogPrint.PrinterSettings.MinimumPage = 1;
    //    dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
    //    dialogPrint.PrinterSettings.FromPage = 1;
    //    dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

    //    if (dialogPrint.ShowDialog() == DialogResult.OK)
    //    {
    //        doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
    //        doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
    //        doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;

    //        PrintDocument printDoc = doc.PrintDocument;
    //        dialogPrint.Document = printDoc;
    //        printDoc.Print();
    //    }
    //}

    public void ExportToText(ComboBox mComboBox, TextBox mTextBox)
    {
        command.CommandText = query;
        connection.Open();
        mTextBox.Text = Convert.ToString(command.ExecuteScalar());
        if (mTextBox.Text == "")
            mTextBox.Text = "1";
        connection.Close();
    }

    public void ExportToDateTimePicker(DateTimePicker msDateTime)
    {
        connection.Open();
        command.CommandText = query;
        mDateTime = Convert.ToDateTime(command.ExecuteScalar());
        connection.Close();
        if (mDateTime < Convert.ToDateTime(ConnectionWithSQL.com_start_date))
            mDateTime = Convert.ToDateTime(ConnectionWithSQL.com_start_date);
        msDateTime.MinDate = ConnectionWithSQL.mDateTime;
        msDateTime.MaxDate = DateTime.Now.Date;

        //msDateTime.Text = DateTime.Now.Date.ToString();
        msDateTime.Value = ConnectionWithSQL.mDateTime;

    }

    public void addpdfdetails(string paramessage, int SpacingBefore, int Fontsize, int IndentationLeft)
    {
        //Document doc = new Document(PageSize.A4, 40, 45, 40, 25);
        Paragraph para = new Paragraph(paramessage);
        para.SpacingBefore = SpacingBefore;
        para.Font.Size = Fontsize;
        para.IndentationLeft = IndentationLeft;
        //doc.Add(para);
    }

    public void accountHelp(DataGridView mDataGridView, string mgridviewname)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        command.CommandText = query;
        connection.Open();
        datareader = command.ExecuteReader();
        int mcolumncount = datareader.FieldCount;
        mDataGridView.AutoGenerateColumns = false;
        if (mgridviewname != "siitemlist" && mgridviewname != "sritemlist" && mgridviewname != "sr_item_help")
        {
            mDataGridView.AutoGenerateColumns = true;
            mDataGridView.Columns.Clear();
            string headertext;
            for (int i = 0; i <= mcolumncount - 1; i++)
            {
                headertext = "Column " + i;
                mDataGridView.Columns.Add(headertext, headertext);
                //mDataGridView.Columns.Add("CustLName", typeof(String));
                mDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        else
            temp_word = "SAnajy";
        mDataSet.Clear();
        int k = 0;
        while (datareader.Read())
        {
            mDataGridView.Rows.Add();
            for (int i = 0; i <= mcolumncount - 1; i++)
            {
                mDataGridView.Rows[k].Cells[i].Value = datareader[i];
            }
            k = k + 1;
        }
        if (mgridviewname == "sisalelistdg")
        {
            mDataGridView.Columns[0].HeaderText = "Inv.num";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "A_N";
            mDataGridView.Columns[3].HeaderText = "S_A";
            mDataGridView.Columns[4].HeaderText = "D_Y";
            mDataGridView.Columns[5].HeaderText = "Amount";
        }
        else if (mgridviewname == "sitaxlist")
        {
            mDataGridView.Columns[0].HeaderText = "Code";
            mDataGridView.Columns[1].HeaderText = "Rate";
            mDataGridView.Columns[2].HeaderText = "Description";
        }
        else if (mgridviewname == "siitemlist" || mgridviewname == "piitemlist")
        {
            mDataGridView.Columns[0].HeaderText = "Type";
            mDataGridView.Columns[1].HeaderText = "Item Code";
            mDataGridView.Columns[2].HeaderText = "Title";
            mDataGridView.Columns[3].HeaderText = "Case";
            mDataGridView.Columns[4].HeaderText = "Box";
            mDataGridView.Columns[5].HeaderText = "Quantity";
            mDataGridView.Columns[6].HeaderText = "Price";
            mDataGridView.Columns[7].HeaderText = "Amount";
            mDataGridView.Columns[3].ValueType = typeof(double);
            mDataGridView.Columns[4].ValueType = typeof(double);
            mDataGridView.Columns[5].ValueType = typeof(double);
            mDataGridView.Columns[6].ValueType = typeof(double);
            mDataGridView.Columns[7].ValueType = typeof(double);
        }

        else if (mgridviewname == "braccountdg")
        {
            mDataGridView.Columns[0].HeaderText = "Name";
            mDataGridView.Columns[1].HeaderText = "City";
            mDataGridView.Columns[2].HeaderText = "A_N";
            mDataGridView.Columns[3].HeaderText = "S_A";
        }
        else if (mgridviewname == "jjtranlist")
        {
            mDataGridView.Columns[0].HeaderText = "Date Sort";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "Doc. No";
            mDataGridView.Columns[3].HeaderText = "Name";
            mDataGridView.Columns[4].HeaderText = "City";
            mDataGridView.Columns[5].HeaderText = "Amount";
            mDataGridView.Columns[6].HeaderText = "Message";
            mDataGridView.Columns[7].HeaderText = "A_n";
            mDataGridView.Columns[8].HeaderText = "S_a";
            mDataGridView.Columns[9].HeaderText = "NA_n";
            mDataGridView.Columns[10].HeaderText = "NS_a";
        }
        else if (mgridviewname == "CustomerListDG")
        {
            mDataGridView.Columns[0].HeaderText = "Name";
            mDataGridView.Columns[1].HeaderText = "City";
            mDataGridView.Columns[2].HeaderText = "Mobile";
            mDataGridView.Columns[3].HeaderText = "Add1";
            mDataGridView.Columns[4].HeaderText = "Add2";
            mDataGridView.Columns[5].HeaderText = "Add3";
            mDataGridView.Columns[6].HeaderText = "Tin";
            mDataGridView.Columns[7].HeaderText = "Budget";
            mDataGridView.Columns[8].HeaderText = "Pin";
            mDataGridView.Columns[9].HeaderText = "Delivery";
            mDataGridView.Columns[10].HeaderText = "Country";
            mDataGridView.Columns[11].HeaderText = "Tax Code";
            mDataGridView.Columns[12].HeaderText = "STD";
            mDataGridView.Columns[13].HeaderText = "O Mobile";
            mDataGridView.Columns[14].HeaderText = "R Mobile";
            mDataGridView.Columns[15].HeaderText = "O Phone1";
            mDataGridView.Columns[16].HeaderText = "O Phone2";
            mDataGridView.Columns[17].HeaderText = "Fax";
            mDataGridView.Columns[18].HeaderText = "Email Id";
            mDataGridView.Columns[19].HeaderText = "Website";
            mDataGridView.Columns[20].HeaderText = "A_N";
            mDataGridView.Columns[21].HeaderText = "S_A";
            mDataGridView.Columns[22].HeaderText = "D_Y";
        }
        else if (mgridviewname == "ItemListDG")
        {
            //[type], item_code, [title],packing,box,price,cat,clo_stk
            mDataGridView.Columns[0].HeaderText = "Type";
            mDataGridView.Columns[1].HeaderText = "Item Code";
            mDataGridView.Columns[2].HeaderText = "Title";
            mDataGridView.Columns[3].HeaderText = "Packing";
            mDataGridView.Columns[4].HeaderText = "Box";
            mDataGridView.Columns[5].HeaderText = "Price";
            mDataGridView.Columns[6].HeaderText = "Catagory";
            mDataGridView.Columns[7].HeaderText = "Clo_stk";
        }
        else if (mgridviewname == "master_item_help")
        {
            //[type], item_code, [title],packing,box,price,cat,clo_stk
            mDataGridView.Columns[0].HeaderText = "Type";
            mDataGridView.Columns[1].HeaderText = "Item Code";
            mDataGridView.Columns[2].HeaderText = "Title";
            mDataGridView.Columns[3].HeaderText = "Packing";
            mDataGridView.Columns[4].HeaderText = "Box";
            mDataGridView.Columns[5].HeaderText = "Price";
            mDataGridView.Columns[6].HeaderText = "Catagory";
            mDataGridView.Columns[7].HeaderText = "Clo_stk";
        }
        else if (mgridviewname == "TaxListDG")
        {
            mDataGridView.Columns[0].HeaderText = "Document Code";
            mDataGridView.Columns[1].HeaderText = "Tax Code";
            mDataGridView.Columns[2].HeaderText = "Rate ";
            mDataGridView.Columns[3].HeaderText = "Discription";
        }
        else if (mgridviewname == "PeriodListDG")
        {
            mDataGridView.Columns[0].HeaderText = "Period";
            mDataGridView.Columns[1].HeaderText = "Start";
            mDataGridView.Columns[2].HeaderText = "End";
            mDataGridView.Columns[3].HeaderText = "Lock";
            mDataGridView.Columns[4].HeaderText = "GP";
            mDataGridView.Columns[5].HeaderText = "Vat";
            mDataGridView.Columns[6].HeaderText = "Data Transfer";
            mDataGridView.Columns[7].HeaderText = "Print Form";
        }
        else if (mgridviewname == "si_party_help")
        {
            mDataGridView.Columns[0].HeaderText = "Name";
            mDataGridView.Columns[1].HeaderText = "City";
            mDataGridView.Columns[2].HeaderText = "A_n";
            mDataGridView.Columns[3].HeaderText = "S_a";
            mDataGridView.Columns[5].HeaderText = "Account Type";
            mDataGridView.Columns[0].Width = 200;
            mDataGridView.Columns[1].Width = 150;
            mDataGridView.Columns[2].Width = 60;
            mDataGridView.Columns[3].Width = 45;
            mDataGridView.Columns[4].Width = 45;
            mDataGridView.Columns[5].Width = 150;
        }
        else if (mgridviewname == "brtranlist" || mgridviewname == "bptranlist")
        {
            mDataGridView.Columns[0].HeaderText = "Date Sort";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "Doc. No";
            mDataGridView.Columns[3].HeaderText = "Name";
            mDataGridView.Columns[4].HeaderText = "City";
            mDataGridView.Columns[5].HeaderText = "Amount";
            mDataGridView.Columns[6].HeaderText = "Chk No.";
            mDataGridView.Columns[7].HeaderText = "Chk Dt.";
            mDataGridView.Columns[8].HeaderText = "Bank";
            mDataGridView.Columns[9].HeaderText = "Pass Date";
            mDataGridView.Columns[10].HeaderText = "Message";
            mDataGridView.Columns[11].HeaderText = "A_n";
            mDataGridView.Columns[12].HeaderText = "S_a";
            mDataGridView.Columns[13].HeaderText = "B_T";
            mDataGridView.Columns[14].HeaderText = "R_p";
        }
        else if (mgridviewname == "bwtranlist" || mgridviewname == "bdtranlist")
        {
            mDataGridView.Columns[0].HeaderText = "Date Sort";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "Doc. No";
            mDataGridView.Columns[3].HeaderText = "Amount";
            mDataGridView.Columns[4].HeaderText = "Message";
            mDataGridView.Columns[5].HeaderText = "A_n";
            mDataGridView.Columns[6].HeaderText = "S_a";
            mDataGridView.Columns[7].HeaderText = "B_T";
            mDataGridView.Columns[8].HeaderText = "R_p";
        }
        else if (mgridviewname == "tr_datagridview")
        {
            mDataGridView.Columns[0].HeaderText = "Date Sort";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "Doc. No";
            mDataGridView.Columns[3].HeaderText = "Title";
            mDataGridView.Columns[4].HeaderText = "Amount";
            mDataGridView.Columns[5].HeaderText = "Message";
            mDataGridView.Columns[6].HeaderText = "A_n";
            mDataGridView.Columns[7].HeaderText = "S_a";
            mDataGridView.Columns[8].HeaderText = "B_T";
            mDataGridView.Columns[9].HeaderText = "R_p";
            mDataGridView.Columns[10].HeaderText = "D_c";
            mDataGridView.Columns[11].HeaderText = "Tran_D_c";
        }
        else if (mgridviewname == "crtranlist" || mgridviewname == "cptranlist")
        {
            mDataGridView.Columns[0].HeaderText = "Date Sort";
            mDataGridView.Columns[1].HeaderText = "Date";
            mDataGridView.Columns[2].HeaderText = "Doc. No";
            mDataGridView.Columns[3].HeaderText = "Name";
            mDataGridView.Columns[4].HeaderText = "City";
            mDataGridView.Columns[5].HeaderText = "Amount";
            mDataGridView.Columns[6].HeaderText = "Message";
            mDataGridView.Columns[7].HeaderText = "A_n";
            mDataGridView.Columns[8].HeaderText = "S_a";
        }
        else if (mgridviewname == "Trading Account" || mgridviewname == "Profit and Loss Account")
        {
            mDataGridView.Columns[0].HeaderText = "A_n";
            mDataGridView.Columns[1].HeaderText = "Particulars";
            mDataGridView.Columns[2].HeaderText = "Amount1";
            mDataGridView.Columns[3].HeaderText = "Particulars";
            mDataGridView.Columns[4].HeaderText = "Amount2";
        }
        else if (mgridviewname == "Capital Account")
        {
            mDataGridView.Columns[0].HeaderText = "A_n";
            mDataGridView.Columns[1].HeaderText = "S_a";
            mDataGridView.Columns[2].HeaderText = "Particulars";
            mDataGridView.Columns[3].HeaderText = "Amount1";
            mDataGridView.Columns[4].HeaderText = "Particulars";
            mDataGridView.Columns[5].HeaderText = "Amount2";
        }
        else if (mgridviewname == "Balance Sheet")
        {
            mDataGridView.Columns[0].HeaderText = "A_n";
            mDataGridView.Columns[1].HeaderText = "S_a";
            mDataGridView.Columns[2].HeaderText = "Particulars";
            mDataGridView.Columns[3].HeaderText = "Amount1";
            mDataGridView.Columns[4].HeaderText = "Amount2";
            mDataGridView.Columns[5].HeaderText = "Particulars";
            mDataGridView.Columns[6].HeaderText = "Amount3";
            mDataGridView.Columns[7].HeaderText = "Amount4";
        }
        else if (mgridviewname == "DayBookMaster")
        {
            //mDataGridView.Columns[0].HeaderText = "Daybook Code";
            //mDataGridView.Columns[1].HeaderText = "A_n";
        }
        else if (mgridviewname == "ChangePeriod")
        {
            mDataGridView.Columns[0].HeaderText = "PRD";
            mDataGridView.Columns[1].HeaderText = "Start";
            mDataGridView.Columns[2].HeaderText = "End";
        }
        else if (mgridviewname == "ledger_account_help")
        {
            mDataGridView.Columns[0].HeaderText = "Desc";
            mDataGridView.Columns[1].HeaderText = "City";
            mDataGridView.Columns[2].HeaderText = "A_n";
            mDataGridView.Columns[3].HeaderText = "S_a";
        }
        data_type = null;
        //alignGridView(mDataGridView, mDataGridView.Columns.Count);
        connection.Close();
    }

    public void check_data_type(string temp_word)
    {
        if (temp_word != null && temp_word != "")
        {
            data_type = null;
            int slash_count = 0;
            if (temp_word.Contains("/"))
            {
                for (int i = 0; i < temp_word.Length; i++)
                {
                    if (temp_word.Substring(i, 1) == "/")
                    {
                        slash_count++;
                    }
                }
                if (slash_count == 2)
                    data_type = "Date";
                else
                    slash_count = 100;
            }
            else
            {
                for (int i = 0; i < temp_word.Length; i++)
                {
                    char c = Convert.ToChar(temp_word.Substring(i, 1));
                    asc_value = Convert.ToInt32(c);
                    if (asc_value >= 48 && asc_value <= 57)
                    {
                        if (data_type == null)
                            data_type = "Numeric";
                    }
                    if (asc_value >= 58 && asc_value <= 100)
                    {
                        data_type = "String";
                    }
                }
            }
        }
    }

    public void invisible_empty_gridview_column(DataGridView mDataGridView)
    {
        string[] report_columns_size = new string[mDataGridView.Columns.Count];
        for (column_pointer = 0; column_pointer < mDataGridView.Columns.Count; column_pointer++)
        {
            for (row_pointer = 0; row_pointer < mDataGridView.RowCount; row_pointer++)
            {
                if (mDataGridView.Rows[row_pointer].Cells[column_pointer].Value != null)
                {
                    temp_word = mDataGridView.Rows[row_pointer].Cells[column_pointer].Value.ToString();
                    temp_word = temp_word.Trim();
                    if (temp_word.Trim().Length > Convert.ToInt32((report_columns_size[column_pointer])))
                    {
                        report_columns_size[column_pointer] = temp_word.Length.ToString();
                    }
                }
            }
        }
        for (int i = 0; i < report_columns_size.Length; i++)
        {
            if (report_columns_size[i] == null)
            {
                mDataGridView.Columns[i].Visible = false;
            }
        }
    }

    public void hide_columns_of_datagridview(DataGridView mDataGridView, string column_numbers)
    {
        var cellArray = column_numbers.Split(new[] { ',' });
        if (cellArray.Length > 0)
        {
            for (int i = 0; i < cellArray.Length; i++)
            {
                mDataGridView.Columns[Convert.ToInt32(cellArray[i].ToString())].Visible = false;
            }
        }
        
    }

    public void delete_empty_gridview_rows(DataGridView mDataGridView)
    {
        for (int row = 0; row < mDataGridView.Rows.Count; ++row)
        {
            bool isEmpty = true;
            for (int col = 0; col < mDataGridView.Columns.Count; ++col)
            {
                object value = mDataGridView.Rows[row].Cells[col].Value;
                if (value != null && value.ToString().Length > 0)
                {
                    isEmpty = false;
                    break;
                }
            }
            if (isEmpty)
            {
                // deincrement (after the call) since we are removing the row
                mDataGridView.Rows.RemoveAt(row--);
            }
        }
    }

    public void multiplerows(DataGridView gdv, string gdvname)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        ConnectionWithSQL.command.CommandText = ConnectionWithSQL.query;
        ConnectionWithSQL.connection.Open();
        ConnectionWithSQL.datareader = ConnectionWithSQL.command.ExecuteReader();

        int mcolumncount = datareader.FieldCount;
     //   if (gdv.Rows.Count >= 2)
            gdv.Rows.Add();
        while (ConnectionWithSQL.datareader.Read())
        {
            gdv.Rows.Add();
            for (int i = 0; i < mcolumncount; i++)
            {
                temp_word = datareader[i].ToString();
                if (temp_word != null && temp_word != " ")
                {
                    if (gdvname == "LEDGER" || gdvname == "Bankrep" || gdvname == "Cashrep")
                        gdv.Rows[gdv.Rows.Count - 2].Cells[i].Value = ConnectionWithSQL.datareader[i];
                    else
                        gdv.Rows[gdv.Rows.Count - 1].Cells[i].Value = ConnectionWithSQL.datareader[i];
                }
            }
            row_pointer++;
        }
        ConnectionWithSQL.connection.Close();
    }

    public static void connectionStart()
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        ConnectionWithSQL.command.CommandText = ConnectionWithSQL.query;
        ConnectionWithSQL.connection.Open();
    }

    public static void fillCombo(ComboBox cbo)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        cbo.Items.Clear();
        //cbo.Items.Add("All");
        command.CommandText = query;
        connection.Open();
        try
        {
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                cbo.Items.Add(Convert.ToString(datareader[0]));
            }
        }
        catch (Exception ex)
        { }
        connection.Close();
    }

    public static void fillCheckListBox(CheckedListBox cbo)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        cbo.Items.Clear();
        //cbo.Items.Add("All");
        command.CommandText = query;
        connection.Open();
        try
        {
            datareader = command.ExecuteReader();
            temp_int = datareader.FieldCount;
            while (datareader.Read())
            {
                if (temp_int > 1)
                {
                    temp_word = null;
                    for (int i = 0; i < temp_int; i++)
                    {
                        temp_word = temp_word + Convert.ToString(datareader[i]).Trim() + ",";
                    }
                    cbo.Items.Add(temp_word);
                }
                else
                    cbo.Items.Add(Convert.ToString(datareader[0]));
            }
        }
        catch (Exception ex)
        { }
        connection.Close();
    }

    public static void fillgrid(string query, DataGridView gdv)
    {
        if (ConnectionWithSQL.connection.State == ConnectionState.Open) { ConnectionWithSQL.connection.Close(); }
        ConnectionWithSQL.command.CommandText = query;
        ConnectionWithSQL.connection.Open();
        try
        {
            dt.Rows.Clear();
            dt.Columns.Clear();
            ConnectionWithSQL.datareader = ConnectionWithSQL.command.ExecuteReader();
            string columnname;
            columncount = datareader.FieldCount;
            columnnamearray = new string[columncount];

            for (i = 0; i < columncount; i++)
            {
                columnname = ConnectionWithSQL.datareader.GetName(i);
                // gdv.Columns.Add(colname, colname);
                dt.Columns.Add(columnname);
                columnnamearray[i] = columnname;
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
        //catch (Exception ex)
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }
        gdv.DataSource = dt;
        ConnectionWithSQL.connection.Close();


        //for (i = 0; i < columncount; i++)
        //{
        //gdv.Columns[i].DataGridView.Width = 12;
        //gdv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middleleft;               
        //(dtTest.Columns[0].DataType == typeof(Int32))
        //if (gdv.Columns[i].DataType == typeof(Int32))
        //{
        //    gdv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middleleft;               
        //}
        //if (ColumnSize <= 2)
        //    gdv.Columns[ColumnIndex].Width = (ColumnSize * 3);
        //else if (ColumnSize > 2 && ColumnSize <= 10)
        //    gdv.Columns[ColumnIndex].Width = (ColumnSize * 2);
        //else
        //    gdv.Columns[ColumnIndex].Width = (ColumnSize);
        //}
    }

    public static void ChangeColumnCaption(DataGridView gdv)
    {
        try
        {
            for (i = 0; i < columncount; i++)
            {
                gdv.Columns[i].HeaderText = columnnamearray[i];
            }
            gdv.DataSource = dt;
        }
        catch (Exception ex)
        {
        }
    }

    public static void ChangeGridColumnSize(DataGridView gdv, int ColumnIndex, int ColumnSize)
    {
        try
        {
            gdv.Columns[ColumnIndex].Width = ColumnSize;
        }
        catch (Exception ex)
        {
        }
    }

    public static void ChangeGridColumnheader(DataGridView gdv, int ColumnIndex, string Columnheader)
    {
        try
        {
            gdv.Columns[ColumnIndex].HeaderText = Columnheader;
        }
        catch (Exception ex)
        { }
    }

    public static void ChangeGridColumnalignment(DataGridView gdv, int ColumnIndex, string alignment)
    {
        try
        {
            if (alignment.Equals("MiddleRight"))
                gdv.Columns[ColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            else
                gdv.Columns[ColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }
        catch (Exception ex)
        {
        }
    }

    public void CodeToFindCommaCounter()
    {
        int mpos = 0, i, mgap = 0, mcounter = 0;

        for (i = 0; i <= query.Length; i++)
        {
            mpos = query.IndexOf(',', mgap);

            if (mpos > 0)
            {
                mgap = mgap + mpos + 1;
                mcounter = mcounter + 1;
            }
        }
    }

    //public void pdfprintingsample()
    //{
    //    //Variables
    //    bool[] bCode = new bool[95]; //barcode bit data array
    //    bool bValidCode = false; //flag that indicates a valid code
    //    const double dPrintPenSize = 3.0, //size of printing pen (33mm)
    //    dPrintHeight = 20.0, //height of printing area (2.5cm)
    //    dPrintXOffset = 2, //offsets used when printing
    //    dPrintYOffset = 2;
    //    const int iPrintWidth = 100, //width of printing area
    //    iXOffset = 2; //X offset (padding)


    //    PrintDialog pDia = new PrintDialog();
    //    PrinterSettings ps = new PrinterSettings();
    //    pDia.Document = printDocumentMessageBoxTest;
    //    pDia.Document.DocumentName = "Your filename here";

    //    ps.PrinterName = "CutePDF Writer";
    //    ps.PrintToFile = false;
    //    ps.PrintFileName = "C:\\" + pDia.Document.DocumentName + ".pdf";

    //    // take printer settings from the dialog and set into the PrintDocument object
    //    pDia.Document.OriginAtMargins = true;
    //    ps.DefaultPageSettings.Margins.Left = 2;
    //    printDocumentMessageBoxTest.PrinterSettings = ps;

    //    // start the printing process, catch exceptions
    //    try
    //    {
    //        printDocumentMessageBoxTest.Print();
    //    }
    //    catch (Exception exc)
    //    {
    //        MessageBox.Show("Printing error!\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

}
