using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UtttApi.ObjectModel.Abstracts;

namespace UtttApi.DataService.Interfaces
{
    public interface IDataService<TEntity> where TEntity : AEntity
    {
        void CheckParseId(string id);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity document);
        Task<TEntity> FindAsync(string id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity document);
    }
}