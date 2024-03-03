using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expense //gider
    {
        [Key]
        public int ExpenseID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public Decimal Sum { get; set; }
    }
}