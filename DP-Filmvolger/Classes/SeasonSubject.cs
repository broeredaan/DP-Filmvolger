using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    public class SeasonSubject
    {
        private List<Observer> observers;

        public SeasonSubject()
        {
            observers = new List<Observer>();
        }

        public void Register(Observer observer)
        {
            observers.Add(observer);
        }

        public void UnRegister(Observer observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach(var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
