using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Customer //cari
    {
        [Key]
        public int CustomerID { get; set; } 
        public int CustomerName { get; set; }
        public int CustomerSurname { get; set; }
        public int CustomerCity { get; set; }
        public int CustomerMail { get; set; }
    }
}