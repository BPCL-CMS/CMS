using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public partial class Employees
    {
        public long EMP_ID { get; set; }
        public string PO_NUM { get; set; }
        public string EMP_NAME { get; set; }
        public string GENDER { get; set; }
        public string MARITAL_STATUS { get; set; }
        public string ESI_NO { get; set; }
        public Nullable<System.DateTime> ESI_REGN_DATE { get; set; }
        public Nullable<bool> PEHCHAN { get; set; }
        public string PF_NO { get; set; }
        public Nullable<System.DateTime> PF_REGN_DATE { get; set; }
        public string UAN { get; set; }
        public Nullable<bool> EPS { get; set; }
        public Nullable<bool> EVICTEE { get; set; }
        public string EVICTEE_CARD_NO { get; set; }
        public Nullable<bool> ISMW { get; set; }
        public string DISABILITY_TYPE { get; set; }
        public string RELATION_IP { get; set; }
        public string RELATION_NAME { get; set; }
        public System.DateTime DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string PRESENT_ADRS { get; set; }
        public string PERMANENT_ADRS { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; }
        public string PINCODE { get; set; }
        public string ICE_PHONE { get; set; }
        public string EMP_TYPE { get; set; }
        public string ID_TYPE { get; set; }
        public string ID_NUM { get; set; }
        public byte[] PHOTO { get; set; }
        public string BANK_NAME { get; set; }
        public string BANK_BRANCH { get; set; }
        public string BANK_ADDRESS { get; set; }
        public string BANK_ACNO { get; set; }
        public Nullable<bool> BLACK_LISTED { get; set; }
        public string BLACK_LISTED_REASON { get; set; }
        public Nullable<System.DateTime> BLACK_LISTED_DATE { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_ON { get; set; }

        [ForeignKey ("PO_NUM")]
        public virtual Vendor_PO Vendor_PO { get; set; }
    }
}