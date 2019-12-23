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
        IUnityOfWork UnityOfWork { get; }
        Task<Seller> GetbyId(Guid id);
        Task AddAsync(Seller seller);
    }
}
