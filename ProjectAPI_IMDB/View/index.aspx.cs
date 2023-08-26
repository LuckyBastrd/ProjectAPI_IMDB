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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boxId.Visible = false;
                statusId.Visible = false;
            }
        }

        protected async void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchInput.Value;

            if (!string.IsNullOrWhiteSpace(query))
            {
                storeData dataStore = new storeData();
                List<MovieData> movieDataList = await dataStore.getMovieData(query);

                MovieData movieData = movieDataList.FirstOrDefault();

                if (movieData.status)
                {
                    statusId.Visible = false;
                    boxId.Visible = true;
                    episodesId.Visible = true;

                    string movieId = movieData.Id;
                    Application["movieId"] = movieId;

                    if (!movieData.checkTvSeries)
                    {
                        episodesId.Visible = false;
                    }

                    posterLabel.Text = $"<img src='{movieData.Poster}' width='160' height='240' />";
                    titleLabel.Text = movieData.Title;
                    yearLabel.Text = movieData.Year;
                    durationLabel.Text = movieData.Duration;
                    episodesLabel.Text = movieData.Episode;
                }

                else
                {
                    boxId.Visible = false;
                    statusId.Visible = true;
                }
            }

            else
            {
                boxId.Visible = false;
                statusId.Visible = true;
            }
        }

        protected void detailsButton_Click(object sender, EventArgs e)
        {
            string movieId = Application["movieId"].ToString();

            string imdb = $"https://www.imdb.com{movieId}";

            Response.Redirect(imdb);
        }
    }
}