using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;
using PagedList;
using System.Configuration;

namespace Northwind.Controllers
{
    [LoginRule]
    public class CustomersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Customers
        public ActionResult Index(int page=1)
        {
            //if (Session["employee"] == null)
            //    return RedirectToAction("Login","Manager");

            var list = db.Customers.ToList();

            int pagesize = 20;
            int pagecurrent = page < 1 ? 1 : page;
            var pagedlist = list.ToPagedList(pagecurrent, pagesize);

            return View("Index",pagedlist);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,PostalCode,Phone,Fax")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,PostalCode,Phone,Fax")] Customers customers)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
                //使用ado.net直接呼叫函數，可直接寫函數名稱就好，在指定cmd類型即可
                SqlCommand cmd = new SqlCommand("updateCustomer",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CompanyName",customers.CompanyName);
                cmd.Parameters.AddWithValue("ContactName",customers.ContactName);
                cmd.Parameters.AddWithValue("ContactTitle", customers.ContactTitle);
                cmd.Parameters.AddWithValue("Address", customers.Address);
                cmd.Parameters.AddWithValue("PostalCode", customers.PostalCode);
                cmd.Parameters.AddWithValue("Phone", customers.Phone);
                cmd.Parameters.AddWithValue("Fax", customers.Fax);
                cmd.Parameters.AddWithValue("CustomerID", customers.CustomerID);

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();

                return RedirectToAction("Index");
            }
            catch(DbException e) {
                ViewBag.Ex = e.Message;
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(customers).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
