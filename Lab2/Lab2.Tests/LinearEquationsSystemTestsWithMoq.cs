using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Lab2.ProductionCode.LinearEquations;

namespace Lab2.Tests
{
    [TestFixture]
    internal class LinearEquationsSystemTestsWithMoq
    {
        private readonly Mock<IMatrix> _mockMatrix = new Mock<IMatrix>();

        [TearDown]
        public void ResetInvokations()
        {
            _mockMatrix.Invocations.Clear();
        }

        [Test]
        public void TestZeroDeterminantWithMoq()
        {
            _mockMatrix.Setup(matrix => matrix.Determinant()).Returns(0);
            var linearEquationSystem = new LinearEquationsSystem();
            linearEquationSystem.Matrix = _mockMatrix.Object;
            linearEquationSystem.SetCoefficients(new double[,]
            {
                { 1, 1, 2 },
                { 2, 2, 3}
            });
            Assert.Throws<ZeroDeterminantException>(delegate
            {
                double[] roots = linearEquationSystem.Solve();
            });
        }

        [Test]
        public void TestDeterminantMethodGetsCalledAllThreeTimesWithMoq()
        {
            _mockMatrix.Setup(matrix => matrix.Determinant()).Returns(1);
            var linearEquationSystem = new LinearEquationsSystem();
            linearEquationSystem.Matrix = _mockMatrix.Object;
            linearEquationSystem.SetCoefficients(new double[,]
            {
                { 3, 4, 5 },
                { 4, 5, 6 },
            });
            double[] roots = linearEquationSystem.Solve();
            _mockMatrix.Verify(matrix => matrix.Determinant(), Times.Exactly(3));
        }

        [Test]
        public void TestDeterminantMethodGetsCalledLessThanThreeTimesWithMoq()
        {
            _mockMatrix.SetupSequence(matrix => matrix.Determinant())
                .Returns(1)
                .Returns(0);
            var linearEquationSystem = new LinearEquationsSystem();
            linearEquationSystem.Matrix = _mockMatrix.Object;
            linearEquationSystem.SetCoefficients(new double[,]
            {
                { 2, 3, 3 },
                { 4, 3, 3 },
            });
            try
            {
                double[] roots = linearEquationSystem.Solve();
            }
            catch
            {

            }
            _mockMatrix.Verify(matrix => matrix.Determinant(), Times.AtMost(2));
        }

        [Test]
        public void TestNormalWorkOfSystemSolvingWithMoq()
        {
            _mockMatrix.SetupSequence(matrix => matrix.Determinant())
                .Returns(10)
                .Returns(10)
                .Returns(-10);
            var linearEquationSystem = new LinearEquationsSystem();
            linearEquationSystem.Matrix = _mockMatrix.Object;
            linearEquationSystem.SetCoefficients(new double[,]
            {
                { 3, 2, 1 },
                { 1, 4, -3 },
            });
            double[] roots = linearEquationSystem.Solve();
            Assert.That(roots, Is.EqualTo(new double[] { 1, -1 }));
        }
    }
}
