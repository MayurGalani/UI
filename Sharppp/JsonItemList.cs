using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARP_ACCOUNTING
{
    public class JsonItemList
    {
        public int itemNo { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; }
        public int hsnCode { get; set; }
        public double quantity { get; set; }
        public string qtyUnit { get; set; }
        public double taxableAmount { get; set; }
        public double sgstRate { get; set; }
        public double cgstRate { get; set; }
        public double igstRate { get; set; }
        public double cessRate { get; set; }
    }
}
