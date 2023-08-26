using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ProjectAPI_IMDB.Controller
{
    public class ImdbAPI
    {
        private const string ApiKey = "66cec4a34cmsh42b948df1dc2129p19a0c3jsn9397716204d7";
        private const string ApiHost = "imdb8.p.rapidapi.com";

        private readonly HttpClient _client;

        public ImdbAPI()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", ApiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", ApiHost);
        }

        public async Task<JObject> getImdbApiData(string query)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={query}"),
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var apiResponse = JObject.Parse(responseBody);

                //System.Diagnostics.Debug.WriteLine(apiResponse.ToString());

                if (!string.IsNullOrEmpty(apiResponse.ToString()))
                {
                    return apiResponse;
                }

                else
                {
                    return null;
                }
            }
        }
    }
}