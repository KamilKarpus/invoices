using System.Threading;
using System.Threading.Tasks;

using Invoices.Application.Configuration.Processing;
using Invoices.Domain.Repo;
using MediatR;

namespace Invoices.Application.Commands.Handlers
{
    public class DeleteProductFromInvoiceCommandHandler : ICommandHandler<DeleteProductFromInvoiceCommand>
    {
        private readonly IInvoicesRepository _repository;
        public DeleteProductFromInvoiceCommandHandler(IInvoicesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductFromInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _repository.GetbyId(request.InvoiceId);
            invoice.DeleteProduct(request.ProductId);
            return Unit.Value;
        }
    }
}
