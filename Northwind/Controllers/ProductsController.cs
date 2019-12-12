using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    [LoginRule]
    public class ProductsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Products
        public ActionResult Index(int cid=1)
        {
            var products = db.Products.Include(p => p.Categories).Include(p => p.Suppliers).Where(p=>p.CategoryID==cid);

            ViewBag.CID = cid;
            ViewBag.Categories = db.Categories.ToList();

            return View(products.ToList());
        }

        // GET: Products/Create
        public ActionResult Create(int cid)
        {
            //ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.CID = cid;
            ViewBag.CName = db.Categories.Find(cid).CategoryName;
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products,int cid)
        {
            if (ModelState.IsValid)
            {
                products.CategoryID = cid;
                products.UnitsOnOrder = 0;

                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index",new { cid=cid});
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id ,int cid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            TempData["id"] = id;
            ViewBag.CID = cid;
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int cid, short UnitsInStock,short ReorderLevel,bool Discontinued)
        {
            Products p = db.Products.Find((int)TempData["id"]);
            if (ModelState.IsValid)
            {
                p.UnitsInStock = UnitsInStock;
                p.ReorderLevel = ReorderLevel;
                p.Discontinued = Discontinued;

                db.SaveChanges();
                return RedirectToAction("Index",new { cid=cid});
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", p.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", p.SupplierID);
            return View(p);
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
