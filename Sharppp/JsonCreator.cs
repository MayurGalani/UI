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
    public partial class JsonCreator : Form
    {
        public JsonCreator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GSTJsonDetails objGSTDetails = new GSTJsonDetails();
            List<B2b> objListB2b = new List<B2b>();
            List<B2cs> objListB2cs = new List<B2cs>();
            
            #region b2b 1
            //b2b 1
            B2b objB2b = new B2b();
            List<Inv> objListInv = new List<Inv>();
            List<Itm> objListitms = new List<Itm>();
            
            ItmDet objItmDet = new ItmDet();
            objItmDet.txval = 11000;
            objItmDet.rt = 18;
            objItmDet.camt = 990;
            objItmDet.samt = 990;
            objItmDet.csamt = 0;

            Itm objItm = new Itm();
            objItm.num = 1;
            objItm.itm_det = objItmDet;
            objListitms.Add(objItm);
            
            Inv objInv = new Inv();
            objInv.inum = "24";
            objInv.idt = "03-08-2017";
            objInv.val = 12980;
            objInv.pos = "27";
            objInv.rchrg = "N";
            objInv.cfs = "N";
            objInv.itms = objListitms;
            objInv.inv_typ = "R";
            objListInv.Add(objInv);

            objB2b.ctin = "27ACUPN1784G1Z1";
            objB2b.inv = objListInv;
            objListB2b.Add(objB2b);

            #endregion b2b 1

            #region b2b 2
            //b2b 2
            B2b objB2b1 = new B2b();
            List<Inv> objListInv1 = new List<Inv>();
            List<Itm> objListitms1 = new List<Itm>();
            
            Itm objItm1 = new Itm();
            ItmDet objItmDet1 = new ItmDet();
            objItmDet1.txval = 27000;
            objItmDet1.rt = 18;
            objItmDet1.camt = 2430;
            objItmDet1.samt = 2430;
            objItmDet1.csamt = 0;

            objItm1.num = 1;
            objItm1.itm_det = objItmDet1;
            objListitms1.Add(objItm1);

            Inv objInv1 = new Inv();
            objInv1.inum = "27";
            objInv1.idt = "19-08-2017";
            objInv1.val = 31860;
            objInv1.pos = "27";
            objInv1.rchrg = "N";
            objInv1.cfs = "N";
            objInv1.itms = objListitms1;
            objInv1.inv_typ = "R";
            objListInv1.Add(objInv1);

            objB2b1.ctin = "27ABPPM3644J1Z7";
            objB2b1.inv = objListInv1;
            objListB2b.Add(objB2b1);
            #endregion b2b 2

            #region b2b 3
            //b2b 1
            B2b objB2b2 = new B2b();
            List<Inv> objListInv2 = new List<Inv>();
            List<Itm> objListitms2 = new List<Itm>();

            ItmDet objItmDet2 = new ItmDet();
            objItmDet2.txval = 147600;
            objItmDet2.rt = 18;
            objItmDet2.camt = 13284;
            objItmDet2.samt = 13284;
            objItmDet2.csamt = 0;

            Itm objItm2 = new Itm();
            objItm2.num = 1;
            objItm2.itm_det = objItmDet2;
            objListitms2.Add(objItm2);

            Inv objInv2 = new Inv();
            objInv2.inum = "28";
            objInv2.idt = "20-08-2017";
            objInv2.val = 174168;
            objInv2.pos = "27";
            objInv2.rchrg = "N";
            objInv2.cfs = "N";
            objInv2.itms = objListitms2;
            objInv2.inv_typ = "R";
            objListInv2.Add(objInv2);

            objB2b2.ctin = "27AGAPN6381P1ZR";
            objB2b2.inv = objListInv2;
            objListB2b.Add(objB2b2);

            #endregion b2b 3

            #region b2b 4
            //b2b 4
            B2b objB2b3 = new B2b();
            List<Inv> objListInv3 = new List<Inv>();
            List<Itm> objListitms3 = new List<Itm>();

            ItmDet objItmDet3 = new ItmDet();
            objItmDet3.txval = 24910.5;
            objItmDet3.rt = 12;
            objItmDet3.camt = 1494.63;
            objItmDet3.samt = 1494.63;
            objItmDet3.csamt = 0;

            Itm objItm3 = new Itm();
            objItm3.num = 1;
            objItm3.itm_det = objItmDet3;
            objListitms3.Add(objItm3);

            Inv objInv3 = new Inv();
            objInv3.inum = "29";
            objInv3.idt = "23-08-2017";
            objInv3.val = 27899.76;
            objInv3.pos = "27";
            objInv3.rchrg = "N";
            objInv3.cfs = "N";
            objInv3.itms = objListitms3;
            objInv3.inv_typ = "R";
            objListInv3.Add(objInv3);

            objB2b3.ctin = "27AAPPR4212E1ZP";
            objB2b3.inv = objListInv3;
            objListB2b.Add(objB2b3);

            #endregion b2b 4

            #region b2b 5
            //b2b 5
            B2b objB2b4 = new B2b();
            List<Inv> objListInv4 = new List<Inv>();
            List<Itm> objListitms4 = new List<Itm>();

            ItmDet objItmDet4 = new ItmDet();
            objItmDet4.txval = 5280;
            objItmDet4.rt = 12;
            objItmDet4.camt = 316.8;
            objItmDet4.samt = 316.8;
            objItmDet4.csamt = 0;

            Itm objItm4 = new Itm();
            objItm4.num = 1;
            objItm4.itm_det = objItmDet4;
            objListitms4.Add(objItm4);

            Inv objInv4 = new Inv();
            objInv4.inum = "30";
            objInv4.idt = "24-08-2017";
            objInv4.val = 5913.6;
            objInv4.pos = "27";
            objInv4.rchrg = "N";
            objInv4.cfs = "N";
            objInv4.itms = objListitms4;
            objInv4.inv_typ = "R";
            objListInv4.Add(objInv4);

            List<Itm> objListitms5 = new List<Itm>();

            ItmDet objItmDet5 = new ItmDet();
            objItmDet5.txval = 19178.34;
            objItmDet5.rt = 12;
            objItmDet5.camt = 1150.7;
            objItmDet5.samt = 1150.7;
            objItmDet5.csamt = 0;

            Itm objItm5 = new Itm();
            objItm5.num = 1;
            objItm5.itm_det = objItmDet5;
            objListitms5.Add(objItm5);


            Inv objInv5 = new Inv();
            objInv5.inum = "31";
            objInv5.idt = "28-08-2017";
            objInv5.val = 21479.74;
            objInv5.pos = "27";
            objInv5.rchrg = "N";
            objInv5.cfs = "N";
            objInv5.itms = objListitms5;
            objInv5.inv_typ = "R";
            objListInv4.Add(objInv5);

            objB2b4.ctin = "27ATXPP2224P1ZT";
            objB2b4.inv = objListInv4;
            objListB2b.Add(objB2b4);

            #endregion b2b 5

            #region b2cs
            //b2cs
            B2cs objB2cs = new B2cs();
            objB2cs.sply_ty = "INTRA";
            objB2cs.pos = "27";
            objB2cs.typ = "OE";
            objB2cs.txval = 27653;
            objB2cs.rt = 12;
            objB2cs.iamt = 0;
            objB2cs.camt = 1659.18;
            objB2cs.samt = 1659.18;
            objB2cs.csamt = 0;
            objListB2cs.Add(objB2cs);
            #endregion b2cs

            #region Main
            objGSTDetails.gstin = "27AAYPA2720K1ZJ";
            objGSTDetails.fp = "082017";
            objGSTDetails.gt = 0;
            objGSTDetails.cur_gt = 0;
            objGSTDetails.version = "GST2.0";
            objGSTDetails.hash = "hash";
            objGSTDetails.b2b = objListB2b;
            objGSTDetails.b2cs = objListB2cs;
            #endregion Main

            string srtJSON = GSTJsonClasses.ToJSON(objGSTDetails);
            txtJSon.Text = srtJSON;
        }
    }
}
