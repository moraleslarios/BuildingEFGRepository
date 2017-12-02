using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingEFGRepository.DAL;

namespace BuildingEFGRepository.DataBase.Repositories
{
    public class FootballClubConRepository : ConGenericRepository<FootballClub>, IFootballClubConRepository
    {
        public FootballClubConRepository(DbContext dbContext) : base(dbContext) { }



        public bool IsUpdateState(int id)
        {
            bool result = _dbContext.ChangeTracker.Entries<FootballClub>().Any(a => a.Entity.Id == id && a.State == EntityState.Modified);

            return result;
        }


    }
}
