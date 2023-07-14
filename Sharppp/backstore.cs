using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace SHARP_ACCOUNTING
{
    public partial class backup : Form
    {
        string folderpath, backup_filename, today_day;
        int file_counter;
        public backup()
        {
            InitializeComponent();
            search_drives();
        }

        private void search_drives()
        {
            lbl_data_drive.Text = ConnectionWithAccess.data_drive;
            ComboBox ddldrives = new ComboBox();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo mdrive in drives)
            {
                comdrive.Items.Add(Convert.ToString(mdrive));
            }
            comdrive.SelectedIndex = comdrive.Items.Count - 1;
            if (ConnectionWithAccess.company_details[37].Length > 10)
            {
                if (ConnectionWithAccess.company_details[37].Contains("["))
                    tb_company_backup_emailid.Text = ConnectionWithAccess.company_details[37].Substring(0, ConnectionWithAccess.company_details[37].IndexOf("["));
                else
                    tb_company_backup_emailid.Text = ConnectionWithAccess.company_details[37];
            }
        }

        string original_filename;

        private void btn_perform_backup_Click(object sender, EventArgs e)
        {
            today_day = DateTime.Now.DayOfWeek.ToString();
            btn_perform_backup.Enabled = false;
            comdrive.Enabled = false;
            cb_backup_full_data.Enabled = false;
            string old_data_file = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".mdb";
            string old_txt_filename = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + ".txt";
            string backup_data_file_folder = comdrive.Text + "backup\\" + ConnectionWithAccess.mNIK + "\\" + ConnectionWithAccess.mNIK + ".mdb";
            string backup_txt_filename_folder = comdrive.Text + "backup\\" + ConnectionWithAccess.mNIK + ".txt";
            string backup_data_file = comdrive.Text + "backup\\" + ConnectionWithAccess.mNIK + "\\" + today_day + "\\" + ConnectionWithAccess.mNIK + ".mdb";
            string backup_txt_filename = comdrive.Text + "backup\\" + ConnectionWithAccess.mNIK + "\\" + today_day + "\\" + ConnectionWithAccess.mNIK + ".txt";
            ConnectionWithAccess.create_file_folder(backup_data_file);
            ConnectionWithAccess.create_file_folder(backup_txt_filename);
            if (cb_backup_full_data.Checked == true)
            {
                folderpath = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK;
                string[] filePaths = Directory.GetFiles(folderpath, "*.*", SearchOption.AllDirectories);
                for (file_counter = 0; file_counter < filePaths.Length; file_counter++)
                {
                    original_filename = filePaths[file_counter].ToString().ToLower();
                    backup_filename = comdrive.Text + "backup\\" + ConnectionWithAccess.mNIK + "\\" + today_day + "\\" + original_filename.Substring(11, original_filename.Length - 11);
                    System.IO.File.Copy(old_data_file, backup_data_file_folder, true);
                    System.IO.File.Copy(old_txt_filename, backup_txt_filename_folder, true);
                    ConnectionWithAccess.create_file_folder(backup_filename);
                    System.IO.File.Copy(original_filename, backup_filename, true);
                }
            }
            else
            {
                System.IO.File.Copy(old_data_file, backup_data_file_folder, true);
                System.IO.File.Copy(old_txt_filename, backup_txt_filename_folder, true);
                System.IO.File.Copy(old_data_file, backup_data_file, true);
                System.IO.File.Copy(old_txt_filename, backup_txt_filename, true);
            }
            if (cb_send_backup_email.Checked && tb_company_backup_emailid.Text.Contains("@"))
            {
                MainForm.sendemail(ConnectionWithAccess.mNIK + "Company Backup", tb_company_backup_emailid.Text, backup_data_file);
                backup_email_done_date_in_text_file();
            }
            btn_perform_backup.Visible = false;
            comdrive.Enabled = true;
            cb_backup_full_data.Enabled = true;
            this.Close();
        }

        private void backup_email_done_date_in_text_file()
        {
             ConnectionWithAccess.mtextfilename = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + ".txt";
             if (File.Exists(ConnectionWithAccess.mtextfilename))
             {
                 ConnectionWithAccess.company_details[37] = tb_company_backup_emailid.Text + " [" + DateTime.Now.ToShortDateString() + "]";
                 File.Delete(ConnectionWithAccess.mtextfilename);
                 StringBuilder sb = new StringBuilder();
                 for (int row_counter = 0; row_counter < ConnectionWithAccess.company_details.Length; row_counter++)
                 {
                     sb.AppendLine(ConnectionWithAccess.encode(ConnectionWithAccess.company_details[row_counter]));
                 }
                 TextWriter writer = new StreamWriter(ConnectionWithAccess.mtextfilename);
                 writer.WriteLine(sb);
                 writer.Flush();
             }
        }
    }
}
