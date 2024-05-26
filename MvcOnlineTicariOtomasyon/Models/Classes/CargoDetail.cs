using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string Descriptions { get; set; }

        [Display(Name = " Tracking Code")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Employee { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Customer { get; set; }
       
        public DateTime Date { get; set; }


    }
}