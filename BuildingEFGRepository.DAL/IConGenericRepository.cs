using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL
{
    public interface IConGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        ObservableCollection<TEntity> All();
        Task<ObservableCollection<TEntity>> AllAsync();
        ObservableCollection<TEntity> GetData(Expression<Func<TEntity, bool>> filter);
        Task<ObservableCollection<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> filter);
        TEntity Find(params object[] pks);
        Task<TEntity> FindAsync(object[] pks);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}