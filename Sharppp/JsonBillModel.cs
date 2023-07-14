using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARP_ACCOUNTING
{
    public class JsonBillModel
    {
        public string UserGstin { get; set; }
        public string SupplyType { get; set; }
        public int SubSupplyType { get; set; }
        public string DocType { get; set; }
        public string docNo { get; set; }
        public string docDate { get; set; }
        public string fromGstin { get; set; }
        public string fromTrdName { get; set; }
        public string fromAddr1 { get; set; }
        public string fromAddr2 { get; set; }
        public string fromPlace { get; set; }
        public int fromPincode { get; set; }
        public int fromStateCode { get; set; }
        public int actualFromStateCode { get; set; }
        public string toGstin { get; set; }
        public string toTrdName { get; set; }
        public string toAddr1 { get; set; }
        public string toAddr2 { get; set; }
        public string toPlace { get; set; }
        public int toPincode { get; set; }
        public int toStateCode { get; set; }
        public int actualToStateCode { get; set; }
        public double totalValue { get; set; }
        public double cgstValue { get; set; }
        public double sgstValue { get; set; }
        public double igstValue { get; set; }
        public double cessValue { get; set; }
        public int transMode { get; set; }
        public int transDistance { get; set; }
        public string transporterName { get; set; }
        public string transporterId { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
        public string vehicleNo { get; set; }
        public string vehicleType { get; set; }
        public double totInvValue { get; set; }
        public int mainHsnCode { get; set; }
        public IList<JsonItemList> itemList { get; set; }
    }
}
