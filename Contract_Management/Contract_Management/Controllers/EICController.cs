using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Contract_Management.Data.DomainModels;

namespace Contract_Management.Controllers
{
    public class EICController : BaseController
    {
        #region Views

        // GET: EIC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contractor()
        {
            return View();
        }
        public ActionResult ContractorDetails(int ID)
        {
            var contractor = db.Contractors.Where(c => c.ID == ID).FirstOrDefault();
            if (contractor != null)
            {
                return View("ContractorDetails", contractor);
            }
            return null;
        }


        #endregion

        #region Member Functions

        [HttpPost]
        public ActionResult LoadContractors()
        {
            //var obj = db.Contractors.Where(t => t.STATUS ==(int) STATUS.Approved_By_ThirdParty).ToList();
            var obj = db.Database.SqlQuery<Contractors>("SELECT DISTINCT CMS.Contractor.ID, CMS.Contractor.VENDOR_CODE, CMS.Contractor.CONTRACTOR_NAME, CMS.Contractor.CONTRACTOR_ADDRESS FROM CMS.Contractor INNER JOIN CMS.Job ON CMS.Contractor.VENDOR_CODE = CMS.Job.CONT_ID where CMS.Contractor.STATUS=" + (int)STATUS.Approved_By_ThirdParty + "").ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}