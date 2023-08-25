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
using ProjectAPI_IMDB.Controller;

namespace ProjectAPI_IMDB.View
{
    public partial class index : System.Web.UI.Page
    {
        private readonly ImdbAPI _imdbAPI = new ImdbAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boxId.Visible = false;
            }
        }

        protected async void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchInput.Value;

            if (!string.IsNullOrWhiteSpace(query))
            {
                JObject apiResponse = await _imdbAPI.getImdbApiData(query);

                if (apiResponse != null)
                {
                    boxId.Visible = true;

                    if (apiResponse.TryGetValue("results", out var results))
                    {
                        durationId.Visible = true;
                        episodesId.Visible = true;

                        if (results is JArray resultsArray && resultsArray.Count > 0)
                        {
                            JObject firstData = (JObject)resultsArray[0];

                            string Poster = firstData["image"]?["url"]?.Value<string>() ?? "../Image/Sign_in_with_IMDb_-_IMDb.png";
                            string Title = firstData["title"]?.Value<string>() ?? "Data Unavailable";
                            string Year = firstData["year"]?.Value<string>() ?? "Data Unavailable";
                            string Duration = firstData["runningTimeInMinutes"]?.Value<string>() ?? "Data Unavailable";
                            string Episode = firstData["numberOfEpisodes"]?.Value<String>() ?? "Data Unavailable";

                            string type = firstData["titleType"]?.Value<String>();

                            if(type == "movie" || type == "video" || type == "tvMovie")
                            {
                                episodesId.Visible = false;
                            } else if(type == "tvSeries")
                            {
                                durationId.Visible = false;
                            }

                            posterLabel.Text = $"<img src='{Poster}' width='140' height='220' />";
                            titleLabel.Text = Title;
                            yearLabel.Text = Year;
                            durationLabel.Text = Duration;
                            episodesLabel.Text = Episode;
                        }
                    }
                }
            }

            else
            {
                boxId.Visible = false;
            }
        }
    }
}