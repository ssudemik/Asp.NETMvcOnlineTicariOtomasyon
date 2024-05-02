using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillsID { get; set; }

        [Display(Name = " Bills Serial No ")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillsSerialNo { get; set; } //seri no

        [Display(Name = " Bills No ")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string BillsNo { get; set;} //sıra no
        public DateTime Date { get; set;}

        [Display(Name = " Tax Office ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TaxOffice { get; set;} //vergi dairesi

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set;} //teslim eden

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set;} //teslim alan

        public decimal Sum { get; set;}

        [Display(Name = " Bill Categorys ")]
        public ICollection<BillCategory> BillCategorys { get; set; } //fatura nın birden fazla fatura kalemi olabili.
                                                                     //bir fatura kaleminin sadece bir tane faturası
                                                                     //olabilir diye. ilişki kurma.

    }
}