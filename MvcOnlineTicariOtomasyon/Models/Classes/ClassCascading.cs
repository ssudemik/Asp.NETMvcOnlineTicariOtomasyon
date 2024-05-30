using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ClassCascading
    {
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> Product { get; set; }
    }
}