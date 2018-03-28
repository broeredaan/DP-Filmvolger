using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DP_Filmvolger.Enums;

namespace DP_Filmvolger.Classes
{
    class ApiHandler
    {
        static HttpClient client = new HttpClient();
        private const string apiUrl = "http://www.omdbapi.com/";
        private const string apiKey = "2f69327a";

        //example call
        //http://www.omdbapi.com/?i=tt0108778&season=1&episode=1&apikey=2f69327a

        public ApiHandler()
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Movie> GetMovie(string imdbid)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject movieJson = JObject.Parse(json);
                JsonData data = new JsonData
                {
                    Title = (string)movieJson["Title"],
                    Length = (string)movieJson["Runtime"],
                    Actors = (string)movieJson["Actors"],
                    Director = (string)movieJson["Director"],
                    ReleaseDate = (string)movieJson["Released"],
                    Genre = (string)movieJson["Genre"],
                    PosterUrl = (string)movieJson["Poster"],
                    Rated = (string)movieJson["Rated"],
                    Imdbid = (string)movieJson["imdbid"],
                    Awards = (string)movieJson["Awards"],
                    Plot = (string)movieJson["Plot"],
                    Language = (string)movieJson["Language"],
                    Country = (string)movieJson["Country"],
                    // TODO Ratings,
                    Ratings = new List<Rating>(),
                    BoxOffice = (string)movieJson["BoxOffice"]
                };
                MediaFactory factory = new MediaFactory();
                return (Movie)factory.GetMedia(MediaType.Movie, data);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Movie>> SearchMovie(string search, string[] genres)
        {
            var movielist = new List<Movie>();
            string parameters = "?apikey=" + apiKey + "&t=" + search + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(json);
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<Serie> GetSerie(string imdbid)
        {
            return null;
        }

        public async Task<IEnumerable<Serie>> SearchSerie(string search, string[] genres)
        {

            return null;
        }

    }
}
