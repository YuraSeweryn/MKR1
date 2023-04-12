using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MKR1.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Test.Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Test.Context.DatabaseContext";
        }

        protected override void Seed(Test.Context.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
