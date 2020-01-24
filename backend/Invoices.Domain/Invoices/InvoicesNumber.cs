using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Domain.Invoices
{
    public class InvoicesNumber
    {
        public int Number { get; private set; }
        public int Year { get; private set; }

        public InvoicesNumber(int number, int year)
        {
            Number = number;
            Year = year;
        }
    }
}
