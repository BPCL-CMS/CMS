﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public class Contractors
    {
        public int ID { get; set; }
        public string VENDOR_CODE { get; set; }
        public string CONTRACTOR_NAME { get; set; }
        public string CONTRACTOR_ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string PINCODE { get; set; }
        public string PAN { get; set; }
        public string GST { get; set; }
        public string E_MAIL { get; set; }
        public string MOBILE { get; set; }
        public string FAX { get; set; }
        public Nullable<bool> WHETHER_HAVING_ESI_CODE { get; set; }
        public string ESI_ESTABLISHMENT_CODE { get; set; }
        public Nullable<bool> WHETHER_HAVING_PF_ESTABLISHMENT_CODE { get; set; }
        public string PF_CODE { get; set; }
        public string CST { get; set; }
        public string CONTRACTOR_INCHARGE { get; set; }
        public string DESIGNATION { get; set; }
        public string CONT_INCHARGE_MOBILE { get; set; }
        public byte[] PHOTO { get; set; }
        public byte[] SIGNATURE { get; set; }
        public Nullable<bool> DEACTIVATED { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_ON { get; set; }
        public string CONT_PREV_ID { get; set; }
        public Nullable<bool> ISTEMPID { get; set; }
        public string SEC_EMAIL { get; set; }
        public string SUPERVISOR { get; set; }
        public string SUP_MOBILE { get; set; }
        public string SUP_EMAIL { get; set; }
        public string DECLARATION { get; set; }
        public Nullable<int> STATUS { get; set; }


        //  public virtual vendor_details vendor_details { get; set; }
    }
}