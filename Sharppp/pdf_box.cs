using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//test tfs
//using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Zen.Barcode;
//using System.Web.Mail;
using Excel = Microsoft.Office.Interop.Excel;
using YLScsImage;

namespace SHARP_ACCOUNTING
{
    public partial class pdf_box : Form
    {
        public pdf_box()
        {
            InitializeComponent();
        }

        PdfWriter writer;
        private AxAcroPDFLib.AxAcroPDF utilities_pdfviewer;
        private Button btn_invoice_pdf_generator;
        Document doc1;
        BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\cour.ttf", BaseFont.IDENTITY_H, true);


              private void AddPDFRectangle(float x1, float y1, float x2, float y2, float borderWidht)
        {
            PdfContentByte cb = writer.DirectContent;
            //var Rectangular = new iTextSharp.text.Rectangle(x1, y1, x2, y2);
            var Rectangular = new iTextSharp.text.Rectangle(x1, y1, (x1 + x2), y2); // this means x2 = x1 + x2
            Rectangular.Border = iTextSharp.text.Rectangle.BOX;

            Rectangular.BorderWidth = borderWidht;
            Rectangular.BorderColor = new BaseColor(0, 0, 0);
            cb.Rectangle(Rectangular);
        }

        private void ADDPDFText(float leftdistance, float GetBottom, string text_matter, float fontWidth)
        {
            PdfContentByte cb = writer.DirectContent;
            //BaseFont bf11 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //iTextSharp.text.Font bf2 = FontFactory.GetFont(FontName, fontWidth, iTextSharp.text.Font.BOLD);
            //BaseFont bf2 = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\" + FontName + ".ttf", BaseFont.IDENTITY_H, true);
            cb.BeginText();
            cb.SetFontAndSize(bf, fontWidth);
            cb.SetTextMatrix(doc1.PageSize.GetLeft(leftdistance), doc1.PageSize.GetBottom(GetBottom));
            cb.ShowText(text_matter);
            cb.EndText();
        }

        private void btn_invoice_pdf_generator_Click(object sender, EventArgs e)
        {
            btn_invoice_pdf_generator.Visible = false;
            string pdf_invoice_text_file = "C:\\sharp\\pdf_invoice_text_file.txt";
            if (File.Exists(pdf_invoice_text_file))
            {
                float y2;
                //float.TryParse(textBox1.Text, out x1);
                //float.TryParse(textBox2.Text, out y1);
                //float.TryParse(textBox3.Text, out x2);
                //float.TryParse(textBox4.Text, out y2);
                //x1 = 5;
                //y1 = 5;
                //x2 = 590;
                //y2 = 835;
                //string strFilepath = "c:\\acc\\ap2\\reports\\pdf_box_sample.pdf";
                string strFilepath = ConnectionWithAccess.data_drive + "acc\\" + ConnectionWithAccess.mNIK + "\\reports\\pdf_box_sample.pdf";
                FileStream FS1 = File.Create(strFilepath);
                doc1 = new Document(PageSize.A4, 5, 5, 5, 5);
                writer = PdfWriter.GetInstance(doc1, FS1);
                doc1.Open();
                var lines = File.ReadAllLines(pdf_invoice_text_file);
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i] != null)
                    {
                        var cellArray = lines[i].Split(new[] { ',' });
                        if (cellArray[0] == "T")
                        {
                            if (cellArray.Count() == 5)
                            {
                                ADDPDFText(Convert.ToInt32(cellArray[1]), Convert.ToInt32(cellArray[2]), cellArray[3].ToString(), Convert.ToInt32(cellArray[4]));
                            }
                        }
                        else if (cellArray[0] == "B")
                        {
                            if (cellArray.Count() == 6)
                                AddPDFRectangle(Convert.ToInt32(cellArray[1]), Convert.ToInt32(cellArray[2]), Convert.ToInt32(cellArray[3]), Convert.ToInt32(cellArray[4]), Convert.ToSingle(cellArray[5]));
                            else if (cellArray.Count() >= 6)
                            {
                                float last_start_postion = Convert.ToInt32(cellArray[1]);
                                float last_end_postion = Convert.ToInt32(cellArray[3]);
                                y2 = Convert.ToSingle(cellArray[cellArray.Count() - 2]);
                                float borderWidht = Convert.ToSingle(cellArray[cellArray.Count() - 1]);
                                for (int j = 0; j < cellArray.Count() - 5; j++)
                                {
                                    AddPDFRectangle(last_start_postion, Convert.ToInt32(cellArray[2]), last_end_postion, y2, borderWidht);
                                    last_start_postion = last_start_postion + last_end_postion;
                                    if (j < cellArray.Count() - 5)
                                        last_end_postion = Convert.ToInt32(cellArray[4 + j]);
                                }
                            }
                        }
                    }
                }
                //ADDPDFText(20,20,"hello this is testing",8);
                //AddPDFRectangle(x1, y1, x2, y2, 1);
                //AddPDFRectangle(5, 775, 590, 835, 1);
                //AddPDFRectangle(5, 715, 295, 775, 1);
                //AddPDFRectangle(295, 715, 590, 775, 1);
                //AddPDFRectangle(5, 315, 590, 775, 1);
                doc1.Close();
                utilities_pdfviewer.Visible = true;
                utilities_pdfviewer.LoadFile(strFilepath);
            }
            btn_invoice_pdf_generator.Visible = true;
        }
        
    }
}
