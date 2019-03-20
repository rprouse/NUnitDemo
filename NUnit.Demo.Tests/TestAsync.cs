using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Demo.Tests
{
    public class TestAsync
    {
        [TestCase(0, 10)]
        [TestCase(-100, 0)]
        [TestCase(100, 200)]
        [TestCase(0, 0)]
        public async Task RandomAsyncTest(int low, int high)
        {
            int actual = await RandomAsync(low, high);

            Assert.That(actual, Is.GreaterThanOrEqualTo(low));
            Assert.That(actual, Is.LessThanOrEqualTo(actual));
        }

        [Test]
        public void RandomAsyncThrowsArgumentOutOfRangeException()
        {
            Assert.That(async () => await RandomAsync(10, 0), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        async Task<int> RandomAsync(int low, int high)
        {
            int r = TestContext.CurrentContext.Random.Next(low, high);

            return await Task.FromResult(r);
        }
    }
}
