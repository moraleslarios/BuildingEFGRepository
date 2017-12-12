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



        public string GetState(FootballClub entity)
        {
            var stateEntity = _dbContext.Entry(entity).State;

            return stateEntity.ToString();
        }


    }
}
