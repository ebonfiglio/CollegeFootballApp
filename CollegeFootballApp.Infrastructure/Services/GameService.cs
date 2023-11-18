using CFBSharp.Model;
using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Infrastructure.Services
{
    public class GameService : IGameService
    {
        public Task UpsertGameData(GameDto gameDto)
        {
            throw new NotImplementedException();
        }

        public Task UpsertGameData(Game gameCFBSharpModel)
        {
            throw new NotImplementedException();
        }
    }
}
