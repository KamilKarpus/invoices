using Administration.Application.Configuration.Processing;
using Administration.Domain.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Commands.Handlers
{
    public class AddSellerCommandHandler : ICommandHandler<AddSellerCommand>
    {
        private readonly ISellerRepository _repository;
        public AddSellerCommandHandler(ISellerRepository repo)
        {
            _repository = repo;
        }
        public async Task<Unit> Handle(AddSellerCommand request, CancellationToken cancellationToken)
        {
           await _repository.AddAsync(new Domain.Sellers.Seller(request.CompanyName,request.Street, request.City, request.PostalCode, request.BankName,request.BankAccountNumber,request.BankSwift, request.NIP));
           return Unit.Value;
        }
    }
}
