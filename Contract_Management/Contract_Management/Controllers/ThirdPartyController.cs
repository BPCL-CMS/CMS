using System;
using System.Collections.Generic;
using System.Data;
using Contract_Management.Data.DomainModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Contract_Management.Data;
using Newtonsoft.Json;

namespace Contract_Management.Controllers
{
    public class ThirdPartyController : BaseController
    {
        // GET: ThirdParty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contractor()
        {
            return View();
        }
        public ActionResult Job()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }

        #region CONTRACTOR       
        [HttpPost]
        public ActionResult GetAllPendingContractorsList()
        {
            var obj = db.Database.SqlQuery<Contractors>("select * from cms.Contractor where STATUS=" + (int)ActivityMaster.SubmittedByContractor + "").ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContractorDetails(int CONTRACTOR_ID)
        {

            var vendor = db.Contractors.Where(t => t.ID == CONTRACTOR_ID && t.STATUS == (int)ActivityMaster.SubmittedByContractor).FirstOrDefault();
            if (vendor != null)
            {
                return View("ContractorDetails", vendor);
            }
            return null;


            // return View();
        }


        [HttpPost]
        public ActionResult ApproveContractor(int CONT_ID)
        {
            var vendor = db.Contractors.Where(t => t.ID == CONT_ID && t.STATUS == (int)ActivityMaster.SubmittedByContractor).FirstOrDefault();
            vendor.STATUS = (int)ActivityMaster.ApprovedByThirdParty;
            db.SaveChanges();
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region JOB
        [HttpPost]
        public ActionResult GetAllPendingjOBList()
        {
            var obj = db.Database.SqlQuery<Job>("select * from cms.job where STATUS=" + (int)ActivityMaster.SubmittedByContractor + "").ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
