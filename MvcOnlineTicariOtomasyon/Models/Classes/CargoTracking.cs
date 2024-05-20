using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }

        [Display(Name = " Tracking Code ")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Descriptions { get; set; }

        [Display(Name = " Date Time ")]
        public DateTime DateTime { get; set; }
    }
}