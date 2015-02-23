using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVPWebApiRESTfulJSON.Entity;
using MVPWebApiRESTfulJSON.Mappers;

namespace MVPWebApiRESTfulJSON.DAL
{
    public class MVPContext : DbContext
    {
        public MVPContext() :
            base("MVPConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MVPContext, MVPWebApiRESTfulJSON.Migrations.Configuration>("MVPConnection"));
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMapper());
            modelBuilder.Configurations.Add(new CategoryMapper());
            modelBuilder.Configurations.Add(new BlogMapper());
            modelBuilder.Configurations.Add(new CommentMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}