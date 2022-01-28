using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestDb.ApplicationCore;

namespace TestDb.Infrastructure
{

    public class EFTestDbRepository<T> : ITestDbRepository<T> where T : BaseEntity
    {
        private readonly TestDbContext dbContext;
        public EFTestDbRepository(TestDbContext context) =>
            dbContext = context;

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await dbContext.Set<T>().FindAsync(keyValues, cancellationToken);
        }
    }
}
