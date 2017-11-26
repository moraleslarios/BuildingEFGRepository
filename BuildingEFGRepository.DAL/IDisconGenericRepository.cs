using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL
{
    public interface IDisconGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();
        Task<IEnumerable<TEntity>> AllAsync();
        TEntity Find(params object[] pks);
        Task<TEntity> FindAsync(params object[] pks);
        IEnumerable<TEntity> GetData(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetDataAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter);
        int Add(TEntity newEntity);
        Task<int> AddAsync(TEntity newEntity);
        int Add(IEnumerable<TEntity> newEntities);
        Task<int> AddAsync(IEnumerable<TEntity> newEntities);
        int Remove(TEntity removeEntity);
        Task<int> RemoveAsync(TEntity removeEntity);
        int Remove(IEnumerable<TEntity> removeEntities);
        Task<int> RemoveAsync(IEnumerable<TEntity> removeEntities);
        int Remove(params object[] pks);
        Task<int> RemoveAsync(params object[] pks);
        int Update(TEntity updateEntity);
        Task<int> UpdateAsync(TEntity updateEntity);
    }
}