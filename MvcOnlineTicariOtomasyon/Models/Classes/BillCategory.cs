using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillCategory //fatura kalemi
    {
        [Key]
        public int BillCategoryID { get; set; }
        public string Explanation { get; set; } //açıklama
        public int Amount { get; set; } //miktat
        public decimal UnitPrice { get; set; } //birimFiyat
        public decimal Sum { get; set; } //tutar
    }
}