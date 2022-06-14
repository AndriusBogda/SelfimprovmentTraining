using Allure.Commons;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace SeleniumTrainingCenter.Tests.Bases
{
    public class BaseTest
    {
        private static IWebDriver _driver;
        private static int _switchState = 0;

        private static string _url = @"http://localhost:4444/wd/hub/";

        protected IConfiguration Configuration { get; set; }

        protected static IWebDriver Driver
        {
            get => _driver;
        }

        public void Switch(DriverOptions driverOptions)
        {
            _switchState++; 
            if (_switchState == 0)
            {
                _driver = new ChromeDriver();
            }
            else if (_switchState == 1)
            {
                _driver = new RemoteWebDriver(new System.Uri(_url), new ChromeOptions());
            }
            else if (_switchState == 2)
            {
                var sauceOptions = new Dictionary<string, object>();
                //sauceOptions.Add("name", TestContext.TestName);
                sauceOptions.Add("username", Environment.GetEnvironmentVariable("SauceLabsMyUsername", EnvironmentVariableTarget.User));
                sauceOptions.Add("accessKey", Environment.GetEnvironmentVariable("SauceLabsMyAccessKey", EnvironmentVariableTarget.User));

                var browserOptions = driverOptions;
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var sauceUrl = new Uri("https://ondemand.eu-central-1.saucelabs.com/wd/hub");

                _driver = new RemoteWebDriver(sauceUrl, browserOptions);
            }
            else
            {
                _switchState = 0;
            }
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