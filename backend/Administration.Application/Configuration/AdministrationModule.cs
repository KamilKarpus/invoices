using System.Threading.Tasks;
using Administration.Application.Configuration.Processing;
using Autofac;
using MediatR;

namespace Administration.Application.Configuration
{
    public class AdministrationModule : IAdministrationModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = AdministrationsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = AdministrationsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}