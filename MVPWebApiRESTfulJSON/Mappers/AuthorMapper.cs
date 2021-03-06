﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVPWebApiRESTfulJSON.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVPWebApiRESTfulJSON.Mappers
{
    class AuthorMapper : EntityTypeConfiguration<Author>
    {
        public AuthorMapper()
        {
            this.ToTable("Author");

            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();

            this.Property(s => s.Email).IsRequired();
            this.Property(s => s.Email).HasMaxLength(255);
            this.Property(s => s.Email).IsUnicode(false);

            this.Property(s => s.UserName).IsRequired();
            this.Property(s => s.UserName).HasMaxLength(50);
            this.Property(s => s.UserName).IsUnicode(false);

            this.Property(s => s.Password).IsRequired();
            this.Property(s => s.Password).HasMaxLength(255);

            this.Property(s => s.FirstName).IsRequired();
            this.Property(s => s.FirstName).HasMaxLength(50);

            this.Property(s => s.LastName).IsRequired();
            this.Property(s => s.LastName).HasMaxLength(50);

            this.Property(s => s.LoginAttempt).IsOptional();
        }
    }
}