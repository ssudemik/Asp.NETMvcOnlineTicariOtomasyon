using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index() //index üzerinden grafiği
        {
            return View();
        }
        public ActionResult Index2() //controller üzerinden grafiği
        {
            var graphicDraw = new Chart(600, 600);
            graphicDraw.AddTitle(" Categories-Product Stock").AddLegend("Stock")
                .AddSeries("Value", xValue: new[] { "Beyaz Eşya", "Telefon", "Küçük Ev Altei", "Bilgisayar", "Mobilya", "Televizyon" },
                 yValues: new[] { 500, 250, 340, 620, 220, 110 }).Write();
            return File(graphicDraw.ToWebImage().GetBytes(), "image/jpeg");

        }
        Context c = new Context();
        public ActionResult Index3() //veri tabanından veri çekme grafiği
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var results = c.Products.ToList();
            results.ToList().ForEach(x => xValue.Add(x.ProductName));
            results.ToList().ForEach(y => yValue.Add(y.Stock));
            var graphic = new Chart(width: 1800, height: 1200)
            .AddTitle("Stocks")
                .AddSeries(chartType:"Pie", name: "Stock", xValue: xValue, yValues: yValue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");

        }
        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }

        public List<graphClass> ProductList()
        {
            List<graphClass> clss = new List<graphClass>();
            using (var c = new Context())
            {
                clss = c.Products.Select(x => new graphClass
                {
                    prdct = x.ProductName,
                    stck = x.Stock
                }).ToList();
            }
            return clss;
        }
        public ActionResult Index6()
        {
            return View();
        }
       
        public ActionResult Index7()
        {
            return View();
        }
    }
}