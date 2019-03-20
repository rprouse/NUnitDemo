using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit.Demo
{
    public class TestCalculator
    {
        #region Setup

        Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        #endregion

        #region TestCaseSource

        [TestCaseSource(nameof(AddData))]
        public void TestAdd(int x, int y, int expected)
        {
            var result = calc.Add(x, y);
            Assert.That(result, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> AddData()
        {
            yield return new TestCaseData(1, 1, 2);
            yield return new TestCaseData(100, 120, 220);
            yield return new TestCaseData(-100, 120, 20);
            yield return new TestCaseData(100, 0, 100);
            yield return new TestCaseData(int.MinValue, int.MaxValue, -1);
        }

        #endregion

        #region Assert.Throws

        [Test]
        public void DivideByZeroThrowsArgumentException()
        {
            Assert.That(() => calc.Divide(10, 0), Throws.ArgumentException.With.Message.EqualTo("Cannot divide by zero"));
        }

        #endregion
    }
}