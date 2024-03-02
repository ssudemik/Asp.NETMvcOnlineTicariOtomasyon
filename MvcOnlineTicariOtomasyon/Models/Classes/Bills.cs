using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bills
    {
        [Key]
        public int BillsID { get; set; }
        public string BillsSerialNo { get; set; } //seri no
        public string BillsNo { get; set;} //sıra no
        public DateTime Date { get; set;}
        public string TaxOffice { get; set;} //vergi dairesi
        public DateTime Time { get; set;}
        public string Deliverer { get; set;} //teslim eden
        public string Receiver { get; set;} //teslim alan

    }
}