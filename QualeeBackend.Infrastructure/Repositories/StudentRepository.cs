using Microsoft.EntityFrameworkCore;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(QualeeContext ctx) : base(ctx) { }

        public async Task<Student?> GetByEmailAsync(string email, CancellationToken ct = default)
        => await _set.FirstOrDefaultAsync(s => s.Email == email, ct);

        public async Task<Student?> GetByStudentNumberAsync(
        string number, CancellationToken ct = default)
        => await _set.FirstOrDefaultAsync(s => s.StudentNumber == number, ct);

        public async Task<IEnumerable<Student>> GetActiveStudentsAsync(
        CancellationToken ct = default)
        => await _set.Where(s => s.IsActive).ToListAsync(ct);

        public async Task<Student?> GetWithGradesAsync(Guid id, CancellationToken ct = default)
        => await _set.Include(s => s.Grades)
        .FirstOrDefaultAsync(s => s.Id == id, ct);
    }
}
