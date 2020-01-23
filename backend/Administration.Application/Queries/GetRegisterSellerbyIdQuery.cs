using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels.Seller;
using System;

namespace Administration.Application.Queries
{
    public class GetRegisterSellerbyIdQuery : IQuery<RegisterSellerView>
    {
        public Guid Id { get; set; }
    }
}
