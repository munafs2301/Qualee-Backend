using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<Student?> GetByStudentNumberAsync(string number, CancellationToken ct = default);
        Task<IEnumerable<Student>> GetActiveStudentsAsync(CancellationToken ct = default);
        Task<Student?> GetWithGradesAsync(Guid id, CancellationToken ct = default);
    }
}
