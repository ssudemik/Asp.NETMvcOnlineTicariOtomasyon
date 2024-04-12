
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context : DbContext //database set gibi komutları kullanabilmek için miras alma işlemi
    {
        public DbSet<Admin> Admins { get; set; } //tablo bazlı çalışılıcağından ve bu tablolar veri tabanına
        public DbSet<Customer> Customers { get; set; } // yansıtılacaığı için dbset sınıfından yararlanıldı. (<sınıf adı> sql adı)
        public DbSet<BillCategory> BillCategories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }

    }
}