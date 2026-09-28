using Microsoft.EntityFrameworkCore;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(QualeeContext ctx) : base(ctx) { }
        public async Task<Course?> GetByCourseCodeAsync(string code, CancellationToken ct = default)
        => await _set.FirstOrDefaultAsync(c => c.CourseCode == code, ct);
        public async Task<IEnumerable<Course>> GetByTeacherAsync(
        Guid teacherId, CancellationToken ct = default)
        => await _set.Where(c => c.TeacherId == teacherId).ToListAsync(ct);
        public async Task<Course?> GetWithAssignmentsAsync(
        Guid id, CancellationToken ct = default)
        => await _set.Include(c => c.Assignments)
        .FirstOrDefaultAsync(c => c.Id == id, ct);
    }
}
