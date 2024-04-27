using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
        [HttpGet] //form(view) yüklendiği zaman bu kısım çalışsın. boş bir sayfa gelsin
        public ActionResult EmployeeAdd(){ //bir öge seç, seçmiş olduğun ögenin içinde iki tane paremetre olacak.
                                          //dropdown kutucuk içinde seçim yapabilmek için
                                          //1.paremetre valuenumber = seçilen ögenin arka planda çalışacak olan yapısı (yani id)
                                          //2.paremetre displaynumber = kullanıcıya gözükecek kısım (Text)
                                          //ViewBag controller tarafından view tarafına veri taşımak için kullanılır.
        
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString(),
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }
        [HttpPost] //bir butona tıklandığı zaman bu kısım çalışsın
        public ActionResult EmployeeAdd(Employee e) 
        {
            if (!ModelState.IsValid) //eğer modelstate in durum geçerlemesi doğru değilse customerbring i geri döndür.
            {
                List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
                ViewBag.vl1 = value1;
                return View("EmployeeAdd");
            }
            c.Employees.Add(e); 
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult EmployeeBring(int id)
        {

            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString(),
                                           }).ToList();
            ViewBag.vl1 = value1;
            var emp = c.Employees.Find(id);
            return View("EmployeeBring", emp);
        }
        public ActionResult EmployeeUpdate(Employee e)
        {
            if (!ModelState.IsValid) //eğer modelstate in durum geçerlemesi doğru değilse customerbring i geri döndür.
            {
                List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
                ViewBag.vl1 = value1;
                return View("EmployeeBring");
            }

            var emp = c.Employees.Find(e.EmployeeID);
            emp.EmployeeName = e.EmployeeName;
            emp.EmployeeSurname = e.EmployeeSurname;
            emp.EmployeeVisual = e.EmployeeVisual;
            emp.DepartmentId = e.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeList()
        { 
            var query = c.Employees.ToList();
            return View(query);
        }
    }
}