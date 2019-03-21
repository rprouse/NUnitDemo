using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace NUnit.Demo.Tests
{
    public class AttachmentTests
    {
        [Test]
        public void AttachFileToTests()
        {
            var filename = CreateHelloWorld();

            Assert.That(filename, Does.Exist);

            TestContext.AddTestAttachment(filename, "Hello World file");
        }

        string CreateHelloWorld()
        {
            var filename = Path.GetTempFileName();
            File.WriteAllText(filename, "Hello World!");
            return filename;
        }
    }
}
