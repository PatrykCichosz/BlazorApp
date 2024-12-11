using RestSharp;
using System.Threading.Tasks;

namespace MMAApp.Services
{
    public class FightService
    {
        private const string ApiKey = "your_api_key_here";

        public async Task<string> GetFightsByDate(string date)
        {
            var client = new RestClient($"https://v1.mma.api-sports.io/fights?date={date}");
            var request = new RestRequest();
            request.AddHeader("x-rapidapi-key", ApiKey);
            request.AddHeader("x-rapidapi-host", "v1.mma.api-sports.io");

            try
            {
                var response = await client.GetAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
