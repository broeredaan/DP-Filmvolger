﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes.State
{
    public class FavouritesState : IState
    {
    
        public void Handle()
        {
   
        }

        public string DisplayGrid()
        {
            string unhide = "FavGrid";
            return unhide;
        }


    }

}
