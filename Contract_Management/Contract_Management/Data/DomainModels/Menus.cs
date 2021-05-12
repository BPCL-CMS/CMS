using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract_Management.Data.DomainModels
{
    public partial class Menus
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Nullable<long> ParentId { get; set; }
        public Nullable<long> RoleId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}