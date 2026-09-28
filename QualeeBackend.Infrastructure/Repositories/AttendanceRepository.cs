using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace QualeeBackend.Infrastructure.Repositories
{
    public class AttendanceRepository
: GenericRepository<AttendanceRecord>, IAttendanceRepository
    {
        public AttendanceRepository(QualeeContext ctx) : base(ctx) { }
        public async Task<IEnumerable<AttendanceRecord>> GetByStudentAsync(
        Guid studentId, CancellationToken ct = default)
        => await _set.Where(a => a.StudentId == studentId).ToListAsync(ct);
        public async Task<IEnumerable<AttendanceRecord>> GetByCourseAndDateAsync(
        Guid courseId, DateTime date, CancellationToken ct = default)
        => await _set.Where(a => a.CourseId == courseId
        && a.Date.Date == date.Date)
        .ToListAsync(ct);
        public async Task<double> GetAttendanceRateAsync(
        Guid studentId, Guid courseId, CancellationToken ct = default)
        {
            var total = await _set.CountAsync(
            a => a.StudentId == studentId && a.CourseId == courseId, ct);
            if (total == 0) return 0;
            var present = await _set.CountAsync(
            a => a.StudentId == studentId
            && a.CourseId == courseId
            && a.Status == AttendanceStatus.Present, ct);
            return (double)present / total * 100;
        }
    }
}
