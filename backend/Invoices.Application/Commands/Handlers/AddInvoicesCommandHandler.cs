using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Infrastructure;
using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels;
using Invoices.Domain.Invoices;
using Invoices.Domain.Repo;
using MediatR;

namespace Invoices.Application.Commands.Handlers
{
    public class AddInvoicesCommandHandler : ICommandHandler<AddInvoicesCommand>
    {
        private readonly IInvoicesRepository _repository;
        private readonly ISqlConnectionFactory _factory;
        public AddInvoicesCommandHandler(IInvoicesRepository repo, ISqlConnectionFactory factory)
        {
            _repository = repo;
            _factory = factory;
        }
        public async Task<Unit> Handle(AddInvoicesCommand request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var customerId = await conn.QuerySingleAsync<CustomerId>("SELECT id" +
                " FROM public.registercustomer" +
                " where customerId = @Id" +
                " order by modifydate" +
                " limit 1;", new { Id = request.CustomerId });

            await _repository.AddAsync(new Invoice(request.Id, customerId.Id, request.SellerId,
                request.Currency, DateTime.Now, request.VatRate)) ;
            return Unit.Value;
        }
    }
}
