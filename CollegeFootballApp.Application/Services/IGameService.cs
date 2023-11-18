using CFBSharp.Model;
using CollegeFootballApp.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Services
{
    public interface IGameService
    {
        Task UpsertGameData(GameDto gameDto);

        Task UpsertGameData(Game gameCFBSharpModel);
    }
}
