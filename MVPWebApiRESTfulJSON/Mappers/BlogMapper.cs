using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MVPWebApiRESTfulJSON.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVPWebApiRESTfulJSON.Mappers
{
    class BlogMapper : EntityTypeConfiguration<Blog>
    {
        public BlogMapper()
        {
            this.ToTable("Blogs");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Title).IsRequired();
            this.Property(c => c.Title).HasMaxLength(255);

            this.Property(c => c.SubTitle).IsRequired();
            this.Property(c => c.SubTitle).HasMaxLength(255);

            this.Property(c => c.Tags).IsOptional();
            this.Property(c => c.Tags).HasMaxLength(255);

            this.Property(c => c.Content).IsRequired();
            this.Property(c => c.Content).HasMaxLength(1000);

            this.HasRequired(c => c.BlogAuthor).WithMany().Map(s => s.MapKey("AuthorID"));
            this.HasRequired(c => c.BlogCategory).WithMany().Map(s => s.MapKey("CategoryID"));
            //this.HasOptional(c => c.BlogComment).WithMany().Map(s => s.MapKey("CommentID"));
        }
    }
}