using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerCheck.Helpers
{
    public static class ApiHelper
    {
        public static async Task<List<Service>> GetServicesAsync(string host, int port)
        {
            using HttpClient client = new HttpClient();

            string url = $"https://{host}:{port}/ServicesWindows/services";

            try
            {
                var response = await client.GetAsync(url);

                var responseStr = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode != 200)
                    throw new Exception($"[{(int)response.StatusCode}] - {responseStr}");

                var servicesList = JsonSerializer.Deserialize<List<Service>>(responseStr);

                return servicesList;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
