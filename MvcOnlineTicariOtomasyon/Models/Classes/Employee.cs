using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee //çalışan
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeVisual { get; set; } //çalışan görsel

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }  //departman ile personel arasındaki bağlantı
    }
} 