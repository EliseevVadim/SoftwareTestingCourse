using System;

namespace Lab2.ProductionCode.LinearEquations
{
    public class ZeroDeterminantException : Exception
    {
        public ZeroDeterminantException() : base() { }

        public ZeroDeterminantException(string message) : base(message) { }
    }
}
