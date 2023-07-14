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
    public partial class SaleInvoice2 : Form
    {
        public SaleInvoice2()
        {
            InitializeComponent();
        }

        private void SaleInvoice2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AP2DataSet.salesreport' table. You can move, or remove it, as needed.
            this.salesreportTableAdapter.Fill(this.AP2DataSet.salesreport);
            lblconame.Text = ConnectionWithSQL.companyName;
            lblfrom.Text = ConnectionWithSQL.startperiod;
            lblto.Text = ConnectionWithSQL.endperiod;
        }
    }
}
