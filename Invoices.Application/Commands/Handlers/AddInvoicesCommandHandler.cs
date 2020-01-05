using System;
using System.Threading;
using System.Threading.Tasks;
using Invoices.Application.Configuration.Processing;
using Invoices.Domain.Invoices;
using Invoices.Domain.Repo;
using MediatR;

namespace Invoices.Application.Commands.Handlers
{
    public class AddInvoicesCommandHandler : ICommandHandler<AddInvoicesCommand>
    {
        private readonly IInvoicesRepository _repository;

        public AddInvoicesCommandHandler(IInvoicesRepository repo)
        {
            _repository = repo;
        }
        public async Task<Unit> Handle(AddInvoicesCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Invoice(request.Id,request.CustomerId,request.SellerId,
                request.Currency, DateTime.Now, request.VatRate));
            return Unit.Value;
        }
    }
}
