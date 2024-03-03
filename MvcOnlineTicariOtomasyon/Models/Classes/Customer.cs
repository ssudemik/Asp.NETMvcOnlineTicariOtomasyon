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
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}