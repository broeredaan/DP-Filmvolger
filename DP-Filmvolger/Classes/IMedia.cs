using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public interface IMedia
    {
        string Title { get; set;}
        string Length { get; set; }
        string Actors { get; set; }
        string Director { get; set; }
        string ReleaseDate { get; set; }
        string Genre { get; set; }
        string PosterUrl { get; set; }
        string Rated { get; set; }
        string Imdbid { get; set; }
        string Awards { get; set; }
        string Plot { get; set; }
        string Language { get; set; }
        string Country { get; set; }
        IEnumerable<Rating> Ratings { get; set; }
    }
}
