using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Domain.Interfaces
{
    public interface IAttendanceRepository : IRepository<AttendanceRecord>
    {
        Task<IEnumerable<AttendanceRecord>> GetByStudentAsync(Guid studentId, CancellationToken ct = default);
        Task<IEnumerable<AttendanceRecord>> GetByCourseAndDateAsync(
        Guid courseId, DateTime date, CancellationToken ct = default);
        Task<double> GetAttendanceRateAsync(Guid studentId, Guid courseId, CancellationToken ct = default);
    }
}
