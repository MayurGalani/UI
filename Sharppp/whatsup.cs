using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WhatsAppApi;

namespace SHARP_ACCOUNTING
{
    public partial class whatsup : Form
    {
        public whatsup()
        {
            InitializeComponent();
        }

        private void btn_send_whatsup_message_Click(object sender, EventArgs e)
        {
            string from = "919822018644"; //(Enter Your Mobile Number)
            string to = tb_whatsup_msg_to.Text;
            string msg = tb_whatsup_msg_content.Text;
            WhatsApp wa = new WhatsApp(from, "WhatsAppPassword", "NickName", false, false);
            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected to WhatsApp...");
                wa.OnLoginSuccess += (phonenumber, data) =>
                    {
                        wa.SendMessage(to, msg);
                        MessageBox.Show("Message Sent...");
                    };
                wa.OnLoginFailed += (data) =>
                    {
                        MessageBox.Show("Login Failed : {0} : ", data);
                    };

                wa.Login();
            };
            wa.OnConnectFailed += (Exception) =>
                {
                    MessageBox.Show("Connection Failed...");
                };

        }
    }
}
