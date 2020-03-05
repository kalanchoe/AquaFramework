using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaFramework.Events
{
    class EventEntity : IEventEntity
    {
        private event EventHandler<EventArgs> _message;

        void IEventEntity.Publish(object sender, EventArgs eventArgs)
        {
            _message?.Invoke(sender, eventArgs);
        }

        void IEventEntity.Subscribe(EventHandler<EventArgs> eventHandler)
        {
            _message += eventHandler;
        }

        void IEventEntity.SubscribeOnce(EventHandler<EventArgs> eventHandler)
        {
            _message += tempEventHandler;
            void tempEventHandler(object sender, EventArgs eventArgs)
            {
                eventHandler?.Invoke(sender, eventArgs);
                _message -= tempEventHandler;
            }
        }

        void IEventEntity.Unsubscribe(EventHandler<EventArgs> eventHandler)
        {
            _message -= eventHandler;
        }

        public void AutoUnsubscribe()
        {
            _message = delegate { };
        }
    }
}
