using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Shared.JsonResolvers;
using Newtonsoft.Json;

namespace CollegeFootballApp.Infrastructure.Services
{
    public class JsonFileService : IReadFileService
    {
        public JsonFileService()
        {
        }
        public List<T> ReadFile<T>(string filePath)
        {
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                string jsonString = reader.ReadToEnd();
                List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonString);
                return data;
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON-specific exceptions
                Console.WriteLine("JSON Exception: " + jsonEx.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine("General Exception: " + ex.Message);
            }
            return new List<T>();
        }


    }
}
