namespace npl_referralTool.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<npl_referralTool.DAL.ReferralContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(npl_referralTool.DAL.ReferralContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ServiceCategories.AddOrUpdate(
                s => s.ServiceCategoryName,
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Education" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Employment" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Finances" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Health" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Housing and Food" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Youth and Children" },
                new ServiceCategory { ActiveIndicator = true, ServiceCategoryName = "Additional Services" }
                );
        }
    }
}
