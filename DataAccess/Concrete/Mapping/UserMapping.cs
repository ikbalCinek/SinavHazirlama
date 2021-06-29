using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.UserExams).WithOne(a => a.User);
            builder.Property(a=>a.UserName).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);

        }
    }
}
