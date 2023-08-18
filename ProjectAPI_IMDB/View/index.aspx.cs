using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ProjectAPI_IMDB.View
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boxId.Visible = false;
            }
        }

        protected async void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchInput.Value;

            if (string.IsNullOrEmpty(searchText))
            {
                boxId.Visible = false;
            }
            else
            {
                boxId.Visible = true;
            }

            string searchQuery = SearchInput.Value.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={Uri.EscapeDataString(searchQuery)}"),
                    Headers =
            {
                { "X-RapidAPI-Key", "e815cfa37cmsh852ceb36a2f56ebp154fd0jsn69eb902f8d6f" },
                { "X-RapidAPI-Host", "imdb8.p.rapidapi.com" },
            },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    JObject apiResponse = JObject.Parse(responseBody);

                    if (apiResponse.TryGetValue("results", out var results))
                    {
                        if (results is JArray resultsArray && resultsArray.Count > 0)
                        {
                            JObject firstResult = (JObject)resultsArray[0];

                            string title = firstResult["title"]?.Value<string>() ?? "Title unavailable";
                            string year = firstResult["year"]?.Value<string>() ?? "-";
                            string image = firstResult["image"]?["url"]?.Value<string>() ?? "Sign in with IMDb - IMDb.png";
                            string runtime = firstResult["runningTimeInMinutes"]?.Value<string>() ?? "-";

                            titleLabel.Text = title;
                            yearLabel.Text = year;
                            durationLabel.Text = $"{runtime} minutes";
                            posterLabel.Text = $"<img src='{image}' width='140' height='220' />";
                        }
                    }
                }
            }
        }
    }
}