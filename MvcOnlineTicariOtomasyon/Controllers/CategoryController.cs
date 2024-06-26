﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using Newtonsoft.Json.Linq;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }
        [HttpGet] //form(view) yüklendiği zaman bu kısım çalışsın. boş bir sayfa gelsin
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost] //bir butona tıklandığı zaman bu kısım çalışsın
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k); //k nesnesi view tarafından gönderilecek parametreleri tutacak
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CateDelete(int ID)
        {
            var cate = c.Categories.Find(ID);
            c.Categories.Remove(cate);    //cate satırın tamamını tutuyor.
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CateBring(int ID)
        {
            var cate = c.Categories.Find(ID);
            return View("CateBring", cate);
        }
        public ActionResult CateUpdate(Category k)
        {
            var cate = c.Categories.Find(k.CategoryID); //cate adında bir değişken oluşturulup bu değişken yardımı ile ID hafızaya alındı
            cate.CategoryName = k.CategoryName; //bu ID ye göre işlem yapması için k.CategoryName yeni değer diğer taraf atanacak değer.
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            ClassCascading cs = new ClassCascading();
            cs.Category = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Product = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);
        }
        public JsonResult ProductList(int p)
        {
            var productlist = (from x in c.Products
                               join y in c.Categories
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductID.ToString()
                               }).ToList();
            return Json(productlist, JsonRequestBehavior.AllowGet);
        }
    }
}