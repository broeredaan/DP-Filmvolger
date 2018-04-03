using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DP_Filmvolger;

namespace DP_Filmvolger.Classes.State
{
    public class MediaState : IState
    {

        public void Handle(MainPage page)
        {
            page.HideAll();
            page.ShowMedia();
        }

        public string DisplayGrid()
        {
            string unhide = "MediaGrid";
            return unhide;
        }


    }
}
