using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Net;

    public class Global
    {
        string temp_word;
        public ArrayList allnik;

        public void drivesearch()
        {
            allnik = new ArrayList();
            ComboBox ddldrives = new ComboBox();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo mdrive in drives)
            {
                ddldrives.Items.Add(Convert.ToString(mdrive));
            }

            for (int i = 0; i < ddldrives.Items.Count; i++ )
            {
                string directoryname = ddldrives.Items[i] + "acc";

                if (Directory.Exists(directoryname))
                {
                  string[] files = Directory.GetFiles(directoryname);

                    foreach(string file in files)
                    {
                        if (file.Length == 14 && file.Substring(10, 4).Equals(".txt") || file.Substring(10, 4).Equals(".TXT"))
                        {
                            allnik.Add(file);
                        }
                    }
                }
            }
            
            for (int i = 0; i < ddldrives.Items.Count; i++)
            {
                string directoryname = ddldrives.Items[i] + "backup";

                if (Directory.Exists(directoryname))
                {
                    string[] files = Directory.GetFiles(directoryname);

                    foreach (string file in files)
                    {
                        if (file.Length == 17 && file.Substring(13, 4).Equals(".txt") || file.Substring(13, 4).Equals(".TXT"))
                        {
                            allnik.Add(file);
                        }
                    }
                }
            }
        
        }

        public string Globaldrivesearch()
        {
            string data_drive = string.Empty;
            //ComboBox ddldrives = new ComboBox();
            List<string> ddldrives = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo mdrive in drives)
            {
                ddldrives.Add(Convert.ToString(mdrive));
            }
            for (int i = 0; i < ddldrives.Count; i++)
            {
                string directoryname = ddldrives[i] + "acc";

                if (Directory.Exists(directoryname))
                {
                    data_drive = directoryname.Substring(0, 1);
                    break;
                }
            }
            return data_drive;
        }

        public string Globalsetup_drivesearch()
        {
            string setup_drive = string.Empty;
            //ComboBox ddldrives = new ComboBox();
            List<string> ddldrives = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo mdrive in drives)
            {
                ddldrives.Add(Convert.ToString(mdrive));
            }
            for (int i = 0; i < ddldrives.Count; i++)
            {
                string directoryname = ddldrives[i] + "sharp";

                if (Directory.Exists(directoryname))
                {
                    setup_drive = directoryname.Substring(0, 1);
                    break;
                }
            }
            return setup_drive;
        }

        public string decode(string encoded)
        {
            int asc_value;
            string decoded = null;
            if (encoded != null)
            {

                for (int i = 0; i < encoded.Length; i++)
                {
                    char c = Convert.ToChar(encoded.Substring(i, 1));
                    asc_value = Convert.ToInt32(c);
                    if (asc_value > 123 && asc_value < 155)
                        c = Convert.ToChar(asc_value - 90);
                    else if (asc_value >= 157 && asc_value < 167)
                        c = Convert.ToChar(asc_value - 92);
                    else if (asc_value >= 169 && asc_value < 179)
                        c = Convert.ToChar(asc_value - 94);
                    else if (asc_value >= 181 && asc_value < 193)
                        c = Convert.ToChar(asc_value - 96);
                    else if (asc_value >= 195 && asc_value < 205)
                        c = Convert.ToChar(asc_value - 98);
                    else if (asc_value >= 207 && asc_value < 217)
                        c = Convert.ToChar(asc_value - 100);
                    else if (asc_value >= 219 && asc_value < 228)
                        c = Convert.ToChar(asc_value - 102);
                    else if (asc_value == 228)
                        c = Convert.ToChar(32);
                    decoded += Convert.ToString(c);
                }
            }
               return decoded;
        }

        public string encode(string old_english)
        {
            int asc_value;
            string encoded = null;

            if (old_english != null)
            {
                encoded = null;
                for (int i = 0; i < old_english.Length; i++)
                {
                    char c = Convert.ToChar(old_english.Substring(i, 1));
                    asc_value = Convert.ToInt32(c);
                    if (asc_value == 1)
                        c = Convert.ToChar(asc_value + 228);
                    else if (asc_value == 32)
                        c = Convert.ToChar(asc_value + 196);
                    else if (asc_value >= 33 && asc_value < 65)
                        c = Convert.ToChar(asc_value + 90);
                    else if (asc_value >= 65 && asc_value < 75)
                        c = Convert.ToChar(asc_value + 92);
                    else if (asc_value >= 75 && asc_value < 85)
                        c = Convert.ToChar(asc_value + 94);
                    else if (asc_value >= 85 && asc_value < 97)
                        c = Convert.ToChar(asc_value + 96);
                    else if (asc_value >= 97 && asc_value < 107)
                        c = Convert.ToChar(asc_value + 98);
                    else if (asc_value >= 107 && asc_value < 117)
                        c = Convert.ToChar(asc_value + 100);
                    else if (asc_value >= 117 && asc_value < 126)
                        c = Convert.ToChar(asc_value + 102);
                    else
                        temp_word = "Sanjay";
                    encoded += Convert.ToString(c);
                }
            }
            encoded = old_english;
            return encoded;
        }

        public string ImageToBase64(Image image)
        {
            string base64String = null;
            //string path = "D:\\SampleImage.jpg";
            //using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            //{
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);

            }
            return base64String;
            //}
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        public Image GetImage(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return new Bitmap(stream);
                }
            }
        }

    }

