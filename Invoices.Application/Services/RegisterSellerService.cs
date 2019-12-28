using Invoices.Application.Configuration.DataAccess;
using Invoices.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.Services
{
    public class RegisterSellerService
    {
        private readonly InvoicesContext _context;
        public RegisterSellerService(InvoicesContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RegisterSeller seller)
        {
            await _context.AddAsync<RegisterSeller>(seller);
            await _context.SaveChangesAsync();
        }
    }
}
