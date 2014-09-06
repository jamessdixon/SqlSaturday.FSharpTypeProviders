using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChickenSoftware.VarianceCalculator.CS;
using ChickenSoftware.VarianceCalculator.FS;

namespace ChickenSoftware.VarianceCalculator.Tests
{
    [TestClass]
    public class CalcualtionsTests
    {
        [TestMethod]
        public void CSharpVaraiance_ReturnsExpected()
        {
            var numbers = new double[3] { 1, 2, 3};

            var expected = 1;
            var actual = CS.Calculations.Variance(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FSharpVaraiance_ReturnsExpected()
        {
            var numbers = new double[3] { 1, 2, 3 };

            var expected = .667;
            var actual = Math.Round(FS.Calculations.Variance(numbers),3);
            Assert.AreEqual(expected, actual);

        }
        //http://calculator.tutorvista.com/math/502/variance-calculator.html
    }
}
