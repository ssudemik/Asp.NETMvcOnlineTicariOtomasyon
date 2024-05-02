using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = " Product Name ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; } //marka
        public short Stock { get; set; }
        public decimal Price { get; set; } //alış fiyatı

        [Display(Name = " Sale Price ")]
        public decimal SalePrice { get; set; } //satış fiyatı
        public bool Status { get; set; } //ürünler için kritik seviye belirleme

        [Display(Name = " Product Visual ")]
        [Column(TypeName = "Varchar")]
        [StringLength(8000)]
        public string ProductVisual { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = " Sale Transaction ")]
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}