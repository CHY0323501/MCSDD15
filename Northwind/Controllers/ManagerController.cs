using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ManagerController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string LastName,string FirstName)
        {
            var employee = db.Employees.Where(m => m.LastName == LastName && m.FirstName == FirstName).FirstOrDefault();

            if (employee == null) {
                ViewBag.Message = "帳號或密碼錯誤";
                return View();
            }

            Session["employee"] = employee;
            Session["Welcome"] = employee.FirstName+"管理員您好";
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}