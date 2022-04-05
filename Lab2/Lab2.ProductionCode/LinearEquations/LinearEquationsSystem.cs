namespace Lab2.ProductionCode.LinearEquations
{
    public class LinearEquationsSystem
    {
        private double[,] _coefficients;
        private IMatrix _matrix;

        public IMatrix Matrix { get => _matrix; set => _matrix = value; }

        public void SetCoefficients(double[,] coeffs)
        {
            _coefficients = coeffs;
        }

        public double[] Solve()
        {
            double[,] mainCoefficients = new double[,]
                {
                    { _coefficients[0, 0], _coefficients[0, 1] },
                    { _coefficients[1, 0], _coefficients[1, 1] }
                };
            double[,] firstArgumentCoefficients = new double[,]
            {
                    { _coefficients[0, 2], _coefficients[0, 1] },
                    { _coefficients[1, 2], _coefficients[1, 1] }
            };
            double[,] secondArgumentCoefficients = new double[,]
            {
                    { _coefficients[0, 0], _coefficients[0, 2] },
                    { _coefficients[1, 0], _coefficients[1, 2]}
            };
            _matrix.Coeffs = mainCoefficients;
            double mainDeterminant = _matrix.Determinant();
            if (mainDeterminant == 0)
                throw new ZeroDeterminantException();
            _matrix.Coeffs = firstArgumentCoefficients;
            double firstArgumentDeterminant = _matrix.Determinant();
            if (firstArgumentDeterminant == 0)
                throw new ZeroDeterminantException();
            _matrix.Coeffs = secondArgumentCoefficients;
            double secondArgumentDeterminant = _matrix.Determinant();
            if (secondArgumentDeterminant == 0)
                throw new ZeroDeterminantException();
            double firstArgument = firstArgumentDeterminant / mainDeterminant;
            double secondArgument = secondArgumentDeterminant / mainDeterminant;
            return new double[] { firstArgument, secondArgument };
        }

    }
}
