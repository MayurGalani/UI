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
    public partial class export : Form
    {
        public static string email_subject,email_id;
        public export()
        {
            InitializeComponent();
            tb_export_email_id.Text = email_id;
            export_pdf_viewer.LoadFile(MainForm.pdf_filename);
        }

        private void btn_export_email_Click(object sender, EventArgs e)
        {
            if (tb_export_email_id.Text != null && tb_export_email_id.Text != "")
            {
                if (!string.IsNullOrEmpty(MainForm.pdf_filename) && File.Exists(MainForm.pdf_filename))
                {

                    MainForm.sendemail(email_subject, tb_export_email_id.Text, MainForm.pdf_filename);
                }
                else
                {
                    MessageBox.Show("PDF file not found");
                }
            }
            else
            {
                MessageBox.Show("Email Id Invalid Not Excepted");
            }
        }

    }
}
