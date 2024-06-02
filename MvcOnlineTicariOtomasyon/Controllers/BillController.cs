using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
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
        public ActionResult Dynamic()
        {

            ClassDynamic cs = new ClassDynamic();
            cs.value1 = c.Bills.ToList();
            cs.value2 = c.BillCategories.ToList();
            return View(cs);
        }
        public ActionResult BillSave(string BillsSerialNo, string BillsNo, DateTime Date, string TaxOffice, string Time, string Deliverer, string Receiver, string Sum, BillCategory[] catergoryB)
        {
            Bill f = new Bill();
            f.BillsSerialNo = BillsSerialNo;
            f.BillsNo = BillsNo;
            f.Date = Date;
            f.TaxOffice = TaxOffice;
            f.Time = Time;
            f.Deliverer = Deliverer;
            f.Receiver = Receiver;
            f.Sum = decimal.Parse(Sum);
            c.Bills.Add(f);
            foreach (var x in catergoryB)
            {
                BillCategory fk = new BillCategory();
                fk.Explanation = x.Explanation;
                fk.UnitPrice = x.UnitPrice;
                fk.BillCategoryID = x.BillCategoryID;
                fk.Amount = x.Amount;
                fk.Sum = x.Sum;
                c.BillCategories.Add(fk);
            }
            c.SaveChanges();
            return Json("Successful");
        }
    }
}