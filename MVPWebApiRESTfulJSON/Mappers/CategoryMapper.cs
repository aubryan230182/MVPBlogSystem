using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVPWebApiRESTfulJSON.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVPWebApiRESTfulJSON.Mappers
{
    class CategoryMapper : EntityTypeConfiguration<Category>
    {
        public CategoryMapper()
        {
            this.ToTable("Categories");

            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();

            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Name).HasMaxLength(255);
        }
    }
}