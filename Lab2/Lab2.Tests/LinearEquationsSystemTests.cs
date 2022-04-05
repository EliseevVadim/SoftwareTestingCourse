using Lab2.ProductionCode.LinearEquations;
using Lab2.Tests.LinearEquationsFakes;
using NUnit.Framework;

namespace Lab2.Tests
{
    [TestFixture]
    internal class LinearEquationsSystemTests
    {
        private LinearEquationsSystem _linearEquationSystem;

        [SetUp]
        public void InitializeLinearEquationsSystem()
        {
            _linearEquationSystem = new LinearEquationsSystem();
        }

        [Test]
        public void TestZeroDeterminant()
        {
            IMatrix matrix = new AlwaysZeroDeterminantMatrix();
            _linearEquationSystem.Matrix = matrix;
            _linearEquationSystem.SetCoefficients(new double[,]
            {
                { 1, 1, 2 },
                { 2, 2, 3}
            });
            Assert.Throws<ZeroDeterminantException>(delegate
            {
                double[] roots = _linearEquationSystem.Solve();
            });
        }

        [Test]
        public void TestDeterminantMethodGetsCalledAllThreeTimes()
        {
            MockedMatrix matrix = new MockedMatrix();
            _linearEquationSystem.Matrix = matrix;
            _linearEquationSystem.SetCoefficients(new double[,]
            {
                { 3, 4, 5 },
                { 4, 5, 6 },
            });
            double[] roots = _linearEquationSystem.Solve();
            Assert.That(matrix.CallsCount, Is.EqualTo(3));
        }

        [Test]
        public void TestDeterminantMethodGetsCalledLessThanThreeTimes()
        {
            MockedMatrix matrix = new MockedMatrix();
            _linearEquationSystem.Matrix = matrix;
            _linearEquationSystem.SetCoefficients(new double[,]
            {
                { 2, 3, 3 },
                { 4, 3, 3 }
            });
            try
            {
                double[] res = _linearEquationSystem.Solve();
            }
            catch
            {

            }
            Assert.That(matrix.CallsCount, Is.LessThan(3));
        }

        [Test]
        public void TestNormalWorkOfSystemSolving()
        {
            IMatrix matrix = new Matrix();
            _linearEquationSystem.Matrix = matrix;
            _linearEquationSystem.SetCoefficients(new double[,]
            {
                { 3, 2, 1 },
                { 1, 4, -3 }
            });
            double[] roots = _linearEquationSystem.Solve();
            Assert.That(roots, Is.EqualTo(new double[] { 1, -1 }));
            _linearEquationSystem.SetCoefficients(new double[,]
            {
                { 1, -2, 1 },
                { 3, -4, 7 }
            });
            roots = _linearEquationSystem.Solve();
            Assert.That(roots, Is.EqualTo(new double[] { 5, 2 }));
        }
    }
}
