using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL
{
    public class DisconGenericRepository<TEntity> : IDisconGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Func<DbContext> _dbContextCreator;

        public DisconGenericRepository(Func<DbContext> dbContextCreator)
        {
            if (dbContextCreator == null) throw new ArgumentNullException(nameof(dbContextCreator), $"The parameter dbContextCreator can not be null");

            _dbContextCreator = dbContextCreator;
        }


        public IEnumerable<TEntity> All()
        {
            var result = Enumerable.Empty<TEntity>();

            using(var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                result = dbSet.AsNoTracking().ToList();
            }

            return result;
        }

        public Task<IEnumerable<TEntity>> AllAsync()
        {
            return Task.Run(() =>
            {
                return All();
            });
        }

        public TEntity Find(params object[] pks)
        {
            if (pks == null) throw new ArgumentNullException(nameof(pks), $"The parameter pks can not be null");

            TEntity result = null;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                result = dbSet.Find(pks);
            }

            return result;
        }

        public Task<TEntity> FindAsync(params object[] pks)
        {
            return Task.Run(() =>
            {
                return Find(pks);
            });
        }

        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), $"The parameter filter can not be null");

            var result = Enumerable.Empty<TEntity>();

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                result = dbSet.AsNoTracking().Where(filter).ToList();
            }

            return result;
        }

        public Task<IEnumerable<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.Run(() =>
            {
                return GetData(filter);
            });
        }



        public int Add(TEntity newEntity)
        {
            if (newEntity == null) throw new ArgumentNullException(nameof(newEntity), $"The parameter newEntity can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                dbSet.Add(newEntity);

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> AddAsync(TEntity newEntity)
        {
            return Task.Run(() =>
            {
                return Add(newEntity);
            });
        }

        public int Add(IEnumerable<TEntity> newEntities)
        {
            if (newEntities == null) throw new ArgumentNullException(nameof(newEntities), $"The parameter newEntities can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                dbSet.AddRange(newEntities);

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> AddAsync(IEnumerable<TEntity> newEntities)
        {
            return Task.Run(() =>
            {
                return Add(newEntities);
            });
        }

        public int Remove(TEntity removeEntity)
        {
            if (removeEntity == null) throw new ArgumentNullException(nameof(removeEntity), $"The parameter removeEntity can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                dbSet.Attach(removeEntity);

                context.Entry(removeEntity).State = EntityState.Deleted;

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> RemoveAsync(TEntity removeEntity)
        {
            return Task.Run(() =>
            {
                return Remove(removeEntity);
            });
        }

        public int Remove(IEnumerable<TEntity> removeEntities)
        {
            if (removeEntities == null) throw new ArgumentNullException(nameof(removeEntities), $"The parameter removeEntities can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                foreach (var removeEntity in removeEntities)
                {
                    dbSet.Attach(removeEntity);

                    context.Entry(removeEntity).State = EntityState.Deleted;
                }

                dbSet.RemoveRange(removeEntities);

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> RemoveAsync(IEnumerable<TEntity> removeEntities)
        {
            return Task.Run(() =>
            {
                return Remove(removeEntities);
            });
        }

        public int Remove(params object[] pks)
        {
            if (pks == null) throw new ArgumentNullException(nameof(pks), $"The parameter removeEntity can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                var entity = Find(pks);

                dbSet.Attach(entity);

                context.Entry(entity).State = EntityState.Deleted;

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> RemoveAsync(params object[] pks)
        {
            return Task.Run(() =>
            {
                return Remove(pks);
            });
        }

        public int Update(TEntity updateEntity)
        {
            if (updateEntity == null) throw new ArgumentNullException(nameof(updateEntity), $"The parameter updateEntity can not be null");

            var result = 0;

            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();

                dbSet.Attach(updateEntity);

                context.Entry(updateEntity).State = EntityState.Modified;

                result = context.SaveChanges();
            }

            return result;
        }

        public Task<int> UpdateAsync(TEntity updateEntity)
        {
            return Task.Run(() =>
            {
                return Update(updateEntity);
            });
        }
    }
}