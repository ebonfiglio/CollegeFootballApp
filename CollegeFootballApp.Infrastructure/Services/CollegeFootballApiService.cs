using CFBSharp.Api;
using CFBSharp.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Infrastructure.Services
{
    internal class CollegeFootballApiService
    {
        private readonly GamesApi _gamesApi;

        public CollegeFootballApiService()
        {
            // Initialize the API client
            Configuration configuration = new() 
            {
                BasePath = "https://api.collegefootballdata.com",
            };

            configuration.AddApiKey("Authorization", "YOUR_API_KEY");

            _gamesApi = new GamesApi(configuration);
        }
    }
}
