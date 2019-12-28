using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using MediatR;

namespace Invoices.Application.Configuration.Processing
{
    public class UnityOfWorkHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnityOfWork _unityOfWork;
        public UnityOfWorkHandlerDecorator(ICommandHandler<T> decorated, IUnityOfWork unityOfWork)
        {
            _decorated = decorated;
            _unityOfWork = unityOfWork;
        }
        public async Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
           await _decorated.Handle(request, cancellationToken);
           await _unityOfWork.CommitAsync();
           return Unit.Value;
        }
    }
}
