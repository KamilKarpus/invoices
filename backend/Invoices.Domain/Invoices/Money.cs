using System;
using System.Collections.Generic;
using Domain;

namespace Invoices.Domain.Invoices
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Currency must the same!");
            }
            return new Money((a.Value + b.Value), a.Currency);
        }

        public static Money operator *(Money a, int b)
        {
            return new Money((a.Value * b), a.Currency);
        }
    }
}
