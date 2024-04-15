using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Bills.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult BillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BillAdd(Bill b)
        {
            c.Bills.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillBring(int ID)
        {
            var bill = c.Bills.Find(ID); //idye gör buldurma
            return View("BillBring" , bill);
        }
        public ActionResult BillUpdate(Bill b)
        {
            var bill = c.Bills.Find(b.BillsID);
            bill.BillsSerialNo = b.BillsSerialNo;
            bill.BillsNo = b.BillsNo;
            bill.TaxOffice = b.TaxOffice;
            bill.Date = b.Date;
            bill.Time = b.Time;
            bill.Deliverer = b.Deliverer;
            bill.Receiver = b.Receiver;
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult BillDetail(int ID) //bu faturaya ait fatura kalemlerinin getirilebilmesi için
        {
            var values = c.BillCategories.Where(x => x.BillsID == ID).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewBillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBillAdd(BillCategory b)
        {
            c.BillCategories.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}