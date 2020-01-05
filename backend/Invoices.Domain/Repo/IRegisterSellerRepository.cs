using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Domain.Repo
{
    public interface IRegisterSellerRepository
    {
        Task Add(RegisterSeller seller);
        Task<RegisterSeller> GetbyId(Guid id);
    }
}
