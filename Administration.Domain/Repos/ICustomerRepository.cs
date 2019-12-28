using System;
using System.Threading.Tasks;
using Administration.Domain.Customers;

namespace Administration.Domain.Repos
{
    public interface ICustomerRepository
    {
        Task<Customer> GetbyId(Guid id);
        Task AddAsync(Customer customer);
    }
}
