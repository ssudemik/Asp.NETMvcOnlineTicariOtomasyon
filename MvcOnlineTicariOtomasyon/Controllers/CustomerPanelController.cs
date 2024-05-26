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
            var mail = (string)Session["CustomerMail"];
            var degerler = c.Messages.Where(x => x.Recipient == mail).ToList();
            ViewBag.m = mail;
            var mailID = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            ViewBag.mid = mailID;
            var toplamsatis = c.SalesTransactions.Where(x => x.CustomerID == mailID).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SalesTransactions.Where(x => x.CustomerID == mailID).Sum(y => (decimal?)y.Sum) ?? 0;
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = c.SalesTransactions.Where(x => x.CustomerID == mailID).Sum(y => (decimal?)y.Sum) ?? 0;
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            var adsoyad = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var career = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.Career ).FirstOrDefault();
            ViewBag.career = career;
            var city = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerCity).FirstOrDefault();
            ViewBag.city = city;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Order()
        {
            var Mail = (string)Session["CustomerMail"]; //sisteme giriş yapan mail adresini sessiona atadım
            var id = c.Customers.Where(x => x.CustomerMail == Mail.ToString()).Select(y => y.CustomerID).FirstOrDefault();
            //id isminde bir değişken oluşturup bu değişkene sisteme giriş yapan kullanıcının mail adresine göre ilgili idyi attadık. 
            var value = c.SalesTransactions.Where(x => x.CustomerID == id).ToList();

            return View(value);
        }
        [Authorize]
        public ActionResult Inbox()
        {
            var Mail = (string)Session["CustomerMail"];
            var value = c.Messages.Where(x => x.Recipient == Mail).OrderByDescending(x => x.MessageID).ToList();
            var incoming = c.Messages.Count(x => x.Recipient == Mail).ToString();
            ViewBag.d1 = incoming;
            var sent = c.Messages.Count(x => x.Sender == Mail).ToString();
            ViewBag.d2 = sent;
            return View(value);
        }
        [Authorize]
        public ActionResult Sent()
        {
            var Mail = (string)Session["CustomerMail"];
            var value = c.Messages.Where(x => x.Sender == Mail).OrderByDescending(z => z.MessageID).ToList();
            var sending = c.Messages.Count(x => x.Recipient == Mail).ToString();
            ViewBag.d1 = sending;
            var sent = c.Messages.Count(x => x.Sender == Mail).ToString();
            ViewBag.d2 = sent;
            return View(value);
        }
        [Authorize]
        public ActionResult MessagesDetail(int id)
        {
            var value = c.Messages.Where(x => x.MessageID == id).ToList();
            var Mail = (string)Session["CustomerMail"];
            var incoming = c.Messages.Count(x => x.Recipient == Mail).ToString();
            ViewBag.d1 = incoming;
            var sent = c.Messages.Count(x => x.Sender == Mail).ToString();
            ViewBag.d2 = sent;
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var Mail = (string)Session["CustomerMail"];
            var incoming = c.Messages.Count(x => x.Recipient == Mail).ToString();
            ViewBag.d1 = incoming;
            var sent = c.Messages.Count(x => x.Sender == Mail).ToString();
            ViewBag.d2 = sent;
            return View();

        }
        [HttpPost]
        public ActionResult NewMessage(Messages x)
        {
            var Mail = (string)Session["CustomerMail"];
            x.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.Sender = Mail;

            c.Messages.Add(x);
            c.SaveChanges();
            return RedirectToAction("Sent");
        }
        [Authorize]
        public ActionResult CargoTracking(string p)
        {
            var k = from x in c.CargoDetails select x;
            k = k.Where(y => y.TrackingCode.Contains(p));
            return View(k.ToList());

        }
        [Authorize]
        public ActionResult CustomerCargoTracing(string id)
        {
            var value = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(value);
        }
        [Authorize]
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            var customerFind = c.Customers.Find(id);
            return PartialView("Partial1", customerFind);
        }
        public PartialViewResult Partial2()
        {
            var value = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(value);
        }
        public ActionResult CustomerUpdate(Customer cr)
        {
            var customer = c.Customers.Find(cr.CustomerID);
            customer.CustomerName = cr.CustomerName;
            customer.CustomerSurname = cr.CustomerSurname;
            customer.CustomerPassword = cr.CustomerPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}