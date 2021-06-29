using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Question).WithMany(a => a.Answers).HasForeignKey(a => a.QuestionId);
            builder.Property(a=>a.AnswerText).HasMaxLength(200).IsRequired(true);

        }
    }
}
