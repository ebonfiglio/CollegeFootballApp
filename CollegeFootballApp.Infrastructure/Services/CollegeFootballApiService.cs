using CFBSharp.Api;
using CFBSharp.Client;
using CFBSharp.Model;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Shared.Models;

namespace CollegeFootballApp.Infrastructure.Services
{
    public class CollegeFootballApiService : ICollegeFootballApiService
    {
        private readonly GamesApi _gamesApi;

        public CollegeFootballApiService(CFBDApiSettings settings)
        {
            var configuration = new Configuration
            {
                BasePath = "https://api.collegefootballdata.com",
            };
            configuration.ApiKey.Add("Authorization", settings.ApiKey);
            configuration.ApiKeyPrefix.Add("Authorization", "Bearer");

            _gamesApi = new GamesApi(configuration);
        }

        public async Task<List<Game>> GetFBSGames(int startYear, int endYear)
        {
            List<Game> fbsGames = new();

            for (int year = startYear; year <= endYear; year++)
            {
                try
                {
                    ICollection<Game> games = await _gamesApi.GetGamesAsync(year: year, seasonType: "postseason", division:"fbs");

                    fbsGames.AddRange(games);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, possibly logging them
                    Console.WriteLine($"Error fetching games for {year}: {ex.Message}");
                }
            }

            return fbsGames;
        }
    }
}
