namespace BuildingEFGRepository.DataBase.Repositories
{

    using BuildingEFGRepository.DAL;


    public interface IFootballClubConRepository : IConGenericRepository<FootballClub>
    {
        bool IsUpdateState(int id);
    }
}