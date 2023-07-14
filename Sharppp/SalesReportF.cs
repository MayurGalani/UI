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
    public partial class SalesReportF : Form
    {
        public SalesReportF()
        {
            InitializeComponent();
        }

        private void SalesReportF_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
