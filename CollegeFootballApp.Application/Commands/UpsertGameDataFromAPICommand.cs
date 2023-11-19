using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Commands
{
    public class UpsertGameDataFromAPICommand : IRequest<bool>
    {
        public int StartYear { get; }
        public int EndYear { get; }

        public UpsertGameDataFromAPICommand(int startYear, int endYear)
        {
            StartYear = startYear;
            EndYear = endYear;
        }
    }
}
