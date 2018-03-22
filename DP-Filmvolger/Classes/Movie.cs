using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    class Movie : IMedia
    {
        private string boxOffice;
        public Movie(string json)
        {
            JObject movie = JObject.Parse(json);

            Title = (string) movie["Title"];
            Length = (string) movie["Runtime"];
            Actors = (string)movie["Actors"];
            Director = (string)movie["Director"];
            ReleaseDate = (string)movie["Released"];
            Genre = (string)movie["Genre"];
            PosterUrl = (string)movie["Poster"];
            Rated = (string)movie["Rated"];
            Imdbid = (string)movie["imdbid"];
            Awards = (string)movie["Awards"];
            Plot = (string)movie["Plot"];
            Language = (string)movie["Language"];
            Country = (string)movie["Country"];

            var rats = new List<Rating>();
            foreach(var rating in movie["Ratings"])
            {
                Rating rat = new Rating(rating);
                rats.Add(rat);
            }
            Ratings = rats;

            boxOffice = (string) movie["BoxOffice"];
        }

        public string Title { get; set; }
        public string Length { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }
        public string Rated { get; set; }
        public string Imdbid { get; set; }
        public string Awards { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
