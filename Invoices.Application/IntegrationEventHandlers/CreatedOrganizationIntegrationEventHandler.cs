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
    public class CreatedOrganizationIntegrationEventHandler : INotificationHandler<OrganiationCreatedIntegrationEvent>
    {
        public  async Task Handle(OrganiationCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var organization = new RegisterOrganization(notification.OrganizationId, notification.Name,
                notification.Street, notification.City, notification.PostalCode, notification.Nip);

            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var service = scope.Resolve<RegisterOrganizationService>();
                await service.AddAsync(organization);
            }
        }
    }
}
