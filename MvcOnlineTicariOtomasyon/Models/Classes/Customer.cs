using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Customer //cari
    {
        [Key]
        public int CustomerID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "You can not pass this field empty!")]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters :) ")]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters :) ")]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "You can write up to 50 characters :) ")]
        public string CustomerMail { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}