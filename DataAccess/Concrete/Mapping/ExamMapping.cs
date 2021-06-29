using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Questions).WithOne(a => a.Exam);
            builder.HasOne(a => a.Admin).WithMany(a => a.AdminExams).HasForeignKey(a => a.AdminId);
            builder.Property(a=>a.CreatedDate).IsRequired(false);
            builder.Property(a => a.Title).IsRequired(false);
            builder.Property(a => a.Content).IsRequired(false);
           
           
        }
    }
}
