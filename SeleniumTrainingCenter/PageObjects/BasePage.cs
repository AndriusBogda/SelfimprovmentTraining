using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using System.Threading;

namespace SeleniumTrainingCenter.PageObjects
{
    public class BasePage : Page,  IPage
    {
        protected virtual IWebElement GetElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public bool IsElementVisible(By by)
        {
            return GetElement(by).Displayed;
        }

        public bool IsElementClickable(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch
            {
                return false;
            }

            return true;
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

        public void WaitUntilMethodMatchesCondition(bool expected, Func<By, bool> method, By by)
        {
            Thread thread = new Thread
                (() =>{ 

                });

            while(true)
            {
                if (method(by) == expected)
                {
                    return;
                }
            }
        }

        public void ValidateDropdown(string[] expected, By by)
        {
            var dropdown = GetElement(by);
            SelectElement select = new(dropdown);

            bool isMatch;

            var elements = select.Options;
            foreach (var element in elements)
            {
                isMatch = false;

                foreach (var item in expected)
                {
                    if (element.Text == item)
                    {
                        isMatch = true;
                    }
                }

                if (!isMatch)
                {
                    throw new InvalidSelectorException($"expected element was not found in {by.ToString()} select");
                }
            }
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
            Thread.Sleep(30);
        }

        public void Load(string url)
        {
            _driver.Navigate().GoToUrl(url);
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

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        public BasePage(IWebDriver driver, string url) : base(driver, url)
        {
        }
    }
}
