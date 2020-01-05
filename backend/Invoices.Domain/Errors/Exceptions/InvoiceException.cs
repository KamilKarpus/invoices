using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Domain.Errors.Exceptions
{
    public class InvoiceException : Exception
    {
        public InvoiceException(string message) : base(message)
        {
        }
    }
}
