//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contract_Management.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vendor_PO
    {
        public int ID { get; set; }
        public string VENDOR_CODE { get; set; }
        public string PO_NUMBER { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    
        public virtual vendor_details vendor_details { get; set; }
    }
}
