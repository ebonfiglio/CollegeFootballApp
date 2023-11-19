using CFBSharp.Model;

namespace CollegeFootballApp.Application.Services
{
    public interface ICollegeFootballApiService
    {
        Task<List<Game>> GetFBSGames(int startYear, int endYear);
    }
}