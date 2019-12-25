using Administration.Domain.Repos;
using Administration.Domain.Sellers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Configuration.DataAccess.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AdministrationContext _context;
        public SellerRepository(AdministrationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Seller seller)
        {
            await _context.AddAsync(seller);
        }

        public async Task<Seller> GetbyId(Guid id)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(p => p.Id == id);
            return seller;
        }
    }
}
