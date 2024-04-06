using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; } //marka
        public short Stock { get; set; }
        public decimal Price { get; set; } //alış fiyatı
        public decimal SalePrice { get; set; } //satış fiyatı
        public bool Status { get; set; } //ürünler için kritik seviye belirleme

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductVisual { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}