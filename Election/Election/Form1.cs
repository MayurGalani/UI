using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Election
{
    public partial class Form1 : Form
    {
        bool PdDropdownExpand;
        bool EqDropdownExpand;
        bool CtDropdownExpand;
        bool PPDropdownExpand;
        bool DmDropdownExpand;
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool Expand = false;
        private void selectDrowdown_Tick(object sender, EventArgs e)
        {
            if (Expand == false)
            {
                dropdown.Height += 15;
                if (dropdown.Height >= dropdown.MaximumSize.Height)
                {
                    
                    selectDrowdown.Stop();
                    Expand = true;
                }
            }
            else {
                dropdown.Height -= 15;
                if (dropdown.Height <= dropdown.MinimumSize.Height) {
                    
                    selectDrowdown.Stop();
                    Expand = false;
                }
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            selectDrowdown.Start();
            
        }

        private void producttimer_Tick(object sender, EventArgs e)
        {
            if (PdDropdownExpand) 
            {
                PdDropdown.Height -= 10;
                if (PdDropdown.Height <= PdDropdown.MinimumSize.Height)
                {
                    PdDropdownExpand = false;
                    producttimer.Stop();
                }
            }
            else
            {
                PdDropdown.Height += 10;
                if (PdDropdown.Height >= PdDropdown.MaximumSize.Height)
                {
                    PdDropdownExpand = true;
                    producttimer.Stop();
                }
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            producttimer.Start();
        }

        private void enquirytimer_Tick(object sender, EventArgs e)
        {
            if (EqDropdownExpand)
            {
                EqDropdown.Height -= 10;
                if (EqDropdown.Height <= EqDropdown.MinimumSize.Height)
                {
                    EqDropdownExpand = false;
                    enquirytimer.Stop();
                }
            }
            else
            {
                EqDropdown.Height += 10;
                if (EqDropdown.Height >= EqDropdown.MaximumSize.Height)
                {
                    EqDropdownExpand = true;
                    enquirytimer.Stop();
                }
            }
        }

        private void contacttimer_Tick(object sender, EventArgs e)
        {
            if (CtDropdownExpand)
            {
                CtDropdown.Height -= 10;
                if (CtDropdown.Height <= CtDropdown.MinimumSize.Height)
                {
                    CtDropdownExpand = false;
                    contacttimer.Stop();
                }
            }
            else
            {
                CtDropdown.Height += 10;
                if (CtDropdown.Height >= CtDropdown.MaximumSize.Height)
                {
                    CtDropdownExpand = true;
                    contacttimer.Stop();
                }
            }
        }

        private void demotimer_Tick(object sender, EventArgs e)
        {
            if (DmDropdownExpand)
            {
                DmDropdown.Height -= 10;
                if (DmDropdown.Height <= DmDropdown.MinimumSize.Height)
                {
                    DmDropdownExpand = false;
                    demotimer.Stop();
                }
            }
            else
            {
                DmDropdown.Height += 10;
                if (DmDropdown.Height >= DmDropdown.MaximumSize.Height)
                {
                    DmDropdownExpand = true;
                    demotimer.Stop();
                }
            }
        }

        private void privacypolicytimer_Tick(object sender, EventArgs e)
        {
            if (PPDropdownExpand)
            {
                PPDropdown.Height -= 10;
                if (PPDropdown.Height <= PPDropdown.MinimumSize.Height)
                {
                    PPDropdownExpand = false;
                    privacypolicytimer.Stop();
                }
            }
            else
            {
                PPDropdown.Height += 10;
                if (PPDropdown.Height >= PPDropdown.MaximumSize.Height)
                {
                    PPDropdownExpand = true;
                    privacypolicytimer.Stop();
                }
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            demotimer.Start();
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            enquirytimer.Start();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            contacttimer.Start();
        }

        private void btnPrivacyPolicy_Click(object sender, EventArgs e)
        {
            privacypolicytimer.Start();
        }
    }

       

       
    }

