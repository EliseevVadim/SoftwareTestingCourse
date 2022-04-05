using Lab2.ProductionCode.LinearEquations;

namespace Lab2.Tests.LinearEquationsFakes
{
    internal class MockedMatrix : IMatrix
    {
        public double[,] Coeffs { get; set; }
        public int CallsCount { get; set; }

        public double Determinant()
        {
            CallsCount++;
            return Coeffs[0, 0] * Coeffs[1, 1] - Coeffs[0, 1] * Coeffs[1, 0];
        }
    }
}
