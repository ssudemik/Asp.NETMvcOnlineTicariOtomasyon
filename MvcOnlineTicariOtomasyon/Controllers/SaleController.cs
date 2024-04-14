using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        Context c = new Context();
        // GET: Sale
        public ActionResult Index()
        {
            var values = c.SalesTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesTransaction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString()); //DateTime.Parse() bir tarih dizesini DateTime türüne dönüştüren bir yöntemdir. 
                                                                       //ifadesi mevcut tarihi alır, onu kısa bir tarih dizesine dönüştürür ve sonra bu
                                                                       //dizeyi bir DateTime nesnesine çevirir.
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleBring(int ID)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3;

            var value = c.SalesTransactions.Find(ID);
            return View("SaleBring", value);
        }
        public ActionResult SaleUpdate(SalesTransaction s)
        {
            var value = c.SalesTransactions.Find(s.SalesID);
            value.CustomerID = s.CustomerID;
            value.Piece = s.Piece;
            value.Price = s.Price;
            value.EmployeeID = s.EmployeeID;
            value.Date = s.Date;
            value.Sum = s.Sum;
            value.ProductID = s.ProductID;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail (int ID)
        {
            var value = c.SalesTransactions.Where(x=> x.SalesID == ID).ToList();
            return View(value);
        }
    }

}