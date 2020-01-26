using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace Invoices.Application.Configuration.Jobs
{
    public class BackgroundWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var service = scope.Resolve<AssignNumberService>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await service.TryExecuteJobs();
                    await Task.Delay(500);
                }
            }
        }
    }
}
