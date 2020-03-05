using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquaFramework.Events
{
    public class EventAggregator : IEventAggregator
    {
        Dictionary<int, Dictionary<int, EventEntity>> _eventAggregator;

        public EventAggregator()
        {
            _eventAggregator = new Dictionary<int, Dictionary<int, EventEntity>>();
        }

        public IEventEntity SetChannelAndEventEntity(int channel, int eventEntity)
        {
            return _eventAggregator[channel][eventEntity];
        }

        void IEventAggregator.InitializeChannel(int channels)
        {
            for (int i = 0; i < channels; i++)
            {
                _eventAggregator.Add(i, new Dictionary<int, EventEntity>());
            }
        }

        void IEventAggregator.InitializeEventEntity(int channel, int eventEntities)
        {
            for(int i = 0; i < eventEntities; i++)
            {
                _eventAggregator[channel].Add(i, new EventEntity());
            }
        }

        /// <summary>
        /// 清空掉改频道下所有的事件以及该频道
        /// </summary>
        /// <param name="chanel"></param>
        public void ClearChanel(int chanel)
        {
            if (!_eventAggregator.ContainsKey(chanel))
                return;
            Dictionary<int , EventEntity> eventConatiner = _eventAggregator[chanel];
            foreach (EventEntity e in eventConatiner.Values)
            {
                e.AutoUnsubscribe();
            }
            eventConatiner.Clear();
            _eventAggregator.Remove(chanel);
        }
    }
}
