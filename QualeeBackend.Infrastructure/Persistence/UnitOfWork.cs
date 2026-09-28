using Microsoft.EntityFrameworkCore.Storage;
using QualeeBackend.Domain.Interfaces;

namespace QualeeBackend.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QualeeContext _ctx;
        private IDbContextTransaction? _transaction;
        public UnitOfWork(QualeeContext ctx,
            IStudentRepository students,
            ICourseRepository courses,
            IGradeRepository grades,
            IAttendanceRepository attendances)
        {
            _ctx = ctx;
            Students = students;
            Courses = courses;
            Grades = grades;
            Attendances = attendances;
        }
        public IStudentRepository Students { get; }
        public ICourseRepository Courses { get; }
        public IGradeRepository Grades { get; }
        public IAttendanceRepository Attendances { get; }
        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await _ctx.SaveChangesAsync(ct);
        public async Task BeginTransactionAsync(CancellationToken ct = default)
        => _transaction = await _ctx.Database.BeginTransactionAsync(ct);
        public async Task CommitTransactionAsync(CancellationToken ct = default)
        {
            if (_transaction is not null)
                await _transaction.CommitAsync(ct);
        }
        public async Task RollbackTransactionAsync(CancellationToken ct = default)
        {
            if (_transaction is not null)
                await _transaction.RollbackAsync(ct);
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            _ctx.Dispose();
        }
    }
}
