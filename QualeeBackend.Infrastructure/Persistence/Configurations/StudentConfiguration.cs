using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(s => s.LastName).HasMaxLength(100).IsRequired();
            builder.Property(s => s.Email).HasMaxLength(200).IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();
            builder.Property(s => s.StudentNumber).HasMaxLength(20).IsRequired();
            builder.HasIndex(s => s.StudentNumber).IsUnique();
            builder.Ignore(s => s.FullName);
            builder.HasMany(s => s.Grades)
            .WithOne(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Attendances)
            .WithOne(a => a.Student)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
