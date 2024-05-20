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
            var id = c.Customers.Where(x => x.CustomerMail == Mail.ToString()).Select(y => y.CustomerID).FirstOrDefault();
            //id isminde bir değişken oluşturup bu değişkene sisteme giriş yapan kullanıcının mail adresine göre ilgili idyi attadık. 
            var value = c.SalesTransactions.Where(x => x.CustomerID == id).ToList();

            return View(value);
        }
       
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
       
        public ActionResult Sent()
        {
            var Mail = (string)Session["CustomerMail"];
            var value = c.Messages.Where(x => x.Sender == Mail).OrderByDescending(z => z.MessageID).ToList();
            var sending = c.Messages.Count(x => x.Recipient  == Mail).ToString();
            ViewBag.d1 = sending;
            var sent = c.Messages.Count(x => x.Sender == Mail).ToString();
            ViewBag.d2 = sent;
            return View(value);
        }
        
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
        public ActionResult NewMessage(Messages m)
        {
            var Mail = (string)Session["CustomerMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Recipient = Mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}