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
    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
    {
        private readonly IOrganizationRepository _repository;
        public AddCustomerCommandHandler(IOrganizationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetbyId(request.OrganizationId);
            organization.AddCustomer(request.Id,request.Name, request.Surname);
            return Unit.Value;

        }
    }
}
