using CFBSharp.Api;
using CFBSharp.Client;
using CFBSharp.Model;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ApiKey = new Dictionary<string, string>
                {
                    ["Your_Api_Key_Header"] = settings.ApiKey
                }
            };

            _gamesApi = new GamesApi(configuration);
        }

        public async Task<List<Game>> GetFBSGames(int startYear, int endYear)
        {
            List<Game> fbsGames = new();

            for (int year = startYear; year <= endYear; year++)
            {
                try
                {
                    ICollection<Game> games = await _gamesApi.GetGamesAsync(year: year, seasonType: "regular");

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

        private IEnumerable<Game> FilterFBSGames(List<Game> games)
        {
            // Implement logic to filter only FBS games.
            // This might involve checking certain properties of the Game model.
            return games; // Placeholder
        }
    }
}
