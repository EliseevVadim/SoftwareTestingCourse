using NUnit.Framework;
using Lab1.ProductionCode;
using System;

namespace Lab1.NUnitTests
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        public void TestOneNegativeSide()
        {
            // Arrange
            Triangle triangle = new Triangle();
            // Assert and Act
            Assert.Throws<FormatException>(() => triangle.SetSides(-1, 5, 3));
            Assert.Throws<FormatException>(() => triangle = new Triangle(2, 3, -1));
        }

        [Test]
        public void TestZeroSides()
        {
            // Arrange
            Triangle triangle = new Triangle();
            //Assert and act
            Assert.Throws<FormatException>(() => triangle.SetSides(0, 0, 0));
            Assert.Throws<FormatException>(() => triangle = new Triangle(0, 1, 0));
        }

        [Test]
        public void TestInvalidTriangle()
        {
            // Arrange
            Triangle triangle = new Triangle();
            //Assert and act
            Assert.Throws<ArgumentException>(() => triangle.SetSides(5, 1, 1));
            Assert.Throws<ArgumentException>(() => triangle.SetSides(5, 2, 16));
        }

        [Test]
        public void TestCorrectSides()
        {
            // Arrange
            Triangle triangle = new Triangle();
            //Assert and act
            Assert.DoesNotThrow(() => triangle.SetSides(3, 4, 5));
            Assert.DoesNotThrow(() => triangle = new Triangle(7, 4, 9));
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(6, 8, 10, 24)]
        [TestCase(3, 8, 6, 7.64444)]
        [TestCase(6, 10, 6, 16.58312)]
        [TestCase(5, 2, 4, 3.79967)]
        public void TestAreaCalculating(double a, double b, double c, double expectedArea)
        {
            // Arrange
            Triangle triangle = new Triangle(a, b, c);
            // Act
            double area = triangle.Area();
            // Assert
            Assert.AreEqual(area, expectedArea, 0.00001);
        }
    }
}
