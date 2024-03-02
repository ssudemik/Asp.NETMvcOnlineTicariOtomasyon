using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; } //marka
        public string Stock { get; set; }
        public decimal Price { get; set; } //alış fiyatı
        public decimal SalePrice { get; set;} //satış fiyatı
        public bool Status { get; set; } //ürünler için kritik seviye belirleme
        public string ProductVisual { get; set; }
    }
}