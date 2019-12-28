using Invoices.Application.Configuration.Processing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoices.Application.Commands.Handlers
{
    public class AddRegisterSellerCommandHandler : ICommandHandler<AddRegisterSellerCommand>
    {
        public Task<Unit> Handle(AddRegisterSellerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
