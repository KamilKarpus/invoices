using System.Threading.Tasks;
using Administration.Application.Configuration;
using Autofac;
using MediatR;

namespace Administration.Application.Configuration.Processing
{
    public static class AdministrationExecutor
    {
        public static async Task ExecuteCommand(ICommand command)
        {
            using (var scope = AdministrationsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public static async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = AdministrationsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}