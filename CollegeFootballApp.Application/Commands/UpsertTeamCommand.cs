using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Commands
{
    public class UpsertTeamCommand : IRequest<bool>
    {
        public string FilePath { get; set; }

        public UpsertTeamCommand(string filePath)
        {
            FilePath = filePath;
        }
    }
}
