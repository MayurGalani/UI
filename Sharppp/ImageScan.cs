using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SHARP_ACCOUNTING
{
    public partial class ImageScan : Form
    {
        string current_folder, file_folder, strImageFileName, img_prefix;
        public static string image_title;
        public ImageScan()
        {
            InitializeComponent();
        }

        public string strScanImageModule { get; set; }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string img_prefix = string.Empty;
            try
            {
                //if (cbType.Text == "Document")
                //    img_prefix = "doc_";
                //else if (cbType.Text == "Photo")
                //    img_prefix = "pho_";
                //else if (cbType.Text == "Business Card")
                //    img_prefix = "buc_";
                if (cbType.Text != null)
                    img_prefix = cbType.Text.Substring(0, 3);

                if (string.IsNullOrEmpty(img_prefix))
                {
                    MessageBox.Show("Please select Image Type");
                    return;
                }
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                //strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + "_" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                List<Image> images = WIAScanner.Scan((string)lbDevices.SelectedItem);
                foreach (Image image in images)
                {
                    System.IO.Directory.CreateDirectory(file_folder);
                    image.Save(strImageFileName, ImageFormat.Jpeg);
                    image.Dispose();
                    //TODO :: Code to update scan image path in access database
                }
                //MessageBox.Show(cbType.Text + " scanned and save completed");
                pb_scanned_image.Visible = true;
                pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                btn_remove_image.Visible = true;
                lbl_image_filename.Text = strImageFileName;
                MainForm.scan_image_filename = strImageFileName;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ImageScan_Load(object sender, EventArgs e)
        {
            //              100 sale invoice 
            //              110 purchase invoice
            //              120 bank receipt
            //              121 bank payment
            //              122 bank deposit
            //              123 bank withdrawal
            //              130 cash receipt
            //              131 cash payment
            //              140 journal
            //              20 masters accounts
            //              21 masters items
            //              22 masters tax
            //              23 masters daybook
            //              24 masters period
            //              25 masters additional
            lbl_image_title.Text = image_title;
            btn_remove_image.Visible = false;
            if (MainForm.current_working_tab == "100" || MainForm.current_working_tab == "110" || MainForm.current_working_tab == "120" || MainForm.current_working_tab == "121")
            {
                cbType.Items.Clear();
                cbType.Items.Add("Business Card");
                cbType.Items.Add("Invoice");
                cbType.Items.Add("Personal Photo");
                cbType.Items.Add("Transport Copy");
                if (MainForm.current_working_tab == "120")
                    cbType.Items.Add("Cheque");
                if (cbType.SelectedIndex == -1)
                    cbType.SelectedIndex = 0;
                if (MainForm.current_working_tab == "100" || MainForm.current_working_tab == "110")
                    cbType.SelectedIndex = 1;
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                } 

                if (lbDevices.Items.Count == 0)
                {
                    //MessageBox.Show("You do not have any WIA devices.");
                    btnScan.Visible = false;
                    lbDevices.Visible = false;
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                    btnScan.Visible = true;
                    lbDevices.Visible = true;
                }
            }

            else if (MainForm.current_working_tab == "122" || MainForm.current_working_tab == "123")
            {
                cbType.Items.Clear();
                cbType.Items.Add("Bank Receipt");
                cbType.SelectedIndex = 1;
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }

                if (lbDevices.Items.Count == 0)
                {
                    //MessageBox.Show("You do not have any WIA devices.");
                    btnScan.Visible = false;
                    lbDevices.Visible = false;
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                    btnScan.Visible = true;
                    lbDevices.Visible = true;
                }
            }
            else if (MainForm.current_working_tab == "20")
            {
                cbType.Items.Clear();
                cbType.Items.Add("Business Card");
                cbType.Items.Add("Personal Photo");
                cbType.SelectedIndex = 0;
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }

                if (lbDevices.Items.Count == 0)
                {
                    //MessageBox.Show("You do not have any WIA devices.");
                    btnScan.Visible = false;
                    lbDevices.Visible = false;
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                    btnScan.Visible = true;
                    lbDevices.Visible = true;
                }
            }
            else if (MainForm.current_working_tab == "21")
            {
                cbType.Items.Clear();
                cbType.Items.Add("Product");
                cbType.SelectedIndex = 0;
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }

                if (lbDevices.Items.Count == 0)
                {
                    //MessageBox.Show("You do not have any WIA devices.");
                    btnScan.Visible = false;
                    lbDevices.Visible = false;
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                    btnScan.Visible = true;
                    lbDevices.Visible = true;
                }
            }
        }

        private void bnt_copy_jpg_to_scan_Click(object sender, EventArgs e)
        {
            OpenFileDialog old = new OpenFileDialog();
            old.Title = "Select file";
            old.InitialDirectory = @current_folder;
            old.InitialDirectory = ConnectionWithAccess.data_drive + "\\corel\\jpg\\";
            old.Filter = "Jpg files (*.JPG) |*.JPG|All Files(*.*)|*.*";
            old.FilterIndex = 1;
            old.RestoreDirectory = true;
            old.ShowDialog();
            if (old.FileName != null && old.FileName != "")
            {
                if (cbType.Text != null)
                    img_prefix = cbType.Text.Substring(0, 3);

                if (string.IsNullOrEmpty(img_prefix))
                {
                    MessageBox.Show("Please select Image Type");
                    return;
                }
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                if (cbType.Text == "Business Card")
                    strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Busi_card_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                else if (cbType.Text == "Product")
                    strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Product_" + strScanImageModule + ".jpeg";
                else if (cbType.Text == "Personal Photo")
                    strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Per_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                else
                    strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                //strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + "_" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg";
                strImageFileName = MainForm.remove_wrong_character_from_file(strImageFileName);
                if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                System.IO.File.Copy(old.FileName, strImageFileName, true);
                pb_scanned_image.Visible = true;
                
                pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                lbl_image_filename.Text = strImageFileName;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pb_scanned_image.Visible = false;
            if (cbType.Text != null)
                img_prefix = cbType.Text.Substring(0, 3);

            if (string.IsNullOrEmpty(img_prefix))
            {
                MessageBox.Show("Please select Image Type");
                return;
            }
            if (cbType.Text == "Business Card")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Busi_card_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
            else if (cbType.Text == "Invoice")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
            else if (cbType.Text == "Personal Photo")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Per_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
            else if (cbType.Text == "Transport Copy")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
            else if (cbType.Text == "Product")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Product_" + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
            else 
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    pb_scanned_image.Visible = true;
                    pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                    pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                    btn_remove_image.Visible = true;
                }
            }
        }

        private void btn_remove_image_Click(object sender, EventArgs e)
        {
            if (cbType.Text == "Business Card")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Busi_card_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }
            else if (cbType.Text == "Invoice")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }
            else if (cbType.Text == "Personal Photo")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Per_" + ConnectionWithAccess.ma_n + "_" + ConnectionWithAccess.ms_a + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }
            else if (cbType.Text == "Transport Copy")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }
            else if (cbType.Text == "Product")
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_Product_" + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }
            else
            {
                file_folder = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\scanned_images\\";
                strImageFileName = file_folder + ConnectionWithAccess.mNIK + "_" + img_prefix + strScanImageModule + ".jpeg";
                if (File.Exists(strImageFileName))
                {
                    if (pb_scanned_image.Image != null) 
                        pb_scanned_image.Image.Dispose();
                    pb_scanned_image.Image = null;
                    File.Delete(strImageFileName);
                }
            }

        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 1, (float)image.Height / 1);

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        public Image RotateImage1(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            
            return bmp;

        }
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (pb_scanned_image.Image != null)
            {
                Image image = new Bitmap(pb_scanned_image.Image);
                Image newImage = RotateImage1(image);
                pb_scanned_image.Image.Dispose();
                newImage.Save(strImageFileName);
                pb_scanned_image.Image = newImage;
            }
        }
        public bool Makeselection = false;
        private void btnMakeSelection_Click(object sender, EventArgs e)
        {
            Makeselection = true;
            btnCrop.Enabled = true;
        }

        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        public Pen cropPen;

        public DashStyle cropDashStyle = DashStyle.DashDot;
        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(pb_scanned_image.Image, pb_scanned_image.Width, pb_scanned_image.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinf image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                if (pb_scanned_image.Image != null)
                    pb_scanned_image.Image.Dispose();
                _img.Save(strImageFileName);
                //System.IO.File.Copy(old.FileName, strImageFileName, true);
                pb_scanned_image.Visible = true;

                pb_scanned_image.Image = System.Drawing.Image.FromFile(strImageFileName);
                pb_scanned_image.SizeMode = PictureBoxSizeMode.Zoom;
                lbl_image_filename.Text = strImageFileName;

                //pb_scanned_image.Image = _img;
                //pb_scanned_image.Width = _img.Width;
                //pb_scanned_image.Height = _img.Height;
                //PictureBoxLocation();
                btnCrop.Enabled = false;
                //System.IO.File.Copy(strImageFileName, strImageFileName, true);
            }
            catch (Exception ex)
            {
            }
        }

        private void pb_scanned_image_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {

                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Cursor = Cursors.Cross;
                        cropX = e.X;
                        cropY = e.Y;

                        cropPen = new Pen(Color.Black, 1);
                        cropPen.DashStyle = DashStyle.DashDotDot;


                    }
                    pb_scanned_image.Refresh();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void pb_scanned_image_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {

                try
                {
                    if (pb_scanned_image.Image == null)
                        return;


                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        pb_scanned_image.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                        pb_scanned_image.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                    }

                }
                catch (Exception ex)
                {
                    //if (ex.Number == 5)
                    //    return;
                }
            }
        }

        private void pb_scanned_image_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }
        }

       

    }
}
