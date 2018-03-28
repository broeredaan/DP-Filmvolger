using DP_Filmvolger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class MediaFactory
    {
        public IMedia GetMedia(MediaType mediaType, JsonData data)
        {
            if(mediaType == MediaType.Series)
            {
                return new Serie {
                    Title = data.Title,
                    Length = data.Length,
                    Actors = data.Actors,
                    Director = data.Director,
                    ReleaseDate = data.ReleaseDate,
                    Genre = data.Genre,
                    PosterUrl = data.PosterUrl,
                    Rated = data.Rated,
                    Imdbid = data.Imdbid,
                    Awards = data.Awards,
                    Plot = data.Plot,
                    Language = data.Language,
                    Country = data.Country,
                    Ratings = data.Ratings,
                    TotalSeasons = data.TotalSeasons,
                    Seasons = data.Seasons,
                };
            }
            else if (mediaType == MediaType.Movie)
            {
                return new Movie
                {
                    Title = data.Title,
                    Length = data.Length,
                    Actors = data.Actors,
                    Director = data.Director,
                    ReleaseDate = data.ReleaseDate,
                    Genre = data.Genre,
                    PosterUrl = data.PosterUrl,
                    Rated = data.Rated,
                    Imdbid = data.Imdbid,
                    Awards = data.Awards,
                    Plot = data.Plot,
                    Language = data.Language,
                    Country = data.Country,
                    Ratings = data.Ratings,
                    BoxOffice = data.BoxOffice
                };
            }
            throw new ArgumentException("Invalid Media Type");
        }
    }
}
