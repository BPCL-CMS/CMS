using System;
using System.Collections.Generic;
using System.Data;
using Contract_Management.Data.DomainModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Contract_Management.Data;
using Contract_Management.Data.Mapping;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Activities.Statements;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using System.Web.Routing;

namespace Contract_Management.Controllers
{
    public class ContractorController : BaseController
    {
        // GET: Contractor
        public ActionResult Index()
        {
            return View();
        }

        #region Common
        [HttpPost]
        public JsonResult GetAllDepartments(string name)
        {
            var list = db.Departments.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.DEPT_ID, text = c.DEPT_NAME }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetAllPOs(string q, int page, string type)
        {
            var list = db.Vendor_PO.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<PONUMSelect2DropDownViewModel> Data = new List<PONUMSelect2DropDownViewModel>();
            Data = list.Select(c => new PONUMSelect2DropDownViewModel { id = c.PO_NUMBER, text = c.PO_NUMBER }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetESIExemptionSelect2(string q, int page, string type)
        {
            var list = db.Employee_ESIExemption.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.ID, text = c.WC_POLICY }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetPFExemptionSelect2(string q, int page, string type)
        {
            var list = db.Employee_PFExemption.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.ID, text = c.SALARY_EXEMPTION }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetEmployee_TypeSelect2(string q, int page, string type)
        {
            var list = db.Employee_Type.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.ID, text = c.WORKER_TYPE }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetEmployee_RelationsSelect2(string q, int page, string type)
        {
            var list = db.Employee_Relations.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.ID, text = c.RELATION }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetEmployee_MaritalStatusSelect2(string q, int page, string type)
        {
            var list = db.Employee_MaritalStatus.ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = c.ID, text = c.MARITAL_STATUS }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetAllVendorCodes(string q, int page, string type)
        {
            var list = db.Contractors.Where(t => t.STATUS == (int)STATUS.Submitted).ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = Convert.ToInt32(c.VENDOR_CODE), text = c.CONTRACTOR_NAME }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetAllPONumByVendorCodeSelect2(string q, int page, string type, string VENDOR_CODE)
        {
            var list = db.Jobs.Where(t => t.CONT_ID == VENDOR_CODE && t.STATUS == (int)STATUS.Submitted).ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = Convert.ToInt32(c.PO_NUM), text = c.PO_NUM + "-" + c.JOB_NAME }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetAllEMP_PONumSelect2(string q, int page, string type, string VENDOR_CODE)
        {
            var list = db.Jobs.Where(t => t.CONT_ID == VENDOR_CODE && t.STATUS == (int)STATUS.Approved).ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = Convert.ToInt32(c.PO_NUM), text = c.PO_NUM + "-" + c.JOB_NAME }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetAllEMP_AADHAR_NO_Select2(string q, int page, string type, string PO_NUM)
        {
            var list = db.Employees.Where(t => t.PO_NUM == PO_NUM && t.STATUS == (int)STATUS.Submitted).ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<SelectDropDownViewModel> Data = new List<SelectDropDownViewModel>();
            Data = list.Select(c => new SelectDropDownViewModel { id = Convert.ToInt32(c.EMP_ID), text = c.AADHAR_NO }).AsEnumerable();
            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region contractor
        public ActionResult Contractor()
        {
            string cont_id = Session["VendorNo"].ToString();
            var list = db.Contractors.Where(t => t.VENDOR_CODE == cont_id).FirstOrDefault();
            return View(list);
        }

        [HttpPost]
        public ActionResult SaveContractor(Contractor model)
        {
            var vendor = db.Contractors.Where(t => t.VENDOR_CODE == model.VENDOR_CODE).FirstOrDefault();
            if (vendor == null)
            {
                model.CREATED_ON = DateTime.Now.Date;
                model.CREATED_BY = model.VENDOR_CODE;
                model.STATUS = 0;
                db.Contractors.Add(model);
                db.SaveChanges();
            }
            else
            {
                vendor.CONTRACTOR_NAME = model.CONTRACTOR_NAME;
                vendor.CONTRACTOR_ADDRESS = model.CONTRACTOR_ADDRESS;
                vendor.CITY = model.CITY;
                vendor.STATE = model.STATE;
                vendor.PINCODE = model.PINCODE;
                vendor.PAN = model.PAN;
                vendor.GST = model.GST;
                vendor.MOBILE = model.MOBILE;
                vendor.FAX = model.FAX;
                vendor.CONTRACTOR_INCHARGE = model.CONTRACTOR_INCHARGE;
                vendor.DESIGNATION = model.DESIGNATION;
                vendor.CONT_INCHARGE_MOBILE = model.CONT_INCHARGE_MOBILE;
                vendor.SUPERVISOR = model.SUPERVISOR;
                vendor.SUP_MOBILE = model.SUP_MOBILE;
                vendor.SUP_EMAIL = model.SUP_EMAIL;
                vendor.SEC_EMAIL = model.SEC_EMAIL;
                db.SaveChanges();
            }


            return RedirectToAction("Contractor");


        }
        [HttpPost]
        public ActionResult VendorDetailsPartial(string VENDOR_CODE)
        {
            var vendor = db.Contractors.Where(t => t.VENDOR_CODE == VENDOR_CODE && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();
            if (vendor != null)
            {
                return PartialView("VendorPartial", vendor);
            }
            return null;

        }

        [HttpPost]
        public ActionResult JobDetailsPartial(string PO_NUM)
        {
            var vendor = db.Jobs.Where(t => t.PO_NUM == PO_NUM && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();
            if (vendor != null)
            {
                return PartialView("JobsPartial");
            }

            return null;

        }

        [HttpPost]
        public JsonResult StatusChange(string status, string VENDOR_CODE)
        {
            var vendor = db.Contractors.Where(t => t.VENDOR_CODE == VENDOR_CODE).FirstOrDefault();
            if (vendor != null)
            {
                if (status == "Approve")
                {
                    vendor.STATUS = (int)STATUS.Approved;
                    Contractor model = new Contractor()
                    {
                       // COMP_ID = 1, //CURRENTLY COMP_ID IS HARDCODED FROM COMPANY SINCE THERE IS ONLY ONE COMAPNY(Bharat Petroleum Corporation Limited) IN THE TABLE 
                        VENDOR_CODE = vendor.VENDOR_CODE,
                        CONTRACTOR_NAME = vendor.CONTRACTOR_NAME,
                        CONTRACTOR_ADDRESS = vendor.CONTRACTOR_ADDRESS,
                        CITY = vendor.CITY,
                        STATE = vendor.STATE,
                        PINCODE = vendor.PINCODE,
                        MOBILE = vendor.MOBILE,
                        FAX = vendor.FAX,
                        CONTRACTOR_INCHARGE = vendor.CONTRACTOR_INCHARGE,
                        DESIGNATION = vendor.DESIGNATION,
                        CONT_INCHARGE_MOBILE = vendor.CONT_INCHARGE_MOBILE,
                        E_MAIL = vendor.SUP_EMAIL,
                        CREATED_BY = vendor.CREATED_BY,
                        CREATED_ON = vendor.CREATED_ON,
                        DELETED_BY = vendor.DELETED_BY,
                        DELETED_ON = vendor.DELETED_ON,
                        CONT_PREV_ID = vendor.CONT_PREV_ID,
                        ISTEMPID = vendor.ISTEMPID,
                        SEC_EMAIL = vendor.SEC_EMAIL,
                        SUPERVISOR = vendor.SUPERVISOR,
                        SUP_MOBILE = vendor.SUP_MOBILE

                    };

                    db.Contractors.Add(model);
                    db.SaveChanges();

                    return Json("Approved", JsonRequestBehavior.AllowGet);
                }
                else if (status == "Sendback")
                {
                    vendor.STATUS = (int)STATUS.Send_Back;
                    return Json("Send_Back", JsonRequestBehavior.AllowGet);
                }
                else if (status == "Reject")
                {
                    vendor.STATUS = (int)STATUS.Rejected;
                    return Json("Rejected", JsonRequestBehavior.AllowGet);
                }

                db.SaveChanges();
            }

            return Json("Success", JsonRequestBehavior.AllowGet);


        }






        #endregion

        #region Jobs

        public ActionResult Jobs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveJob(JobsViewModel model)
        {
            try
            {
                if (model.JOB_ID == 0)
                {
                    string VENDOR_CODE = Session["VendorNo"].ToString();
                    var job = db.Jobs.Where(t => t.PO_NUM == model.PO_NUM).FirstOrDefault();
                    if (job == null)
                    {
                        model.CREATED_ON = DateTime.Now.Date;
                        model.CREATED_BY = VENDOR_CODE;
                        db.Jobs.Add(model.ConvertAsDataEntity());
                        db.SaveChanges();

                        Job_Arc obj = new Job_Arc()
                        {
                            ARC_NO = model.ARC_NO,
                            PO_NUM = model.PO_NUM,
                            DESCRIPTION = model.DESCRIPTION,
                            ARC_DATE = model.ARC_DATE,
                            SCHEDULE_FROM = model.SCHEDULE_FROM,
                            SCHEDULE_TO = model.SCHEDULE_TO,
                            DEACTIVATED_ON = model.DEACTIVATED_ON,
                            CREATED_BY = model.CREATED_BY,
                            CREATED_ON = model.CREATED_ON

                        };

                        db.Job_Arc.Add(obj);
                        db.SaveChanges();

                        var doc = db.Vendor_Doc.Where(t => t.PO_NUMBER == Convert.ToDouble(model.PO_NUM)).ToList();
                        foreach (var li in doc)
                        {
                            li.ACTIVE = true;
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    var job = db.Jobs.Where(t => t.JOB_ID == model.JOB_ID).FirstOrDefault();
                    if (job != null)
                    {
                        job.PO_NUM = model.PO_NUM;
                        job.ARC = model.ARC;
                        job.ARC_NO = model.ARC_NO;
                        job.JOB_NAME = model.JOB_NAME;
                        job.DEPT_ID = model.DEPT_ID;
                        job.AREA = model.AREA;
                        job.CONT_ID = model.CONT_ID;
                        job.ADDRESS = model.ADDRESS;
                        job.HOUSE_KEEPING = model.HOUSE_KEEPING;
                        job.ONLY_EXCEMPTION = model.ONLY_EXCEMPTION;
                        job.NO_WORKERS = model.NO_WORKERS;
                        job.TOTAL_WORKERS = model.TOTAL_WORKERS;
                        job.TOTAL_PASS_COUNT = model.TOTAL_PASS_COUNT;
                        job.ISMW_WORKERS_ASSIGNED = model.ISMW_WORKERS_ASSIGNED;
                        job.ISMW_PASS_COUNT = model.ISMW_PASS_COUNT;
                        job.COMPLETED_DATE = model.COMPLETED_DATE;
                        job.WORKERS_LICENSE_PASS = model.WORKERS_LICENSE_PASS;
                        job.WL_PASS_FROM = model.WL_PASS_FROM;
                        job.WL_PASS_TO = model.WL_PASS_TO;
                        job.STAFF_PASS = model.STAFF_PASS;
                        job.ISWL_LICENSE_CLOSED = model.ISWL_LICENSE_CLOSED;
                        job.ISMW = model.ISMW;
                        job.ISMW_LICENSE_PASS = model.ISMW_LICENSE_PASS;
                        job.ISMW_FROM = model.ISMW_FROM;
                        job.ISMW_TO = model.ISMW_TO;
                        job.BLOCK = model.BLOCK;
                        job.BLOCK_REMARKS = model.BLOCK_REMARKS;
                        job.SEC_REMARKS = model.SEC_REMARKS;
                        db.SaveChanges();
                    }
                    var job_Arc = db.Job_Arc.Where(t => t.ARC_ID == model.ARC_ID).FirstOrDefault();
                    if (job != null)
                    {
                        job_Arc.ARC_NO = model.ARC_NO;
                        job_Arc.PO_NUM = model.PO_NUM;
                        job_Arc.DESCRIPTION = model.DESCRIPTION;
                        job_Arc.ARC_DATE = model.ARC_DATE;
                        job_Arc.SCHEDULE_FROM = model.SCHEDULE_FROM;
                        job_Arc.SCHEDULE_TO = model.SCHEDULE_TO;
                        job_Arc.DEACTIVATED_ON = model.DEACTIVATED_ON;
                        db.SaveChanges();
                    }

                    var doc = db.Vendor_Doc.Where(t => t.PO_NUMBER == Convert.ToDouble(model.PO_NUM)).ToList();
                    foreach (var li in doc)
                    {
                        li.ACTIVE = true;
                        db.SaveChanges();
                    }


                }
            }
            catch (Exception Ex)
            {

            }


            return RedirectToAction("Jobs");
        }

        [HttpPost]
        public JsonResult GetAllJobsByPO_NUM(string PO_NUM)
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
                       }).Where(t => t.PO_NUM == PO_NUM).FirstOrDefault();
            if (job != null)
            {
                return Json(JsonConvert.SerializeObject(new { success = true, results = job }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { success = false, results = job }), JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult GetAllJobDOCSByPO_NUM(long PO_NUM)
        {
            var docs = (from VD in db.Vendor_Doc
                        join DM in db.Doc_Master on VD.DOC_ID equals DM.DOC_ID
                        orderby VD.DOC_ID
                        select new
                        {
                            TRANS_ID = VD.TRANS_ID,
                            VENDOR_CODE = VD.VENDOR_CODE,
                            PO_NUMBER = VD.PO_NUMBER,
                            DOC_ID = VD.DOC_ID,
                            DOC_EXTN = VD.DOC_ID,
                            DOCUMENT = VD.DOC_EXTN,
                            DOC_TYPE = DM.DOC_TYPE,
                            DOC_NAME = DM.DOC_NAME,
                            DESCRIPTION = DM.DESCRIPTION,
                            USER_TYPE = DM.USER_TYPE,
                            ACTIVE = VD.ACTIVE,
                        }).Where(t => t.PO_NUMBER == PO_NUM && t.ACTIVE == true).ToList();
            //var docs = db.Vendor_Doc.Where(t => t.PO_NUMBER == PO_NUM).ToList();

            if (docs != null)
            {
                // var img = db.Vendor_Doc.Where(t => t.TRANS_ID == TRANS_ID).FirstOrDefault();               
                //var imgdata = img.DOCUMENT;

                //string base64String = Convert.ToBase64String(imgdata, 0, imgdata.Length);
                //return "data:image/png;base64," + base64String;
                //return Json(docs, JsonRequestBehavior.AllowGet);
                return Json(JsonConvert.SerializeObject(new { success = true, results = docs }), JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { success = false, results = docs }), JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult JobStatusChange(string status, string PO_NUM)
        {
            try
            {
                var job = db.Jobs.Where(t => t.PO_NUM == PO_NUM && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();
                var job_arc = db.Job_Arc.Where(t => t.PO_NUM == PO_NUM).FirstOrDefault();
                if (job != null)
                {
                    if (status == "Approve")
                    {
                        job.STATUS = (int)STATUS.Approved;
                        JOB1 model = new JOB1()
                        {
                            COMP_ID = 1,
                            JOB_ID = job.PO_NUM,
                            ARC = job.ARC,
                            ARC_ID = job_arc.ARC_ID.ToString(),
                            DEPT_ID = job.DEPT_ID,
                            DESCRIPTION = job_arc.DESCRIPTION,
                            AREA = job.AREA,
                            CONT_ID = job.CONT_ID,
                            NO_WORKERS = job.NO_WORKERS,
                            COMPLETED = job.COMPLETED_DATE,
                            WORKERS_LICENSE_PASS = job.WORKERS_LICENSE_PASS,
                            WL_PASS_FROM = job.WL_PASS_FROM,
                            WL_PASS_TO = job.WL_PASS_TO,
                            ISWL_LICENSE_CLOSED = job.ISWL_LICENSE_CLOSED,
                            ISMW = job.ISMW,
                            ISMW_LICENSE_PASS = job.ISMW_LICENSE_PASS,
                            ISMW_FROM = job.ISMW_FROM,
                            ISMW_TO = job.ISMW_TO,
                            BLOCK = job.BLOCK,
                            BLOCK_REMARKS = job.BLOCK_REMARKS,
                            CREATED_BY = job.CREATED_BY,
                            CREATED_ON = job.CREATED_ON,
                            DELETED_BY = job.DELETED_BY,
                            DELETED_ON = job.DELETED_ON,
                            PASS_COUNT = job.TOTAL_PASS_COUNT,
                            STAFF = job.STAFF_PASS,
                            ONLYEX = job.ONLY_EXCEMPTION,
                            SEC_REMARKS = job.SEC_REMARKS,

                        };
                        db.JOB1.Add(model);
                        db.SaveChanges();

                        JOB_ARC1 model1 = new JOB_ARC1()
                        {
                            COMP_ID = 1,
                            ARC_ID = job_arc.ARC_ID.ToString(),
                            DEPT_ID = job.DEPT_ID,
                            CONT_ID = job.CONT_ID,
                            JOB_NAME = job.JOB_NAME,
                            ARC_DATE = job_arc.ARC_DATE,
                            ARC_DETAILS = job_arc.DESCRIPTION,
                            ARC_FROM = Convert.ToDateTime(job_arc.SCHEDULE_FROM),
                            ARC_TO = Convert.ToDateTime(job_arc.SCHEDULE_TO),
                            DEACTIVATED_ON = job_arc.DEACTIVATED_ON,
                            CREATED_BY = job_arc.CREATED_BY,
                            CREATED_ON = Convert.ToDateTime(job_arc.CREATED_ON),
                        };
                        db.JOB_ARC1.Add(model1);
                        db.SaveChanges();

                        db.SaveChanges();
                        return Json("Approved", JsonRequestBehavior.AllowGet);
                    }
                    else if (status == "Sendback")
                    {
                        job.STATUS = (int)STATUS.Send_Back;
                        db.SaveChanges();
                        return Json("Send_Back", JsonRequestBehavior.AllowGet);
                    }
                    else if (status == "Reject")
                    {
                        job.STATUS = (int)STATUS.Rejected;
                        db.SaveChanges();
                        return Json("Rejected", JsonRequestBehavior.AllowGet);
                    }


                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return null;




        }

        #endregion

        #region Employee

        public ActionResult Employees()
        {
            return View();
        }

        public ActionResult EmployeeList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEmployeeList(string PO_NUM)
        {
            var obj = db.Employees.Where(t => t.PO_NUM == PO_NUM && t.STATUS == (int)STATUS.Submitted).ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SaveEmployee(EmployeesViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string cont_id = Session["VendorNo"].ToString();
                    var Employee = db.Employees.Where(t => t.EMP_ID == model.EMP_ID).FirstOrDefault();
                    if (Employee == null)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            model.PHOTO = new byte[file.ContentLength]; // file1 to store image in binary formate  
                            file.InputStream.Read(model.PHOTO, 0, file.ContentLength);
                        }
                        model.CREATED_ON = DateTime.Now.Date;
                        model.CREATED_BY = cont_id;
                        db.Employees.Add(model.ConvertAsDataEntity());
                        db.SaveChanges();

                        Employee_Servicebook obj = new Employee_Servicebook
                        {
                            EMP_ID = model.EMP_ID,
                            JOB_ID = model.JOB_ID,
                            ESI_EXEMPTION = model.ESI_EXEMPTION,
                            WC_POLICY = model.ESI_EXEMPTION,
                            WC_POLICY_VALID_UPTO = model.WC_POLICY_VALID_UPTO,
                            PF_EXEMPTION = model.PF_EXEMPTION,
                            EMP_ESINO = model.EMP_ESINO,
                            EMPR_ESI_CODE = model.EMPR_ESI_CODE,
                            EMP_PF_NO = model.EMPR_ESI_CODE,
                            UAN_NO = model.UAN_NO,
                            EMPR_PF_CODE = model.EMPR_PF_CODE,
                            CREATEDBY = model.CREATED_BY,
                            CREATED_ON = model.CREATED_ON,
                        };
                        db.Employee_Servicebook.Add(obj);
                        db.SaveChanges();

                        var doc = db.Employee_Doc.Where(t => t.PO_NUMBER == Convert.ToDouble(model.PO_NUM)).ToList();
                        foreach (var li in doc)
                        {
                            li.ACTIVE = true;
                            db.SaveChanges();
                        }
                        return RedirectToAction("EmployeeList", new { status = "Saved" });
                    }
                    else
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            Employee.PHOTO = new byte[file.ContentLength]; // file1 to store image in binary formate  
                            file.InputStream.Read(Employee.PHOTO, 0, file.ContentLength);
                        }
                        Employee.PO_NUM = model.PO_NUM;
                        Employee.EMP_NAME = model.EMP_NAME;
                        Employee.GENDER = model.GENDER;
                        Employee.MARITAL_STATUS = model.MARITAL_STATUS;
                        Employee.EMP_ESINO = model.EMP_ESINO;
                        Employee.ESI_REGN_DATE = model.ESI_REGN_DATE;
                        Employee.PEHCHAN = model.PEHCHAN;
                        Employee.EMP_PF_NO = model.EMP_PF_NO;
                        Employee.PF_REGN_DATE = model.PF_REGN_DATE;
                        Employee.UAN = model.UAN;
                        Employee.EPS = model.EPS;
                        Employee.EVICTEE = model.EVICTEE;
                        Employee.EVICTEE_CARD_NO = model.EVICTEE_CARD_NO;
                        Employee.ISMW = model.ISMW;
                        Employee.DISABILITY_TYPE = model.DISABILITY_TYPE;
                        Employee.NOMINEE_RELATIONSHIP_TYPE = model.RELATION_IP;
                        Employee.NOMINEE_RELATION_NAME = model.RELATION_NAME;
                        Employee.DOB =Convert.ToDateTime(model.DOB);
                        Employee.DOJ = Convert.ToDateTime(model.DOJ);
                        Employee.PRESENT_ADRS = model.PRESENT_ADRS;
                        Employee.PERMANENT_ADRS = model.PERMANENT_ADRS;
                        Employee.CITY = model.CITY;
                        Employee.DISTRICT = model.DISTRICT;
                        Employee.STATE = model.STATE;
                        Employee.PINCODE = model.PINCODE;
                        Employee.MOBILE_NO = model.ICE_PHONE;
                        Employee.EMP_TYPE = model.EMP_TYPE;
                        Employee.ID_TYPE = model.ID_TYPE;
                        Employee.AADHAR_NO = model.ID_NUM;
                        Employee.BANK_NAME = model.BANK_NAME;
                        Employee.BANK_BRANCH = model.BANK_BRANCH;
                        Employee.BANK_ADDRESS = model.BANK_ADDRESS;
                        Employee.BANK_ACNO = model.BANK_ACNO;
                        Employee.BANK_IFSC = model.BANK_IFSC;
                        Employee.BLACK_LISTED = model.BLACK_LISTED;
                        Employee.BLACK_LISTED_REASON = model.BLACK_LISTED_REASON;
                        Employee.BLACK_LISTED_DATE = model.BLACK_LISTED_DATE;
                        Employee.REMARKS = model.REMARKS;                  
                        db.SaveChanges();


                        var EmpSB = db.Employee_Servicebook.Where(t => t.EMP_ID == model.EMP_ID).FirstOrDefault();
                        if(EmpSB!=null)
                        {
                            EmpSB.ESI_EXEMPTION = model.ESI_EXEMPTION;
                            EmpSB.WC_POLICY = model.ESI_EXEMPTION;
                            EmpSB.WC_POLICY_VALID_UPTO = model.WC_POLICY_VALID_UPTO;
                            EmpSB.PF_EXEMPTION = model.PF_EXEMPTION;
                            EmpSB.EMP_ESINO = model.EMP_ESINO;
                            EmpSB.EMPR_ESI_CODE = model.EMPR_ESI_CODE;
                            EmpSB.EMP_PF_NO = model.EMPR_ESI_CODE;
                            EmpSB.UAN_NO = model.UAN_NO;
                            EmpSB.EMPR_PF_CODE = model.EMPR_PF_CODE;
                            db.SaveChanges();

                        }
                        var doc = db.Employee_Doc.Where(t => t.PO_NUMBER == Convert.ToDouble(model.PO_NUM)).ToList();
                        foreach (var li in doc)
                        {
                            li.ACTIVE = true;
                            db.SaveChanges();
                        }
                    }

                    return RedirectToAction("EmployeeList", new { status = "Updated" });
                }
                else
                {
                    ViewBag.valid = "ValidationError";
                    return RedirectToAction("Employees", new { status = "Error" });

                }

            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public ActionResult GetEmployeeDetailsById(long EMP_ID, bool? IS_PARTIAL)
        {
            var emp = (from E in db.Employees
                       join MS in db.Employee_MaritalStatus on E.MARITAL_STATUS equals MS.ID.ToString()
                       join RE in db.Employee_Relations on E.NOMINEE_RELATIONSHIP_TYPE equals RE.ID.ToString()
                       join SB in db.Employee_Servicebook on E.EMP_ID equals SB.EMP_ID
                       join ESI in db.Employee_ESIExemption on SB.ESI_EXEMPTION equals ESI.ID.ToString()
                       join PF in db.Employee_PFExemption on SB.PF_EXEMPTION equals PF.ID.ToString()
                       join ET in db.Employee_Type on E.EMP_TYPE equals ET.ID.ToString()
                       //orderby E.EMP_ID
                       select new EmployeesViewModel
                       {
                           EMP_ID = E.EMP_ID,
                           PO_NUM = E.PO_NUM,
                           EMP_NAME = E.EMP_NAME,
                           GENDER = E.GENDER,
                           MARITAL_STATUS = MS.MARITAL_STATUS,
                           MARITAL_STATUS_ID = E.MARITAL_STATUS,
                           EMP_ESINO = E.EMP_ESINO,
                           ESI_REGN_DATE = E.ESI_REGN_DATE,
                           PEHCHAN = E.PEHCHAN,
                           EMP_PF_NO = E.EMP_PF_NO,
                           PF_REGN_DATE = E.PF_REGN_DATE,
                           UAN = E.UAN,
                           EPS = E.EPS,
                           EVICTEE = E.EVICTEE,
                           EVICTEE_CARD_NO = E.EVICTEE_CARD_NO,
                           ISMW = E.ISMW,
                           DISABILITY_TYPE = E.DISABILITY_TYPE,
                           RELATION_IP = RE.RELATION,
                           RELATION_IP_ID = E.NOMINEE_RELATIONSHIP_TYPE,
                           RELATION_NAME = E.NOMINEE_RELATION_NAME,
                           DOB = E.DOB.ToString(),
                           DOJ = E.DOJ.ToString(),
                           PRESENT_ADRS = E.PRESENT_ADRS,
                           PERMANENT_ADRS = E.PERMANENT_ADRS,
                           CITY = E.CITY,
                           DISTRICT=E.DISTRICT,
                           STATE = E.STATE,
                           PINCODE = E.PINCODE,
                           ICE_PHONE = E.MOBILE_NO,
                           EMP_TYPE = ET.WORKER_TYPE,
                           EMP_TYPE_ID = E.EMP_TYPE,
                           ID_TYPE = E.ID_TYPE,
                           ID_NUM = E.AADHAR_NO,
                           PHOTO = E.PHOTO,
                           BANK_NAME = E.BANK_NAME,
                           BANK_BRANCH = E.BANK_BRANCH,
                           BANK_ADDRESS = E.BANK_ADDRESS,
                           BANK_ACNO = E.BANK_ACNO,
                           BANK_IFSC=E.BANK_IFSC,
                           BLACK_LISTED = E.BLACK_LISTED,
                           BLACK_LISTED_REASON = E.BLACK_LISTED_REASON,
                           BLACK_LISTED_DATE = E.BLACK_LISTED_DATE,
                           REMARKS = E.REMARKS,
                           STATUS = E.STATUS,
                           ESI_EXEMPTION = ESI.WC_POLICY,
                           ESI_EXEMPTION_ID = SB.ESI_EXEMPTION,
                           WC_POLICY = SB.WC_POLICY,
                           WC_POLICY_VALID_UPTO = SB.WC_POLICY_VALID_UPTO,
                           PF_EXEMPTION = PF.SALARY_EXEMPTION,
                           PF_EXEMPTION_ID = SB.PF_EXEMPTION,
                           EMPR_PF_CODE = SB.EMPR_PF_CODE,
                           UAN_NO = SB.UAN_NO,
                           EMPR_ESI_CODE = SB.EMPR_ESI_CODE,
                       }).Where(t => t.EMP_ID == EMP_ID && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();
            return View("Employees", emp);
        }

        [HttpPost]
        public ActionResult GetEmployeeDetailsByIdPartial(long EMP_ID, bool? IS_PARTIAL)
        {
            var emp = (from E in db.Employees
                       join MS in db.Employee_MaritalStatus on E.MARITAL_STATUS equals MS.ID.ToString()
                       join RE in db.Employee_Relations on E.NOMINEE_RELATIONSHIP_TYPE equals RE.ID.ToString()
                       join SB in db.Employee_Servicebook on E.EMP_ID equals SB.EMP_ID
                       join ESI in db.Employee_ESIExemption on SB.ESI_EXEMPTION equals ESI.ID.ToString()
                       join PF in db.Employee_PFExemption on SB.PF_EXEMPTION equals PF.ID.ToString()
                       join ET in db.Employee_Type on E.EMP_TYPE equals ET.ID.ToString()
                       //orderby E.EMP_ID
                       select new EmployeesViewModel
                       {
                           EMP_ID = E.EMP_ID,
                           PO_NUM = E.PO_NUM,
                           EMP_NAME = E.EMP_NAME,
                           GENDER = E.GENDER,
                           MARITAL_STATUS = MS.MARITAL_STATUS,
                           EMP_ESINO = E.EMP_ESINO,
                           ESI_REGN_DATE = E.ESI_REGN_DATE,
                           PEHCHAN = E.PEHCHAN,
                           EMP_PF_NO = E.EMP_PF_NO,
                           PF_REGN_DATE = E.PF_REGN_DATE,
                           UAN = E.UAN,
                           EPS = E.EPS,
                           EVICTEE = E.EVICTEE,
                           EVICTEE_CARD_NO = E.EVICTEE_CARD_NO,
                           ISMW = E.ISMW,
                           DISABILITY_TYPE = E.DISABILITY_TYPE,
                           RELATION_IP = RE.RELATION,
                           RELATION_NAME = E.NOMINEE_RELATIONSHIP_TYPE,
                           DOB = E.DOB.ToString(),
                           DOJ = E.DOJ.ToString(),
                           PRESENT_ADRS = E.PRESENT_ADRS,
                           PERMANENT_ADRS = E.PERMANENT_ADRS,
                           CITY = E.CITY,
                           STATE = E.STATE,
                           PINCODE = E.PINCODE,
                           ICE_PHONE = E.MOBILE_NO,
                           EMP_TYPE = ET.WORKER_TYPE,
                           ID_TYPE = E.ID_TYPE,
                           ID_NUM = E.AADHAR_NO,
                           PHOTO = E.PHOTO,
                           BANK_NAME = E.BANK_NAME,
                           BANK_BRANCH = E.BANK_BRANCH,
                           BANK_ADDRESS = E.BANK_ADDRESS,
                           BANK_ACNO = E.BANK_ACNO,
                           BLACK_LISTED = E.BLACK_LISTED,
                           BLACK_LISTED_REASON = E.BLACK_LISTED_REASON,
                           BLACK_LISTED_DATE = E.BLACK_LISTED_DATE,
                           REMARKS = E.REMARKS,
                           STATUS = E.STATUS,
                           ESI_EXEMPTION = ESI.WC_POLICY,
                           WC_POLICY = SB.WC_POLICY,
                           WC_POLICY_VALID_UPTO = SB.WC_POLICY_VALID_UPTO,
                           PF_EXEMPTION = PF.SALARY_EXEMPTION,
                           EMPR_PF_CODE = SB.EMPR_PF_CODE,
                           UAN_NO = SB.UAN_NO,
                           EMPR_ESI_CODE = SB.EMPR_ESI_CODE,

                       }).Where(t => t.EMP_ID == EMP_ID && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();

            if (IS_PARTIAL == false)
            {
                return RedirectToAction("Employees", emp);
            }
            else
            {
                return PartialView("EmployeePartial", emp);
            }

        }
        [HttpPost]
        public JsonResult GetAllEMPDOCSByEMPID(long EMP_ID)
        {
            var docs = (from ED in db.Employee_Doc
                        join DM in db.Doc_Master on ED.DOC_ID equals DM.DOC_ID
                        orderby ED.DOC_ID
                        select new
                        {
                            EMP_ID=ED.EMPLOYEE_ID,
                            TRANS_ID = ED.TRANS_ID,
                            VENDOR_CODE = ED.VENDOR_CODE,
                            PO_NUMBER = ED.PO_NUMBER,
                            DOC_ID = ED.DOC_ID,
                            DOC_EXTN = ED.DOC_ID,
                            DOCUMENT = ED.DOC_EXTN,
                            DOC_TYPE = DM.DOC_TYPE,
                            DOC_NAME = DM.DOC_NAME,
                            DESCRIPTION = DM.DESCRIPTION,
                            USER_TYPE = DM.USER_TYPE,
                            ACTIVE = ED.ACTIVE,
                        }).Where(t => t.EMP_ID == EMP_ID && t.ACTIVE == true).ToList();

            if (docs != null)
            {             
                return Json(JsonConvert.SerializeObject(new { success = true, results = docs }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { success = false, results = docs }), JsonRequestBehavior.AllowGet);
            }

        }

       
        [HttpPost]
        public JsonResult GetJobByJobId(int job_id)
        {
            var list = db.Jobs.Where(t => t.JOB_ID == job_id).FirstOrDefault();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}