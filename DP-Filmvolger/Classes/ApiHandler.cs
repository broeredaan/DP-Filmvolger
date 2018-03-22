using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Movie> getMovie(string imdbid)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Movie movie = new Movie(json);
                return movie;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Movie>> searchMovie(string search, string[] genres)
        {
            var movielist = new List<Movie>();
            string parameters = "?apikey=" + apiKey + "&t=" + search + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<Serie> getSerie(string imdbid)
        {
            return null;
        }

        public async Task<IEnumerable<Serie>> searchSerie(string search, string[] genres)
        {

            return null;
        }

    }
}
