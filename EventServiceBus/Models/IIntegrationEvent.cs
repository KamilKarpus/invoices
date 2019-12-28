using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventServiceBus.Models
{
    public interface IIntegrationEvent : INotification
    {
    }
}
