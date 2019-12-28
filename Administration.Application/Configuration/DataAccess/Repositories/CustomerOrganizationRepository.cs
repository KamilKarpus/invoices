using Administration.Domain.Customers;
using Administration.Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Administration.Application.Configuration.DataAccess.Repositories
{
    public class CustomerOrganizationRepository : IOrganizationRepository
    {
        private readonly AdministrationContext _context;
        public CustomerOrganizationRepository(AdministrationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Organization customer)
        {
           await _context.AddAsync(customer);
        }

        public async Task<Organization> GetbyId(Guid id)
        {
            var result = await _context.Organizations.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }
    }
}
