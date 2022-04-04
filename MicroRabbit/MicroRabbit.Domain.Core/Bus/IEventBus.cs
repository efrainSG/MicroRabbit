using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<CustomType>(CustomType command) where CustomType : Command;

        void Publish<CustomType>(CustomType @event) where CustomType : Event;

        void Subscribe<CustomType, CustomHandler>()
            where CustomType : Event
            where CustomHandler : IEventHandler<CustomType>;
    }

    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent: Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
