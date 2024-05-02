using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Display(Name = " Department Name ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmentName{ get; set; }
        public bool Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}