using System.Threading;
using System.Threading.Tasks;
using Invoices.Application.Configuration.Processing;
using Invoices.Domain.Repo;
using MediatR;

namespace Invoices.Application.Commands.Handlers 
{ 
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IInvoicesRepository _invoicesRepository;
        public UpdateProductCommandHandler(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoicesRepository.GetbyId(request.InvoiceId);
            invoice.UpdateProduct(request.ProductId, request.Name, request.NetPrice, request.Quantity);
            return Unit.Value;
        }
    }
}
