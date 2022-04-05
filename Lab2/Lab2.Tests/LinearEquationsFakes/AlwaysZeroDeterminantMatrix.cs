using Lab2.ProductionCode.LinearEquations;

namespace Lab2.Tests.LinearEquationsFakes
{
    internal class AlwaysZeroDeterminantMatrix : IMatrix
    {
        public double[,] Coeffs { get; set; }

        public double Determinant()
        {
            return 0;
        }
    }
}
