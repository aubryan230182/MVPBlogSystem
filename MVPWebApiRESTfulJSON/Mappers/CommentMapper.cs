using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MVPWebApiRESTfulJSON.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVPWebApiRESTfulJSON.Mappers
{
    class CommentMapper : EntityTypeConfiguration<Comment>
    {
        public CommentMapper()
        {
            this.ToTable("Comments");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Body).IsRequired();
            this.Property(c => c.Body).HasMaxLength(1000);

            //this.HasRequired(c => c.CommentAuthor).WithMany().Map(s => s.MapKey("AuthorID"));
        }
    }
}