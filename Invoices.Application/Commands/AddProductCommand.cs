using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class AddProductCommand : ICommand
    {
        public Guid ProductId { get; private set; }
        public Guid InvoiceId { get; private set; }
        public string Name { get; private set; }
        public decimal NetPrice { get; private set; }
        public int Quantity { get; private set; }

        public AddProductCommand(Guid id, Guid invoiceid, string name, decimal netprice, int quantity)
        {
            ProductId = id;
            Name = name;
            NetPrice = netprice;
            InvoiceId = invoiceid;
            Quantity = quantity;
        }
    }
}
