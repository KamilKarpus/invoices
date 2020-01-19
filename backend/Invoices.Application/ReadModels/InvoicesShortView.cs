using System;

namespace Invoices.Application.ReadModels
{
    public class InvoicesShortView
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal LeftToPay { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDeadLine { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
