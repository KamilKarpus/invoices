using System;
using System.Threading.Tasks;
using Invoices.Domain.Invoices;
using Invoices.Domain.Repo;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Application.Configuration.DataAccess.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly InvoicesContext _context;
        public InvoicesRepository(InvoicesContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Invoice invoice)
        {
            await _context.AddAsync(invoice);
        }

        public Task<Invoice> GetbyId(Guid id)
        {
            return _context.Invoices.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
