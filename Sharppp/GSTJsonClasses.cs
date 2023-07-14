using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace SHARP_ACCOUNTING
{
    public static class GSTJsonClasses
    {
        public static string ToJSON(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }

    public class ItmDet
    {
        public double txval { get; set; }
        public int rt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class Itm
    {
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }

    public class Inv
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string cfs { get; set; }
        public List<Itm> itms { get; set; }
        public string inv_typ { get; set; }
    }

    public class B2b
    {
        public string ctin { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class B2cs
    {
        public string sply_ty { get; set; }
        public string pos { get; set; }
        public string typ { get; set; }
        public int txval { get; set; }
        public int rt { get; set; }
        public int iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class GSTJsonDetails
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public int gt { get; set; }
        public int cur_gt { get; set; }
        public string version { get; set; }
        public string hash { get; set; }
        public List<B2b> b2b { get; set; }
        public List<B2cs> b2cs { get; set; }
    }

}
