using Invoices.Application.Configuration.Processing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.Configuration.Module
{
    public interface IInvoicesModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}
