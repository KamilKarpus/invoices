using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels;
using System;

namespace Administration.Application.Queries
{
    public class GetSellerInfoQuery : IQuery<SellerReadModel>
    {
        public Guid SellerId {get; set;}
    }
}
