namespace BuildingEFGRepository.DataBase.Repositories
{

    using BuildingEFGRepository.DAL;


    public interface IFootballClubConRepository : IConGenericRepository<FootballClub>
    {
        string GetState(FootballClub entity);
    }
}