using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public partial class DocumentUploadModel
    {
        public long TRANS_ID { get; set; }
        public string VENDOR_CODE { get; set; }
        public Nullable<long> PO_NUMBER { get; set; }
        public Nullable<long> EMPLOYEE_ID { get; set; }
        public Nullable<long> DOC_ID { get; set; }
        public string DOC_EXTN { get; set; }
        public byte[] DOCUMENT { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    }
}