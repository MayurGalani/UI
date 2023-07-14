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
    public partial class subForm_Report : Form
    {
        public subForm_Report()
        {
            InitializeComponent();
        }
        
        public string pdfFileToLoad { get; set; }
        private void subForm_Report_Load(object sender, EventArgs e)
        {
            pdf_viewer1.Visible = true;
            pdf_viewer1.LoadFile(pdfFileToLoad);

        }
    }
}
