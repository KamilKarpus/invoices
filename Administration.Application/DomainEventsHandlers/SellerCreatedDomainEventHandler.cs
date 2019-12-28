using Administration.Domain.DomainEvents.Sellers;
using Adminstration.IntegrationEvents;
using EventServiceBus;
using Invoices.Common.DomainEvents;
using System.Threading.Tasks;

namespace Administration.Application.DomainEventsHandlers
{
    public class SellerCreatedDomainEventHandler : IDomainEventHandler<SellerCreatedDomainEvent>
    {
        private readonly IServiceBus _bus;
        public SellerCreatedDomainEventHandler(IServiceBus bus)
        {
            _bus = bus;
        }
        public Task Handle(SellerCreatedDomainEvent @event)
        {
            _bus.Publish(new SellerCreatedIntegrationEvent(@event.Id,@event.CompanyName,
                @event.Street,@event.City,@event.PostalCode,@event.BankName,
                @event.BankAcountNumber,@event.BankSwift,@event.NIP));
            return Task.CompletedTask;
        }
    }
}
