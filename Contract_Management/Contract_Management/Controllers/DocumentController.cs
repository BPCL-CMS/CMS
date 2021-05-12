using Contract_Management.Data.DomainModels;
using Contract_Management.Data.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contract_Management.Controllers
{
    public class DocumentController : BaseController
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DocumentUpload()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult DocumentsUpload()
        {
            byte[] UPLOAD_DOC = null;
            string cont_id = Session["VendorNo"].ToString();
            string PO_NUM = db.Vendor_PO.Where(t => t.VENDOR_CODE == cont_id).FirstOrDefault().PO_NUMBER;
            ImageUploadTableModel Data = new ImageUploadTableModel();
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    var USER_TYPE = Request.Form["USER_TYPE"];
                    var EMP_ID = Request.Form["EMP_ID"].ToString();
                    long DOC_ID = Convert.ToInt32(Request.Form["DOC_ID"].ToString());
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;

                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            UPLOAD_DOC = new byte[file.ContentLength]; // file1 to store image in binary formate  
                            file.InputStream.Read(UPLOAD_DOC, 0, file.ContentLength);
                        }

                        string extn = System.IO.Path.GetExtension(file.FileName);
                        //// Get the complete folder path and store the file inside it.  
                        //fname = "EMP_" + DOC_NAME + "_" + EMP_ID + extn;
                        //string FILE_NAME = "EMP_" + DOC_NAME + "_" + EMP_ID + extn;
                        //fname = Path.Combine(Server.MapPath("~/Uploads/Employee"), fname);


                        // file.SaveAs(fname);


                        DocumentUploadModel model = new DocumentUploadModel()
                        {
                            DOC_ID = DOC_ID,
                            VENDOR_CODE = cont_id,
                            DOCUMENT = UPLOAD_DOC,
                            PO_NUMBER = Convert.ToInt32(PO_NUM),
                            EMPLOYEE_ID = Convert.ToInt32(EMP_ID),
                            DOC_EXTN = extn,
                            CREATED_DATE = DateTime.Now.Date,
                            CREATED_BY = cont_id,
                            ACTIVE = false

                        };
                        if (USER_TYPE == "VENDOR")
                        {
                            db.Vendor_Doc.Add(model.ConvertAsDataEntity("vendor"));    //ONLY FOR CREATING METHOD WITH DIFFERENT PARAMETERS
                            db.SaveChanges();
                            var TRANS_DATA = db.Vendor_Doc.Local.LastOrDefault();
                            var DOC_NAME = db.Doc_Master.Where(t => t.DOC_ID == TRANS_DATA.DOC_ID).FirstOrDefault().DOC_NAME;
                            Data = new ImageUploadTableModel { DOC_ID = model.DOC_ID, DOC_NAME = DOC_NAME, TRANS_ID = TRANS_DATA.TRANS_ID };
                        }
                        else
                        {
                            db.Employee_Doc.Add(model.ConvertAsDataEntity());
                            db.SaveChanges();
                            var TRANS_DATA = db.Employee_Doc.Local.LastOrDefault();
                            var DOC_NAME = db.Doc_Master.Where(t => t.DOC_ID == TRANS_DATA.DOC_ID).FirstOrDefault().DOC_NAME;
                            Data = new ImageUploadTableModel { DOC_ID = model.DOC_ID, DOC_NAME = DOC_NAME, TRANS_ID = TRANS_DATA.TRANS_ID };
                        }



                    }


                    // Returns message that successfully uploaded  
                    return Json(Data, JsonRequestBehavior.AllowGet);
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
                    return Json("Error occurred. Error details: " + ex.Message);
                }

                //catch (Exception ex)
                //{
                //    return Json("Error occurred. Error details: " + ex.Message);
                //}
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public ActionResult DeleteUpload(long TRANS_ID, string USER_TYPE)
        {
            try
            {
                if (USER_TYPE == "EMPLOYEE")
                {
                    var img = db.Employee_Doc.Where(t => t.TRANS_ID == TRANS_ID).FirstOrDefault();
                    string docname = db.Doc_Master.Where(t => t.DOC_ID == img.DOC_ID).FirstOrDefault().DOC_NAME;
                    db.Employee_Doc.Remove(img);
                    db.SaveChanges();
                }
                else
                {
                    var img = db.Vendor_Doc.Where(t => t.TRANS_ID == TRANS_ID).FirstOrDefault();
                    string docname = db.Doc_Master.Where(t => t.DOC_ID == img.DOC_ID).FirstOrDefault().DOC_NAME;
                    db.Vendor_Doc.Remove(img);
                    db.SaveChanges();
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
            return Json("Success");
        }

        [HttpPost]
        public ActionResult GetUploadedImg(long TRANS_ID, string USER_TYPE)
        {
            try
            {
                if (USER_TYPE == "VENDOR")
                {
                    var img = db.Vendor_Doc.Where(t => t.TRANS_ID == TRANS_ID).Where(t=>t.ACTIVE==true).FirstOrDefault();
                    var imgdata = img.DOCUMENT;

                    string base64String = Convert.ToBase64String(imgdata, 0, imgdata.Length);
                    //return "data:image/png;base64," + base64String;
                    return Json(base64String, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var img = db.Employee_Doc.Where(t => t.TRANS_ID == TRANS_ID).Where(t => t.ACTIVE == true).FirstOrDefault();
                    var imgdata = img.DOCUMENT;

                    string base64String = Convert.ToBase64String(imgdata, 0, imgdata.Length);
                    //return "data:image/png;base64," + base64String;
                    return Json(base64String, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex) { }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllDoctypeByUserType(string q, int page, string type, string USER_TYPE, string SEL_DOCS)
        {
            var list = db.Doc_Master.Where(t => t.USER_TYPE == USER_TYPE).ToList();
            SelectDropDownViewModel dummy = new SelectDropDownViewModel()
            {
                id = 0,
                text = "no data found",
            };
            IEnumerable<DocumentSelectDropDownViewModel> Data = new List<DocumentSelectDropDownViewModel>();
            Data = list.Select(c => new DocumentSelectDropDownViewModel { id = Convert.ToInt32(c.DOC_ID), text = c.DOC_NAME, disabled = false }).AsEnumerable();
            if (SEL_DOCS != "")
            {
                string[] sel_docs = SEL_DOCS.TrimStart(',').Split(',');
                for (int i = 0; i < sel_docs.Length; i++)
                {
                    var item = list.Find(t => t.DOC_ID == Convert.ToDouble(sel_docs[i]));
                    list.Remove(item);

                }
            }
            else
            {
                Data = list.Select(c => new DocumentSelectDropDownViewModel { id = Convert.ToInt32(c.DOC_ID), text = c.DOC_NAME }).AsEnumerable();
            }

            return Json(JsonConvert.SerializeObject(new { success = true, results = Data, items = Data, total_count = Data.Count() }), JsonRequestBehavior.AllowGet);

        }

        public class ImageUploadTableModel
        {
            public long? DOC_ID { get; set; }
            public string DOC_NAME { get; set; }
            public string FILE_NAME { get; set; }
            public long TRANS_ID { get; set; }
        }

        public class DocumentSelectDropDownViewModel
        {
            public int id { get; set; }
            public string text { get; set; }
            public bool disabled { get; set; }
        }
    }
}