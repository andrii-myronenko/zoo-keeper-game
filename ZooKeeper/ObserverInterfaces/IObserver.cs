using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeper.ObserverInterfaces
{
    public interface IObserver
    {
        void Update(ActionType actionType, int value);
    }
}
