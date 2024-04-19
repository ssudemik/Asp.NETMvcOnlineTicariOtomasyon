using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Class1
    {
        public IEnumerable<Product> Value1 { get; set; } //üründen gelen ve detaydan gelen değerleri bir koleksiyon olarak tutarlar
        public IEnumerable<Detail> Value2 { get; set; }
    }
}