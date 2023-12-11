using CollegeFootballApp.Domain.Entities;
using CollegeFootballApp.Domain.Interfaces;
using CollegeFootballApp.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Services.Interfaces
{
    public interface IHeadToHeadRecordService
    {
        Dictionary<string, Dictionary<string, HeadToHeadRecordDto>> CalculateMultiCompetitorHeadToHeadRecordAsync<T>(
            List<Game> games, List<T> competitors) where T : IHeadToHeadCompetitor;
    }
}