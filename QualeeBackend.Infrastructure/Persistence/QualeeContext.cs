using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Persistence
{
    public class QualeeContext : DbContext
    {
        private readonly IMediator _mediator;
        public QualeeContext(
        DbContextOptions<QualeeContext> options, IMediator mediator)
        : base(options) => _mediator = mediator;
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(typeof(QualeeContext).Assembly);
            base.OnModelCreating(mb);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            var result = await base.SaveChangesAsync(ct);
            await DispatchDomainEventsAsync(ct);
            return result;
        }
        private async Task DispatchDomainEventsAsync(CancellationToken ct)
        {
            var entities = ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();
            var events = entities.SelectMany(e => e.DomainEvents).ToList();
            entities.ForEach(e => e.ClearDomainEvents());
            foreach (var evt in events)
                await _mediator.Publish(evt, ct);
        }
    }
}
