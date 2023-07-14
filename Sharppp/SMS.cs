using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace SHARP_ACCOUNTING
{

    class SMS
    {
        public static string sms_response;
        //static string url = "http://www.smsjust.com/blank/sms/user/urlsms.php?username=sanjayailani&response=Y&pass=sanjay@1234&senderid=" + ConnectionWithAccess.com_senderid + "&dest_mobileno={0}&message={1}";
        // working perfect     static string url = "http://www.smsjust.com/blank/sms/user/urlsms.php?username=sanjayailani&response=Y&pass=sanjay@1234&senderid=ANUPEG&dest_mobileno={0}&message={1}";
        //static string url = "http://www.smsjust.com/blank/sms/user/urlsms.php?username={{sanjayailani}}&response=Y&pass={{sanjay@1234}}&senderid={{ANUPEG}}&dest_mobileno={{recipient}}&message={{smsBody}}";

        static string url = "http://smpp.co.in/app/smsapi/index.php?key=3602F513384664&campaign=1&routeid=18&type=text&contacts=";
        static string SenderId = "SMATFY";

        //public static void SendSMS(string strMobileNo, string strMsg, string from_position )
        //{
        //    try
        //    {
        //        string strURL = string.Format(url, strMobileNo, strMsg);
        //        using (WebClient client = new WebClient())
        //        {
        //            client.DownloadString(strURL);

        //            string result = client.DownloadString(url);
        //            sms_response = result;
        //            //string result=Client
        //            //if (result.Contains("OK"))
        //            //    MessageBox.Show("Your message has been successfully Sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            //else
        //            //    MessageBox.Show("Message send failuer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sms_response = ex.ToString();
        //    }
        //    finally
        //    {
        //        update_sms_table(strMobileNo, strMsg, from_position, SMS.sms_response);
        //    }
            
        //}

        public static void SendSMS(string strMobileNo, string strMsg, string from_position, int TemplateId = 0)
        {
            string SendingUrl = string.Empty;
            try
            {
                long TemplateIdNumber = 0;
                if (TemplateId == 0) // Smartify Technologies your otp is {#var#} 
                    TemplateIdNumber = 1207161555436530772;
                else if (TemplateId == 1) // Your Outstanding Payment Rs  {#var#} is due as per our Accounts as on  {#var#} . Please send Payment at earliest. 
                    TemplateIdNumber = 1207161555458081439;
                else if (TemplateId == 2) // Smaritfy Technologies Security Device Activated Successfully at  {#var#}
                    TemplateIdNumber = 1207161560172939016;
                else if (TemplateId == 3) // Smaritfy Technologies Security Device De-Activated Successfully at  {#var#} 
                    TemplateIdNumber = 1207161560180024564;
                else if (TemplateId == 4) // Smaritfy Technologies Shutter Opened Detected at  {#var#} 
                    TemplateIdNumber = 1207161560186865676;
                else if (TemplateId == 5) // Smaritfy Technologies Shutter Closed Detected at  {#var#} 
                    TemplateIdNumber = 1207161560190322606;
                else if (TemplateId == 6) // Smartify Technologies Please Check Problem in Area Detected  {#var#} 
                    TemplateIdNumber = 1207161560196119115;
                else if (TemplateId == 7) // Smaritfy Technologies Motion Detected at  {#var#} 
                    TemplateIdNumber = 1207161560199672363;
                else if (TemplateId == 8) // Smaritfy Technologies Mobile Number  {#var#}  Saved Successfully
                    TemplateIdNumber = 1207161560203749199;
                else if (TemplateId == 9) // Smaritfy Technologies Mobile Number  {#var#}  Deleted Successfully
                    TemplateIdNumber = 1207161560207797989;
                else if (TemplateId == 10) // Smaritfy Technologies Thanks for Registration Device  {#var#} 
                    TemplateIdNumber = 1207161560211848688;
                else if (TemplateId == 11) // Smaritfy Technologies Yours Device password for Unique Number {#var#}  is  {#var#} 
                    TemplateIdNumber = 1207161560216151848;
                else if (TemplateId == 12) // Smaritfy Technologies Thanks for Purchasing Device  {#var#} 
                    TemplateIdNumber = 1207161560219931105;
                else if (TemplateId == 13) // Smaritfy Technologies New Location {#var#}  Added Successfully
                    TemplateIdNumber = 1207161564075809826;
                else if (TemplateId == 14) // Smaritfy Technologies New Room {#var#}  Added Successfully
                    TemplateIdNumber = 1207161564080403239;
                else if (TemplateId == 15) // Smaritfy Technologies New Device {#var#}  Added Successfully
                    TemplateIdNumber = 1207161564084004838;
                else if (TemplateId == 16) // Smaritfy Technologies Permission assigned to  {#var#}  Successfully
                    TemplateIdNumber = 1207161564087315644;
                else if (TemplateId == 17) // Smaritfy Technologies For any Techinical Assistance Contact  {#var#}
                    TemplateIdNumber = 1207161564096598233;
                //else if (TemplateId == 18) // sending Otp
                //    TemplateIdNumber = 1207161555436530772;
                //else if (TemplateId == 19) // sending Otp
                //    TemplateIdNumber = 1207161555436530772;
                //else if (TemplateId == 20) // sending Otp
                //    TemplateIdNumber = 1207161555436530772;
                //else if (TemplateId == 21) // sending Otp
                //    TemplateIdNumber = 1207161555436530772;
                using (WebClient client = new WebClient())
                {
                    //client.DownloadString(strURL);
                    //string result = client.DownloadString(url);
                    if (TemplateIdNumber != 0)
                    {
                        SendingUrl = url + strMobileNo;
                        SendingUrl += "&senderid=" + SenderId;
                        SendingUrl += "&msg=" + strMsg;
                        SendingUrl += "&template_id=" + TemplateIdNumber;
                        sms_response = client.DownloadString(SendingUrl);

                    }
                    //string result=Client
                    //if (result.Contains("OK"))
                    //    MessageBox.Show("Your message has been successfully Sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //    MessageBox.Show("Message send failuer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                sms_response = ex.ToString();
            }
            finally
            {
                update_sms_table(strMobileNo, strMsg, from_position, SMS.sms_response, SendingUrl);
            }
        }

        public static void update_sms_table(string strMobileNo, string strMsg, string from_position, string response = "", string SendingUrl = "")
        {
            if (strMsg.Length > 140)
                strMsg = strMsg.Substring(0, 140);
            strMsg = strMsg.Replace(",", "");
            if (response.Length > 10)
                response = response.Substring(0, 10);
            ConnectionWithAccess ConnectionCommand = new ConnectionWithAccess();
            ConnectionWithAccess.query = "insert into " + ConnectionWithAccess.tablename[10] + " (d_d_time,senderid, mobilenumber, message, from_position,response,[user]) values('" + DateTime.Now.ToShortDateString() + "' , '" + ConnectionWithAccess.com_senderid + "', '" + strMobileNo + "', '" + strMsg + "', '" + from_position + "', '" + response + "', '" + ConnectionWithAccess.muser + "')";
            ConnectionCommand.fUpdateInsertDeleteData();
        }
       
    }
}
