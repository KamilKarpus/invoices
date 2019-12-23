using MediatR;

namespace Administration.Application.Configuration.DataAccess.Processing
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}