using Microsoft.EntityFrameworkCore;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace QualeeBackend.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly QualeeContext _ctx;
        protected readonly DbSet<T> _set;
        public GenericRepository(QualeeContext ctx)
        {
            _ctx = ctx;
            _set = ctx.Set<T>();
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _set.FindAsync(new object[] { id }, ct);
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        => await _set.ToListAsync(ct);
        public async Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => await _set.Where(predicate).ToListAsync(ct);
        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            await _set.AddAsync(entity, ct);
            return entity;
        }
        public void Update(T entity) => _set.Update(entity);
        public void Remove(T entity) => _set.Remove(entity);
        public async Task<bool> ExistsAsync(
        Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => await _set.AnyAsync(predicate, ct);
        public async Task<int> CountAsync(
        Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
        => predicate is null
        ? await _set.CountAsync(ct)
        : await _set.CountAsync(predicate, ct);
    }
}
