using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context c = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var Mail = (string)Session["CustomerMail"];
            var value = c.Customers.FirstOrDefault(x => x.CustomerMail == Mail);
            ViewBag.m = Mail;
            return View(value);
        }
        public ActionResult Order()
        {
            var Mail = (string)Session["CustomerMail"]; //sisteme giriş yapan mail adresini sessiona atadım
            var id = c.Customers.Where(x => x.CustomerMail == Mail.ToString()).Select(y=>y.CustomerID).FirstOrDefault();
            //id isminde bir değişken oluşturup bu değişkene sisteme giriş yapan kullanıcının mail adresine göre ilgili idyi attadık. 
            var value = c.SalesTransactions.Where(x => x.CustomerID==id).ToList();

            return View(value);
        }
    }
}