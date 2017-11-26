using BuildingEFGRepository.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BuildingEFGRepository.DataBase.Repositories
{
    public class FootballClubRepository : DisconGenericRepository<FootballClub>, IFootballClubRepository
    {
        public FootballClubRepository(Func<DbContext> dbContextCreator) : base(dbContextCreator) { }



        public int UpdateRangeLow(IEnumerable<FootballClub> entities)
        {
            int result = 0;

            foreach (var entity in entities)
            {
                /// Is low, because create a conexion foreach entity
                /// we use this case for didactic reasons
                result += base.Update(entity);
            }

            return result;
        }

        public int UpdateRangeFast(IEnumerable<FootballClub> entities)
        {
            int result = 0;

            using(var context = base._dbContextCreator())
            {
                entities.ToList().ForEach(e => UpdateEntity(e, context));

                result = context.SaveChanges();
            }

            return result;
        }



        private void UpdateEntity(FootballClub entity, DbContext context)
        {
            var dbSet = context.Set<FootballClub>();

            dbSet.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

    }
}
