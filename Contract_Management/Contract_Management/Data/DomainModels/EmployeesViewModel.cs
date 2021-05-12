using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public partial class EmployeesViewModel
    {
        public long EMP_ID { get; set; }
        [Required]
        public string PO_NUM { get; set; }
        [Required]
        public string EMP_NAME { get; set; }
        public string GENDER { get; set; }
        [Required]
        public string MARITAL_STATUS { get; set; }
        public string MARITAL_STATUS_ID { get; set; }
        public string EMP_ESINO { get; set; }
        public Nullable<System.DateTime> ESI_REGN_DATE { get; set; }
        public Nullable<bool> PEHCHAN { get; set; }
        public string EMP_PF_NO { get; set; }
        public Nullable<System.DateTime> PF_REGN_DATE { get; set; }
        public string UAN { get; set; }
        public Nullable<bool> EPS { get; set; }
        public Nullable<bool> EVICTEE { get; set; }
        public string EVICTEE_CARD_NO { get; set; }
        public Nullable<bool> ISMW { get; set; }
        public string DISABILITY_TYPE { get; set; }
        [Required]
        public string RELATION_IP { get; set; }
        public string RELATION_IP_ID { get; set; }
        [Required]
        public string RELATION_NAME { get; set; }
        [Required]
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string PRESENT_ADRS { get; set; }
        [Required]
        public string PERMANENT_ADRS { get; set; }
        public string CITY { get; set; }
        [Required]
        public string DISTRICT { get; set; }
        [Required]
        public string STATE { get; set; }
        [Required]
        public string PINCODE { get; set; }
        [Required]
        public string ICE_PHONE { get; set; }
        public string EMP_TYPE { get; set; }
        public string EMP_TYPE_ID { get; set; }
        [Required]
        public string ID_TYPE { get; set; }
        [Required]
        public string ID_NUM { get; set; }
        public byte[] PHOTO { get; set; }
        [Required]
        public string BANK_NAME { get; set; }
        [Required]
        public string BANK_BRANCH { get; set; }
        [Required]
        public string BANK_ADDRESS { get; set; }
        [Required]
        public string BANK_ACNO { get; set; }
        [Required]
        public string BANK_IFSC { get; set; }
        public Nullable<bool> BLACK_LISTED { get; set; }
        public string BLACK_LISTED_REASON { get; set; }
        public Nullable<System.DateTime> BLACK_LISTED_DATE { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_ON { get; set; }
        public int? STATUS { get; set; }
        //SERVICE BOOK
        public string JOB_ID { get; set; }
        [Required]
        public string ESI_EXEMPTION { get; set; }
        public string ESI_EXEMPTION_ID { get; set; }
        
        public string WC_POLICY { get; set; }
        public Nullable<System.DateTime> WC_POLICY_VALID_UPTO { get; set; }
        [Required]
        public string PF_EXEMPTION { get; set; }
        public string PF_EXEMPTION_ID { get; set; }
        
        public string EMPR_ESI_CODE { get; set; }
        public string UAN_NO { get; set; }
        public string EMPR_PF_CODE { get; set; }

        [ForeignKey("PO_NUM")]
        public virtual Vendor_PO Vendor_PO { get; set; }
    }
}