using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Services
{
    public interface ICollegeFootballApiService
    {
        Task GetFBSGames(int startYear, int endYear);
    }
}
