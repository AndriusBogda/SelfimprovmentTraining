using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using System.Threading;

namespace SeleniumTrainingCenter.PageObjects
{
    public class Page
    {
        protected IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public Page(IWebDriver driver, string url) : this(driver)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
