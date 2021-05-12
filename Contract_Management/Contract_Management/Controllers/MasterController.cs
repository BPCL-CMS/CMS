using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Contract_Management.Data.DomainModels;

namespace Contract_Management.Controllers
{
    public class MasterController : BaseController
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetAllRoles()
        {
            var roleList = db.Roles.ToList();
            SelectMasterDropDownViewModel masterddl = new SelectMasterDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectMasterDropDownViewModel> Data = new List<SelectMasterDropDownViewModel>();
            Data = roleList.Select(c => new SelectMasterDropDownViewModel { id = c.RoleId, text = c.RoleName }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);
        }
    }
}