using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken);

        Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(string id,TEntity entity, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(string id,CancellationToken cancellationToken);
    }
}