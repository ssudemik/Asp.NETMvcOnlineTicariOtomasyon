using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Class01
    {
        public IEnumerable<Product> ProductValue { get; set; }
        public IEnumerable<Detay> DetayValue { get; set; }
    }
}