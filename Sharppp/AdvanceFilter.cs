using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARP_ACCOUNTING
{
    public partial class AdvanceFilter : UserControl
    {
        public AdvanceFilter()
        {
            InitializeComponent();
        }

        string multiple_choice;
        private static int row_pointer;
        string selectedpartyname, selectedpartycity, selectedcitylist, selecteditemlist, selectedtaxlist, selectedarealist;
        string temp_word;
        int temp_int;
        public string PartyListQuery { get; set; }
        public string CityListQuery { get; set; }
        public string AreaListQuery { get; set; }
        public string ItemListQuery { get; set; }
        public string TaxListQuery { get; set; }

        //public string ma_n { get; set; }
        //public string md_c { get; set; }

        public string selectedPartyList { get { return selectedpartyname; } }
        public string selectedPartyCityList { get { return selectedpartycity; } }
        public string selectedCityList { get { return selectedcitylist; } }
        public string selectedAreaList { get { return selectedarealist; } }
        public string selectedItemList { get { return selecteditemlist; } }
        public string selectedTaxList { get { return selectedtaxlist; } }
        
        private void picpartyList_Click(object sender, EventArgs e)
        {
            chkpartyList.BringToFront();
            multiple_choice = "Party";
            chkpartyList.Visible = true;
            chkpartyList.Size =  new System.Drawing.Size(300, 200);
            btnPartyListSelectAll.Visible = true;
            btncloseselection.Visible = true;
            fill_report_party_combobox();
            //Generate.Visible = false;
        }

        private void fill_report_party_combobox()
        {
            //if (chkpartyList.Items.Count == 0)
            //{
                //ConnectionWithAccess.query = "select [desc],city,a_n,s_a from " + ConnectionWithAccess.tablename[01] + " f1 where f1.a_n = '" + ma_n + "' and f1.s_a <> '@@@'";
                ConnectionWithAccess.query = PartyListQuery;
                ConnectionWithAccess.fillCheckListBox(chkpartyList);
            //}
        }
        public event EventHandler ButtonClick;

        protected void PictureBox43_Click(object sender, EventArgs e)
        {
            //report_keys_enable();
            if (multiple_choice == "Party")
            {
                for (row_pointer = 0; row_pointer < chkpartyList.Items.Count - 1; row_pointer++)
                {
                    if (chkpartyList.GetItemCheckState(row_pointer) == CheckState.Checked)
                        chkpartyList.SetItemCheckState(row_pointer, CheckState.Unchecked);
                }
                tbselacc.Text = "0 Selected";
                btnPartyListSelectAll.Text = "Select All";
                selectedpartyname = string.Empty;
                selectedpartycity = string.Empty;
            }
            else if (multiple_choice == "City")
            {
                for (row_pointer = 0; row_pointer < chkcityList.Items.Count - 1; row_pointer++)
                {
                    if (chkcityList.GetItemCheckState(row_pointer) == CheckState.Checked)
                        chkcityList.SetItemCheckState(row_pointer, CheckState.Unchecked);
                }
                tbreportcity.Text = "0 Selected";
                btnPartyListSelectAll.Text = "Select All";
                selectedcitylist = string.Empty;
            }
            else if (multiple_choice == "Area")
            {
                for (row_pointer = 0; row_pointer < chkAreaList.Items.Count - 1; row_pointer++)
                {
                    if (chkAreaList.GetItemCheckState(row_pointer) == CheckState.Checked)
                        chkAreaList.SetItemCheckState(row_pointer, CheckState.Unchecked);
                }
                tbreprotArea.Text = "0 Selected";
                btnAreaListSelectAll.Text = "Select All";
                selectedarealist = string.Empty;
            }
            else if (multiple_choice == "Tax")
            {
                for (row_pointer = 0; row_pointer < chktaxlist.Items.Count - 1; row_pointer++)
                {
                    if (chktaxlist.GetItemCheckState(row_pointer) == CheckState.Checked)
                        chktaxlist.SetItemCheckState(row_pointer, CheckState.Unchecked);
                }
                tbreporttax.Text = "0 Selected";
                btnPartyListSelectAll.Text = "Select All";
                selectedtaxlist = string.Empty;
            }
            else if (multiple_choice == "Item")
            {
                for (row_pointer = 0; row_pointer < chktaxlist.Items.Count - 1; row_pointer++)
                {
                    if (chktaxlist.GetItemCheckState(row_pointer) == CheckState.Checked)
                        chktaxlist.SetItemCheckState(row_pointer, CheckState.Unchecked);
                }
                tbreportitems.Text = "0 Selected";
                btnPartyListSelectAll.Text = "Select All";
                selecteditemlist = string.Empty;
            }
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);     
        }

        private void picpartycity_Click(object sender, EventArgs e)
        {
            multiple_choice = "City";
            chkcityList.Visible = true;
            chkcityList.Size = new System.Drawing.Size(300, 200);
            btnPartyListSelectAll.Visible = true;
            btncloseselection.Visible = true;
            fill_report_city_combobox();
        }

        private void fill_report_city_combobox()
        {
            if (chkcityList.Items.Count == 0)
            {
                //ConnectionWithAccess.query = "select distinct [city] from " + ConnectionWithAccess.tablename[01] + " f1 where f1.a_n = '" + ma_n + "' and f1.s_a <> '@@@'";
                ConnectionWithAccess.query = CityListQuery;
                ConnectionWithAccess.fillCheckListBox(chkcityList);
            }
        }

        private void pictaxList_Click(object sender, EventArgs e)
        {
            multiple_choice = "Tax";
            chktaxlist.Visible = true;
            chktaxlist.Size = new System.Drawing.Size(300, 200);
            btnPartyListSelectAll.Visible = true;
            btncloseselection.Visible = true;
            fill_report_tax_combobox();
        }

        private void fill_report_tax_combobox()
        {
            //if (chktaxlist.Items.Count == 0)
            //{
                //ConnectionWithAccess.query = "select distinct f6.tx_code, f6.[desc] from " + ConnectionWithAccess.tablename[06] + " f6 where f6.d_c = " + md_c;
                ConnectionWithAccess.query = TaxListQuery;
                ConnectionWithAccess.fillCheckListBox(chktaxlist);
            //}
        }

        private void btncloseselection_Click(object sender, EventArgs e)
        {
            //Generate.Visible = true;
            chkpartyList.Visible = false;
            chkcityList.Visible = false;
            chktaxlist.Visible = false;
            chkAreaList.Visible = false;
            btnPartyListSelectAll.Visible = false;
            btncloseselection.Visible = false;
            selectedpartyname = "";
            temp_int = 0;
            if (multiple_choice == "Party")
            {
                selectedpartyname = null;
                selectedpartycity = null;
                for (row_pointer = 0; row_pointer < chkpartyList.Items.Count; row_pointer++)
                {
                    if (chkpartyList.GetItemCheckState(row_pointer) == CheckState.Checked)
                    {
                        var cellArray = chkpartyList.Items[row_pointer].ToString().Trim().Split(new[] { ',' });
                        selectedpartyname = selectedpartyname + "'" + cellArray[0] + "',";
                        selectedpartycity = selectedpartycity + "'" + cellArray[1] + "',";
                        temp_int++;
                    }
                }
                if (temp_int > 0)
                {
                    selectedpartyname = selectedpartyname.Substring(0, selectedpartyname.Length - 1);
                    selectedpartycity = selectedpartycity.Substring(0, selectedpartycity.Length - 1);
                }
                tbselacc.Text = Convert.ToString(temp_int) + " Selected";
            }
            else if (multiple_choice == "City")
            {
                selectedcitylist = null;
                for (row_pointer = 0; row_pointer < chkcityList.Items.Count; row_pointer++)
                {
                    if (chkcityList.GetItemCheckState(row_pointer) == CheckState.Checked)
                    {
                        selectedcitylist = selectedcitylist + "'" + chkcityList.Items[row_pointer].ToString() + "',";
                        temp_int++;
                    }
                }
                if (temp_int > 0)
                    selectedcitylist = selectedcitylist.Substring(0, selectedcitylist.Length - 1);
                tbreportcity.Text = Convert.ToString(temp_int) + " Selected";
            }
            else if (multiple_choice == "Area")
            {
                selectedarealist = null;
                for (row_pointer = 0; row_pointer < chkAreaList.Items.Count; row_pointer++)
                {
                    if (chkAreaList.GetItemCheckState(row_pointer) == CheckState.Checked)
                    {
                        selectedarealist = selectedarealist + "'" + chkAreaList.Items[row_pointer].ToString() + "',";
                        temp_int++;
                    }
                }
                if (temp_int > 0)
                    selectedarealist = selectedarealist.Substring(0, selectedarealist.Length - 1);
                tbreprotArea.Text = Convert.ToString(temp_int) + " Selected";
            }
            else if (multiple_choice == "Tax")
            {
                selectedtaxlist = null;
                for (row_pointer = 0; row_pointer < chktaxlist.Items.Count; row_pointer++)
                {
                    if (chktaxlist.GetItemCheckState(row_pointer) == CheckState.Checked)
                    {
                        temp_word = chktaxlist.Items[row_pointer].ToString().Substring(0, (chktaxlist.Items[row_pointer].ToString().IndexOf("-")) - 1);
                        selectedtaxlist = selectedtaxlist + "'" + temp_word + "',";
                        temp_int++;
                    }
                }
                if (temp_int > 0)
                    selectedtaxlist = selectedtaxlist.Substring(0, selectedtaxlist.Length - 1);
                tbreporttax.Text = Convert.ToString(temp_int) + " Selected";
            }
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);  
            //Generate.Visible = true;
            //gdvreport.Visible = false;
            //dgv_tax_report.Visible = false;
        }

        private void btnPartyListSelectAll_Click(object sender, EventArgs e)
        {
            if (chkpartyList.Visible)
            {
                for (int i = 0; i < chkpartyList.Items.Count - 1; i++)
                {
                    if (btnPartyListSelectAll.Text == "Select All")
                        chkpartyList.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkpartyList.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (btnPartyListSelectAll.Text == "Select All")
                    btnPartyListSelectAll.Text = "UnSelect All";
                else
                    btnPartyListSelectAll.Text = "Select All";
                tbselacc.Text = "0 Selected";
                selectedpartyname = null;
            }
            else if (chkcityList.Visible)
            {
                for (int i = 0; i < chkcityList.Items.Count - 1; i++)
                {
                    if (btnPartyListSelectAll.Text == "Select All")
                        chkcityList.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkcityList.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (btnPartyListSelectAll.Text == "Select All")
                    btnPartyListSelectAll.Text = "UnSelect All";
                else
                    btnPartyListSelectAll.Text = "Select All";
                tbreportcity.Text = "0 Selected";
                selectedcitylist = null;
            }
            else if (chkAreaList.Visible)
            {
                for (int i = 0; i < chkAreaList.Items.Count - 1; i++)
                {
                    if (btnAreaListSelectAll.Text == "Select All")
                        chkAreaList.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkAreaList.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (btnAreaListSelectAll.Text == "Select All")
                    btnAreaListSelectAll.Text = "UnSelect All";
                else
                    btnAreaListSelectAll.Text = "Select All";
                tbreprotArea.Text = "0 Selected";
                selectedarealist = null;
            }
            else if (chktaxlist.Visible)
            {
                for (int i = 0; i < chktaxlist.Items.Count - 1; i++)
                {
                    if (btnPartyListSelectAll.Text == "Select All")
                        chktaxlist.SetItemCheckState(i, CheckState.Checked);
                    else
                        chktaxlist.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (btnPartyListSelectAll.Text == "Select All")
                    btnPartyListSelectAll.Text = "UnSelect All";
                else
                    btnPartyListSelectAll.Text = "Select All";
                tbreporttax.Text = "0 Selected";
                selectedtaxlist = null;
            }
            
            //Generate.Visible = true;
            //gdvreport.Visible = false;
            //dgv_tax_report.Visible = false;
            //Generate.Visible = false;
        }

        private void picpartyArea_Click(object sender, EventArgs e)
        {
            chkAreaList.BringToFront();
            multiple_choice = "Area";
            chkAreaList.Visible = true;
            chkAreaList.Size = new System.Drawing.Size(300, 200);
            btnAreaListSelectAll.Visible = true;
            btncloseselection.Visible = true;
            fill_report_area_combobox();
            //Generate.Visible = false;
        }

        private void fill_report_area_combobox()
        {
            if (chkAreaList.Items.Count == 0)
            {
                //ConnectionWithAccess.query = "select [desc],city,a_n,s_a from " + ConnectionWithAccess.tablename[01] + " f1 where f1.a_n = '" + ma_n + "' and f1.s_a <> '@@@'";
                ConnectionWithAccess.query = AreaListQuery;
                ConnectionWithAccess.fillCheckListBox(chkAreaList);
            }
        }

        
    }
}
