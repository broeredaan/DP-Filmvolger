using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class MovieDecorator : Movie, IMediaDecorator
    {
        public bool IsFavourite { get; set; }
        public int UserRating { get; set; }
    }
}
