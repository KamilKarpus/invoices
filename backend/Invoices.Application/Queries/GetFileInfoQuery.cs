using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels;
using System;


namespace Invoices.Application.Queries
{
    public class GetFileInfoQuery : IQuery<CustomFileInfo>
    {
       public Guid Id { get; set; }
    }
}
