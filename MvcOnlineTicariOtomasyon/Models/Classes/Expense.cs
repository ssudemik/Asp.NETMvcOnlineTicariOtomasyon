using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expense //gider
    {
        [Key]
        public int ExpenseID { get; set; }
        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public Decimal Sum { get; set; }
    }
}