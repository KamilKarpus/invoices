using Administration.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Repos
{
    public interface IOrganizationRepository
    {
        Task<Organization> GetbyId(Guid id);
        Task AddAsync(Organization customer);
    }
}
