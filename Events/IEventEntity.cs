using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaFramework.Events
{
    public interface IEventEntity
    {
        void Subscribe(EventHandler<EventArgs> eventHandler);
        void Unsubscribe(EventHandler<EventArgs> eventHandler);
        void SubscribeOnce(EventHandler<EventArgs> eventHandler);
        void Publish(object sender, EventArgs eventArgs);
    }
}
