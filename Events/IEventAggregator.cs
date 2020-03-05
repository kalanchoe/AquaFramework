using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaFramework.Events
{
    public interface IEventAggregator
    {
        void InitializeChannel(int channels);
        void InitializeEventEntity(int channel, int eventEntities);
        IEventEntity SetChannelAndEventEntity(int channel, int eventEntity);
        void ClearChanel(int channel);
    }
}
