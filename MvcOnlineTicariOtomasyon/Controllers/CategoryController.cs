using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using Newtonsoft.Json.Linq;

namespace MvcOnlineTicariOtomasyon.Controllers
{
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
    }
}