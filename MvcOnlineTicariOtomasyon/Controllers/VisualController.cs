﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class VisualController : Controller
    {
        // GET: Visual
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Products.ToList();
            return View(value);
        }
        public ActionResult View()
        {
            var value = c.Products.ToList();
            return View(value);
        }
    }
}