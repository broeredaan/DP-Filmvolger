
using System.Collections.Generic;

namespace DP_Filmvolger.Classes
{
    public class Episode
    {
        public string Title { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Plot { get; set; }
        public string PosterUrl { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public string ImdbId { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
