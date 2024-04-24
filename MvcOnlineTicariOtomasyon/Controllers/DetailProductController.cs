using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: DetailProduct
        Context c = new Context();
        public ActionResult Index()
        {
            Class01 c1 = new Class01();
           // var value = c.Products.Where(x => x.ProductID==1).ToList();
            c1.ProductValue = c.Products.Where(x => x.ProductID == 2).ToList();
            c1.DetayValue = c.detays.Where(y => y.ID == 2).ToList();
            return View(c1);
        }
        public ActionResult Deneme()
        {
           
             var value = c.Products.Where(p => p.ProductID==2).ToList();
         
            return View(value);
        }
    }
}