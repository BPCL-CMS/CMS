using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public class SelectDropDownViewModel
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class PONUMSelect2DropDownViewModel
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    public class SelectMasterDropDownViewModel
    {
        public long id { get; set; }
        public string text { get; set; }
    }

}