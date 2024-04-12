using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillCategory //fatura kalemi
    {
        [Key]
        public int BillCategoryID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Explanation { get; set; } //açıklama
        public int Amount { get; set; } //miktat
        public decimal UnitPrice { get; set; } //birimFiyat
        public decimal Sum { get; set; } //tutar
        public Bill Bills { get; set; } // bir fatura kaleminin sadece bir tane faturası olabilir diye
    }
}