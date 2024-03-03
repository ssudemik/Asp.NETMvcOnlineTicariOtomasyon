﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcOnlineTicariOtomasyon.Models.Classes.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //true olunca database e izin veriliyor
        }

        protected override void Seed(MvcOnlineTicariOtomasyon.Models.Classes.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
