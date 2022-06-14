using Allure.Commons;
using Microsoft.Extensions.Configuration;
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

        protected IConfiguration Configuration { get; set; }

        protected static IWebDriver Driver
        {
            get => _driver;
        }

        

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<BaseTest>();

            Configuration = builder.Build();

            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public static void Setup()
        {
            try
            {
                //_driver = new RemoteWebDriver(new System.Uri(_url), new ChromeOptions());
                _driver = new ChromeDriver();
            }
            catch
            {
                throw new System.Exception("wrong url for remote web driver");
            }

            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(2);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}