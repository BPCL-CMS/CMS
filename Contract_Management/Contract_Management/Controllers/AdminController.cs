using Contract_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contract_Management.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Verification()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdminLogin()
        {
            string username = Request["username"].ToString();
            string pwd = Request["password"].ToString();
            if (username == "Admin" && pwd == "admin")
            {
                Session["Admin"] = "Admin";
                Session["RoleId"] = Request["UserRole"].ToString();

                Role role = GetRoleDetails(int.Parse(Session["RoleId"].ToString()));
                return View(role.DefaultPageUrl);
                //return RedirectToAction("Index", role.DefaultPageUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult EMPStatusChange(string status, long EMP_ID)
        {
            Employee EMP = db.Employees.Where(t => t.EMP_ID == EMP_ID && t.STATUS == (int)STATUS.Submitted).FirstOrDefault();
            if (EMP != null)
            {
                if (status == "Approve")
                {
                    EMP.STATUS = (int)STATUS.Approved;
                    db.SaveChanges();
                    return Json("Approved", JsonRequestBehavior.AllowGet);
                }
                else if (status == "Sendback")
                {
                    EMP.STATUS = (int)STATUS.Send_Back;
                    db.SaveChanges();
                    return Json("Send_Back", JsonRequestBehavior.AllowGet);
                }
                else if (status == "Reject")
                {
                    EMP.STATUS = (int)STATUS.Rejected;
                    db.SaveChanges();
                    return Json("Rejected", JsonRequestBehavior.AllowGet);
                }


            }

            return Json("Success", JsonRequestBehavior.AllowGet);


        }

        private Role GetRoleDetails(int roleId)
        {
            Role role = db.Roles.Where(r => r.RoleId == roleId).FirstOrDefault();
            return role;
        }
    }
}