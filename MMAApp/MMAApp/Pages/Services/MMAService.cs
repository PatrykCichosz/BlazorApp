using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MMAApp.Services
{
    public class MMAService
    {
        private const string ApiKey = "f7fc9dad1a2719b1f8c234ec0ad61713";
        private const string BaseUrl = "https://v1.mma.api-sports.io";

        public async Task<List<Fight>> GetFightResultsByDate(string date)
        {
            var client = new RestClient($"{BaseUrl}/fights?date={date}");
            var request = new RestRequest()
                .AddHeader("x-rapidapi-key", ApiKey)
                .AddHeader("x-rapidapi-host", "v1.mma.api-sports.io");

            try
            {
                var response = await client.GetAsync<ApiResponse>(request);
                return response?.Response ?? new List<Fight>();
            }
            catch (Exception ex)
            {
                return new List<Fight>();
            }
        }

        public async Task<string> SearchFighters(string fighterName)
        {
            var client = new RestClient($"{BaseUrl}/fighters");
            var request = new RestRequest()
                .AddHeader("x-rapidapi-key", ApiKey)
                .AddHeader("x-rapidapi-host", "v1.mma.api-sports.io")
                .AddParameter("name", fighterName);

            try
            {
                var response = await client.GetAsync(request);
                return response?.Content ?? "No response received.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> GetFighterRecords(int fighterId)
        {
            var client = new RestClient($"{BaseUrl}/fighters/records");
            var request = new RestRequest()
                .AddHeader("x-rapidapi-key", ApiKey)
                .AddHeader("x-rapidapi-host", "v1.mma.api-sports.io")
                .AddParameter("id", fighterId);

            try
            {
                var response = await client.GetAsync(request);
                return response?.Content ?? "No response received.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

    public class ApiResponse
    {
        public List<Fight> Response { get; set; }
    }

    public class Fight
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Slug { get; set; }
        public string Category { get; set; }
        public Status Status { get; set; }
        public Fighters Fighters { get; set; }
        public string WinnerName { get; set; }
        public Fighter FirstFighter { get; set; }
        public Fighter SecondFighter { get; set; }
    }

    public class Status
    {
        public string Long { get; set; }
        public string Short { get; set; }
    }

    public class Fighters
    {
        public Fighter First { get; set; }
        public Fighter Second { get; set; }
    }

    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool Winner { get; set; }
    }
}