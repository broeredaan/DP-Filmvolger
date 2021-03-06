﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class Movie : IMedia
    {
        public string BoxOffice { get; set; }
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
