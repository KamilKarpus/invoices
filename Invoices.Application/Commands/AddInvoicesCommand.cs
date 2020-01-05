using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class AddInvoicesCommand : ICommand
    {
        public Guid Id { get; private set; }
        public Guid CustomerId {get; private set;}
        public Guid SellerId {get; private set;}
        public string Currency {get; private set;}
        public int VatRate { get; private set; }
        public AddInvoicesCommand(Guid id, Guid customerId, Guid sellerId, string currency,
            int vatRate)
        {
            Id = id;
            CustomerId= customerId;
            SellerId = sellerId;
            Currency = currency;
            VatRate = vatRate;
        }
    }
}
