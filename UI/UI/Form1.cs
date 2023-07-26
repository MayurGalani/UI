using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tdreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maintab.SelectedIndexChanged += maintab_SelectedIndexChanged;
        }

        private void maintab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (maintab.SelectedTab.Name == "tdreport")
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tbdash_Click(object sender, EventArgs e)
        {

        }
    }
}
