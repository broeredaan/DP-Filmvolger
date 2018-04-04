using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DP_Filmvolger.Classes;
namespace DP_Filmvolger.Classes
{
    public static class Notification 
    {
        static MainPage mainPage;

        public static void AddNotification(string message)
        {
          
          mainPage.UpdateMessage(message);
        }

        public static void InsertPage(MainPage page)
        {
            mainPage = page;
        }
    }
}
