using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SHARP_ACCOUNTING
{
    public partial class AccessKey : Form
    {

        ConnectionWithAccess ConnectionCommand = new ConnectionWithAccess();
        public AccessKey()
        {
            InitializeComponent();
        }

        #region declaration
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

        public static string[] data_from_company_file;
        public string strAccess_key { get; set; }
        public bool bGetDataFromServer { get; set; }
        public string sharp_details_filename { get; set; }
        private string candidate_data { get; set; }
        //public string srtCandidateInfoURI { get; set; }
        Global objGlobalClass = new Global();

        string data_drive = string.Empty;
        string setup_drive = string.Empty;
        //string sharp_details_filename = string.Empty;
        //string candidate_data = string.Empty;
        //string straccess_key = string.Empty;
        //public string srtCandidateInfoURI = "https://papa.fit/rewamp/routes/accurateSearchRoute.php?action=getCandidateInfo";
        //public string srtCandidateInfoURI = "http://139.59.39.178/rewamp/routes/accurateSearchRoute.php?action=getCandidateInfo";
        //public string srtCandidateInfoURI = "http://139.59.39.178/rewamp/routes/accurateSearchRoute.php?action=getAccess";
        //public string srtCandidateInfoURI = "http://139.59.39.178/rewamp/controllers/accurateSearch.php?action=getAccess";
        //public string srtCandidateInfoURI = "http://139.59.39.178/rewamp/controllers/accurateSearch.php?action=getAccess";
        //public string srtCandidateInfoURI = "https://papa.fit/rewamp/controllers/accurateSearch.php?action=getAccess";
        public string srtCandidateInfoURI = "https://papa.fit/rewamp/controllers/accurateSearch.php?action=getAccess";
        string strServerUrl = "http://smartifyindia.co.in:8083/";

        //cVoters objVoters = new cVoters();
        //Global objGlobalClass = new Global();
        //string data_drive = string.Empty;
        public bool bShowStartupScreen { get; set; }

        #endregion

        private void AccessKey_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            setup_drive = objGlobalClass.Globalsetup_drivesearch();
            if (setup_drive == string.Empty)
            {
                MessageBox.Show("Sorry Setup Folder Not Found, Improper Installation....");
                System.Environment.Exit(1);
                System.Windows.Forms.Application.Exit();
                Application.Exit();
                this.Close();
            }

            CheckSharpFileExists();
        }

        #region Methods

       

        private void CheckSharpFileExists()
        {
            string strAccess_Key = string.Empty;
            sharp_details_filename = setup_drive + ":\\sharp\\sharp_info.txt";
           // bool bGetDataFromServer = false;
            bool bGoToStartup = false;
            bool bFirstTimeLoad = false;

            if (File.Exists(sharp_details_filename) && bShowStartupScreen == false)
            {
                strAccess_Key = GetAccessKey();
                if (CheckForInternetConnection())
                {
                    bGetDataFromServer = true;
                    bGoToStartup = true;
                }
                else
                {
                    bGoToStartup = true;
                }
            }
            else
            {
                if (CheckForInternetConnection())
                {
                    txtAccessKey.Enabled = true;
                    btnStart.Enabled = true;
                    lblMsg.Visible = false;
                    bGetDataFromServer = true;
                    bGoToStartup = true;
                    bFirstTimeLoad = true;

                }
                else
                {
                    lblMsg.Text = "No Internet Connection..." + System.Environment.NewLine + "Application requires working internet connection." + System.Environment.NewLine + "Please connect to internet and restart application.";
                    lblMsg.Visible = true;
                    btnStart.Enabled = false;
                    txtAccessKey.Enabled = false;
                    return;
                }
            }

            if (bFirstTimeLoad)
                return;

            if (bGoToStartup)
            {
                vOpenCompanyStartup();
            }
        }

        #region CandidateDetails
        //private void GetCandidateDetailsFromServer(string straccess_key)
        //{
        //    //Global objvoters = new Global();
        //    CandidateData cd = null;
        //    var strRequest = "{\"access_key\":\"" + straccess_key.Trim() + "\"} ";
        //    try
        //    {
        //        //srtCandidateInfoURI = ""https://papa.fit/rewamp/controllers/accurateSearch.php?action=getAccess";
        //        //strRequest = { "access_key":"1234"};
        //        //cd = PostMessageToURLHttp(srtCandidateInfoURI, strRequest);
        //        //        string party_logo_imgBase64String = string.Empty;
        //        string candidate_slip_imgBase64String = string.Empty;

        //        if (cd != null && cd.data != null && cd.data.Count > 0)
        //        {
        //            CandidateInfo ci = cd.data[0];
        //            ci.get_data_from_server = "1";
        //            if (ci.inactive.Trim() == "1")
        //            {
        //                MessageBox.Show("Application de-activated! Contact application owner to re-activate", "Application de-activated", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                System.Environment.Exit(1);
        //                System.Windows.Forms.Application.Exit();
        //                Application.Exit();
        //                this.Close();
        //            }

        //            if (cd.data[0].party_logo != string.Empty)
        //                party_logo_imgBase64String = objGlobalClass.ImageToBase64(objGlobalClass.GetImage(ci.party_logo));
        //            if (cd.data[0].candidate_slip != string.Empty)
        //                candidate_slip_imgBase64String = objGlobalClass.ImageToBase64(objGlobalClass.GetImage(ci.candidate_slip));

        //            candidate_data += objGlobalClass.encode("access_key~panel~panel_image~party_name~party_logo_imgBase64String~name1~name2~name3~name4~name5~candidate_slip_imgBase64String~db_name~get_data_from_server") + System.Environment.NewLine;

        //            candidate_data += objGlobalClass.encode(straccess_key) + "~" + objGlobalClass.encode(ci.panel) + "~" + ci.panel_image + "~" + objGlobalClass.encode(ci.party_name) + "~" + party_logo_imgBase64String + "~" +
        //                objGlobalClass.encode(ci.name1) + "~" + objGlobalClass.encode(ci.name2) + "~" + objGlobalClass.encode(ci.name3) + "~" + objGlobalClass.encode(ci.name4) + "~" + objGlobalClass.encode(ci.name5) + "~" + candidate_slip_imgBase64String + "~" +
        //                objGlobalClass.encode(ci.db_name.ToLower().Replace(".db", ".mdb")) + "~" + objGlobalClass.encode(ci.get_data_from_server) + System.Environment.NewLine;

        //            if (candidate_data.Trim() != string.Empty)
        //                Save_CandidateInfo_File();
        //        }
        //        //else
        //        //{
        //        //    MessageBox.Show("No Data found from server. Local data will be used", "Data missing");
        //        //    //System.Environment.Exit(1);
        //        //    //System.Windows.Forms.Application.Exit();
        //        //    //Application.Exit();
        //        //    //this.Close();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void GetCandidateDetailsFromServer(string straccess_key, bool bConnectServer = false)
        {
            //Global objvoters = new Global();
            CandidateData cd = null;

            var strRequest = "{\"access_key\":\"" + straccess_key.Trim() + "\"} ";
            try
            {
                //srtCandidateInfoURI = ""https://papa.fit/rewamp/controllers/accurateSearch.php?action=getAccess";
                //strRequest = { "access_key":"1234"};
                //cd = PostMessageToURLHttp(srtCandidateInfoURI, strRequest);
                strServerUrl = strServerUrl + "query";
                strRequest = "select * from CandidateInfo where access_key = " + straccess_key.Trim();
                strRequest = "{\"query\":\"" + "select * from CandidateInfo where access_key = " + straccess_key.Trim() + "\"} "; 
                cd = PostMessageToURLHttp(strServerUrl, strRequest);

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
                    if (cd.data[0].candidate_slip != string.Empty)
                        candidate_slip_imgBase64String = objGlobalClass.ImageToBase64(objGlobalClass.GetImage(ci.candidate_slip));

                    candidate_data += objGlobalClass.encode("access_key~panel~panel_image~party_name~party_logo_imgBase64String~name1~name2~name3~name4~name5~candidate_slip_imgBase64String~db_name~get_data_from_server") + System.Environment.NewLine;

                    candidate_data += objGlobalClass.encode(straccess_key) + "~" + objGlobalClass.encode(ci.panel) + "~" + ci.panel_image + "~" + objGlobalClass.encode(ci.party_name) + "~" + party_logo_imgBase64String + "~" +
                        objGlobalClass.encode(ci.name1) + "~" + objGlobalClass.encode(ci.name2) + "~" + objGlobalClass.encode(ci.name3) + "~" + objGlobalClass.encode(ci.name4) + "~" + objGlobalClass.encode(ci.name5) + "~" + candidate_slip_imgBase64String + "~" +
                        objGlobalClass.encode(ci.db_name.ToLower().Replace(".db", ".mdb")) + "~" + objGlobalClass.encode(ci.get_data_from_server) + System.Environment.NewLine;

                    if (candidate_data.Trim() != string.Empty)
                        Save_CandidateInfo_File();
                }
                //else
                //{
                //    MessageBox.Show("No Data found from server. Local data will be used", "Data missing");
                //    //System.Environment.Exit(1);
                //    //System.Windows.Forms.Application.Exit();
                //    //Application.Exit();
                //    //this.Close();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadCandidateDetails()
        {
            //cVoters objvoters = new cVoters();
            CandidateInfo ci = new CandidateInfo();
            if (File.Exists(sharp_details_filename))
            {
                string[] strcandidate_array = File.ReadAllLines(sharp_details_filename);
                if (strcandidate_array != null && strcandidate_array.Length > 1)
                {
                    string[] strcandidate_data = strcandidate_array[1].Split('~');
                    if (strcandidate_data != null && strcandidate_data.Length > 11)
                    {
                        ci.panel = objGlobalClass.decode(strcandidate_data[1].ToString());
                        //panel_number = ci.panel;
                        //lblPanel.Text = ci.panel;
                        ci.panel_image = strcandidate_data[2].ToString();
                        ci.party_name = objGlobalClass.decode(strcandidate_data[3].ToString());
                        // lblParty.Text = ci.party_name;
                        ci.party_logo = strcandidate_data[4].ToString();
                        ci.name1 = objGlobalClass.decode(strcandidate_data[5].ToString());
                        //lblCandidate1.Text = ci.name1;
                        ci.name2 = objGlobalClass.decode(strcandidate_data[6].ToString());
                        //lblCandidate2.Text = ci.name2;
                        ci.name3 = objGlobalClass.decode(strcandidate_data[7].ToString());
                        //lblCandidate3.Text = ci.name3;
                        ci.name4 = objGlobalClass.decode(strcandidate_data[8].ToString());
                        //lblCandidate4.Text = ci.name4;
                        ci.name5 = objGlobalClass.decode(strcandidate_data[9].ToString());
                        //lblName.Text = ci.name5;
                        ci.candidate_slip = strcandidate_data[10].ToString();
                        ci.db_name = objGlobalClass.decode(strcandidate_data[11].ToString());
                        //mdb_fileName = ci.db_name;
                        if (strcandidate_data.Length > 12)
                            ci.get_data_from_server = objGlobalClass.decode(strcandidate_data[12].ToString());
                        else
                            ci.get_data_from_server = "0";
                        if (ci.get_data_from_server == "1")
                            bGetDataFromServer = true;
                        else
                            bGetDataFromServer = false;
                        ConnectionWithAccess.setup_drive = setup_drive + ":\\";
                        MainForm.access_line1 = ci.name1;
                        MainForm.access_line2 = ci.name2;
                        MainForm.access_line3 = ci.name3;
                        MainForm.access_line4 = ci.name4;
                        MainForm.access_line5 = ci.name5;
                        MainForm.software_for = ci.name1;
                        MainForm.total_sms_count = Convert.ToInt32(objGlobalClass.decode(strcandidate_data[1].ToString()));
                    }
                }

                //if (ci.party_logo != string.Empty)
                //    pb_party_logo.Image = objvoters.Base64ToImage(ci.party_logo);

                //if (ci.candidate_slip != string.Empty)
                //    pb_candidate_details.Image = objvoters.Base64ToImage(ci.candidate_slip);

            }
            else
            {
                MessageBox.Show("Invalid key, No data found. Application will be closed! Contact application owner to re-activate", "Invlaid Key", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Environment.Exit(1);
                System.Windows.Forms.Application.Exit();
                Application.Exit();
                this.Close();
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



        #endregion

        private void vOpenCompanyStartup()
        {
            if (bGetDataFromServer)
            {
                if (File.Exists(sharp_details_filename))
                {
                    strAccess_key = GetAccessKey();
                }
                GetCandidateDetailsFromServer(strAccess_key, true);
            }
            LoadCandidateDetails();

            this.Close();
            //Startup objStartUp = new Startup();
            ////Dashboard objDashboard = new Dashboard();
            //objStartUp.bGetDataFromServer = bGetDataFromServer;
            //objStartUp.strAccess_key = strAccess_Key;
            //objStartUp.sharp_details_filename = sharp_details_filename;
            ////// objDashboard.candidate_data = candidate_data;
            //objStartUp.srtCandidateInfoURI = srtCandidateInfoURI;
            //this.Hide();
            //objStartUp.Closed += (s, args) => this.Close();
            //objStartUp.Show();
            //this.Hide();
            //this.Close();
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
                }
            }
            return strAccess_key;


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

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            //PleaseWait objPleaseWait = new PleaseWait();
            //objPleaseWait.Show();
            //Application.DoEvents();
            if (txtAccessKey.Text.Trim() != string.Empty)
            {
                strAccess_key = txtAccessKey.Text.Trim();
                vOpenCompanyStartup();
                //vOpenCompanyStartup(true, txtAccessKey.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please enter Access Key");
            }
            //objPleaseWait.Close();
        }

        private void AccessKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAccessKey.Text.Trim() != string.Empty)
                {
                    strAccess_key = txtAccessKey.Text.Trim();
                    vOpenCompanyStartup();
                }
                else
                {
                    MessageBox.Show("Please enter Access Key");
                }
            }
        }
    }
}
