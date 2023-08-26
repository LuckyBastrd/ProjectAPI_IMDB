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

namespace ProjectAPI_IMDB.Controller
{
    public class storeData
    {
        private readonly ImdbAPI _imdbAPI = new ImdbAPI();
        public async Task<List<MovieData>> getMovieData(string query)
        {
            List<MovieData> movieDataList = new List<MovieData>();

            JObject apiResponse = await _imdbAPI.getImdbApiData(query);

            if (apiResponse != null)
            {
                if (apiResponse.TryGetValue("results", out var results))
                {
                    if (results is JArray resultsArray && resultsArray.Count > 0)
                    {
                        JObject firstData = (JObject)resultsArray[0];

                        string type = firstData["titleType"]?.Value<String>();

                        MovieData movieData = new MovieData
                        {
                            status = checkAllType(type),
                            checkTvSeries = checkTvSeries(type),
                            Id = firstData["id"]?.Value<string>(),
                            Poster = firstData["image"]?["url"]?.Value<string>() ?? "../Image/Sign_in_with_IMDb_-_IMDb.png",
                            Title = firstData["title"]?.Value<string>() ?? "Data Unavailable",
                            Year = firstData["year"]?.Value<string>() ?? "Data Unavailable",
                            Duration = firstData["runningTimeInMinutes"]?.Value<string>() ?? "Data Unavailable",
                            Episode = firstData["numberOfEpisodes"]?.Value<string>() ?? "Data Unavailable"
                        };
                        movieDataList.Add(movieData);
                    }
                }
            }
            return movieDataList;
        }

        private bool checkAllType(string type)
        {
            return type == "movie" || type == "video" || type == "tvMovie" || type == "tvSeries";
        }

        private bool checkTvSeries(string type)
        {
            return type == "tvSeries";
        }
    }

    public class MovieData
    {
        public bool status { get; set; }
        public bool checkTvSeries { get; set; }
        public string Id { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Duration { get; set; }
        public string Episode { get; set; }
    }
}