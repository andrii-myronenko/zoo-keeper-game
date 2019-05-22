using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.ObserverInterfaces
{
    public enum ActionType
    {
        LevelChanged,
        MoneyChanged
    }

    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(ActionType actionType, int value);
    }
}