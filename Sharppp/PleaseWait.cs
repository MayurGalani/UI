﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARP_ACCOUNTING
{
    public partial class PleaseWait : Form
    {
        public PleaseWait(string strMsg="Please Wait Loading Data...")
        {
            InitializeComponent();
            lblWait.Text = strMsg;
        }
    }
}
