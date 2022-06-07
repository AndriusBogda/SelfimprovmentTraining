using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumTrainingCenter.Tests.Bases
{
    public class BaseTest
    {
        private static IWebDriver _driver;

        private static string _url = @"http://localhost:4444/wd/hub/";

        protected static IWebDriver Driver
        {
            get => _driver;
        }

        [SetUp]
        public static void Setup()
        {
            try
            {
                _driver = new RemoteWebDriver(new System.Uri(_url), new ChromeOptions());
            }
            catch
            {
                throw new System.Exception("wrong url for remote web driver");
            }
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}