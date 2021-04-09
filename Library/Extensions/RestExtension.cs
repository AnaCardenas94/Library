using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.Extensions
{
    public static class RestExtension
    {
        public static async Task<TResponse> Get<TResponse>(this HttpClient client, string path)
        {
            var response = await client.GetAsync(path);
            return await response.ParseResponse<TResponse>();

        }

        private static async Task<TResponse> ParseResponse<TResponse>(this HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(json));
        }
    }
}
