using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesTransaction //satış hareketi
    {
        [Key]
        public int SalesID { get; set; }        
        public DateTime Date  { get; set; }
        public int Piece { get; set; } //adet,tane
        public decimal Price { get; set; }
        public decimal Sum { get; set; } //toplam tutar

        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public virtual Product Product { get; set; }//ürün                                        
        public virtual Customer Customer { get; set; }//müşteri                        
        public virtual Employee Employee { get; set; }//personel
    }
}