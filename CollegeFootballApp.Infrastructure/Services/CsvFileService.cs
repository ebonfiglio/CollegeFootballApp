using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CsvHelper;
using Newtonsoft.Json;
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
            var jsonString = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<GameDto>>(jsonString);
            return data;
        }
    }
}
