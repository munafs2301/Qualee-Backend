using QualeeBackend.Domain.Entities;

namespace QualeeBackend.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course?> GetByCourseCodeAsync(string code, CancellationToken ct = default);
        Task<IEnumerable<Course>> GetByTeacherAsync(Guid teacherId, CancellationToken ct = default);
        Task<Course?> GetWithAssignmentsAsync(Guid id, CancellationToken ct = default);
    }
}
