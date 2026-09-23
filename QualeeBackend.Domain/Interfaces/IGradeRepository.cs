using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Domain.Interfaces
{
    public interface IGradeRepository : IRepository<Grade>
    {
        Task<IEnumerable<Grade>> GetByStudentAsync(Guid studentId, CancellationToken ct = default);
        Task<IEnumerable<Grade>> GetByCourseAsync(Guid courseId, CancellationToken ct = default);
        Task<double> GetAverageScoreAsync(Guid studentId, CancellationToken ct = default);
    }
}
