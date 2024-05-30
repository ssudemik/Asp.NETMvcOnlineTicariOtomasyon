using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ClassDynamic
    {
        public IEnumerable<Bill> value1 { get; set; }
        public IEnumerable<BillCategory> value2 { get; set; }
    }
}