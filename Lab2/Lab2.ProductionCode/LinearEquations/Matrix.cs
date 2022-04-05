namespace Lab2.ProductionCode.LinearEquations
{
    public class Matrix : IMatrix
    {
        public double[,] Coeffs { get; set; }

        public double Determinant()
        {
            return Coeffs[0, 0] * Coeffs[1, 1] - Coeffs[0, 1] * Coeffs[1, 0];
        }
    }
}
