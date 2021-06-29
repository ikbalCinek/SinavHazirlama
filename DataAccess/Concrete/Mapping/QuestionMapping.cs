using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Answers).WithOne(a => a.Question);
            builder.HasOne(a => a.Exam).WithMany(a => a.Questions).HasForeignKey(a => a.ExamId);
            builder.Property(a => a.QuestionContent).IsRequired(true);
        }
    }
}
