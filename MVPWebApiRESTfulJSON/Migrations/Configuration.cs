namespace MVPWebApiRESTfulJSON.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVPWebApiRESTfulJSON.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<MVPWebApiRESTfulJSON.DAL.MVPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MVPWebApiRESTfulJSON.DAL.MVPContext context)
        {
            context.Authors.AddOrUpdate
                (
                    a => a.Email,
                    new Author
                    {
                        Email = "barbosa_bryan@hotmail.com",
                        UserName = "bbarbosa",
                        Password = "pass1234",
                        FirstName = "Bryan",
                        LastName = "Barbosa",
                    },
                    new Author 
                    {
                        Email = "kingjames@mailcatch.com",
                        UserName = "kingjames",
                        Password = "pass1234",
                        FirstName = "Lebron",
                        LastName = "James",
                    }
                );

            context.Categories.AddOrUpdate
                (
                    c => c.Name,
                    new Category
                    {
                        Name = "PHP",
                    },
                    new Category
                    {
                        Name = ".Net"
                    }
                );

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
        }
    }
}
