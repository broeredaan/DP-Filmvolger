using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public interface IMediaDecorator
    {
        bool IsFavourite { get; set; }
        int UserRating { get; set; }
    }
}
