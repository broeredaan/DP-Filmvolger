using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class Season
    {
        public string Title { get; set; }
        public int SeasonNumber { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }
    }
}
