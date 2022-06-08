using SeleniumTrainingCenter.PageObjects;
using System.IO;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTrainingCenter.Tests.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SeleniumTrainingCenter.Tests
{
    [TestFixture(Description = "Automationpractice store tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/AndriusBogda/SeleniumTrainingCenter")]
    [TestClass]
    public class StoreTests : BaseTest
    {
        private readonly string _storeLoginURL = @"http://automationpractice.com/index.php?controller=authentication&back=my-account";

        [Test]
        public void TestLogin()
        {
            var a = new LoginPage(Driver, _storeLoginURL);

            var namejj = Configuration["fName"];
        }
    }
}
