﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var product = c.Products.Where(x => x.Status == true).ToList(); //linq where sorgusu
            return View(product);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            //bir öge seç, seçmiş olduğun ögenin içinde iki tane paremetre olacak.
            //dropdown kutucuk içinde seçim yapabilmek için
            //1.paremetre valuenumber = seçilen ögenin arka planda çalışacak olan yapısı (yani id)
            //2.paremetre displaynumber = kullanıcıya gözükecek kısım (Text)
            //ViewBag controller tarafından view tarafına veri taşımak için kullanılır.
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p) //ürün sınıfından nesne türetildi
        {
            p.Status = true;
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index"); //aksiyona gitmek için kullanılıyor
        }
        public ActionResult ProductDelete(int id)  //ürünü databaseden silmedik durumunu false yaptk.
                                                   //linq where sorgusu ile de durumu true olanları view da
                                                   //göstermiş olduk böylece db de ürün kalmış görselde kalmamış oldu.
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.vl1 = value1;

            var value = c.Products.Find(id);
            return View("ProductList", value);
        }
        public ActionResult ProductUpdate( Product x)
        {
            var prd = c.Products.Find(x.ProductID);
            prd.Status = x.Status;
            prd.Brand = x.Brand;
            prd.Price = x.Price;
            prd.SalePrice = x.SalePrice;
            prd.CategoryId = x.CategoryId;
            prd.Stock = x.Stock;
            prd.ProductName = x.ProductName;
            prd.ProductVisual = x.ProductVisual;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductPrint() 
        { 
            var value = c.Products.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult ProductSale(int id)
        {
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.v3 = value3;
            var value1 = c.Products.Find(id);
            ViewBag.v1 = value1.ProductID;
            ViewBag.v2 = value1.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult ProductSale( SalesTransaction p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesTransactions.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Sale");
        }
    }
}