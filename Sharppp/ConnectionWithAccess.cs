using System;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Net;
using Newtonsoft.Json;

class ConnectionWithAccess
{
    # region declaration

    public static bool BoolConnectServer = true;

    public static OleDbConnection connection = new OleDbConnection();
    public static OleDbConnection connection2 = new OleDbConnection();
    public static DataSet mDataSet = new DataSet();
    public static OleDbCommand command = new OleDbCommand();
    public static OleDbCommand command2 = new OleDbCommand();
    public static OleDbDataReader datareader;
    public static OleDbDataReader datareader2;
    public static OleDbDataAdapter dataadapter1;

    public static string outputDate = "", prd_lock, stOutput;
    public static string databasename;
    public static string[] company_details;
    public static string[] tablename = new string[100];
    //public static string[] data_from_company_file;
    public static string[] period_array;
    public static string[] columnnamearray = new string[25];
    public static string[] report_columns_size;
    public static string[] report_columns_name;
    public static string[] report_column_header;
    public static string[] report_column_type;
    public static string[] tab_details;
    public static int[] datetemparray;
    public static string moprd, mprd, mnew_prd, msdate, medate,master_a_n,master_desc,master_city, ma_n, ms_a, md_y, mna_n, mns_a, md_n, mdesc, mcity, com_start_date, com_end_date, mtpt, mbillx2 = "N", delivery_desc,mr_p;
    public static string mitemtype, mitemcode, mitemdesc, macc_desc, mtax_desc, temp_prd, temp_old_prd, sales_purchase_transfer;
    public static string j1a_n, j1s_a, j2a_n, j2s_a;
    public static int md_c, mtq_cs, mwoodcase, mtx_code, mtx_desc, total_companies;
    public static double mtax_rate, gp_percent, use_sql_access;
    public static double gross_profit, closing_stock, net_profit, value1, value2, value3, value4, temp_double;
    public static DateTime mDateTime;
    public static string query;
    public static string mNIK = "", mdrive, file_type, use_login_password;
    public static string mDataFile, mpdffile, df_filename;
    public static string line, report_file_location;
    public static string emerg_oprd, emerg_nprd;
    public static string muser, companyName, mpassword, company_font,com_senderid;
    //public static string coname, coadd1, coadd2, coadd3, cocity, coowner, costatus1, costatus2, covattax, copannumber, cobillformat;
    //public static string copin, cooffice_phone, resi_phone, comobile1, comobile2;
    //public static string coemail, coscr1, coscr2, coscr3, cobstno, cotinnum, colbtnum;
    //public static string coitnumber, cointnumber2, cocoments, coownerdob, costatus;
    //public static string cobankacnum, covattinnum, covatcstnum, cowebsite, cobankneft, cobankname;
    public static string accountname, accountaddress, accountcontact, accountbalance, accountemail, accountcity, accounttype;
    public static string bankname, bankaddress, bankcity, bankaccno, bankneft;
    public static string imagelocation, imagetype;
    public static string bank_a_n, cash_a_n;
    public static string mtextfilename, data_entry_working;
    public static int i = 0, columncount = 0;
    public static DataTable dt = new DataTable();
    public static string message_box;
    public static string mUserFeatures;
    public static string data_drive;
    public static string setup_drive;
    public static string font_name, font_size;
    public static string data_type;
    public static int column_pointer, row_pointer;
    public static int asc_value, total_line_length;
    public static string temp_word, ExcelFileName;
    public static string extra_form_use, new_additional_a_n, fix_account_a_n;
    public static int temp_int;
    public static int slashposition, array_record;
    public static string actual_filename, file_folder;
    List<string> temporary_list_array = new List<string>();

    public static string strResult;
    string strServerUrl = "http://smartifyindia.co.in:8083/";
    public static string strImageUploadUrl = "http://smartifyindia.co.in:3000/uploadfile";
    public static string strNotificationUrl = "http://smartifyindia.co.in:8080/api/sendPushNotification";
    public static string strBinUploadUrl = "http://smartifyindia.co.in:3000/binupload";
    public static string strExcelFilePath = "";


    public class QueryParams
    {
        public string paramName { get; set; }
        public DateTime paramValue { get; set; }
    }

    public static List<QueryParams> QueryParamList {get; set; }

    # endregion

    static ConnectionWithAccess()
    {
        //connection.ConnectionString = "data source = .; integrated security = true; initial catalog = " + ConnectionWithAccess.mNIK;
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;  //Kunal
        //connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\\acc\\AP1\\Ap1.MDB";
        command.Connection = connection;
    }

    public static void add_contains_of_company_details_in_excel_sheet()
    {
        if (ConnectionWithAccess.mUserFeatures.Substring(41, 1) == "Y")
        {
            for (int i = 1; i < 6; i++)
            {
                if (company_details[i].Trim().Length > 3)
                    stOutput += company_details[i] + "\r\n";
            }
        }
    }

    public static string encode(string old_english)
    {
        int asc_value;
        string encoded = null;
        if (old_english != null)
        {
            encoded = null;
            for (int i = 0; i < old_english.Length; i++)
            {
                char c = Convert.ToChar(old_english.Substring(i, 1));
                asc_value = Convert.ToInt32(c);
                if (asc_value == 1)
                    c = Convert.ToChar(asc_value + 228);
                else if (asc_value == 32)
                    c = Convert.ToChar(asc_value + 196);
                else if (asc_value >= 33 && asc_value < 65)
                    c = Convert.ToChar(asc_value + 90);
                else if (asc_value >= 65 && asc_value < 75)
                    c = Convert.ToChar(asc_value + 92);
                else if (asc_value >= 75 && asc_value < 85)
                    c = Convert.ToChar(asc_value + 94);
                else if (asc_value >= 85 && asc_value < 97)
                    c = Convert.ToChar(asc_value + 96);
                else if (asc_value >= 97 && asc_value < 107)
                    c = Convert.ToChar(asc_value + 98);
                else if (asc_value >= 107 && asc_value < 117)
                    c = Convert.ToChar(asc_value + 100);
                else if (asc_value >= 117 && asc_value < 126)
                    c = Convert.ToChar(asc_value + 102);
                else
                    temp_word = "Sanjay";
                encoded += Convert.ToString(c);
            }
        }
        encoded = old_english;
        return encoded;
    }

    public static string decode(string encoded)
    {
        int asc_value;
        string decoded = null;
        if (encoded != null)
        {

            for (int i = 0; i < encoded.Length; i++)
            {
                char c = Convert.ToChar(encoded.Substring(i, 1));
                asc_value = Convert.ToInt32(c);
                if (asc_value > 123 && asc_value < 155)
                    c = Convert.ToChar(asc_value - 90);
                else if (asc_value >= 157 && asc_value < 167)
                    c = Convert.ToChar(asc_value - 92);
                else if (asc_value >= 169 && asc_value < 179)
                    c = Convert.ToChar(asc_value - 94);
                else if (asc_value >= 181 && asc_value < 193)
                    c = Convert.ToChar(asc_value - 96);
                else if (asc_value >= 195 && asc_value < 205)
                    c = Convert.ToChar(asc_value - 98);
                else if (asc_value >= 207 && asc_value < 217)
                    c = Convert.ToChar(asc_value - 100);
                else if (asc_value >= 219 && asc_value < 228)
                    c = Convert.ToChar(asc_value - 102);
                else if (asc_value == 228)
                    c = Convert.ToChar(32);
                decoded += Convert.ToString(c);
            }
        }
               return decoded;
    }

    public static void ToCsV(DataGridView dGV, string filename)
    {
        stOutput = "";
        add_contains_of_company_details_in_excel_sheet();
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
            temp_word = stLine.Replace("\t", "");
            if (temp_word != "")
                stOutput += stLine + "\r\n";
        }
        filename = remove_filename_error(filename);
        create_file_folder(filename);
        Encoding utf16 = Encoding.GetEncoding(1254);
        byte[] output = utf16.GetBytes(stOutput);
        FileStream fs = new FileStream(filename, FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(output, 0, output.Length); //write the encoded file
        bw.Flush();
        bw.Close();
        fs.Close();
    }

    public static string remove_filename_error(string filename)
    {
        if (filename != null && filename.Trim() != "")
        {
            filename = filename.Replace("/", "");
            filename = filename.Replace("(", "");
            filename = filename.Replace(")", "");
            filename = filename.Replace("<", "");
            filename = filename.Replace(">", "");
            filename = filename.Replace("\"", "~");
            filename = filename.Replace("  ", " ");
        }
        return filename;
    }

    public static void export(DataGridView dataGridView1, string filename)
    {
        if (ConnectionWithAccess.mUserFeatures.Substring(42, 1) == "Y")
        {
            if (ConnectionWithAccess.mUserFeatures.Substring(43, 1) == "Y")
                filename += "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes;
            if (filename.Contains("GST"))
                ExcelFileName = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\gst_reports\\" + filename + ".xls";
            else
            ExcelFileName = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\excel Reports\\" + filename + ".xls";

            //ExcelFileName = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\reports\\Ledger_" + mdesc + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + ".xls";  //+  DateTime.Now ;
            ToCsV(dataGridView1, ExcelFileName);
        }
    }

    public static string convertDate(string inputDate)
    {
        string outputDate;
        outputDate = "convert(varchar(2), datepart(day, " + inputDate + ")) + '/' +  convert(varchar(2), datepart(month, " + inputDate + ")) +  '/' +  convert(varchar(4), datepart(year, " + inputDate + "))";
        return outputDate;
    }

    public ConnectionWithAccess()
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
    if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
       
        try
        {
            ConnectionWithAccess.connection.Open();
            ConnectionWithAccess.command.ExecuteNonQuery();
            ConnectionWithAccess.connection.Close();
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
       
    }

    public static void open_executenonquery_close()
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
        ConnectionWithAccess.connection.Open();
        ConnectionWithAccess.command.ExecuteNonQuery();
        ConnectionWithAccess.connection.Close();
    }

    public void ConnectionCommandWithReader()
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        try
        {
            command.CommandText = ConnectionWithAccess.query;
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
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        command.CommandText = "use " + ConnectionWithAccess.databasename;
        try
        {
            ConnectionWithAccess.connection.Open();
            ConnectionWithAccess.command.ExecuteNonQuery();
            ConnectionWithAccess.connection.Close();
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
        query = "select prd, start,[end] from " + ConnectionWithAccess.tablename[50] + " order by [end]";
        DataTable dtData1 = fGetDataTable();
        if (dtData1 != null && dtData1.Rows.Count > 0)
        {
            if (dtData1.Rows[0][0] != null)
            {
                temp_old_prd = dtData1.Rows[0][0].ToString();
            }
            if (dtData1.Rows[1][1] != null)
            {
                com_start_date = dtData1.Rows[1][1].ToString();
                com_start_date = com_start_date.Substring(0, com_start_date.IndexOf(" "));
            }
            if (dtData1.Rows[dtData1.Rows.Count - 1][0] != null)
            {
                com_end_date = dtData1.Rows[dtData1.Rows.Count - 1][2].ToString();
                com_end_date = com_end_date.Substring(0, com_end_date.IndexOf(" "));
            }
        }
    }

    public static string get_old_prd_name(string prd)
    {
        char c = Convert.ToChar(prd.ToUpper());
        asc_value = Convert.ToInt32(c);
        emerg_oprd = Convert.ToString(Convert.ToChar(asc_value - 1));
        return emerg_oprd;
    }

    public static string get_next_prd_name(string prd)
    {
        char c = Convert.ToChar(prd.ToUpper());
        asc_value = Convert.ToInt32(c);
        emerg_nprd = Convert.ToString(Convert.ToChar(asc_value + 1));
        return emerg_nprd;
    }

    public void retrieval(ComboBox mComboBox)
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        connection.Open();
        mComboBox.Items.Clear();
        command.CommandText = query;
        DataTable dtData1 = fGetDataTable();

        if (dtData1 != null && dtData1.Rows.Count > 0)
        {
            if (dtData1.Rows.Count == 1)
            {
                temp_word = dtData1.Rows[0][0].ToString();
                mComboBox.Items.Add(temp_word);
            }
            else
            {
                int mcolumncount = dtData1.Columns.Count;
                for (int iRowCount = 0; iRowCount < dtData1.Rows.Count; iRowCount++)
                {
                    if (query.Substring(0, 16) != "select distinct tpt" && query.Substring(0, 26) != "select distinct d_c,[desc]")
                    {
                        if (dtData1.Rows[iRowCount][0].ToString().Trim() != "" && dtData1.Rows[iRowCount][0].ToString() != null)
                            mComboBox.Items.Add(dtData1.Rows[iRowCount][0].ToString());
                    }
                    else
                    {
                        if (query.Substring(0, 16) == "select distinct tpt")
                            mComboBox.Items.Add(dtData1.Rows[iRowCount][0].ToString() + "," + dtData1.Rows[iRowCount][1].ToString());
                        else if (query.Substring(0, 26) == "select distinct d_c,[desc]")
                            mComboBox.Items.Add(dtData1.Rows[iRowCount][1].ToString());
                    }
                }
            }
        }
        if (mComboBox.Items.Count >= 1)
        {
            mComboBox.SelectedIndex = 0;
        }
        if (mComboBox.Items.Count == 1)
            if (query.Substring(0, 19) != "select distinct tpt")
                mComboBox.Enabled = false;
            else
                mComboBox.Enabled = true;
        else
            mComboBox.Enabled = true;
        mComboBox.Refresh();
    }

    public void add_retrieval(ComboBox mComboBox)
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        connection.Open();
        command.CommandText = query;
        try
        {
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                mComboBox.Items.Add(datareader[0]);
            }
            connection.Close();
            if (mComboBox.Items.Count >= 1)
            {
                mComboBox.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            //MessageBox.Show("Day Book Not Found"); 
        }
        connection.Close();
        if (mComboBox.Items.Count == 1)
            mComboBox.Enabled = false;
        else
            mComboBox.Enabled = true;
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

    public void addpdfdetails(string paramessage, int SpacingBefore, int Fontsize, int IndentationLeft)
    {
        //Document doc = new Document(PageSize.A4, 40, 45, 40, 25);
        Paragraph para = new Paragraph(paramessage);
        para.SpacingBefore = SpacingBefore;
        para.Font.Size = Fontsize;
        para.IndentationLeft = IndentationLeft;
        //doc.Add(para);
    }

    public static bool CheckItemExists(string StrQuery)
    {
        DataTable dtData = new DataTable();
        int iItemUsedCount = 0;
        bool isItemUsed = false;
        try
        {
            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
            connection.Open();
            ConnectionWithAccess.command.CommandText = StrQuery;
            iItemUsedCount = Convert.ToInt32(command.ExecuteScalar());
            if (iItemUsedCount > 0)
                isItemUsed = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return isItemUsed;
    }

    private void getTotal(DataGridView mDataGridView, int total_of_column)
    {
        temp_double = 0;
        for (row_pointer = 0; row_pointer < mDataGridView.Rows.Count; row_pointer++)
        {
            if (mDataGridView.Rows[row_pointer].Cells[total_of_column].Value != null && mDataGridView.Rows[row_pointer].Cells[total_of_column].Value.ToString() != "")
                if (Convert.ToDouble(mDataGridView.Rows[row_pointer].Cells[total_of_column].Value.ToString()) != 0)
                    temp_double = temp_double + Convert.ToDouble(mDataGridView.Rows[row_pointer].Cells[total_of_column].Value.ToString());
        }
        ConnectionWithAccess.connectionStart();
        try
        {
            mDataGridView.Rows.Add();
            //mDataGridView.Rows[mDataGridView.Rows.Count - 1].Cells[total_of_column - 1].Value = "Total ";
            mDataGridView.Rows[mDataGridView.Rows.Count - 1].Cells[total_of_column].Value = Convert.ToString(temp_double);
        }
        catch (Exception ex)
        {
        }
        ConnectionWithAccess.connection.Close();
    }

    public void accountHelp_datatable_GridColumns(DataGridView mDataGridView, string mgridviewname)
    {
        DataTable dtData = new DataTable();
        try
        {
            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
            connection.Open();
            var adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dtData);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            connection.Close();
        }
        mDataGridView.AutoGenerateColumns = false;
        mDataGridView.DataSource = null;
        mDataGridView.DataSource = dtData;
    }

    //public void fUpdateInsertDeleteData()
    //{
    //    OleDbConnection conn = new OleDbConnection();
    //    String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
    //    try
    //    {
    //        conn.ConnectionString = connection;
    //        conn.Open();

    //        OleDbCommand oCmd = new OleDbCommand();
    //        oCmd.CommandText = query;
    //        oCmd.Connection = conn;

    //        if (QueryParamList != null && QueryParamList.Count > 0)
    //        {
    //            for (int i = 0; i < QueryParamList.Count; i++)
    //            {
    //                oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
    //            }
    //        }

    //        oCmd.ExecuteNonQuery();
    //        if (QueryParamList != null && QueryParamList.Count > 0)
    //            QueryParamList.Clear();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message + " Line number 584");
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //}'

    public void fUpdateInsertDeleteData(bool bConnectServer = false, bool bSaveLocaldb = true, bool InsertBothServerLocal = false)
    {
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        if ((bConnectServer && BoolConnectServer == true) || InsertBothServerLocal == true)
        {
            string strJsonQueryData = ConvertInsertUpdateQueryToJsonQuery(query);
            string srtQueryURI = strServerUrl;
            if (query.Trim().ToLower().StartsWith("insert"))
                srtQueryURI += "insert";
            else if (query.Trim().ToLower().StartsWith("update"))
                srtQueryURI += "update";
            else if (query.Trim().ToLower().StartsWith("delete"))
                srtQueryURI += "delete";
            else
                srtQueryURI += "insert";

            strResult = PostMessageToURLHttp(srtQueryURI, strJsonQueryData);
        }
        if ((bSaveLocaldb || BoolConnectServer == false) || InsertBothServerLocal == true)
        {
            try
            {
                conn.ConnectionString = connection;
                conn.Open();

                OleDbCommand oCmd = new OleDbCommand();
                oCmd.CommandText = query;
                oCmd.Connection = conn;

                if (QueryParamList != null && QueryParamList.Count > 0)
                {
                    for (int i = 0; i < QueryParamList.Count; i++)
                    {
                        oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                    }
                }

                oCmd.ExecuteNonQuery();
                if (QueryParamList != null && QueryParamList.Count > 0)
                    QueryParamList.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Line number 997");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    private string PostMessageToURLHttp(string url, string parameters)
    {
        strResult = string.Empty;
        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(parameters);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (result != null)
                {
                    strResult = result.ToString();
                    //var serializer = new JavaScriptSerializer();
                    //cd = serializer.Deserialize<CandidateData>(result);
                }
            }
        }
        catch (Exception ex)
        {
            //if (ex.Message.Contains("500"))
            //{
            //    if (File.Exists("C:\\sharp\\smartify\\ChargerNotWorking.WAV"))
            //    {
            //        SoundPlayer simpleSound = new SoundPlayer("C:\\sharp\\smartify\\ChargerNotWorking.WAV");
            //        simpleSound.Play();
            //    }
            //}
            //else
            //{
            var result = ex.Message;
            MessageBox.Show(ex.Message + " Line number 2149");
            //}
            //System.Environment.Exit(1);
            //System.Windows.Forms.Application.Exit();
            //Application.Exit();
        }
        return strResult;
    }

    public static string ConvertInsertUpdateQueryToJsonQuery(string InsertQuery)
    {
        InsertQuery = InsertQuery.Replace("   ", " ");
        InsertQuery = InsertQuery.Replace("  ", " ");
        InsertQuery = InsertQuery.Replace(" (", "(");
        InsertQuery = InsertQuery.Replace(", ", ",");
        InsertQuery = InsertQuery.Replace(" ,", ",").Trim();

        string TempWord = InsertQuery;
        string tempword0 = "";
        string tempword1 = "";
        string tempword2 = "";
        string tempword3 = "";
        string tempword4 = "";
        string tempword5 = "";
        string tempword6 = "";

        string InsertfileName = "";
        string InsertFieldName = "";
        string FieldWithData = "";
        string WhereString = "";
        string[] InsertField;
        string[] InsertData;
        string[] WhereData;
        if (TempWord.Length > 0)
        {
            if (TempWord.ToLower().Contains("insert into"))
            {
                InsertfileName = TempWord.Substring(TempWord.IndexOf("insert into") + 12, TempWord.IndexOf("(") - TempWord.IndexOf("insert into") - 12).Trim();
                InsertfileName = InsertfileName.Replace("[", "").Trim();
                InsertfileName = InsertfileName.Replace("]", "").Trim();

                InsertFieldName = TempWord.Substring(TempWord.IndexOf("(") + 1, TempWord.IndexOf(")") - TempWord.IndexOf("(") - 1);
                InsertField = InsertFieldName.Split(new[] { ',' });
                if (TempWord.Substring(TempWord.Length - 1, 1) == "\"")
                {
                    FieldWithData = TempWord.Substring(TempWord.IndexOf("values(") + 7, TempWord.Length - TempWord.IndexOf(")") - 10);
                }
                else
                {
                    FieldWithData = TempWord.Substring(TempWord.IndexOf("values(") + 7, TempWord.Length - TempWord.IndexOf(")") - 10); // CHECKED WITH LAST NEMURIC
                    if (FieldWithData.Substring(FieldWithData.Length - 1, 1) == ")")
                    {
                        FieldWithData = FieldWithData.Substring(0, FieldWithData.Length - 1);
                    }
                }
                if (FieldWithData.Contains("'"))
                {
                    //FieldWithData = FieldWithData.Replace("0 ", "0");
                    InsertData = FieldWithData.Split(new[] { ',' });
                    for (int i = 0; i < InsertData.Length; i++)
                    {
                        InsertData[i] = "";
                    }
                    temp_int = 0;
                    tempword5 = FieldWithData;
                    tempword6 = "";
                    //tempword7 = "";
                    for (int i = 0; i < FieldWithData.Length; i++)
                    {
                        if (FieldWithData.Length - i == 1)
                        {
                            InsertData[temp_int] = tempword5;
                            i = FieldWithData.Length;
                        }
                        else if (FieldWithData.Substring(i, 2) == "''")
                        {
                            InsertData[temp_int] = "";
                            temp_int++;
                            if (tempword5.Length > 2)
                            {
                                tempword5 = tempword5.Substring(3, tempword5.Length - 3);
                                i = i + 2;
                                tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i - 1);
                            }
                            else
                                i = FieldWithData.Length;
                        }
                        else if (FieldWithData.Substring(i, 1) == "'")
                        {
                            tempword6 = FieldWithData.Substring(i + 1, FieldWithData.Length - i - 1);
                            if (tempword6.Contains("'"))
                                tempword6 = tempword6.Substring(0, tempword6.IndexOf("'"));
                            else
                                i = FieldWithData.Length;
                            InsertData[temp_int] = tempword6;
                            temp_int++;
                            if (FieldWithData.Length > i + tempword6.Length + 2)
                            {
                                tempword5 = FieldWithData.Substring(i + tempword6.Length + 3, FieldWithData.Length - tempword6.Length - i - 3);
                                //tempword5 = tempword5.Substring(tempword6.Length + 3, tempword5.Length - tempword6.Length - 3);
                                i = i + tempword6.Length + 2;
                                tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i - 1);
                            }
                            else
                                i = FieldWithData.Length;
                        }
                        else
                        {
                            if (tempword5.IndexOf(",") >= 0)
                            {
                                tempword6 = tempword5.Substring(0, tempword5.IndexOf(","));
                                InsertData[temp_int] = tempword6;
                                temp_int++;
                                tempword5 = FieldWithData.Substring(i + tempword6.Length + 1, FieldWithData.Length - tempword6.Length - i - 1);
                                //tempword5 = tempword5.Substring(2, tempword5.Length - tempword6.Length - 1);
                                i = i + tempword6.Length;
                                tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i - 1);
                            }
                            else
                            {
                                tempword6 = tempword5;
                                InsertData[temp_int] = tempword6;
                                i = FieldWithData.Length;
                            }
                        }
                    }
                }
                else
                    InsertData = FieldWithData.Split(new[] { ',' });

                for (int i = 0; i < InsertField.Length; i++)
                {
                    InsertField[i] = InsertField[i].Replace("[", "");
                    InsertField[i] = InsertField[i].Replace("]", "").Trim();
                    if (InsertData[i] == "False")
                        InsertData[i] = "0";
                    else if (InsertData[i] == "True")
                        InsertData[i] = "1";
                    else
                    {
                        InsertData[i] = InsertData[i].Replace("'", "").Trim();
                        InsertData[i] = InsertData[i].Replace("\\", "/");
                    }
                }
                tempword1 = "{ " + Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                //tempword1 = "{ " + Environment.NewLine + "\t" + "\"database\"" + ": " + "\"" + ConnectionWithAccess.databasename.Trim() + "\"" + ",";
                //tempword1 += Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" + 
                InsertfileName.Trim() + "\"" + "," +
                Environment.NewLine + "\t" + "\"data\"" + ": [{";
                for (int i = 0; i < InsertField.Length; i++)
                {
                    tempword2 += Environment.NewLine + "\t" + "\t" + "\"" + InsertField[i] + "\"" + ": " + "\"" + InsertData[i] + "\"" + ",";
                }
                tempword2 = tempword2.Substring(0, tempword2.Length - 1);
                tempword3 = Environment.NewLine + "\t" + "}" + "]" +
                Environment.NewLine + "}";
                TempWord = tempword1 + tempword2 + tempword3;
                TempWord = TempWord.Replace("`", ",");
            }

            else if (TempWord.ToLower().Substring(0, 6) == "update")
            {
                InsertfileName = TempWord.Substring(TempWord.ToLower().IndexOf("update") + 7, TempWord.ToLower().IndexOf(" set ") - TempWord.ToLower().IndexOf("update") - 7).Trim();
                //InsertfileName = TempWord.Substring(TempWord.ToLower().IndexOf("update") + 7, TempWord.ToLower().IndexOf(" set ") +1).Trim();
                InsertfileName = InsertfileName.Replace("[", "");
                InsertfileName = InsertfileName.Replace("]", "");
                FieldWithData = TempWord.Substring(TempWord.ToLower().IndexOf(" set ") + 4, TempWord.ToLower().IndexOf("where") - TempWord.ToLower().IndexOf(" set ") - 4).Trim();
                FieldWithData = FieldWithData.Replace(", ", ",");
                //FieldWithData = FieldWithData.Replace("[", "");
                //FieldWithData = FieldWithData.Replace("]", "");

                InsertField = FieldWithData.Split(new[] { ',' });


                if (FieldWithData.Contains("'"))
                {
                    int NoOfSingleQuotes = 0;
                    for (int i = 0; i < FieldWithData.Length; i++)
                    {
                        if (FieldWithData.Substring(i, 1) == "'")
                        {
                            NoOfSingleQuotes++;
                        }
                    }
                    //FieldWithData = FieldWithData.Replace("0 ", "0");
                    if (NoOfSingleQuotes > 2)
                    {
                        InsertField = FieldWithData.Split(new[] { ',' });
                        for (int i = 0; i < InsertField.Length; i++)
                        {
                            InsertField[i] = "";
                        }
                        temp_int = 0;
                        tempword5 = FieldWithData;
                        tempword6 = "";
                        //tempword7 = "";
                        Boolean StringDataFound = false;
                        for (int i = 0; i < FieldWithData.Length; i++)
                        {
                            if (FieldWithData.Substring(i, 1) == "," && StringDataFound == false)
                            {
                                int tempInt = (FieldWithData.Length - tempword5.Length);
                                InsertField[temp_int] = FieldWithData.Substring(tempInt, i - tempInt);
                                temp_int++;
                                tempword5 = FieldWithData.Substring(i + 1, FieldWithData.Length - i - 1);
                                tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i - 1);
                                i = i + 2;
                            }
                            else if (tempword5.Contains("'',") && FieldWithData.Substring(i, 3) == "'',")
                            {
                                int tempInt = (FieldWithData.Length - tempword5.Length);
                                InsertField[temp_int] = FieldWithData.Substring(tempInt, i - tempInt + 2);

                                //InsertField[temp_int] = FieldWithData.Substring(0, i + 2);
                                temp_int++;
                                tempword5 = FieldWithData.Substring(i + 3, FieldWithData.Length - i - 3);
                                i = i + 2;
                                tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i - 1);
                            }
                            else if (tempword5.Contains("',") && FieldWithData.Substring(i, 2) == "',")
                            {
                                int tempInt = (FieldWithData.Length - tempword5.Length);
                                InsertField[temp_int] = FieldWithData.Substring(tempInt, i - tempInt + 1);

                                //InsertField[temp_int] = FieldWithData.Substring(0, i + 1);
                                temp_int++;
                                tempword5 = FieldWithData.Substring(i + 2, FieldWithData.Length - i - 2);
                                i = i + 2;
                                tempword3 = FieldWithData.Substring(i - 1, FieldWithData.Length - i - 1);
                            }

                            else if (StringDataFound == false && FieldWithData.Substring(i, 1) == "'")
                            {
                                if (tempword5.IndexOf("',") > 0)
                                {
                                    int tempInt2 = tempword5.IndexOf("',");
                                    InsertField[temp_int] = FieldWithData.Substring(FieldWithData.Length - tempword5.Length, tempword5.IndexOf("',") + 1);
                                    tempword5 = FieldWithData.Substring(FieldWithData.Length - tempword5.Length + InsertField[temp_int].Length + 1, tempword5.Length - InsertField[temp_int].Length - 1);
                                    i = FieldWithData.Length - tempword5.Length - 1;
                                    tempword3 = FieldWithData.Substring(i, FieldWithData.Length - i);
                                    temp_int++;
                                    i = i + 2;
                                }
                                else
                                {
                                    if (tempword5 != "\"")
                                        tempword5 = tempword5.Substring(0, tempword5.IndexOf("=") - 1) + " " + tempword5.Substring(tempword5.IndexOf("="), tempword5.Length - tempword5.IndexOf("="));
                                    InsertField[temp_int] = tempword5;
                                    i = FieldWithData.Length;
                                }
                            }
                        }
                        if (tempword5 != "")
                        {
                            if (InsertField[InsertField.Length - 1] == "")
                            {
                                InsertField[InsertField.Length - 1] = tempword5;
                                tempword5 = "";
                            }
                        }
                    }
                    else
                    {
                        InsertField = new string[1];
                        InsertField[0] = FieldWithData.ToString();
                    }
                }
                else
                    InsertField = FieldWithData.Split(new[] { ',' });

                WhereString = TempWord.Substring(TempWord.ToLower().IndexOf("where") + 5, TempWord.Length - TempWord.ToLower().IndexOf("where") - 5);
                WhereString = WhereString.Replace("[", "");
                WhereString = WhereString.Replace("]", "").Trim();
                WhereData = WhereString.Split(new[] { ',' });
                WhereString = "";
                for (int i = 0; i < WhereData.Length; i++)
                {
                    WhereData[i] = "\"" + WhereData[i].Trim() + " ,";
                    WhereString += WhereData[i];
                }
                WhereString = WhereString.Substring(0, WhereString.Length - 1);

                if (InsertField.Length != 1)
                {
                    for (int i = 0; i < InsertField.Length; i++)
                    {
                        //InsertField[i] = InsertField[i].Replace("[", "").Trim();
                        //InsertField[i] = InsertField[i].Replace("]", "").Trim();
                        InsertField[i] = InsertField[i].Replace("'", "\"").Trim();
                        InsertField[i] = InsertField[i].Replace("=", ":").Trim();
                        InsertField[i] = InsertField[i].Replace(" : ", "\": ").Trim();
                        InsertField[i] = InsertField[i].Replace("\\", "/").Trim();
                    }
                    tempword1 = "{ " + Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                    InsertfileName + "\"" + "," + Environment.NewLine + "\t" + "\"data\"" + ": {";

                    //tempword1 = "{ " + Environment.NewLine + "\t" + "\"database\"" + ": " + "\"" + ConnectionWithAccess.databasename.Trim() + "\"" + ",";
                    //tempword1 += Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                    //InsertfileName.Trim() + "\"" + "," + Environment.NewLine + "\t" + "\"data\"" + ": {";

                    for (int i = 0; i < InsertField.Length; i++)
                    {
                        if (InsertField[i] != "")
                            tempword2 += Environment.NewLine + "\t" + "\t" + "\"" + InsertField[i] + ", ";
                        //+ "\"" + InsertData[i] + "\"" + ",";
                    }
                }
                else
                {
                    tempword1 = "{ " + Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                    InsertfileName + "\"" + "," + Environment.NewLine + "\t" + "\"data\"" + ": {";

                    //tempword1 = "{ " + Environment.NewLine + "\t" + "\"database\"" + ": " + "\"" + ConnectionWithAccess.databasename.Trim() + "\"" + ",";
                    //tempword1 += Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                    //InsertfileName.Trim() + "\"" + "," + Environment.NewLine + "\t" + "\"data\"" + ": {";
                    string TempFieldName = "";
                    string TempFieldData = "";


                    //InsertField[0] = InsertField[0].Replace(" ", "").Trim();

                    //InsertField[0] = InsertField[0].Replace("[", "").Trim();
                    //InsertField[0] = InsertField[0].Replace("]", "").Trim();
                    InsertField[0] = InsertField[0].Replace("'", "").Trim();
                    InsertField[0] = InsertField[0].Replace("\"", "").Trim();
                    if (InsertField[0].Contains("="))
                    {
                        TempFieldName = InsertField[0].Substring(0, InsertField[0].IndexOf("=")).TrimEnd();
                        TempFieldData = InsertField[0].Substring(InsertField[0].IndexOf("=") + 1, InsertField[0].Length - InsertField[0].IndexOf("=") - 1).TrimStart();
                    }
                    tempword2 += Environment.NewLine + "\t" + "\t" + "\"" + TempFieldName + "\" : \"" + TempFieldData + "\", ";
                }
                tempword2 = tempword2.Substring(0, tempword2.Length - 2);
                tempword3 = Environment.NewLine + "\t" + "},";
                tempword4 = Environment.NewLine + "\t" + "\"" + "where" + "\"" + " : " +
                WhereString + "\"" +
                Environment.NewLine + "}";
                TempWord = tempword1 + tempword2 + tempword3 + tempword4;
                TempWord = TempWord.Replace("`", ",");
            }
            else if (TempWord.ToLower().Contains("delete"))
            {
                if (TempWord.Contains("where"))
                {
                    InsertfileName = TempWord.Substring(TempWord.IndexOf("from") + 5, TempWord.IndexOf("where") - TempWord.IndexOf("from") - 6).Trim();

                    WhereString = TempWord.Substring(TempWord.IndexOf("where") + 5, TempWord.Length - TempWord.IndexOf("where") - 5);
                    WhereString = WhereString.Replace("[", "");
                    WhereString = WhereString.Replace("]", "").Trim();
                    WhereData = WhereString.Split(new[] { ',' });
                    WhereString = "";
                    for (int i = 0; i < WhereData.Length; i++)
                    {
                        WhereData[i] = "\"" + WhereData[i].Trim() + " ,";
                        WhereString += WhereData[i];
                    }
                    WhereString = WhereString.Substring(0, WhereString.Length - 1);
                    tempword1 = "{ " + Environment.NewLine + "\"table\"" + ": " + "\"" +
                    InsertfileName + "\"" + "," + Environment.NewLine;

                    //tempword1 = "{ " + Environment.NewLine + "\t" + "\"database\"" + ": " + "\"" + ConnectionWithAccess.databasename.Trim() + "\"" + ",";
                    //tempword1 += Environment.NewLine + "\t" + "\"table\"" + ": " + "\"" +
                    //InsertfileName + "\"" + "," + Environment.NewLine;



                    tempword4 = "\"" + "where" + "\"" + " : " + WhereString + "\"" +
                    Environment.NewLine + "}";
                    TempWord = tempword1 + tempword2 + tempword3 + tempword4;
                }
            }
        }
        return TempWord;
    }

    public void fUpdateMultipleQueries(DataTable dtTable, string strTableName)
    {
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();
            
            OleDbCommand oCmd = new OleDbCommand();
            oCmd.Connection = conn;
            int TempCLO_STK = 0;
            for (int j = 0; j < dtTable.Rows.Count -1 ; j++)
            {
                int.TryParse(dtTable.Rows[j]["CLO_STK"].ToString(), out TempCLO_STK);
                oCmd.CommandText = " Update " + strTableName + " set CLO_STK = " + TempCLO_STK + " where item_code = '" + dtTable.Rows[j]["item_code"].ToString() + "' ";
                temp_word = " Update " + strTableName + " set CLO_STK = " + dtTable.Rows[j]["CLO_STK"].ToString() + " where item_code = '" + dtTable.Rows[j]["item_code"].ToString() + "' ";
                if (QueryParamList != null && QueryParamList.Count > 0)
                {
                    for (int i = 0; i < QueryParamList.Count; i++)
                    {
                        oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                    }
                }
                

                oCmd.ExecuteNonQuery();
                if (QueryParamList != null && QueryParamList.Count > 0)
                    QueryParamList.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 702");
            //MessageBox.Show(ex.Message + temp_word);
        }
        finally
        {
            conn.Close();
        }
    }

    public static void setMDBpassword(string FilePath, string OldPassword, string NewPassword)
    {
        try
        {

            if (File.Exists(FilePath))
            {
                string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Jet OLEDB:Database Password=" + OldPassword + ";Mode=12";
                string OledbConnectionString = conString;
                using (OleDbConnection con = new OleDbConnection(OledbConnectionString))
                {
                    string sql = string.Empty;
                    sql = string.Format("ALTER DATABASE PASSWORD [{0}] [{1}]", NewPassword, OldPassword);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    public static void BulkInserInTable51(DataTable DT, string strTableName)
    {
        string ConnString = ConnectionWithAccess.connection.ConnectionString;
        string SQL = "SELECT prd, a_n, s_a, amt, d_d, [user], insert_dt_tm FROM " + strTableName + " WHERE PRD='0'";
        string INSERT = "INSERT INTO " + strTableName + "  (prd, a_n, s_a, amt, d_d, [user], insert_dt_tm) " +
                        "VALUES (@prd, @a_n, @s_a, @amt, @d_d, @user, @insert_dt_tm)";

        OleDbConnection OleConn = new OleDbConnection(ConnString);
        OleDbDataAdapter OleAdp = new OleDbDataAdapter(SQL, OleConn);
        OleAdp.InsertCommand = new OleDbCommand(INSERT);
        OleAdp.InsertCommand.Parameters.Add("@prd", OleDbType.VarChar).SourceColumn = "prd";
        OleAdp.InsertCommand.Parameters.Add("@a_n", OleDbType.VarChar).SourceColumn = "a_n";
        OleAdp.InsertCommand.Parameters.Add("@s_a", OleDbType.VarChar).SourceColumn = "s_a";
        OleAdp.InsertCommand.Parameters.Add("@amt", OleDbType.Double).SourceColumn = "amt";
        OleAdp.InsertCommand.Parameters.Add("@d_d", OleDbType.Date).SourceColumn = "d_d";
        OleAdp.InsertCommand.Parameters.Add("@user", OleDbType.VarChar).SourceColumn = "user";
        OleAdp.InsertCommand.Parameters.Add("@insert_dt_tm", OleDbType.Date).SourceColumn = "insert_dt_tm";
        OleAdp.InsertCommand.Connection = OleConn;
        OleAdp.InsertCommand.Connection.Open();
        foreach (DataRow row in DT.Rows)
            row.SetAdded();
       int i = OleAdp.Update(DT);
        OleAdp.InsertCommand.Connection.Close();
    }

    public string fGetExecuteScalar()
    {
        string strResult = string.Empty;
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();

            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandText = query;
            oCmd.Connection = conn;

            if (QueryParamList != null && QueryParamList.Count > 0)
            {
                for (int i = 0; i < QueryParamList.Count; i++)
                {
                    oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                }
            }

            strResult = Convert.ToString(oCmd.ExecuteScalar());//.ToString();
            if (QueryParamList != null && QueryParamList.Count > 0)
                QueryParamList.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            conn.Close();
        }

        return strResult;
    }

    //public DataTable fGetDataTable()
    //{
    //    DataTable dtData = new DataTable();
    //    OleDbConnection conn = new OleDbConnection();
    //    String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
    //    try
    //    {
    //        conn.ConnectionString = connection;
    //        conn.Open();

    //        OleDbCommand oCmd = new OleDbCommand();
    //        oCmd.CommandText = query;
    //        oCmd.Connection = conn;

    //        if (QueryParamList != null && QueryParamList.Count > 0)
    //        {
    //            for (int i = 0; i < QueryParamList.Count; i++)
    //            {
    //                oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
    //            }
    //        }

    //        OleDbDataAdapter adapter = new OleDbDataAdapter(oCmd);
    //        adapter.Fill(dtData);
    //        if (QueryParamList != null && QueryParamList.Count > 0)
    //            QueryParamList.Clear();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message + " Line number 765");
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return dtData;
    //}

    public DataTable fGetDataTable(bool bConnectServer = false)
    {
        DataTable dtData = new DataTable();
        OleDbConnection conn = new OleDbConnection();
        if (bConnectServer && BoolConnectServer == true)
        {
            try
            {
                string strRequest = " {\"query\":\"" + query.Trim() + "\"} ";
                //string strRequest = " {\"database\":\"" + ConnectionWithAccess.databasename.Trim() + "\"" + ",";
                //strRequest += "\"query\":\"" + query.Trim() + "\"} ";
                string srtQueryURI = strServerUrl + "query";
                strResult = PostMessageToURLHttp(srtQueryURI, strRequest);
                if (!string.IsNullOrEmpty(strResult))
                {
                    if (!query.Contains("Truncate"))
                        dtData = (DataTable)JsonConvert.DeserializeObject(strResult, (typeof(DataTable)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Line number 1200");
            }
        }
        else
        {
            String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
            try
            {
                conn.ConnectionString = connection;
                conn.Open();
                if ((query.Contains("CONCAT") || query.Contains("concat")) && BoolConnectServer == false)
                    query = Convertconcate(query);
                //query = query.Replace("CONCAT", "");     
                OleDbCommand oCmd = new OleDbCommand();
                oCmd.CommandText = query;
                oCmd.Connection = conn;

                if (QueryParamList != null && QueryParamList.Count > 0)
                {
                    for (int i = 0; i < QueryParamList.Count; i++)
                    {
                        oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                    }
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(oCmd);
                adapter.Fill(dtData);
                if (QueryParamList != null && QueryParamList.Count > 0)
                    QueryParamList.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Line number 1231");
            }
            finally
            {
                conn.Close();
            }
        }
        return dtData;
    }

    public string Convertconcate(string OldQuery)
    {
        strResult = OldQuery;
        if (strResult.Contains("(") && strResult.Contains(")"))
        {
            if (strResult.Contains("CONCAT"))
                temp_word = strResult.Substring(strResult.IndexOf("CONCAT(") + 7, strResult.IndexOf(")") - strResult.IndexOf("(") - 1);
            else
                temp_word = strResult.Substring(strResult.IndexOf("concat(") + 7, strResult.IndexOf(")") - strResult.IndexOf("(") - 1);
            temp_word = temp_word.Replace("' ,", "]");
            temp_word = temp_word.Replace("',", "]");
            temp_word = temp_word.Replace("' ,", "]");
            temp_word = temp_word.Replace(", '", "[");
            temp_word = temp_word.Replace(",'", "[");
            temp_word = temp_word.Replace("[", " & \"");
            temp_word = temp_word.Replace("]", "\" & ");
            temp_word = temp_word.Replace(",", " & \" \" & ");

            strResult = strResult.Substring(0, strResult.IndexOf("CONCAT(")) + temp_word + strResult.Substring(strResult.IndexOf(")") + 1, strResult.Length - strResult.IndexOf(")") - 1);


            //temp_word = strResult.Substring(0, strResult.IndexOf("CONCAT("));
            //temp_word = strResult.Substring(strResult.IndexOf(")") + 1, strResult.Length - strResult.IndexOf(")") - 1);
            //strResult = temp_word;
        }

        return strResult;
    }

    public DataTable fGetAllTables()
    {
        DataTable dtData = new DataTable();
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();
            object[] objArrRestrict = new object[] { null, null, null, "TABLE" };

            //dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Select("TABLE_TYPE='TABLE'").CopyToDataTable();
            dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 790");
        }
        finally
        {
            conn.Close();
        }
        return dtData;
    }

    public DataSet fGetTableStructure()
    {
        DataSet dsTableStructure = new DataSet();
        DataTable dtData = new DataTable();
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();
            object[] objArrRestrict = new object[] { null, null, null, "TABLE" };

            dtData = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
            if (dtData != null)
            {
                for (int iTableCount = 0; iTableCount < dtData.Rows.Count; iTableCount++)
                {
                    DataTable schemaTable = new DataTable(dtData.Rows[iTableCount][2].ToString());
                    schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, dtData.Rows[iTableCount][2].ToString(), null });
                    schemaTable.TableName = dtData.Rows[iTableCount][2].ToString();
                    if (schemaTable != null)
                        dsTableStructure.Tables.Add(schemaTable);
                }
            }
            //dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, strTableName, null });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 827");
        }
        finally
        {
            conn.Close();
        }
        return dsTableStructure;
    }

    public DataTable fReturnDataTable(string strSortColumnOrder = "")
    {
        DataTable dtData = new DataTable();
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();

            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandText = query;
            oCmd.Connection = conn;

            if (QueryParamList != null && QueryParamList.Count > 0)
            {
                for (int i = 0; i < QueryParamList.Count; i++)
                {
                    oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                }
            }

            DataGridView dataGridView1 = new DataGridView();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(oCmd);
            adapter.Fill(dtData);

            if (!string.IsNullOrEmpty(strSortColumnOrder))
                dtData.DefaultView.Sort = strSortColumnOrder;
            if (QueryParamList != null && QueryParamList.Count > 0)
                QueryParamList.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 870");
        }
        finally
        {
            conn.Close();
        }
        return dtData;
    }

    private static DataTable AddAutoIncrementColumn()
    {

        DataColumn myDataColumn = new DataColumn();
        myDataColumn.AllowDBNull = false;
        myDataColumn.AutoIncrement = true;
        myDataColumn.AutoIncrementSeed = 1;
        myDataColumn.AutoIncrementStep = 1;
        myDataColumn.ColumnName = "autoID";
        myDataColumn.DataType = System.Type.GetType("System.Int32");
        myDataColumn.Unique = true;

        //Create a new datatable
        DataTable mydt = new DataTable();

        //Add this AutoIncrement Column to a new datatable
        mydt.Columns.Add(myDataColumn);

        return mydt;

    }

    public void accountHelp_datatable_Seperate(DataGridView mDataGridView, string mgridviewname, string strSortColumnOrder = "", bool bAddSerialNumber = false)
    {
        mDataGridView.DataSource = null;
        DataTable dtData = new DataTable();
        if(bAddSerialNumber)
            dtData = AddAutoIncrementColumn();
        OleDbConnection conn = new OleDbConnection();
        String connection = ConnectionWithAccess.connection.ConnectionString;// ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + mNIK;
        try
        {
            conn.ConnectionString = connection;
            conn.Open();

            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandText = query;
            oCmd.Connection = conn;

            if (QueryParamList != null && QueryParamList.Count > 0)
            {
                for (int i = 0; i < QueryParamList.Count; i++)
                {
                    oCmd.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                }
            }

            DataGridView dataGridView1 = new DataGridView();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(oCmd);
            adapter.Fill(dtData);
            if (QueryParamList != null && QueryParamList.Count > 0)
                QueryParamList.Clear();
            if (!string.IsNullOrEmpty(strSortColumnOrder))
                dtData.DefaultView.Sort = strSortColumnOrder;
            //conn.Close();                         
            //if (mgridviewname == "Outstanding" || mgridviewname == "sr_item_help" || mgridviewname == "sisalelistdg" || mgridviewname == "sosalelistdg" || mgridviewname == "CustomerList" || mgridviewname == "Trading Account" || mgridviewname == "Profit and Loss Account" || mgridviewname == "Capital Account" || mgridviewname == "Balance Sheet" || mgridviewname == "SaleList" || mgridviewname == "PurcList" || mgridviewname == "braccountdg" || mgridviewname == "brtranlist" || mgridviewname == "bptranlist" || mgridviewname == "Gst Sale List" || mgridviewname == "bpaccountdg" || mgridviewname == "crtranlist" || mgridviewname == "Bankrep" || mgridviewname == "Cashrep" || mgridviewname == "tr_datagridview" || mgridviewname == "cp_datagridview" || mgridviewname == "master_item_help" || mgridviewname == "UserListDG" || mgridviewname == "ledger_item_help" || mgridviewname == "Gst Purchase List" || mgridviewname == "Gst Bank List" || mgridviewname == "Gst Journal List" || mgridviewname == "bp_dgv_gst_tax_brief" || mgridviewname == "OMS PURCHASE LIST" || mgridviewname == "ro_account_help" || mgridviewname == "so_item_help" || mgridviewname == "Item Stock" || mgridviewname == "simple_item_help" || mgridviewname == "siitemlist")
            if (mgridviewname == "Job_Work_Dispatch" || mgridviewname == "Outstanding" || mgridviewname == "sr_item_help" || mgridviewname == "CustomerList" || mgridviewname == "Trading Account" || mgridviewname == "Profit and Loss Account" || mgridviewname == "Capital Account" || mgridviewname == "Balance Sheet" || mgridviewname == "SaleList" || mgridviewname == "PurcList" || mgridviewname == "braccountdg" || mgridviewname == "Gst Sale List" || mgridviewname == "Bankrep" || mgridviewname == "Cashrep" || mgridviewname == "cp_datagridview" || mgridviewname == "master_item_help" || mgridviewname == "UserListDG" || mgridviewname == "Gst Purchase List" || mgridviewname == "Gst Bank List" || mgridviewname == "Gst Journal List" || mgridviewname == "bp_dgv_gst_tax_brief" || mgridviewname == "OMS PURCHASE LIST" || mgridviewname == "ro_account_help" || mgridviewname == "Item Stock" || mgridviewname == "simple_item_help" || mgridviewname == "siitemlist" || mgridviewname == "Cust_bal_rep" || mgridviewname == "Supl_bal_rep" || mgridviewname == "item_Closing_stock" || mgridviewname == "Jourrep" || mgridviewname == "Loans Taken" || mgridviewname == "master_account_help_dg" || mgridviewname == "sitaxlist" || mgridviewname == "Item Box List")
                mDataGridView.AutoGenerateColumns = true;
            else
                mDataGridView.AutoGenerateColumns = false;

            //mDataGridView.DataSource = null;
            mDataGridView.DataSource = dtData;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 922");
        }
        finally
        {
            conn.Close();
        }

        int mcolumncount = dtData.Columns.Count;// datareader.FieldCount;
        //mDataGridView.Columns.Clear();
        //mDataGridView.DataSource = null;
        //mDataGridView.DataSource = dtData;
        //mDataGridView.DataMember = dtData.TableName;
        #region ColumnHeaders
        if (mDataGridView.Rows.Count >= 1)
        {
            if (mgridviewname == "si_party_help" || mgridviewname == "replacement_party_code" || mgridviewname == "sale_order_dgv" || mgridviewname == "bp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Name";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";
                mDataGridView.Columns[4].HeaderText = "D_y";
                mDataGridView.Columns[5].HeaderText = "Account Type";
                mDataGridView.Columns[0].Width = 300;
                mDataGridView.Columns[1].Width = 170;
                mDataGridView.Columns[2].Width = 60;
                mDataGridView.Columns[3].Width = 45;
                mDataGridView.Columns[4].Width = 45;
                mDataGridView.Columns[5].Width = 200;

                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
                mDataGridView.Columns[4].Visible = false;
            }
            else if (mgridviewname == "item_Closing_stock")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item_code";
                mDataGridView.Columns[2].HeaderText = "title";
                mDataGridView.Columns[3].HeaderText = "Close. Stock";
                mDataGridView.Columns[4].HeaderText = "Price";
                mDataGridView.Columns[5].HeaderText = "Amount";
                mDataGridView.Columns[0].Width = 70;
                mDataGridView.Columns[1].Width = 70;
                mDataGridView.Columns[2].Width = 270;
                mDataGridView.Columns[3].Width = 70;
                mDataGridView.Columns[4].Width = 70;
                mDataGridView.Columns[5].Width = 70;
                mDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //"select [type], item_code, [title],packing,box,price,cat,clo_stk,igst_per,hsn_code
            }
            else if (mgridviewname == "braccountdg" || mgridviewname == "bpaccountdg" || mgridviewname == "cr_datagridview" || mgridviewname == "cp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Desc";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";
                mDataGridView.Columns[4].HeaderText = "Master Account";
                mDataGridView.Columns[0].Width = 300;
                mDataGridView.Columns[1].Width = 170;
                mDataGridView.Columns[2].Width = 60;
                mDataGridView.Columns[3].Width = 45;
                mDataGridView.Columns[4].Width = 200;
                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
            }
            else if (mgridviewname == "sitaxlist")
            {
                mDataGridView.Columns[0].HeaderText = "Code";
                mDataGridView.Columns[1].HeaderText = "Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            else if (mgridviewname == "dgv_user_list")
            {
                mDataGridView.Columns[0].HeaderText = "f1";
                mDataGridView.Columns[1].HeaderText = "f2";
            }
            else if (mgridviewname == "pitaxlist_dgv")
            {
                mDataGridView.Columns[0].HeaderText = "Tax Code";
                mDataGridView.Columns[1].HeaderText = "Tax Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            //else if (mgridviewname == "jjtranlist")
            //{
            //    mDataGridView.Columns[0].HeaderText = "Date";
            //    mDataGridView.Columns[1].HeaderText = "Doc. No";
            //    mDataGridView.Columns[2].HeaderText = "Name";
            //    mDataGridView.Columns[3].HeaderText = "City";
            //    mDataGridView.Columns[4].HeaderText = "Amount";
            //    mDataGridView.Columns[5].HeaderText = "Message";
            //    mDataGridView.Columns[6].HeaderText = "A_n";
            //    mDataGridView.Columns[7].HeaderText = "S_a";
            //    mDataGridView.Columns[8].HeaderText = "NA_n";
            //    mDataGridView.Columns[9].HeaderText = "NS_a";

            //    mDataGridView.Columns[6].Visible = false;
            //    mDataGridView.Columns[7].Visible = false;
            //    mDataGridView.Columns[8].Visible = false;
            //    mDataGridView.Columns[9].Visible = false;
            //}
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

                mDataGridView.Columns[20].Visible = false;
                mDataGridView.Columns[21].Visible = false;
                mDataGridView.Columns[22].Visible = false;
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
                mDataGridView.Columns[2].HeaderText = "Rate";
                mDataGridView.Columns[3].HeaderText = "Discription";
            }
            else if (mgridviewname == "dgv_dataentry_additional_item")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
            }
            else if (mgridviewname == "Job_Work_Dispatch")
            {
                mDataGridView.Columns[0].HeaderText = "D_C";
                mDataGridView.Columns[1].HeaderText = "A_N";
                mDataGridView.Columns[2].HeaderText = "S_A";
                mDataGridView.Columns[2].HeaderText = "Total Amount";
            }
            //else if (mgridviewname == "PeriodListDG")
            //{
            //    mDataGridView.Columns[0].HeaderText = "Period";
            //    mDataGridView.Columns[1].HeaderText = "Start";
            //    mDataGridView.Columns[2].HeaderText = "End";
            //    mDataGridView.Columns[3].HeaderText = "Lock";
            //    mDataGridView.Columns[4].HeaderText = "GP";
            //    mDataGridView.Columns[5].HeaderText = "Vat";
            //    mDataGridView.Columns[6].HeaderText = "Data Transfer";
            //    mDataGridView.Columns[7].HeaderText = "Print Form";
            //}
            //else if (mgridviewname == "pi_item_help")
            //{
            //    mDataGridView.Columns[0].HeaderText = "Type";
            //    mDataGridView.Columns[1].HeaderText = "Item Code";
            //    mDataGridView.Columns[2].HeaderText = "Title";
            //    mDataGridView.Columns[3].HeaderText = "Packing";
            //    mDataGridView.Columns[4].HeaderText = "Box";
            //    mDataGridView.Columns[5].HeaderText = "Price";
            //    mDataGridView.Columns[6].HeaderText = "Cat";
            //    mDataGridView.Columns[7].HeaderText = "clo_stk";
            //}
            //else if (mgridviewname == "Trading Account" || mgridviewname == "Profit and Loss Account")
            //{
            //    mDataGridView.Columns[0].HeaderText = "A_n";
            //    mDataGridView.Columns[1].HeaderText = "Particulars";
            //    mDataGridView.Columns[2].HeaderText = "Amount1";
            //    mDataGridView.Columns[3].HeaderText = "Particulars";
            //    mDataGridView.Columns[4].HeaderText = "Amount2";

            //}
            //else if (mgridviewname == "Capital Account")
            //{
            //    mDataGridView.Columns[0].HeaderText = "A_n";
            //    mDataGridView.Columns[1].HeaderText = "S_a";
            //    mDataGridView.Columns[2].HeaderText = "Particulars";
            //    mDataGridView.Columns[3].HeaderText = "Amount1";
            //    mDataGridView.Columns[4].HeaderText = "Particulars";
            //    mDataGridView.Columns[5].HeaderText = "Amount2";

            //}
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
                mDataGridView.Columns[0].HeaderText = "Daybook Code";
                mDataGridView.Columns[1].HeaderText = "A_n";
            }
            else if (mgridviewname == "ChangePeriod")
            {
                mDataGridView.Columns[0].HeaderText = "PRD";
                mDataGridView.Columns[1].HeaderText = "Start";
                mDataGridView.Columns[2].HeaderText = "End";
            }
        }
        #endregion ColumnHeaders
        data_type = null;
    }

    public void accountHelp_datatable(DataGridView mDataGridView, string mgridviewname)
    {
        DataTable dtData = new DataTable();
        try
        {
            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
            connection.Open();

            if (QueryParamList != null && QueryParamList.Count > 0)
            {
                ConnectionWithAccess.command.Parameters.Clear();
                for (int i = 0; i < QueryParamList.Count; i++)
                {
                    ConnectionWithAccess.command.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
                }

            }
            ConnectionWithAccess.command.CommandText = query;
            ConnectionWithAccess.command.Connection = connection;
            
            //var adapter = new OleDbDataAdapter(query, connection);
            var adapter = new OleDbDataAdapter(ConnectionWithAccess.command);
            adapter.Fill(dtData);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + " Line number 1185");
        }
        finally
        {
            GC.Collect();
            //ConnectionWithAccess.command.Dispose();

            QueryParamList = null;
            connection.Close();
        }
        int mcolumncount = dtData.Columns.Count;// datareader.FieldCount;
        mDataGridView.Columns.Clear();
        mDataGridView.DataSource = null;
        mDataGridView.DataSource = dtData;
        //mDataGridView.DataMember = dtData.TableName;
        #region ColumnHeaders
        if (mDataGridView.Rows.Count >= 0)
        {
            if (mgridviewname == "si_party_help" || mgridviewname == "replacement_party_code" || mgridviewname == "sale_order_dgv" || mgridviewname == "pr_acc_help_dgv")
            {
                mDataGridView.Columns[0].HeaderText = "Name";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";
                mDataGridView.Columns[4].HeaderText = "d_y";
                mDataGridView.Columns[5].HeaderText = "Account Type";
                mDataGridView.Columns[0].Width = 300;
                mDataGridView.Columns[1].Width = 170;
                mDataGridView.Columns[2].Width = 60;
                mDataGridView.Columns[3].Width = 45;
                mDataGridView.Columns[4].Width = 45;
                mDataGridView.Columns[5].Width = 200;
                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
                mDataGridView.Columns[4].Visible = false;
            }
            else if (mgridviewname == "ledger_account_help" || mgridviewname == "bp_datagridview" || mgridviewname == "cr_datagridview" || mgridviewname == "cp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Desc";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";
                mDataGridView.Columns[4].HeaderText = "Master Account";
                mDataGridView.Columns[0].Width = 300;
                mDataGridView.Columns[1].Width = 170;
                mDataGridView.Columns[2].Width = 60;
                mDataGridView.Columns[3].Width = 45;
                mDataGridView.Columns[4].Width = 200;
                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
            }
            else if (mgridviewname == "sitaxlist")
            {
                mDataGridView.Columns[0].HeaderText = "Code";
                mDataGridView.Columns[1].HeaderText = "Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            else if (mgridviewname == "dgv_user_list")
            {
                mDataGridView.Columns[0].HeaderText = "f1";
                mDataGridView.Columns[1].HeaderText = "f2";
            }
            else if (mgridviewname == "pitaxlist_dgv")
            {
                mDataGridView.Columns[0].HeaderText = "Tax Code";
                mDataGridView.Columns[1].HeaderText = "Tax Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            else if (mgridviewname == "jjtranlist")
            {
                mDataGridView.Columns[0].HeaderText = "Date";
                mDataGridView.Columns[1].HeaderText = "Doc. No";
                mDataGridView.Columns[2].HeaderText = "Name";
                mDataGridView.Columns[3].HeaderText = "City";
                mDataGridView.Columns[4].HeaderText = "Amount";
                mDataGridView.Columns[5].HeaderText = "Message";
                mDataGridView.Columns[6].HeaderText = "A_n";
                mDataGridView.Columns[7].HeaderText = "S_a";
                mDataGridView.Columns[8].HeaderText = "NA_n";
                mDataGridView.Columns[9].HeaderText = "NS_a";

                mDataGridView.Columns[6].Visible = false;
                mDataGridView.Columns[7].Visible = false;
                mDataGridView.Columns[8].Visible = false;
                mDataGridView.Columns[9].Visible = false;
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

                mDataGridView.Columns[20].Visible = false;
                mDataGridView.Columns[21].Visible = false;
                mDataGridView.Columns[22].Visible = false;
            }
            //else if (mgridviewname == "ItemListDG")
            //{
            //    //[type], item_code, [title],packing,box,price,cat,clo_stk
            //    mDataGridView.Columns[0].HeaderText = "Type";
            //    mDataGridView.Columns[1].HeaderText = "Item Code";
            //    mDataGridView.Columns[2].HeaderText = "Title";
            //    mDataGridView.Columns[3].HeaderText = "Packing";
            //    mDataGridView.Columns[4].HeaderText = "Box";
            //    mDataGridView.Columns[5].HeaderText = "Price";
            //    mDataGridView.Columns[6].HeaderText = "Catagory";
            //    mDataGridView.Columns[7].HeaderText = "Clo_stk";
            //}
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
                mDataGridView.Columns[2].HeaderText = "Rate";
                mDataGridView.Columns[3].HeaderText = "Discription";
                //mDataGridView.Columns[3].HeaderText = "a_n";
            }
            else if (mgridviewname == "dgv_dataentry_additional_item")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
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
            else if (mgridviewname == "pi_item_help")
            {
                //[type], item_code, [title],packing,box,price,cat,clo_stk,igst_per,hsn_code
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Packing";
                mDataGridView.Columns[4].HeaderText = "Box";
                mDataGridView.Columns[5].HeaderText = "Price";
                mDataGridView.Columns[6].HeaderText = "Cat";
                mDataGridView.Columns[7].HeaderText = "clo_stk";
                mDataGridView.Columns[8].HeaderText = "Igst Per";
                mDataGridView.Columns[9].HeaderText = "Hsn Code";
                //mDataGridView.Columns[0].Visible = false;
                //mDataGridView.Columns[1].Visible = false;
                //mDataGridView.Columns[2].Width = 300;
                //mDataGridView.Columns[3].Width = 33;
                //mDataGridView.Columns[4].Width = 60;
                //mDataGridView.Columns[5].Width = 90;
                //mDataGridView.Columns[6].Width = 100;
                //mDataGridView.Columns[7].Width = 40;
                //mDataGridView.Columns[8].Width = 45;
                //mDataGridView.Columns[8].Width = 90;
                //mDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //mDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //mDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //mDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //mDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //mDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //mDataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (mgridviewname == "tr_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Date";
                mDataGridView.Columns[1].HeaderText = "Doc. No";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Amount";
                mDataGridView.Columns[4].HeaderText = "Message";
                mDataGridView.Columns[5].HeaderText = "A_n";
                mDataGridView.Columns[6].HeaderText = "S_a";
                mDataGridView.Columns[7].HeaderText = "B_T";
                mDataGridView.Columns[8].HeaderText = "R_p";
                mDataGridView.Columns[9].HeaderText = "D_c";
                mDataGridView.Columns[10].HeaderText = "Tran_D_c";

                mDataGridView.Columns[5].Visible = false;
                mDataGridView.Columns[6].Visible = false;
                mDataGridView.Columns[7].Visible = false;
                mDataGridView.Columns[8].Visible = false;
                mDataGridView.Columns[9].Visible = false;
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
                mDataGridView.Columns[0].HeaderText = "Daybook Code";
                mDataGridView.Columns[1].HeaderText = "A_n";
            }
            else if (mgridviewname == "ChangePeriod")
            {
                mDataGridView.Columns[0].HeaderText = "PRD";
                mDataGridView.Columns[1].HeaderText = "Start";
                mDataGridView.Columns[2].HeaderText = "End";
            }

            else if (mgridviewname == "cp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Desc";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";

                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
            }
            else if (mgridviewname == "soitemlist")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Quantity_cs";
                mDataGridView.Columns[4].HeaderText = "Box";
                mDataGridView.Columns[5].HeaderText = "Quanitty";
                mDataGridView.Columns[6].HeaderText = "Price";
                mDataGridView.Columns[7].HeaderText = "Amount";
                mDataGridView.Columns[8].HeaderText = "Cat";
            }
        }
        #endregion ColumnHeaders
        data_type = null;
    }

    public void accountHelp(DataGridView mDataGridView, string mgridviewname)
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        command.CommandText = query;

        if (QueryParamList != null && QueryParamList.Count > 0)
        {
            ConnectionWithAccess.command.Parameters.Clear();
            for (int i = 0; i < QueryParamList.Count; i++)
            {
                ConnectionWithAccess.command.Parameters.AddWithValue(QueryParamList[i].paramName, QueryParamList[i].paramValue);
            }
            
        }

        connection.Open();
            datareader = command.ExecuteReader();
            int mcolumncount = datareader.FieldCount;
            mDataGridView.AutoGenerateColumns = false;
            if (mgridviewname != "si_item_help" && mgridviewname != "sritemlist" && mgridviewname != "sr_item_help")
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
            datareader.Close();
            QueryParamList = null;
            #region ColumnHeaders
            if (mgridviewname == "si_party_help" || mgridviewname == "replacement_party_code" || mgridviewname == "sale_order_dgv" || mgridviewname == "bpaccountdg" || mgridviewname == "braccountdg" || mgridviewname == "bp_datagridview" || mgridviewname == "cr_datagridview" || mgridviewname == "cp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Name";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";
                mDataGridView.Columns[5].HeaderText = "Account Type";
                mDataGridView.Columns[0].Width = 300;
                mDataGridView.Columns[1].Width = 170;
                mDataGridView.Columns[2].Width = 60;
                mDataGridView.Columns[3].Width = 45;
                mDataGridView.Columns[4].Width = 45;
                mDataGridView.Columns[5].Width = 200;

                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
                mDataGridView.Columns[4].Visible = false;
            }
            else if (mgridviewname == "sitaxlist")
            {
                mDataGridView.Columns[0].HeaderText = "Code";
                mDataGridView.Columns[1].HeaderText = "Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            else if (mgridviewname == "dgv_user_list")
            {
                mDataGridView.Columns[0].HeaderText = "f1";
                mDataGridView.Columns[1].HeaderText = "f2";
            }
            else if (mgridviewname == "pitaxlist_dgv")
            {
                mDataGridView.Columns[0].HeaderText = "Tax Code";
                mDataGridView.Columns[1].HeaderText = "Tax Rate";
                mDataGridView.Columns[2].HeaderText = "Description";
            }
            else if (mgridviewname == "jjtranlist")
            {
                mDataGridView.Columns[0].HeaderText = "Date";
                mDataGridView.Columns[1].HeaderText = "Doc. No";
                mDataGridView.Columns[2].HeaderText = "Name";
                mDataGridView.Columns[3].HeaderText = "City";
                mDataGridView.Columns[4].HeaderText = "Amount";
                mDataGridView.Columns[5].HeaderText = "Message";
                mDataGridView.Columns[6].HeaderText = "A_n";
                mDataGridView.Columns[7].HeaderText = "S_a";
                mDataGridView.Columns[8].HeaderText = "NA_n";
                mDataGridView.Columns[9].HeaderText = "NS_a";

                mDataGridView.Columns[6].Visible = false;
                mDataGridView.Columns[7].Visible = false;
                mDataGridView.Columns[8].Visible = false;
                mDataGridView.Columns[9].Visible = false;
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

                mDataGridView.Columns[20].Visible = false;
                mDataGridView.Columns[21].Visible = false;
                mDataGridView.Columns[22].Visible = false;
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
                mDataGridView.Columns[2].HeaderText = "Rate";
                mDataGridView.Columns[3].HeaderText = "Discription";
                //mDataGridView.Columns[3].HeaderText = "a_n";
            }
            else if (mgridviewname == "dgv_dataentry_additional_item")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
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
            else if (mgridviewname == "tr_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Date";
                mDataGridView.Columns[1].HeaderText = "Doc. No";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Amount";
                mDataGridView.Columns[4].HeaderText = "Message";
                mDataGridView.Columns[5].HeaderText = "A_n";
                mDataGridView.Columns[6].HeaderText = "S_a";
                mDataGridView.Columns[7].HeaderText = "B_T";
                mDataGridView.Columns[8].HeaderText = "R_p";
                mDataGridView.Columns[9].HeaderText = "D_c";
                mDataGridView.Columns[10].HeaderText = "Tran_D_c";

                mDataGridView.Columns[5].Visible = false;
                mDataGridView.Columns[6].Visible = false;
                mDataGridView.Columns[7].Visible = false;
                mDataGridView.Columns[8].Visible = false;
                mDataGridView.Columns[9].Visible = false;
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
                mDataGridView.Columns[0].HeaderText = "Daybook Code";
                mDataGridView.Columns[1].HeaderText = "A_n";
            }
            else if (mgridviewname == "ChangePeriod")
            {
                mDataGridView.Columns[0].HeaderText = "PRD";
                mDataGridView.Columns[1].HeaderText = "Start";
                mDataGridView.Columns[2].HeaderText = "End";
            }
            //else if (mgridviewname == "ledger_account_help")
            //{
            //    mDataGridView.Columns[0].HeaderText = "Desc";
            //    mDataGridView.Columns[1].HeaderText = "City";
            //    mDataGridView.Columns[2].HeaderText = "A_n";
            //    mDataGridView.Columns[3].HeaderText = "S_a";
            //    mDataGridView.Columns[4].HeaderText = "Master Account";

            //    mDataGridView.Columns[2].Visible = false;
            //    mDataGridView.Columns[3].Visible = false;
            //}
            else if (mgridviewname == "cp_datagridview")
            {
                mDataGridView.Columns[0].HeaderText = "Desc";
                mDataGridView.Columns[1].HeaderText = "City";
                mDataGridView.Columns[2].HeaderText = "A_n";
                mDataGridView.Columns[3].HeaderText = "S_a";

                mDataGridView.Columns[2].Visible = false;
                mDataGridView.Columns[3].Visible = false;
            }
            else if (mgridviewname == "soitemlist")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Quantity_cs";
                mDataGridView.Columns[4].HeaderText = "Box";
                mDataGridView.Columns[5].HeaderText = "Quanitty";
                mDataGridView.Columns[6].HeaderText = "Price";
                mDataGridView.Columns[7].HeaderText = "Amount";
                mDataGridView.Columns[8].HeaderText = "Cat";
            }
            else if (mgridviewname == "pi_item_help")
            {
                mDataGridView.Columns[0].HeaderText = "Type";
                mDataGridView.Columns[1].HeaderText = "Item Code";
                mDataGridView.Columns[2].HeaderText = "Title";
                mDataGridView.Columns[3].HeaderText = "Packing";
                mDataGridView.Columns[4].HeaderText = "Box";
                mDataGridView.Columns[5].HeaderText = "Price";
                mDataGridView.Columns[6].HeaderText = "Cat";
                mDataGridView.Columns[7].HeaderText = "Igst";
                mDataGridView.Columns[8].HeaderText = "Hsn";
                mDataGridView.Columns[0].Visible = false;
                mDataGridView.Columns[1].Visible = false;
                mDataGridView.Columns[2].Width = 270;
                mDataGridView.Columns[3].Width = 70;
                mDataGridView.Columns[4].Width = 70;
                mDataGridView.Columns[5].Width = 70;
                mDataGridView.Columns[6].Width = 70;
                mDataGridView.Columns[7].Width = 70;
                mDataGridView.Columns[8].Width = 70;
                mDataGridView.Columns[3].DefaultCellStyle.Format = "N0";
                mDataGridView.Columns[4].DefaultCellStyle.Format = "N0";
                mDataGridView.Columns[5].DefaultCellStyle.Format = "N2";
                mDataGridView.Columns[6].DefaultCellStyle.Format = "N3";
                mDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mDataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //"select [type], item_code, [title],packing,box,price,cat,clo_stk,igst_per,hsn_code
            }
            #endregion ColumnHeaders
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
        if (mDataGridView.Rows.Count > 1)
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
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
        ConnectionWithAccess.connection.Open();
        ConnectionWithAccess.datareader = ConnectionWithAccess.command.ExecuteReader();

        int mcolumncount = datareader.FieldCount;
     //   if (gdv.Rows.Count >= 2)
            gdv.Rows.Add();
        while (ConnectionWithAccess.datareader.Read())
        {
            gdv.Rows.Add();
            for (int i = 0; i < mcolumncount; i++)
            {
                temp_word = datareader[i].ToString();
                if (temp_word != null && temp_word != " ")
                {
                    if (gdvname == "LEDGER" || gdvname == "Bankrep" || gdvname == "Cashrep")
                        gdv.Rows[gdv.Rows.Count - 2].Cells[i].Value = ConnectionWithAccess.datareader[i];
                    else
                        gdv.Rows[gdv.Rows.Count - 1].Cells[i].Value = ConnectionWithAccess.datareader[i];
                }
            }
            row_pointer++;
        }
        ConnectionWithAccess.connection.Close();
    }

    public void multiplerows_datatable(DataGridView gdv, string gdvname)
    {
        DataTable dtNewData = new DataTable();
        DataTable dtGridData = new DataTable();
        try
        {
            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
            ConnectionWithAccess.connection.Open();
            var adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dtNewData);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            ConnectionWithAccess.connection.Close();
        }


        if (dtNewData != null && dtNewData.Rows.Count > 0)
        {
            if (gdv.DataSource != null)
            {
                dtGridData = (DataTable)gdv.DataSource;
            }
            dtGridData.Merge(dtNewData);
            gdv.DataSource = null;
            gdv.DataSource = dtGridData;

        }
        
    }

    public static void connectionStart()
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
        ConnectionWithAccess.connection.Open();
    }

    public static void fillCombo(ComboBox cbo)
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
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
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        cbo.Items.Clear();
        //cbo.Items.Add("All");
        command.CommandText = query;
        if (query != null)
        {
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
    }

    public static void fillgrid(string query, DataGridView gdv)
    {
        if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        ConnectionWithAccess.command.CommandText = query;
        ConnectionWithAccess.connection.Open();
        try
        {
            dt.Rows.Clear();
            dt.Columns.Clear();
            ConnectionWithAccess.datareader = ConnectionWithAccess.command.ExecuteReader();
            string columnname;
            columncount = datareader.FieldCount;
            columnnamearray = new string[columncount];

            for (i = 0; i < columncount; i++)
            {
                columnname = ConnectionWithAccess.datareader.GetName(i);
                // gdv.Columns.Add(colname, colname);
                dt.Columns.Add(columnname);
                columnnamearray[i] = columnname;
            }

            while (ConnectionWithAccess.datareader.Read())
            {
                DataRow ddr = dt.NewRow();
                for (i = 0; i < ConnectionWithAccess.datareader.FieldCount; i++)
                {
                    ddr[i] = ConnectionWithAccess.datareader[i];
                }
                dt.Rows.Add(ddr);
            }

        }
        //catch (Exception ex)
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message + " Line number 2034");
        }
        gdv.DataSource = dt;
        ConnectionWithAccess.connection.Close();
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

    public static string get_actual_file_name(string filename)
    {
        slashposition = 0;
        for (array_record = 0; array_record < filename.Length; array_record++)
        {
            if (filename.Substring(array_record, 1) == "\\")
            {
                slashposition = array_record;
                actual_filename = (filename.Substring(array_record + 1, filename.Length - array_record - 5));
            }
        }
        return actual_filename;
    }

    public static void create_file_folder(string filename)
    {
        if (filename != null)
        {
            filename = remove_filename_error(filename);
            get_actual_file_name(filename);
            if (filename.Contains("."))
                file_folder = filename.Substring(0, slashposition);
            else
                file_folder = filename.Substring(0, slashposition);
            System.IO.Directory.CreateDirectory(file_folder);
            Clipboard.SetText(filename);
        }
    }

    public string ExportDataSetToExcel(DataSet ds)
    {
        string strExcelFilePath = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\excel Reports\\SearchAll_Results_";
        //Creae an Excel application instance
        Excel.Application excelApp = new Excel.Application();

        Excel.Workbook excelWorkBook;
        object misValue = System.Reflection.Missing.Value;
        excelWorkBook = excelApp.Workbooks.Add(misValue);

        try
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table != null && table.Rows.Count > 0)
                {
                    //Add a new worksheet to workbook with the Datatable name
                    Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                    excelWorkSheet.Name = table.TableName;
                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                }
            }
            strExcelFilePath += DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + ".xls";
            excelWorkBook.SaveAs(strExcelFilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            excelWorkBook.Close(true, misValue, misValue);

        }
        catch (Exception ex)
        {
        }
        finally
        {
            excelApp.Quit();

            Marshal.ReleaseComObject(excelWorkBook);
            Marshal.ReleaseComObject(excelApp);
        }
        return strExcelFilePath;
    }

    public void ExportToText(ComboBox mComboBox, TextBox mTextBox)
    {
        //if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
        //command.CommandText = query;
        //connection.Open();
        //mTextBox.Text = Convert.ToString(command.ExecuteScalar());
        //if (mTextBox.Text == "")
        //    mTextBox.Text = "1";
        //connection.Close();
        DataTable dtData1 = fGetDataTable();
        if (dtData1 != null && dtData1.Rows.Count > 0)
        {
            int mcolumncount = dtData1.Columns.Count;
            for (int iRowCount = 0; iRowCount < dtData1.Rows.Count; iRowCount++)
            {
                for (int i = 0; i <= mcolumncount - 1; i++)
                {
                    if (dtData1.Rows[iRowCount][0].ToString().Length > 0 && dtData1.Rows[iRowCount][0].ToString() != "")
                        mTextBox.Text = (Convert.ToInt32(dtData1.Rows[iRowCount][0].ToString())).ToString();
                    else
                        mTextBox.Text = "1";
                }
            }
        }
        else
            mTextBox.Text = "1";
    }

    public void ExportToDateTimePicker(DateTimePicker msDateTime)
    {
        connection.Open();
        command.CommandText = query;
        mDateTime = Convert.ToDateTime(command.ExecuteScalar());
        connection.Close();
        if (mDateTime < Convert.ToDateTime(ConnectionWithAccess.com_start_date))
            mDateTime = Convert.ToDateTime(ConnectionWithAccess.com_start_date);
        msDateTime.MinDate = ConnectionWithAccess.mDateTime;
        msDateTime.MaxDate = DateTime.Now.Date;

        //msDateTime.Text = DateTime.Now.Date.ToString();
        msDateTime.Value = ConnectionWithAccess.mDateTime;

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
