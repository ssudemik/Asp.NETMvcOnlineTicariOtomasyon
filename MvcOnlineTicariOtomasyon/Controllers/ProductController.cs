using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Classes;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace MvcOnlineTicariOtomasyon.Controllers
{
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
    }
}