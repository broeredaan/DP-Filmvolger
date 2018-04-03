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

        public async Task<MovieDecorator> GetMovie(string imdbid)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject movieJson = JObject.Parse(json);
                var rats = movieJson["Ratings"];
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
                    Ratings = movieJson["Ratings"].Select(r => new Rating
                    {
                        Source = (string)r["Source"],
                        Value = (string)r["Value"]
                    }),
                    BoxOffice = (string)movieJson["BoxOffice"]
                };
                MediaFactory factory = new MediaFactory();
                return (MovieDecorator)factory.GetMedia(MediaType.Movie, data);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<MovieDecorator>> SearchMovie(string search)
        {
            var movielist = new List<Movie>();
            string parameters = "?apikey=" + apiKey + "&s=" + search + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject movieJson = JObject.Parse(json);
                var movies = new List<JsonData>();

                if (movieJson["Response"].ToString() != "false")
                {
                    movies = movieJson["Search"].Select(r => new JsonData
                    {
                        Title = r["Title"].ToString(),
                        ReleaseDate = r["Year"].ToString(),
                        Imdbid = r["imdbID"].ToString(),
                        PosterUrl = r["Poster"].ToString()
                    }).ToList();

                    var rats = movieJson["Ratings"];
                    MediaFactory factory = new MediaFactory();
                    return movies.Select(m =>
                    {
                        return (MovieDecorator)factory.GetMedia(MediaType.Movie, m);

                    });
                }
                else
                {
                    return new List<MovieDecorator>();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<SerieDecorator> GetSerie(string imdbid)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject serieJson = JObject.Parse(json);

                var rats = serieJson["Ratings"];
                JsonData data = new JsonData
                {
                    Title = (string)serieJson["Title"],
                    Length = (string)serieJson["Runtime"],
                    Actors = (string)serieJson["Actors"],
                    Director = (string)serieJson["Director"],
                    ReleaseDate = (string)serieJson["Released"],
                    Genre = (string)serieJson["Genre"],
                    PosterUrl = (string)serieJson["Poster"],
                    Rated = (string)serieJson["Rated"],
                    Imdbid = (string)serieJson["imdbid"],
                    Awards = (string)serieJson["Awards"],
                    Plot = (string)serieJson["Plot"],
                    Language = (string)serieJson["Language"],
                    Country = (string)serieJson["Country"],
                    Ratings = serieJson["Ratings"].Select(r => new Rating
                    {
                        Source = (string)r["Source"],
                        Value = (string)r["Value"]
                    }),
                    TotalSeasons = (int)serieJson["totalSeasons"],
                    Seasons = new List<Season>()
                };
                MediaFactory factory = new MediaFactory();
                return (SerieDecorator)factory.GetMedia(MediaType.Series, data);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<SerieDecorator>> SearchSerie(string search)
        {
            var movielist = new List<Serie>();
            string parameters = "?apikey=" + apiKey + "&s=" + search + "&type=movie";
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject serieJson = JObject.Parse(json);
                if (serieJson["Response"].ToString() != "false")
                {
                    var series = new List<JsonData>();
                    series = serieJson["Search"].Select(r => new JsonData
                    {
                        Title = r["Title"].ToString(),
                        ReleaseDate = r["Year"].ToString(),
                        Imdbid = r["imdbID"].ToString(),
                        PosterUrl = r["Poster"].ToString()
                    }).ToList();
                    var rats = serieJson["Ratings"];
                    MediaFactory factory = new MediaFactory();
                    return series.Select(s =>
                    {
                        return (SerieDecorator)factory.GetMedia(MediaType.Series, s);

                    });
                }
                else
                {
                    return new List<SerieDecorator>();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Season> GetSeason(string imdbid, int season)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie" + "&season=" + season;
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject seasonJson = JObject.Parse(json);

                return new Season
                {
                    Title = (string)seasonJson["Title"],
                    SeasonNumber = (int)seasonJson["Season"],
                    Episodes = seasonJson["Episodes"].Select(s => new Episode
                    {
                        Title = (string)s["Title"],
                        Released = (string)s["Released"],
                        EpisodeNumber = (int)s["Episode"],
                        Ratings = new List<Rating>() { new Rating() {
                            Source = "Internet Movie Database",
                            Value = (string)s["imdbRating"]
                        }},
                        ImdbId = (string)s["imdbID"],
                    })
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Season>> GetSeasons(string imdbid, int seasons)
        {
            var s = new List<Season>();
            for(int i = 0; i < seasons; i++)
            {
                s.Add(await GetSeason(imdbid, i));
            }
            return s;
        }

        public async Task<Episode> GetEpisode(string imdbid, int season, int episode)
        {
            string parameters = "?apikey=" + apiKey + "&i=" + imdbid + "&type=movie" + "&season=" + season + "&episode=" + episode;
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject episodeJson = JObject.Parse(json);

                return new Episode
                {
                    Title = (string)episodeJson["Title"],
                    Rated = (string)episodeJson["Rated"],
                    Ratings = episodeJson["Ratings"].Select(r => new Rating
                    {
                        Source = (string)r["Source"],
                        Value = (string)r["Value"]
                    }),
                    EpisodeNumber = (int)episodeJson["Episode"],
                    ImdbId = (string)episodeJson["imdbID"],
                    Plot = (string)episodeJson["Plot"],
                    PosterUrl = (string)episodeJson["Poster"],
                    Released = (string)episodeJson["Released"],
                    Runtime = (string)episodeJson["Runtime"]
                };
            }
            else
            {
                return null;
            }
        }
    }
}
