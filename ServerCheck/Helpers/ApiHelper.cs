using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ApiHelper
    {
        public static async Task<List<Service>> GetServicesAsync(string host, int port)
        {
            using HttpClient client = new HttpClient();

            string url = $"https://{host}:{port}/api/ServicesWindows/services";

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
        public static async Task<string> StartStopService(int action, string serviceName, string host, int port)
        {
            using HttpClient client = new HttpClient();

            string url = $"https://{host}:{port}/api/ServicesWindows/{(action == 0 ? "start" : "stop")}?serviceName={Uri.EscapeDataString(serviceName)}";

            try
            {
                var response = await client.PostAsync(url, new StringContent(""));

                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"[{(int)response.StatusCode}] - {responseStr}");
                return responseStr; 
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public static async Task<IEnumerable<Process>> GetListProcess(string host, int port)
        {
            using HttpClient client = new HttpClient();
            var url = $"https://{host}:{port}/api/Process/list";
            List<Process> listProcess = new List<Process>();

            try
            {
                var response = await client.GetAsync(url);

                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"[{(int)response.StatusCode}] - {responseStr}");

                var processes = JsonSerializer.Deserialize<List<Models.Process>>(responseStr);
                return processes;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public static async Task<string> KillProcess(string host, int port, int pid)
        {
            using HttpClient client = new HttpClient();
            var url = $"https://{host}:{port}/api/Process/list?pid={pid}";
            List<Process> listProcess = new List<Process>();

            try
            {
                var response = await client.PostAsync(url, new StringContent(""));

                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"[{(int)response.StatusCode}] - {responseStr}");

                return responseStr;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        public static async Task<string> ExecuteScriptPython(string host, int port, string script)
        {
            using HttpClient client = new HttpClient();
            var url = $"https://{host}:{port}/api/Scripts/cmd/run";

            try
            {
                var content = new StringContent(script, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"[{(int)response.StatusCode}] - {responseStr}");

                return responseStr;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
