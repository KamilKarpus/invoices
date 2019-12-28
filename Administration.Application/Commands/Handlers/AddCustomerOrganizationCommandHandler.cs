using Administration.Application.Configuration.Processing;
using Administration.Domain.Customers;
using Administration.Domain.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Commands.Handlers
{
    public class AddCustomerOrganizationCommandHandler : ICommandHandler<AddCustomerOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        public AddCustomerOrganizationCommandHandler(IOrganizationRepository repo)
        {
            _repository = repo;
        }
        public async Task<Unit> Handle(AddCustomerOrganizationCommand request, CancellationToken cancellationToken)
        {
            var customerOrganization = new Organization(request.Id, request.Name, request.Street, request.City,
                request.PostalCode, request.Nip);
            await _repository.AddAsync(customerOrganization);
            return Unit.Value;
        }
    }
}
