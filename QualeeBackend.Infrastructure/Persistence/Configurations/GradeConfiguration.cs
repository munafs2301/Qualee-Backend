using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Persistence.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Score).HasColumnType("decimal(5,2)");
            builder.Property(g => g.LetterGrade).HasMaxLength(2).IsRequired();
            builder.Property(g => g.Semester).HasMaxLength(20).IsRequired();
        }
    }
}
