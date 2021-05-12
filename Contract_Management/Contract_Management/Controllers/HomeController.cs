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
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
       

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ValidateVendor(string vendorno)
        {
            var vendor = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno).ToList();
            var result = Content(JsonConvert.SerializeObject(vendor,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveOTP(string vendorno, string otp)
        {
            var vendor = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno).FirstOrDefault();
            if (vendor != null)
            {
                vendor.OTP = otp;
                db.SaveChanges();
            }
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool ValidateOTP(string vendorno, string otp)
        {
            var checkotp = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno && t.OTP == otp).FirstOrDefault();
            if (checkotp != null)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterVendor(string vendorno, string otp, string password)
        {
            var vendor = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno && t.OTP == otp).FirstOrDefault();
            if (vendor != null)
            {
                if (vendor.IS_REGISTERED != true)
                {
                    vendor.PASWORD = Encrypt(password.Trim());
                    vendor.IS_REGISTERED = true;
                    db.SaveChanges();
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Already Registered", JsonRequestBehavior.AllowGet);
                }
            }

            return Json("Failed", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(string vendorno, string password)
        {
            password = Encrypt(password.Trim());
            var login = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno && t.PASWORD == password && t.IS_ACTIVE == true && t.IS_REGISTERED == true).FirstOrDefault();
            if (login != null)
            {
                Session["USER_ID"] = vendorno;
                Session["VendorNo"] = vendorno;
                Session["VendorNo"] = vendorno;
                Session["VendorName"] = login.VENDOR_NAME;
                Session["VendorMob"] = login.MOBILE_NO;
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ChangePassword(string vendorno, string otp, string password)
        {
            var vendor = db.vendor_details.Where(t => t.VENDOR_CODE == vendorno && t.OTP == otp).FirstOrDefault();
            if (vendor != null)
            {
                vendor.PASWORD = Encrypt(password.Trim());
                db.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Menu(string vendorno, string otp)
        {
            string userid = Session["RoleId"].ToString();
            var Menulist = db.Database.SqlQuery<Menu>("select * from cms.Menu where RoleId='"+ userid + "' and IsActive=1").ToList();
            if (Menulist != null)
            {
                return PartialView(Menulist);
            }
            return null;
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session["VendorNo"] = null;
            Session["Admin"] = null;
            return Json("Success", JsonRequestBehavior.AllowGet);

        }
        
    }
}