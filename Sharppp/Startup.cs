using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Net;
using System.Web.Script.Serialization;

namespace SHARP_ACCOUNTING
{

    public partial class Startup : Form
    {
        
        string programmer_laptop;
        string security_check_drive, security_check_filename, security_check_filepath;
        string oldPid, oldHDD, oldBM, oldBios, oldPM, oldCS, oldCM;
        string currentPid, currentHDD, currentBM, currentBios, currentPM, currentCS, currentCM;
        string[] reload_security;
        //static string mdrive = "";
        Global GlobalClass = new Global();
        ConnectionWithAccess commandconnection = new ConnectionWithAccess();
        string mtextfilename = "";
        string line;
        string mdirectorypath = "";
        int asc_value, space_count, row_counter;
        public static string encoded, decoded;
        
        string check_legal = "N";

        public static string[] data_from_company_file;
        public string strAccess_key { get; set; }
        public bool bGetDataFromServer { get; set; }
        public string sharp_details_filename { get; set; }
        private string candidate_data { get; set; }
        public string srtCandidateInfoURI { get; set; }
        Global objGlobalClass = new Global();
        string data_drive = string.Empty;
        string setup_drive = string.Empty;
        private string temp_word;

        public class CandidateData
        {
            public List<CandidateInfo> data { get; set; }
            public string error { get; set; }
        }

        public class CandidateInfo
        {
            public string panel { get; set; }
            public string panel_image { get; set; }
            public string inactive { get; set; }
            public string party_name { get; set; }
            public string party_logo { get; set; }
            public string name1 { get; set; }
            public string name2 { get; set; }
            public string name3 { get; set; }
            public string name4 { get; set; }
            public string name5 { get; set; }
            public string candidate_slip { get; set; }
            public string db_name { get; set; }
            public string get_data_from_server { get; set; }
        }

        BackgroundWorker m_oWorker;

        public Startup()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }

        #region
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.co.in"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void Save_CandidateInfo_File()
        {
            FileStream fs1 = new FileStream(sharp_details_filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer1 = new StreamWriter(fs1);
            writer1.WriteLine(candidate_data);
            writer1.Flush();
            writer1.Close();
        }

        private string GetAccessKey()
        {
            string strAccess_key = string.Empty;
            //cVoters objvoters = new cVoters();
            CandidateInfo ci = new CandidateInfo();
            string[] strcandidate_array = File.ReadAllLines(sharp_details_filename);
            if (strcandidate_array != null && strcandidate_array.Length > 1)
            {
                string[] strcandidate_data = strcandidate_array[1].Split('~');
                if (strcandidate_data != null && strcandidate_data.Length > 0)
                {
                    strAccess_key = objGlobalClass.decode(strcandidate_data[0].ToString());
                    MainForm.software_for = objGlobalClass.decode(strcandidate_data[5].ToString());
                    MainForm.access_line1 = objGlobalClass.decode(strcandidate_data[5].ToString());
                    MainForm.access_line2 = objGlobalClass.decode(strcandidate_data[6].ToString());
                    MainForm.access_line3 = objGlobalClass.decode(strcandidate_data[7].ToString());
                    MainForm.access_line4 = objGlobalClass.decode(strcandidate_data[8].ToString());
                    MainForm.access_line5 = objGlobalClass.decode(strcandidate_data[9].ToString());
                    MainForm.total_sms_count = Convert.ToInt32(objGlobalClass.decode(strcandidate_data[1].ToString()));
                }
            }
            return strAccess_key;
        }

        private CandidateData PostMessageToURLHttp(string url, string parameters)
        {
            CandidateData cd = null;
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
                        var serializer = new JavaScriptSerializer();
                        cd = serializer.Deserialize<CandidateData>(result);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return cd;

        }

        private void GetCandidateDetailsFromServer(string straccess_key)
        {
            //Global objvoters = new Global();
            CandidateData cd = null;
            var strRequest = " {\"access_key\":\" " + straccess_key + " \"} ";
            //var strRequest = " {\"deviceid\":\" " + straccess_key + " \"} ";
            //srtCandidateInfoURI = "https://anup01.herokuapp.com/Publiclogdata";

            //strRequest = " {\"query\":\" select * from Location limit 1  \"} ";
            //srtCandidateInfoURI = "http://68.183.246.170:8080/query"; // smartify

            try
            {
                cd = PostMessageToURLHttp(srtCandidateInfoURI, strRequest);

                string party_logo_imgBase64String = string.Empty;
                string candidate_slip_imgBase64String = string.Empty;

                if (cd != null && cd.data != null && cd.data.Count > 0)
                {
                    CandidateInfo ci = cd.data[0];
                    ci.get_data_from_server = "1";
                    if (ci.inactive.Trim() == "1")
                    {
                        MessageBox.Show("Application de-activated! Contact application owner to re-activate", "Application de-activated", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        System.Environment.Exit(1);
                        System.Windows.Forms.Application.Exit();
                        Application.Exit();
                        this.Close();
                    }

                    if (cd.data[0].party_logo != string.Empty)
                        party_logo_imgBase64String = objGlobalClass.ImageToBase64(objGlobalClass.GetImage(ci.party_logo));
                    //if (cd.data[0].candidate_slip != string.Empty)
                    //    candidate_slip_imgBase64String = objGlobalClass.ImageToBase64(objGlobalClass.GetImage(ci.candidate_slip));

                    candidate_data += objGlobalClass.encode("access_key~panel~panel_image~party_name~party_logo_imgBase64String~name1~name2~name3~name4~name5~candidate_slip_imgBase64String~db_name~get_data_from_server") + System.Environment.NewLine;

                    candidate_data += objGlobalClass.encode(straccess_key) + "~" + objGlobalClass.encode(ci.panel) + "~" + ci.panel_image + "~" + objGlobalClass.encode(ci.party_name) + "~" + party_logo_imgBase64String + "~" +
                        objGlobalClass.encode(ci.name1) + "~" + objGlobalClass.encode(ci.name2) + "~" + objGlobalClass.encode(ci.name3) + "~" + objGlobalClass.encode(ci.name4) + "~" + objGlobalClass.encode(ci.name5) + "~" + candidate_slip_imgBase64String + "~" +
                        objGlobalClass.encode(ci.db_name.ToLower().Replace(".db", ".mdb")) + "~" + objGlobalClass.encode(ci.get_data_from_server) + System.Environment.NewLine;

                    if (candidate_data.Trim() != string.Empty)
                        Save_CandidateInfo_File();


                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        

        private void CheckSharpFileExists()
        {
            if (File.Exists(sharp_details_filename))
            {
                if (CheckForInternetConnection())
                {
                    GetCandidateDetailsFromServer(strAccess_key);
                }
            }
        }

        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckSharpFileExists();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                m_oWorker.ReportProgress(i);
                if (m_oWorker.CancellationPending)
                {
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }
            }
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }


        #endregion

        private void CloseApp()
        {
            if (!File.Exists(sharp_details_filename))
            {
                System.Environment.Exit(1);
                System.Windows.Forms.Application.Exit();
                Application.Exit();
                this.Close();
            }
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            programmer_laptop = "Y";
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            try
            {
                //wait_for_security();
                setup_drive = objGlobalClass.Globalsetup_drivesearch();
                ConnectionWithAccess.setup_drive = setup_drive + ":\\";
                sharp_details_filename = setup_drive + ":\\sharp\\sharp_info.txt";


                

                if (!File.Exists(sharp_details_filename))
                {
                    MainForm.access_line2 = "11";
                    strAccess_key = "11";
                    go_to_company_list();   // temporary done for Sonu Afc
                    objPleaseWait.Close();
                    return;
                    AccessKey objAccessKey = new AccessKey();
                    objAccessKey.sharp_details_filename = sharp_details_filename;
                    objAccessKey.Closed += (s, args) => CloseApp();// this.Close();
                    objAccessKey.ShowDialog();
                }
                else
                {
                    MainForm.access_line2 = "11";
                    strAccess_key = "11";
                    go_to_company_list();   // temporary done for Sonu Afc
                    return;
                    
                    strAccess_key = GetAccessKey();
                    //srtCandidateInfoURI = "http://139.59.39.178/rewamp/controllers/accurateSearch.php?action=getAccess";
                    srtCandidateInfoURI = " https://papa.fit/rewamp/controllers/accurateSearch.php?action=getAccess";
                    m_oWorker.RunWorkerAsync();
                }


                if (programmer_laptop != "Y")
                {
                    check_system();
                    if (check_legal != "Y")
                    {
                        //System.Environment.Exit(1);
                        //System.Windows.Forms.Application.Exit();
                        //Application.Exit();
                        //this.Close();
                        //this.Close();
                        //if (check_legal != "Y")
                        //{
                        //    install_system();
                        //}
                        //System.Environment.Exit(1);
                    }
                    else
                        go_to_company_list();
                }
                else
                    go_to_company_list();
                lvCompanyNN.Focus();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            objPleaseWait.Close();
        }

        public string encode(string old_english)
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

        public string decode(string encoded)
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

        private void wait_for_security()
        {
            currentPid = HardwareInfo.GetProcessorId();
            if (currentPid == "BFEBFBFF00020655")
            {
                programmer_laptop = "Y";
                security_check_filepath = "C:\\windows\\system32";
                security_check_filepath = "C:\\voterlist";
            }
            programmer_laptop = "N";
        }

        private void check_system()
        {
            security_check_drive = Path.GetPathRoot(Environment.SystemDirectory);
            security_check_filename = (security_check_drive + "windows\\system32\\" + "security_check.TXT").Replace(" ", "");
            security_check_filename = ("C:\\voterlist\\" + "security_check.TXT").Replace(" ", "");
            check_legal = "N";
            currentPid = HardwareInfo.GetProcessorId();
            currentHDD = HardwareInfo.GetHDDSerialNo();
            currentBM = HardwareInfo.GetBoardMaker();
            currentBios = HardwareInfo.GetBIOSmaker();
            currentPM = HardwareInfo.GetPhysicalMemory();
            currentCS = HardwareInfo.GetCpuSpeedInGHz().ToString();
            currentCM = HardwareInfo.GetCPUManufacturer();
            if (File.Exists(security_check_filename))
            {
                reload_security = File.ReadAllLines(security_check_filename);
                oldPid = decode(reload_security[0]);
                oldHDD = decode(reload_security[1]);
                oldBM = decode(reload_security[2]);
                oldBios = decode(reload_security[3]);
                oldPM = decode(reload_security[4]);
                oldCS = decode(reload_security[5]);
                oldCM = decode(reload_security[6]);

                //if (currentPid == oldPid && currentHDD == oldHDD && currentBM == oldBM && currentBios == oldBios && currentPM == oldPM && currentCS == oldCS && currentCM == oldCM)
                if (currentPid == oldPid && currentBM == oldBM && currentBios == oldBios && currentPM == oldPM && currentCS == oldCS && currentCM == oldCM)
                {
                    check_legal = "Y";
                }
                else
                {
                    check_legal = "N";
                }
            }
        }

        private void go_to_company_list()
        {
            GlobalClass.drivesearch();
            int i = 0;
            String nikname, drive_name;
            ConnectionWithAccess.total_companies = GlobalClass.allnik.Count;
            lvCompanyNN.Items.Clear();
            if (GlobalClass.allnik.Count > 1)
            {
                lvCompanyNN.Visible = true;
                foreach (string filename in GlobalClass.allnik)
                {
                    drive_name = filename.Substring(0, 1);
                    if (filename.Length == 14)
                        nikname = filename.Substring(7, 3);
                    else
                        nikname = filename.Substring(3, 10);
                    lvCompanyNN.Items.Add(Convert.ToString(nikname));

                    TextReader reader = new StreamReader(filename);
                    line = reader.ReadLine();
                    line = reader.ReadLine();

                    lvCompanyNN.Items[i].SubItems.Add(decode(line));
                    lvCompanyNN.Items[i].SubItems.Add(drive_name);
                    i++;
                }
            }
            else if (GlobalClass.allnik.Count == 1)
            {
                ConnectionWithAccess.databasename = GlobalClass.allnik[0].ToString().Substring(7, 3);
                DriveInfo[] drives = DriveInfo.GetDrives();
                bool mFound = false;

                foreach (DriveInfo mdrive in drives)
                {
                    ConnectionWithAccess.mNIK = ConnectionWithAccess.databasename;
                    ConnectionWithAccess.mDataFile = mdrive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".mdb";
                    if (File.Exists(ConnectionWithAccess.mDataFile))
                    {
                        ConnectionWithAccess.setMDBpassword(ConnectionWithAccess.mDataFile, string.Empty, "sharp_mdb");
                        ConnectionWithAccess.data_drive = ConnectionWithAccess.mDataFile.Substring(0, 1) + ":\\";
                        ConnectionWithAccess.mpdffile = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".PDF";
                        // ConnectionWithAccess.df_filename = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".LDF";
                        ConnectionWithAccess.report_file_location = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\reports\\";
                        mtextfilename = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + ConnectionWithAccess.mDataFile; //Kunal

                        ConnectionWithAccess.connection.ConnectionString = mtextfilename;
                        mFound = true;
                        break;
                    }
                }

                if (mFound == false)
                {
                    MessageBox.Show("Company Data Not Found", "Company Details");
                    this.Close();
                }
                for (int j = 1; j <= 99; j++)
                {
                    if (j <= 9)
                        ConnectionWithAccess.tablename[j] = ConnectionWithAccess.mNIK + "_000" + j;
                    else
                        ConnectionWithAccess.tablename[j] = ConnectionWithAccess.mNIK + "_00" + j;
                }
                btn_create_new_company.Visible = false;
                lvCompanyNN.Visible = false;
                get_company_details();
                if (ConnectionWithAccess.company_details[33] != "Y")
                {
                    LoginForm login = new LoginForm();
                    login.MdiParent = this;
                    login.Show();
                }
                else
                {
                    ConnectionWithAccess.muser = "admin";
                    ConnectionWithAccess.mUserFeatures = "YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYN";
                    ConnectionWithAccess.mpassword = "admin";
                    MainForm main = new MainForm();
                    main.ShowDialog();
                    this.Hide();

                    //this.ParentForm.Hide();
                }
            }
            else
            {
                comattach new_company_creation_form = new comattach();
                new_company_creation_form.Show();
                this.Hide();
                //System.Environment.Exit(1);
                //System.Windows.Forms.Application.Exit();
                //Application.Exit();
                //this.Close();
            }
            if (i > 1)
                lvCompanyNN.Height = ((i + 1) * 36);
            if (lvCompanyNN.Height < 100)
                lvCompanyNN.Height = 120;
            if (lvCompanyNN.Height > 630)
                lvCompanyNN.Height = 630;
        }

        //private void attachDb(String dbName)
        //{
        //    //if (ConnectionWithAccess.use_attach_detach == "Y")
        //    //{
        //        ConnectionWithAccess.command.CommandText = "EXEC sp_attach_db @dbname = '" + ConnectionWithAccess.mNIK + "', @filename1 = '" + ConnectionWithAccess.mDataFile + "', @filename2 = '" + ConnectionWithAccess.df_filename + "';";
        //        ConnectionWithAccess.connection.Open();
        //        try
        //        {
        //            ConnectionWithAccess.command.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        { }
        //        ConnectionWithAccess.connection.Close();
        //    //}
        //}

        private void get_company_details()
        {
            if (MainForm.backup == true)
                mtextfilename = ConnectionWithAccess.data_drive + "backup\\" + ConnectionWithAccess.mNIK + ".txt";
            else
            mtextfilename = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + ".txt";

            if (File.Exists(mtextfilename))
            {
                var lines = File.ReadAllLines(mtextfilename);
                if (lines.Count() > 0)
                {
                    try
                    {
                        //data_from_company_file = File.ReadAllLines(mtextfilename);
                        ConnectionWithAccess.company_details = File.ReadAllLines(mtextfilename);
                        for (row_counter = 0; row_counter < lines.Length; row_counter++)
                        {
                            //data_from_company_file[row_counter] = decode(data_from_company_file[row_counter]);
                            ConnectionWithAccess.company_details[row_counter] = decode(ConnectionWithAccess.company_details[row_counter]);
                        }
                    }
                    catch (Exception ex)
                    {
                        //message_box.Text = Convert.ToString(ex);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //label1.Location.X = 100;
        }

        private void btn_create_new_company_Click(object sender, EventArgs e)
        {
            lvCompanyNN.Visible = false;
            comattach new_company_creation_form = new comattach();
            new_company_creation_form.Show();

            //lvCompanyNN.Visible = false;
            //NewCompanyForm NewCompanyFormform = new NewCompanyForm();
            //NewCompanyFormform.Show();

            //this.Hide();            
        }

        private void btn_update_authority_code_Click(object sender, EventArgs e)
        {
            string authorise_answer;
            authorise_answer = currentPid.Substring(2, 1) + currentPid.Substring(5, 1) + currentPid.Substring(9, 2) + currentPid.Substring(2, 1) + currentPid.Substring(currentPid.Length - 1, 1) + currentPid.Substring(currentPid.Length - 3, 1) + currentPid.Substring(currentPid.Length - 9, 1) + currentPid.Substring(currentPid.Length - 5, 1) + currentPid.Substring(currentPid.Length - 7, 1) + currentPid.Substring(currentPid.Length - 12, 1) + currentPid.Substring(currentPid.Length - 9, 1) + currentPid.Substring(currentPid.Length - 11, 1);
            authorise_answer = currentPid.Substring(1, 1) + currentPid.Substring(3, 1) + currentPid.Substring(5, 1) + currentPid.Substring(7, 1) + currentPid.Substring(currentPid.Length - 1, 1) + currentPid.Substring(currentPid.Length - 3, 1) + currentPid.Substring(currentPid.Length - 5, 1) + currentPid.Substring(currentPid.Length - 7, 1);
            //                + currentPid.Substring(currentPid.Length - 7, 1) + currentPid.Substring(currentPid.Length - 12, 1) + currentPid.Substring(currentPid.Length - 9, 1) + currentPid.Substring(currentPid.Length - 11, 1);
            //authorise_answer = authorise_answer.ToUpper();
        }

        private void install_legal_file()
        {
            security_check_drive = Path.GetPathRoot(Environment.SystemDirectory);
            security_check_filename = (security_check_drive + "windows\\system32\\" + "security_check.TXT").Replace(" ", "");
            //security_check_filename = ("C:\\voterlist\\" + "security_check.TXT").Replace(" ", "");
            FileStream fs4 = new FileStream(security_check_filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer4 = new StreamWriter(fs4);
            currentPid = HardwareInfo.GetProcessorId();
            writer4.WriteLine(encode(currentPid));
            currentHDD = HardwareInfo.GetHDDSerialNo();
            writer4.WriteLine(encode(currentHDD));
            currentBM = HardwareInfo.GetBoardMaker();
            writer4.WriteLine(encode(currentBM));
            currentBios = HardwareInfo.GetBIOSmaker();
            writer4.WriteLine(encode(currentBios));
            currentPM = HardwareInfo.GetPhysicalMemory();
            writer4.WriteLine(encode(currentPM));
            currentCS = HardwareInfo.GetCpuSpeedInGHz().ToString();
            writer4.WriteLine(encode(currentCS));
            currentCM = HardwareInfo.GetCPUManufacturer();
            writer4.WriteLine(encode(currentCM));
            writer4.Flush();
            writer4.Close();
        }

        private void Startup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fSelectCompanyAndNavigate();
            }
            else if (e.Control && e.KeyCode == Keys.F10)
            {
                btn_create_new_company_Click(sender, e);
            }
        }

        private void Startup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MainForm.add_backup_list = true;
                go_to_company_list();
            }
        }

        private void fSelectCompanyAndNavigate()
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            MainForm.backup = false;
            bool mFound = false;
            lvCompanyNN.Visible = false;
            ConnectionWithAccess.databasename = lvCompanyNN.SelectedItems[0].Text;
            if (ConnectionWithAccess.databasename.Length == 10 && ConnectionWithAccess.databasename.Substring(0,6) == "backup")
            {
                MainForm.backup = true;
                ConnectionWithAccess.data_drive = lvCompanyNN.SelectedItems[0].SubItems[2].Text + ":\\";
                ConnectionWithAccess.mNIK = ConnectionWithAccess.databasename.Substring(7,3);
                ConnectionWithAccess.mDataFile = ConnectionWithAccess.data_drive + "backup\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".mdb";
                if (File.Exists(ConnectionWithAccess.mDataFile))
                {
                    ConnectionWithAccess.setMDBpassword(ConnectionWithAccess.mDataFile, string.Empty, "sharp_mdb");
                    ConnectionWithAccess.mpdffile = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".PDF";
                    ConnectionWithAccess.report_file_location = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\reports\\";
                    mtextfilename = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + ConnectionWithAccess.mDataFile; //Kunal
                    ConnectionWithAccess.connection.ConnectionString = mtextfilename;
                    mFound = true;
                }
            }
            else
            {
                ConnectionWithAccess.data_drive = lvCompanyNN.SelectedItems[0].SubItems[2].Text + ":\\";
                ConnectionWithAccess.mNIK = ConnectionWithAccess.databasename;
                ConnectionWithAccess.mDataFile = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".mdb";
                if (File.Exists(ConnectionWithAccess.mDataFile))
                {
                    ConnectionWithAccess.setMDBpassword(ConnectionWithAccess.mDataFile, string.Empty, "sharp_mdb");
                    ConnectionWithAccess.mpdffile = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".PDF";
                    ConnectionWithAccess.report_file_location = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\reports\\";
                    mtextfilename = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString() + ConnectionWithAccess.mDataFile; //Kunal
                    ConnectionWithAccess.connection.ConnectionString = mtextfilename;
                    mFound = true;
                }
            }
            if (mFound == false)
            {
                MessageBox.Show("Company Data Not Found", "Company Details");
                System.Environment.Exit(1);
                System.Windows.Forms.Application.Exit();
                Application.Exit();
                this.Close();
            }
            for (int i = 1; i <= 99; i++)
            {
                if (i <= 9)
                    ConnectionWithAccess.tablename[i] = ConnectionWithAccess.mNIK + "_000" + i;
                else
                    ConnectionWithAccess.tablename[i] = ConnectionWithAccess.mNIK + "_00" + i;
            }
            btn_create_new_company.Visible = false;
            lvCompanyNN.Visible = false;
            get_company_details();
            if (ConnectionWithAccess.company_details[33] != "Y")
            {
                LoginForm login = new LoginForm();
                //login.MdiParent = this;
                login.Show();
                this.Hide();
            }
            else
            {
                ConnectionWithAccess.muser = "admin";
                ConnectionWithAccess.mUserFeatures = "YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY";
                ConnectionWithAccess.mpassword = "admin";
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
                //this.ParentForm.Hide();
            }
            objPleaseWait.Close();
        }

        private void fUpdatetxtFileWhileinUse(string strFileName)
        {
            System.IO.File.Create(strFileName);
        }

        private void lvCompanyNN_Click(object sender, EventArgs e)
        {
            bool isCompanyinUse = false;
            string strFileName = lvCompanyNN.SelectedItems[0].SubItems[2].Text + ":\\ACC\\" + lvCompanyNN.SelectedItems[0].Text + "\\" + lvCompanyNN.SelectedItems[0].Text + ".abc";
            if (lvCompanyNN.SelectedItems[0].Text.Contains("backup"))
                strFileName = lvCompanyNN.SelectedItems[0].SubItems[2].Text + ":\\" + lvCompanyNN.SelectedItems[0].Text + ".abc";
            else
                strFileName = lvCompanyNN.SelectedItems[0].SubItems[2].Text + ":\\ACC\\" + lvCompanyNN.SelectedItems[0].Text + "\\" + lvCompanyNN.SelectedItems[0].Text + ".abc";
            if (File.Exists(strFileName))
                isCompanyinUse = true;
            if (isCompanyinUse)
            {
                DialogResult dialogResult = MessageBox.Show("Company already opened or was closed incorrectly." + System.Environment.NewLine +
                    "Would like to open?"
                    , "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    fSelectCompanyAndNavigate();
                }
            }
            else
            {
                fUpdatetxtFileWhileinUse(strFileName);
                fSelectCompanyAndNavigate();
            }
        }
    }
}
