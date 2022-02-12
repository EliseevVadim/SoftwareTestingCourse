using System;
using NUnit.Framework;
using Lab1.ProductionCode;
using System.Linq;

namespace Lab1.NUnitTests
{
    [TestFixture]
    public class ArrayProcessorTest
    {
        private readonly ArrayProcessor _processor = new ArrayProcessor();

        [TestCase(new int[] { 1, 6, 9, -5, -12, -13, -15, -15, 8, 3 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 0, 7, 8, 8, 5, 8, -3, -3})]
        [TestCase(new int[] { 10, 36, -5, -9, 6, 8, 9, 9, -6, -5, 1})]
        [TestCase(new int[] { 0, 5})]
        [TestCase(new int[] { -1, -1, -1, -1})]
        public void TestArrayProcessorWork(int[] input)
        {
            int[] result = _processor.SortAndFilter(input);
            Assert.Multiple(() =>
            {
                CollectionAssert.IsOrdered(result);
                CollectionAssert.AllItemsAreUnique(result.Where(item => item < 0).ToArray());
            });
        }
    }
}
