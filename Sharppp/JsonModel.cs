using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARP_ACCOUNTING
{
    public class JsonModel
    {
        public string Version { get; set; }
        public IList<JsonBillModel> BillLists { get; set; }
    }
}
