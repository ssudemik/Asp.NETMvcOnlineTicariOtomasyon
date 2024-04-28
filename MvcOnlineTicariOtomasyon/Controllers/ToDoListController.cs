using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Customers.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = c.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = c.Categories.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = (from x in c.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.d4 = value4;

            var todolist = c.toDoLists.ToList();
            return View(todolist);
        }
    }
}