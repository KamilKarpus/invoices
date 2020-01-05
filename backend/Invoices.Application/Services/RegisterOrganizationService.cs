using Invoices.Application.Configuration.DataAccess;
using Invoices.Domain.RegisterOrganization;
using System;
using System.Threading.Tasks;

namespace Invoices.Application.Services
{
    public class RegisterOrganizationService
    {
        private readonly InvoicesContext _context;
        public RegisterOrganizationService(InvoicesContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RegisterOrganization organization)
        {
            await _context.AddAsync<RegisterOrganization>(organization);
            await _context.SaveChangesAsync();
        }
    }
}
