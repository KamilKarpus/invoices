using System;
using System.Threading;
using System.Threading.Tasks;
using Adminstration.IntegrationEvents;
using Autofac;
using Invoices.Application.Configuration;
using Invoices.Application.Services;
using Invoices.Domain.RegisterOrganization;
using MediatR;

namespace Invoices.Application.IntegrationEventHandlers
{
    public class CustomerIntegrationEventHandler : INotificationHandler<AddCustomerIntegrationEvent>
    {
        public async Task Handle(AddCustomerIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var  customer = new RegisterCustomer(notification.CustomerId,notification.Name, notification.LastName, notification.OrganizationId);

            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var service = scope.Resolve<RegisterCustomerService>();
                await service.AddAsync(customer);

            }
        }
    }
}
