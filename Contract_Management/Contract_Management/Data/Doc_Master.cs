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
    
    public partial class Doc_Master
    {
        public long DOC_ID { get; set; }
        public string DOC_TYPE { get; set; }
        public string DOC_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string USER_TYPE { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
    }
}
