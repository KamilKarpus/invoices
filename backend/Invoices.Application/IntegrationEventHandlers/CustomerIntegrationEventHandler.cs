using System;
using System.Threading;
using System.Threading.Tasks;
using Adminstration.IntegrationEvents;
using Autofac;
using Dapper;
using Infrastructure;
using Invoices.Application.Configuration;
using Invoices.Application.ReadModels;
using Invoices.Application.Services;
using Invoices.Domain.RegisterOrganization;
using MediatR;

namespace Invoices.Application.IntegrationEventHandlers
{
    public class CustomerIntegrationEventHandler : INotificationHandler<AddCustomerIntegrationEvent>
    {
        public async Task Handle(AddCustomerIntegrationEvent notification, CancellationToken cancellationToken)
        {


            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var service = scope.Resolve<RegisterCustomerService>();
                var factory = scope.Resolve<ISqlConnectionFactory>();

                var conn = factory.GetConnection();

                var orgnizationId = await conn.QuerySingleAsync<OrganizationId>(
                "SELECT id " +
                "FROM public.registercustomerorganization " +
                "WHERE id_customerorganization=@Id " +
                "ORDER BY modifydate " +
                "LIMIT 1;",
                new { Id = notification.OrganizationId }
                );
                var customer = new RegisterCustomer(notification.CustomerId, notification.Name, notification.LastName, orgnizationId.Id);
                await service.AddAsync(customer);

            }
        }
    }
}
