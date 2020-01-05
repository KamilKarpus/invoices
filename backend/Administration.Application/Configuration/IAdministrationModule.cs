using Administration.Application.Configuration.Processing;
using System.Threading.Tasks;

namespace Administration.Application.Configuration
{
    public interface IAdministrationModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);


    }
}