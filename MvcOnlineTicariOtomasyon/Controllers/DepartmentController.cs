using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using Newtonsoft.Json.Linq;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context(); //c adında nesne üretiyoruz.
        public ActionResult Index()
        {
            var values = c.Departments.Where(x => x.Status == true).ToList(); //departmanın içerisindeki tüm değerleri listelemek için
            return View(values);
        }
        [HttpGet] //form(view) yüklendiği zaman bu kısım çalışsın. boş bir sayfa gelsin
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost] //bir butona tıklandığı zaman bu kısım çalışsın
        public ActionResult DepartmentAdd(Department d)
        {
            c.Departments.Add(d); //d nesnesi view tarafından gönderilecek parametreleri tutacak
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int ID)
        {
            var dpt = c.Departments.Find(ID);
            dpt.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentBring(int ID)
        {
            var dpt = c.Departments.Find(ID);
            return View("DepartmentBring", dpt);
        }
        public ActionResult DepartmentUpdate(Department d)
        {
            var dpt = c.Departments.Find(d.DepartmentID); //dpt adında bir değişken oluşturulup bu değişken yardımı ile ID hafızaya alındı
            dpt.DepartmentName = d.DepartmentName; //bu ID ye göre işlem yapması için d.DepartmentName yeni değer diğer taraf atanacak değer.
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int ID)
        {
            var values = c.Employees.Where(x => x.DepartmentId == ID).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == ID).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.value = dpt;
            return View(values);
        }
        public ActionResult DepartmentEmployeeSales(int ID)
        {
            var values = c.SalesTransactions.Where(x => x.EmployeeID == ID).ToList();
            var emp = c.Employees.Where(x => x.EmployeeID == ID).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.value = emp;
            return View(values);
        }
    }
}