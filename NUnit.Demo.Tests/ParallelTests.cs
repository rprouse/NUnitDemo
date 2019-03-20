using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Demo.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class ParallelTests
    {
        [TestCaseSource(nameof(ParallelTestData))]
        public async Task ParallelTest(int id)
        {
            // Do long running work
            await Task.Delay(1000);

            TestContext.WriteLine($"Test id: {id}, thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static IEnumerable<int> ParallelTestData() =>
            Enumerable.Range(0, 10);
    }
}
