using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zen.Barcode;

namespace SHARP_ACCOUNTING
{
    public partial class QRCode : Form
    {
        string qr_filename;
        public QRCode()
        {
            InitializeComponent();
        }

        private void btnQRCode_Click(object sender, EventArgs e)
        {
            ConnectionWithAccess.data_drive = "F:\\";
            ConnectionWithAccess.mNIK = "AP2";
            qr_filename = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\images\\temp_qr.png";
            CodeQrBarcodeDraw qrCode = BarcodeDrawFactory.CodeQr;
            pbCode.Image = qrCode.Draw(txtQRCode.Text.Trim(), 80);
            Bitmap bmp = new Bitmap(188, 188);
            //pbCode.DrawToBitmap(bmp, new Rectangle(0, 0, 188, 188));
            pbCode.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, 188, 188));
            bmp.Save(qr_filename);
                //pbCode.Save(qr_filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //pbCode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] ar = new byte[ms.Length];
            //ms.Write(ar, 0, ar.Length);
            //pbCode.Image.Save("C://qr.jpg");
            //pbCode.Image.Save("c:\\abcd", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            Code128BarcodeDraw barCode = BarcodeDrawFactory.Code128WithChecksum;
            pbCode.Image = barCode.Draw(txtBarCode.Text.Trim(), 50);
        }
    }
}
