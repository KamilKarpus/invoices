using System.Threading;
using System.Threading.Tasks;
using Invoices.Application.Configuration.Processing;
using Invoices.Domain.Repo;
using MediatR;

namespace Invoices.Application.Commands.Handlers
{
    public class IssueInvoiceCommandHandler : ICommandHandler<IssueInvoiceCommand>
    {
        private readonly IInvoicesRepository _repository;
        public IssueInvoiceCommandHandler(IInvoicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(IssueInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _repository.GetbyId(request.Id);
            invoice.Issue();
            return Unit.Value;
        }
    }
}
