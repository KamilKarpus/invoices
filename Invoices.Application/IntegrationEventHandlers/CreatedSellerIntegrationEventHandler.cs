using Adminstration.IntegrationEvents;
using Autofac;
using Invoices.Application.Configuration;
using Invoices.Application.Services;
using Invoices.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Invoices.Application.IntegrationEventHandlers
{
    public class CreatedSellerIntegrationEventHandler : INotificationHandler<SellerCreatedIntegrationEvent>
    {  
        public async Task Handle(SellerCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var seller = new RegisterSeller(notification.SellerId, notification.CompanyName, notification.Street,
                notification.City, notification.PostalCode, notification.BankName, 
                notification.BankAcountNumber, notification.BankSwift, notification.NIP);
            
            using(var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var service = scope.Resolve<RegisterSellerService>();
                await service.AddAsync(seller);
            }
        }
    }
}
