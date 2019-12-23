using MediatR;

namespace Administration.Application.Configuration.DataAccess.Processing
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {

    }
}
