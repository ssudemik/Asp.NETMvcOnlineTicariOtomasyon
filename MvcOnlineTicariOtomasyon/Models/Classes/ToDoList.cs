using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ToDoList
    {
        [Key]
        public int ToDoId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName ="bit")]
        public bool Status { get; set; }
    }
}
