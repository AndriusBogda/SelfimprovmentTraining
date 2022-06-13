using SeleniumTrainingCenter.PageObjects;
using SeleniumTrainingCenter.InfoObjects;
using SeleniumTrainingCenter.InfoObjects.Enums;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using System;
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
        public void TestRegister()
        {
            var LOGGEDIN_MESSAGE = "p.info-account";
            var ACCOUNT_ALREADY_CREATED = "#create_account_error";

            var user = new Person
                        (
                            Titles.Mr,
                            Configuration["fName"],
                            Configuration["lName"],
                            Configuration["email"],
                            Configuration["password"],
                            new DateOnly(2001, 03, 17)
                        );
  
            var address = new UserAddress
                        (
                            Configuration["fName"],
                            Configuration["lName"],
                            Configuration["address"],
                            Configuration["city"],
                            "Alaska",
                            "12312",
                            "United States",
                            Configuration["phone"]
                        );

            var loginPage = new LoginPage(Driver, _storeLoginURL);
            var registerPage = loginPage.Register(user);
            
            if (registerPage.DoesElementExist(ACCOUNT_ALREADY_CREATED))
            {
                        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
            }
            else
            {
                var registeredUserPage = registerPage.Register(user, address);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(registeredUserPage.DoesElementExist(LOGGEDIN_MESSAGE));
            }
        }

        [Test]
        public void TestLogin()
        {
            
        }
    }
}
