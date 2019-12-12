using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    [LoginRule]
    public class CategoriesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public FileContentResult GetImage(int id)
        {
            Categories category = db.Categories.Find(id);
            //存圖片時由於北風資料庫設計時就偏移78位元，故在存取圖片都要偏移
            MemoryStream ms = new MemoryStream(category.Picture,78,category.Picture.Length-78);
            return File(ms.ToArray(),"image/png");
        }
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string CategoryName, string Description, HttpPostedFileBase Picture)
        {
            Categories category = new Categories();
            

            if (ModelState.IsValid)
            {
                category.CategoryName = CategoryName;
                category.Description = Description;

                //存圖片時由於北風資料庫設計時就偏移78位元，故在存取圖片都要偏移
                category.Picture =new byte[Picture.ContentLength];
                Picture.InputStream.Read(category.Picture,78,Picture.ContentLength-78);

                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

    }
}
