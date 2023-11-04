using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Shared.JsonResolvers;
using Newtonsoft.Json;

namespace CollegeFootballApp.Infrastructure.Services
{
    public class JsonFileService : IReadFileService
    {
        private readonly JsonSerializerSettings _jsonSettings = new()
        {
            ContractResolver = new SpacePropertyNameResolver()
        };
        public JsonFileService()
        {
        }
        public List<GameDto> ReadFile(string filePath)
        {
            using StreamReader reader = new(filePath);
            string jsonString = reader.ReadToEnd();
            List<GameDto>? data = JsonConvert.DeserializeObject<List<GameDto>>(jsonString, _jsonSettings);
            return data;
        }
    }
}
