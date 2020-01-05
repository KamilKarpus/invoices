using Administration.Domain.Customers;
using Administration.Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Administration.Application.Configuration.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AdministrationContext _context;
        public CustomerRepository(AdministrationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.AddAsync(customer);
        }

        public async Task<Customer> GetbyId(Guid id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }
    }
}
