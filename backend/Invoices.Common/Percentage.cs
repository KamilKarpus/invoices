using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain
{
    public struct Percentage : IEquatable<Percentage>
    {
        public int Value { get; private set; }
        public Percentage(int value)
        {
            Value = value;
        }

        public static Percentage From(int value) => new Percentage(value);
        public decimal Fraction => (decimal)Value / 100;

        public bool Equals(Percentage other)
        {
            return Value == other.Value;
        }
    }
}
