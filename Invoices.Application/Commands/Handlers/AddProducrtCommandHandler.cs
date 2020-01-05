using Invoices.Application.Configuration.Processing;
using Invoices.Domain.Repo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoices.Application.Commands.Handlers
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IInvoicesRepository _repository;
        public AddProductCommandHandler(IInvoicesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var result = await  _repository.GetbyId(request.InvoiceId);
            result.AddProduct(request.ProductId,request.InvoiceId, request.Name, request.NetPrice, request.Quantity);
            return Unit.Value;
        }
    }
}
