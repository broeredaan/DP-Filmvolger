using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class Observer
    {
        public void Update(string message)
        {
            Notification.AddNotification(message);
        }
    }
}
