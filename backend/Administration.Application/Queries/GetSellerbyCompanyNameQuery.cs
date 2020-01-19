using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels;
using System.Collections.Generic;

namespace Administration.Application.Queries
{
    public class GetSellerbyCompanyNameQuery : IQuery<IEnumerable<SellerCompanyName>>
    {
        public string CompanyName { get; set; }
    }
}
