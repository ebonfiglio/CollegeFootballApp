using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Commands
{
    public class UploadGameDataFromCsvCommand : IRequest<bool>
    {
        public string FilePath { get; set; }

        public UploadGameDataFromCsvCommand(string filePath)
        {
            FilePath = filePath;
        }
    }
}
