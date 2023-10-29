using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Infrastructure.Services
{
    public class CsvFileService : ICsvFileService
    {
        public List<GameDto> ReadCsvFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<GameDto>().ToList();
        }
    }
}
