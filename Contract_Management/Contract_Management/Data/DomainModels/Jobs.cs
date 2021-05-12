using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public class Jobs
    {
        public string JOB_ID { get; set; }
        public Nullable<bool> ARC { get; set; }
        public string ARC_ID { get; set; }
        public string JOB_NAME { get; set; }
        public Nullable<int> DEPT_ID { get; set; }
        public string AREA { get; set; }
        public string CONT_ID { get; set; }
        public string ADDRESS { get; set; }
        public Nullable<bool> HOUSE_KEEPING { get; set; }
        public Nullable<bool> ONLY_EXCEMPTION { get; set; }
        public short NO_WORKERS { get; set; }
        public Nullable<short> TOTAL_WORKERS { get; set; }
        public Nullable<short> TOTAL_PASS_COUNT { get; set; }
        public Nullable<short> ISMW_WORKERS_ASSIGNED { get; set; }
        public Nullable<short> ISMW_PASS_COUNT { get; set; }
        public Nullable<System.DateTime> COMPLETED_DATE { get; set; }
        public string WORKERS_LICENSE_PASS { get; set; }
        public Nullable<System.DateTime> WL_PASS_FROM { get; set; }
        public Nullable<System.DateTime> WL_PASS_TO { get; set; }
        public string STAFF_PASS { get; set; }
        public Nullable<bool> ISWL_LICENSE_CLOSED { get; set; }
        public Nullable<bool> ISMW { get; set; }
        public string ISMW_LICENSE_PASS { get; set; }
        public Nullable<System.DateTime> ISMW_FROM { get; set; }
        public Nullable<System.DateTime> ISMW_TO { get; set; }
        public Nullable<bool> BLOCK { get; set; }
        public string BLOCK_REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_ON { get; set; }
        public string SEC_REMARKS { get; set; }

        public virtual vendor_details vendor_details { get; set; }
    }
}