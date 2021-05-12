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

        public ActionResult JobDetails(string JOB_ID)
        {
            string a = JOB_ID;
            return View();
        }
        [HttpPost]
        public JsonResult GetAllJobsByPO_NUM(int JOB_ID)
        {
            //var job = db.Jobs.Where(t => t.PO_NUM == PO_NUM).FirstOrDefault();
            //var job_arc = db.Job_Arc.Where(t => t.PO_NUM == PO_NUM).FirstOrDefault();
            var job = (from jb in db.Jobs
                       join jb_A in db.Job_Arc on jb.PO_NUM equals jb_A.PO_NUM
                       join dp in db.Departments on jb.DEPT_ID equals dp.DEPT_ID
                       join v in db.vendor_details on jb.CONT_ID equals v.VENDOR_CODE
                       orderby jb.JOB_ID
                       select new
                       {
                           JOB_ID = jb.JOB_ID,
                           PO_NUM = jb.PO_NUM,
                           ARC = jb.ARC,
                           ARC_NO = jb.ARC_NO,
                           JOB_NAME = jb.JOB_NAME,
                           DEPT_ID = jb.DEPT_ID,
                           AREA = jb.AREA,
                           CONT_ID = jb.CONT_ID,
                           VENDOR = v.VENDOR_NAME,
                           ADDRESS = jb.ADDRESS,
                           HOUSE_KEEPING = jb.HOUSE_KEEPING,
                           ONLY_EXCEMPTION = jb.ONLY_EXCEMPTION,
                           NO_WORKERS = jb.NO_WORKERS,
                           TOTAL_WORKERS = jb.TOTAL_WORKERS,
                           TOTAL_PASS_COUNT = jb.TOTAL_PASS_COUNT,
                           ISMW_WORKERS_ASSIGNED = jb.ISMW_WORKERS_ASSIGNED,
                           ISMW_PASS_COUNT = jb.ISMW_PASS_COUNT,
                           COMPLETED_DATE = jb.COMPLETED_DATE,
                           WORKERS_LICENSE_PASS = jb.WORKERS_LICENSE_PASS,
                           WL_PASS_FROM = jb.WL_PASS_FROM,
                           WL_PASS_TO = jb.WL_PASS_TO,
                           STAFF_PASS = jb.STAFF_PASS,
                           ISWL_LICENSE_CLOSED = jb.ISWL_LICENSE_CLOSED,
                           ISMW = jb.ISMW,
                           ISMW_LICENSE_PASS = jb.ISMW_LICENSE_PASS,
                           ISMW_FROM = jb.ISMW_FROM,
                           ISMW_TO = jb.ISMW_TO,
                           BLOCK = jb.BLOCK,
                           BLOCK_REMARKS = jb.BLOCK_REMARKS,
                           CREATED_BY = jb.CREATED_BY,
                           CREATED_ON = jb.CREATED_ON,
                           DELETED_BY = jb.DELETED_BY,
                           DELETED_ON = jb.DELETED_ON,
                           SEC_REMARKS = jb.SEC_REMARKS,

                           ARC_ID = jb_A.ARC_ID,
                           DESCRIPTION = jb_A.DESCRIPTION,
                           ARC_DATE = jb_A.ARC_DATE,
                           SCHEDULE_FROM = jb_A.SCHEDULE_FROM,
                           SCHEDULE_TO = jb_A.SCHEDULE_TO,
                           DEACTIVATED_ON = jb_A.DEACTIVATED_ON,
                           DEPT_NAME = dp.DEPT_NAME,
                       }).Where(t => t.JOB_ID == JOB_ID).FirstOrDefault();
            if (job != null)
            {
                return Json(JsonConvert.SerializeObject(new { success = true, results = job }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { success = false, results = job }), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}
