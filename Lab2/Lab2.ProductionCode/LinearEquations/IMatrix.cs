namespace Lab2.ProductionCode.LinearEquations
{
    public interface IMatrix
    {
        public double Determinant();
        public double[,] Coeffs { get; set; }
    }
}
