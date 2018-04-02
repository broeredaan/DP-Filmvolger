using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes.State
{
    public class RatingsState : IState
    {

        public void Handle()
        {
            throw new NotImplementedException();
        }

        public string DisplayGrid()
        {
            string unhide = "RatingsGrid";
            return unhide;
        }

    }

}
