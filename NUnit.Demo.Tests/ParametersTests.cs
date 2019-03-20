using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnit.Demo.Tests
{
    public class ParametersTests
    {
        // This test requires that parameters be passed at the 
        // command line or via a .runsettings file
        [Test]
        public void ShouldPassParameters()
        {
            string webAppUrl = TestContext.Parameters["webAppUrl"];
            string webAppUserName = TestContext.Parameters["webAppUserName"];
            string webAppPassword = TestContext.Parameters["webAppPassword"];

            Assert.That(webAppUrl, Is.EqualTo("http://localhost"));
            Assert.That(webAppUserName, Is.EqualTo("Admin"));
            Assert.That(webAppPassword, Is.EqualTo("Password"));
        }
    }
}
