using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public class vendor_detailss
    {
        public long ID { get; set; }
        public string VENDOR_CODE { get; set; }
        public string VENDOR_NAME { get; set; }
        public string PO_NUMBER { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string PASWORD { get; set; }
        public string OTP { get; set; }
        public Nullable<bool> IS_ACTIVE { get; set; }
        public Nullable<bool> IS_REGISTERED { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
       // public virtual ICollection<Contractor> Contractors { get; set; }
    }
}