using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var values = c.Customers.Where(x => x.Status == true).ToList();

            return View(values);
        }
        [HttpGet] //form(view) yüklendiği zaman bu kısım çalışsın. boş bir sayfa gelsin
        public ActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost] //bir butona tıklandığı zaman bu kısım çalışsın
        public ActionResult CustomerAdd(Customer s)
        {
            s.Status = true;
            c.Customers.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerDelete(int ID)
        {
            var cst = c.Customers.Find(ID);
            cst.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerBring(int ID)
        {
            var cst = c.Customers.Find(ID);
            return View("CustomerBring", cst);
        }
        public ActionResult CustomerUpdate(Customer s)
        {
            if (!ModelState.IsValid) //eğer modelstate in durum geçerlemesi doğru değilse customerbring i geri döndür.
            {
                return View("CustomerBring");
            }

            var cst = c.Customers.Find(s.CustomerID);
            cst.CustomerName = s.CustomerName;
            cst.CustomerSurname = s.CustomerSurname;
            cst.CustomerCity = s.CustomerCity;
            cst.CustomerMail = s.CustomerMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int ID)
        {
            var values = c.SalesTransactions.Where(x => x.CustomerID == ID).ToList();
            var cst = c.Customers.Where(x => x.CustomerID == ID).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.value = cst;
            return View(values);
        }
    }
}