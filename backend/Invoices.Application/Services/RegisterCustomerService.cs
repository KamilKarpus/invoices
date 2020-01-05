using Invoices.Application.Configuration.DataAccess;
using Invoices.Domain.RegisterOrganization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.Services
{
    public class RegisterCustomerService
    {
        private readonly InvoicesContext _context;
        public RegisterCustomerService(InvoicesContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RegisterCustomer customer)
        {
            await _context.AddAsync<RegisterCustomer>(customer);
            await _context.SaveChangesAsync();
        }
    }
}
