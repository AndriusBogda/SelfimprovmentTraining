using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using System.Threading;

namespace SeleniumTrainingCenter.PageObjects
{
    public class BasePage : IPage
    {
        protected IWebDriver _driver;

        protected virtual IWebElement GetElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public bool DoesElementExist(string xPath)
        {
            try
            {
                GetElement(By.CssSelector(xPath));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
            Thread.Sleep(30);
        }

        public void TakeScreenshot(string path)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile($"{path}.jpg");
            }
            catch
            {
                throw new ArgumentException("wrong given path");
            }
        }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public BasePage(IWebDriver driver, string url) : this(driver)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
