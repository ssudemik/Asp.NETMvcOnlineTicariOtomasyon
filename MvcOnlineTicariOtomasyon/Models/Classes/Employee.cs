﻿using System;
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

        [Display(Name = " Employee Name ")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "You can not pass this field empty!")]
        public string EmployeeName { get; set; }

        [Display(Name = " Employee Surname ")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters :) ")]
        public string EmployeeSurname { get; set; }

        [Display(Name = " Employee Visual ")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeVisual { get; set; } //çalışan görsel

        [Display(Name = " Employee Mail ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "You can write up to 50 characters :) ")]
        public string EmployeeMail { get; set; }

        [Display(Name = " Employee Password ")]
        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "You can write up to 50 characters :) ")]
        public string EmployeePassword { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }  //departman ile personel arasındaki bağlantı
    }
} 