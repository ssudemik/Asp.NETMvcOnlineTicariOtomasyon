using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index( string p)
        {
            var k = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TrackingCode.Contains(p));
            }
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult NewCargo()
        {

            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerName + " "+ x.CustomerSurname.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeName + " "+ x.EmployeeSurname.ToString()
                                           }).ToList();

            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3;


            Random rnd = new Random();
            string[] caracter = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, caracter.Length);
            k2 = rnd.Next(0, caracter.Length);
            k3 = rnd.Next(0, caracter.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10--> 3 1 2 1 2 1
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + caracter[k1] + s2 + caracter[k2] + s3 + caracter[k3];
            ViewBag.trackingCode = code;
            return View();
        }

        [HttpPost]
        public ActionResult NewCargo(CargoDetail d)
        {
            c.CargoDetails.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            //p = "489A15B86D";
            var value = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(value);
        }
    }
}