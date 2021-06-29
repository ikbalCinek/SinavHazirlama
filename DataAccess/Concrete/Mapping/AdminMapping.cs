using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class AdminMapping : IEntityTypeConfiguration<Admin>  // todo: why?
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.HasMany(a => a.AdminExams).WithOne(a => a.Admin);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.HasData
              (
                  new Admin
                  {
                      Id = 1,
                      Password = "123",
                       UserName="admin"

                  }
              ); ;


        }
    }
}
