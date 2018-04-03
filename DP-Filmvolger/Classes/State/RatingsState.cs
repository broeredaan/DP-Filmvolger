using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes.State
{
    public class RatingsState : IState
    {

        public void Handle(MainPage page)
        {
            page.HideAll();
            page.ShowRating();
        }


        public string DisplayGrid()
        {
            string unhide = "RatingsGrid";
            return unhide;
        }

    }

}
