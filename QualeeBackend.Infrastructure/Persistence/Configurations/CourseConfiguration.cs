using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CourseCode).HasMaxLength(20).IsRequired();
            builder.HasIndex(c => c.CourseCode).IsUnique();
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(1000);
            builder.HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
