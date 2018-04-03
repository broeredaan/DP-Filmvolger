using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public static class DummyData
    {
        public static IEnumerable<IMedia> Favourites { get; set; }

        public static IEnumerable<IMedia> Ratings { get; set; }

        static DummyData()
        {
            Favourites = new List<IMedia>()
            {
                new MovieDecorator
                {
                    Imdbid = "tt0076759",
                    IsFavourite = true
                },
                new SerieDecorator
                {
                    Imdbid = "tt0475784",
                    IsFavourite = true
                },
                new MovieDecorator
                {
                    Imdbid = "tt0111161",
                    IsFavourite = true
                },
                new SerieDecorator
                {
                    Imdbid = "tt1439629",
                    IsFavourite = true
                }
            };
            Ratings = new List<IMedia>()
            {
                new MovieDecorator
                {
                    Imdbid = "tt1431045",
                    UserRating = 5
                },
                new SerieDecorator
                {
                    Imdbid = "tt0898266",
                    UserRating = 5
                },
                new MovieDecorator
                {
                    Imdbid = "tt1677720",
                    UserRating = 4
                },
                new SerieDecorator
                {
                    Imdbid = "tt0944947",
                    UserRating = 1
                }
            };
        }
    }
}
