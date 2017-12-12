using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL
{
    public class ConGenericRepository<TEntity> : IConGenericRepository<TEntity> where TEntity : class
    {
        public readonly DbContext _dbContext;

        protected internal readonly DbSet<TEntity> _dbSet;


        public ConGenericRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext), $"The parameter dbContext can not be null");

            _dbContext = dbContext;

            _dbContext.Configuration.ProxyCreationEnabled = false;

            _dbSet     = _dbContext.Set<TEntity>();
        }

        public ObservableCollection<TEntity> All()
        {
            _dbSet.Load();

            var result = _dbSet.Local;

            return result;
        }

        public Task<ObservableCollection<TEntity>> AllAsync()
        {
            return Task.Run(() =>
            {
                return All();
            });
        }


        public TEntity Find(params object[] pks)
        {
            if (pks == null) throw new ArgumentNullException(nameof(pks), $"The parameter pks can not be null");

            var result = _dbSet.Find(pks);

            return result;
        }


        public Task<TEntity> FindAsync(object[] pks)
        {
            return Task.Run(() =>
            {
                return Find(pks);
            });
        }

        public ObservableCollection<TEntity> GetData(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), $"The parameter filter can not be null");

            _dbSet.Where(filter).Load();

            var filterFunc = filter.Compile();

            var result =  new ObservableCollection<TEntity>(_dbSet.Local.Where(filterFunc));

            RelinkObservableCollection(result);

            return result;
        }

        public Task<ObservableCollection<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.Run(() =>
            {
                return GetData(filter);
            });
        }

        private void RelinkObservableCollection(ObservableCollection<TEntity> result)
        {
            result.CollectionChanged += (sender, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        _dbSet.Add((TEntity)e.NewItems[0]);
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        _dbSet.Remove((TEntity)e.OldItems[0]);
                        break;
                    default:
                        break;
                }
            };
        }


        public int SaveChanges()
        {
            var result = _dbContext.SaveChanges();

            return result;
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            var result = _dbContext.ChangeTracker.Entries<TEntity>()
                            .Any(a => a.State == EntityState.Added
                                   || a.State == EntityState.Deleted
                                   || a.State == EntityState.Modified);

            return result;
        }

        public Task<bool> HasChangesAsync()
        {
            return Task.Run(() =>
            {
                return HasChanges();
            });
        }

        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }
    }
}