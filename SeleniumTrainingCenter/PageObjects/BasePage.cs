using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using System.Collections.ObjectModel;
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

        protected virtual ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public bool IsElementVisible(string css)
        {
            return GetElement(By.CssSelector(css)).Displayed;
        }

        public bool HasTextChanged(string originalText, string css)
        {
            var a = GetText(css);
            return a != originalText;
        }

        public bool IsElementClickable(string css)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string GetText(string css)
        {
            var a = GetElement(By.CssSelector(css)).GetDomProperty("value");
            return a;
        }

        // SELF NOTE:
        // Instead of this method
        // To check if elements exist should use FindElements and check if collection is empty or not.
        public bool DoesElementExist(string css)
        {
            try
            {
                GetElement(By.CssSelector(css));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WaitUntilMethodMatchesCondition(bool expected, Func<string, string, bool> method, string css, string methodString)
        {
            try
            {
                while (method(methodString, css).CompareTo(expected) != 0)
                {
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WaitUntilMethodMatchesCondition(bool expected, Func<string, bool> method, string css)
        {
            try
            {
                while (method(css).CompareTo(expected) != 0)
                {
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Should be in a different PageObject
        public bool ValidateSelectDropdown(string[] expected, string css)
        {
            var dropdown = GetElement(By.CssSelector(css));
            SelectElement select = new(dropdown);

            bool isMatch;

            var elements = select.Options;
            foreach (var element in expected)
            {
                isMatch = false;

                foreach (var item in elements)
                {
                    if (element.ToLower() == item.Text.ToLower())
                    {
                        isMatch = true;
                    }
                }

                if (!isMatch)
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateDropdown(string[] expected, string css)
        {
            var listElements = GetElements(By.CssSelector(css + " a"));

            bool isMatch;

            foreach (var expectedElement in expected)
            {
                isMatch = false;

                foreach (var listElement in listElements)
                {
                    var a = listElement.GetDomProperty("text").ToString().ToLower();
                    if (a.Contains(expectedElement.ToLower()))
                    {
                        isMatch = true;
                    }
                }

                if (!isMatch)
                {
                    return false;
                }
            }

            return true;
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

        // different PageObject ?
        public void SendKeys(string css, string keys)
        {
            GetElement(By.CssSelector(css)).SendKeys(keys);
        }

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        public BasePage(IWebDriver driver, string url) : base(driver, url)
        {
        }
    }
}
