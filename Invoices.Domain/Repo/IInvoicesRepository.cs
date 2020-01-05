using Invoices.Domain.Invoices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Domain.Repo
{
    public interface IInvoicesRepository
    {
        Task<Invoice> GetbyId(Guid id);
        Task AddAsync(Invoice invoice);
    }
}
