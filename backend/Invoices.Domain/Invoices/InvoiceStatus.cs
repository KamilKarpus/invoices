using System.Collections.Generic;
using Domain;

namespace Invoices.Domain.Invoices
{
    public class InvoiceStatus : ValueObject
    {
        public static InvoiceStatus NotIssued => new InvoiceStatus(1, nameof(NotIssued));
        public static InvoiceStatus Issued => new InvoiceStatus(2, nameof(Issued));
        public int Id { get; private set;}
        public string Name { get; private set; }
        public InvoiceStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private InvoiceStatus()
        {

        }
        public static InvoiceStatus From(int id)
        {
            if(id == 2)
            {
                return Issued;
            }
            else
            {
                return NotIssued;
            }
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
        }
        public static bool operator != (InvoiceStatus a, InvoiceStatus b)
        {
            return !a.Equals(b);
        }
        public static bool operator ==(InvoiceStatus a, InvoiceStatus b)
        {
            return a.Equals(b);
        }
    }
}
