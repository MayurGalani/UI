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
    public partial class SalesFormFinal : Form
    {
        public SalesFormFinal()
        {
            InitializeComponent();
        }

        private void SalesFormFinal_Load(object sender, EventArgs e)
        {
            lblconame.Text = ConnectionWithSQL.companyName;
        }
    }
}
