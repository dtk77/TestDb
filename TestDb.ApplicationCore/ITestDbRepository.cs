using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestDb.ApplicationCore
{
    public interface ITestDbRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellation = default);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
