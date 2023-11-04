using CollegeFootballApp.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Services
{
    public interface IReadFileService
    {
        List<GameDto> ReadFile(string filePath);
    }
}
