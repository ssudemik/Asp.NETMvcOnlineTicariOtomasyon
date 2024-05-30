using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using MvcOnlineTicariOtomasyon.Models.Classes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Customers.Count().ToString();
            ViewBag.v1 = value1;

            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;

            var value3 = c.Employees.Count().ToString();
            ViewBag.v3 = value3;

            var value4 = c.Categories.Count().ToString();
            ViewBag.v4 = value4;

            var value5 = c.Products.Sum(x => x.Stock).ToString(); //stok sayısını toplayıp string olarak alıyoruz 
            ViewBag.v5 = value5;                         //istatistik kısmındaki toplam stok sayısını buluyoruz

            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            //markayı e.ip tekrarsız olarak saydırma yöntemi
            ViewBag.v6 = value6;

            var value7 = c.Products.Count(x => x.Stock <= 20).ToString(); //stok sayısı 20 ve altında ise kritik seviye olarak belirlendi
            ViewBag.v7 = value7;

            var value8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            //ürünün satış fiyatını büyükten küçüğe sıralayıp en yüksek fiyatlı ürünün adını yazdırdık.
            ViewBag.v8 = value8;

            var value9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            //ürünün satış fiyatını küçükten büyüğe sıralayıp en yüksek fiyatlı ürünün adını yazdırdık.
            ViewBag.v9 = value9;

            var value10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.v10 = value10;

            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v11 = value11;

            var value12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            //markaya göre gruplandırma yapıp alfabetik şekilde sıralama yapıldı. en üstteki değeri bize getirecek.
            //key = gruplandırılan değerin karşılığı yani anahtar değerimiz marka adı
            ViewBag.v12 = value12;

            //var value13 = c.SalesTransactions.GroupBy(x => x.Product.ProductName).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            //ViewBag.v13 = value13;

            var value13 = c.SalesTransactions.GroupBy(m => m.Product.ProductName).OrderByDescending
            (m => m.Sum(x => x.Piece)).Select(m => m.Key).FirstOrDefault().ToString();
            ViewBag.v13 = value13;
            //satılan adete göre hesaplama


            var value14 = c.SalesTransactions.Sum(x => x.Sum).ToString();
            ViewBag.v14 = value14;

            DateTime today = DateTime.Today; //bugünün tarihini alan kod parçası
            var value15 = c.SalesTransactions.Count(x => x.Date == today).ToString(); //günün satışları
            ViewBag.v15 = value15;

            var value16 = c.SalesTransactions.Where(x => x.Date == today).Sum(y => (decimal?)y.Sum).ToString();
            //bugünün tarihine eşit olan değerlerin fiyatını getirir(sum) getirir ve bu değerlerin toplam tutarını(sum) string olarak döndürür.
            if(value15 == "0")
            {
                value16 = "0";
            }
            ViewBag.v16 = value16;

            return View();
        }

        public ActionResult SimpleTable() 
        {
            var query = (from x in c.Customers
                         where (x.Status == true)
                         group x by x.CustomerCity into g //şehrine göre gruplandırdık
                         select new ClassGroup
                         {
                             City = g.Key,
                             Count = g.Count()
                         }).OrderByDescending(x => x.Count).Take(5);
            int value = c.Customers.Where(x=>x.Status == true).Count();

            
            ViewBag.v1 = value;
            return View(query); 
        }

        public PartialViewResult Partial1()
        {
            var query2 = (from x in c.Employees
                          group x by x.Department.DepartmentName into g
                          select new ClassGroup2
                          {
                              Department = g.Key,
                              Count = g.Count()
                          }).OrderByDescending(x => x.Count);
            return PartialView(query2);
        }
        public PartialViewResult Partial2()
        {
            var query = c.Customers.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial3()
        {
            var query = c.Products.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial4()
        {
            var query3 = (from x in c.Products
                          where (x.Status == true)
                          group x by x.Brand into g
                          select new ClassGroup3
                          {
                              brand = g.Key,
                              Count = g.Count()
                          }).OrderByDescending(x => x.Count).Take(5);
            int value3 = c.Products.Where(x => x.Status == true).Count();
            ViewBag.v3 = value3;
            return PartialView(query3);
        }
    }
}