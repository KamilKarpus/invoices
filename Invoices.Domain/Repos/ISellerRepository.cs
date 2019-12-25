using Administration.Domain.Sellers;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Repos
{
    public interface ISellerRepository
    {
        Task<Seller> GetbyId(Guid id);
        Task AddAsync(Seller seller);
    }
}
