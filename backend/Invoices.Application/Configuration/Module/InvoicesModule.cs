using Autofac;
using Invoices.Application.Configuration.Processing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.Configuration.Module
{
    public class InvoicesModule : IInvoicesModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}
