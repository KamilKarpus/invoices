using MediatR;

namespace Invoices.Application.Configuration.Processing
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}