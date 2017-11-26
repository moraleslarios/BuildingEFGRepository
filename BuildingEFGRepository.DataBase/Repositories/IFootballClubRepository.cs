using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingEFGRepository.DAL;

namespace BuildingEFGRepository.DataBase.Repositories
{
    public interface IFootballClubRepository : IDisconGenericRepository<FootballClub>
    {
        int UpdateRangeLow(IEnumerable<FootballClub> entities);
        int UpdateRangeFast(IEnumerable<FootballClub> entities);
    }
}
