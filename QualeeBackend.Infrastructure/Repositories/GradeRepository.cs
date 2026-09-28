using Microsoft.EntityFrameworkCore;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Repositories
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(QualeeContext ctx) : base(ctx) { }
        public async Task<IEnumerable<Grade>> GetByStudentAsync(
        Guid studentId, CancellationToken ct = default)
        => await _set.Where(g => g.StudentId == studentId).ToListAsync(ct);
        public async Task<IEnumerable<Grade>> GetByCourseAsync(Guid courseId, CancellationToken ct = default)
=> await _set.Where(g => g.CourseId == courseId).ToListAsync(ct);
        public async Task<double> GetAverageScoreAsync(
        Guid studentId, CancellationToken ct = default)
        => await _set.Where(g => g.StudentId == studentId)
        .AverageAsync(g => (double)g.Score, ct);
    }
}
