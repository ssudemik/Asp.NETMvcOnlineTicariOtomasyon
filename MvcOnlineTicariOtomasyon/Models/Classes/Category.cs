﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; } //property oluşturma
        public string CategoryName { get; set; }
    }
}