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

        [Display(Name = " Customer Name ")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "You can not pass this field empty!")]
        public string CustomerName { get; set; }

        [Display(Name = " Customer Surname ")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters :) ")]
        public string CustomerSurname { get; set; }

        [Display(Name = " Customer City ")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters :) ")]
        public string CustomerCity { get; set; }

        [Display(Name = " Customer Mail ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "You can write up to 50 characters :) ")]
        public string CustomerMail { get; set; }

        [Display(Name = " Customer Password ")]
        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "You can write up to 50 characters :) ")]
        public string CustomerPassword { get; set; }

        public bool Status { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}