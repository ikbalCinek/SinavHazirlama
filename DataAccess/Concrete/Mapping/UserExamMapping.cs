using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class UserExamMapping : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.HasKey(a => new { a.UserId, a.ExamId });
            builder.HasOne(a => a.User).WithMany(a => a.UserExams).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Exam).WithMany(a => a.UserExams).HasForeignKey(a => a.ExamId);
        }
    }
}
