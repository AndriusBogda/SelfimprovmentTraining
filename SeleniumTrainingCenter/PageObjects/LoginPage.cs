using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using System.Configuration;

namespace SeleniumTrainingCenter.PageObjects
{
    public class LoginPage : BasePage, ILoginPage
    {
        public LoginPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public ILoginPage Login(object emailBy, object passwordBy)
        {
            throw new NotImplementedException();
        }

        public ILoginPage Register(object loginInfo)
        {
            //PERSONAL
            By FIRSTNAME_INPUT = By.CssSelector("#customer_firstname");
            By LASTNAME_INPUT = By.CssSelector("#customer_lastname");
            By EMAIL_INPUT = By.CssSelector("#email");
            By PASSWORD_INPUT = By.CssSelector("#passwd");

            By DAYS_SELECT = By.CssSelector("#days");
            By MONTHS_SELECT = By.CssSelector("#uniform-months");
            By YEARS_SELECT = By.CssSelector("#uniform-years");

            //ADDRESS
            By FIRSTNAME_ADDRESS_INPUT = By.CssSelector("[name=firstname]");
            By LASTNAME_ADDRESS_INPUT = By.CssSelector("[name=lastname]");
            By ADDRESS_INPUT = By.CssSelector("#address1");
            By CITY_INPUT = By.CssSelector("#city");
            By STATE_SELECT = By.CssSelector("#id_state");
            By ZIP_INPUT = By.CssSelector("#postcode");
            By COUNTY_SELECT = By.CssSelector("#id_country");
            By PHONE_INPUT = By.CssSelector("#phone_mobile");

            By REGISTER_BUTTON = By.CssSelector("#submitAccount");
            
            //GetElement(FIRSTNAME_INPUT).SendKeys();

            return this;
        }
    }
}
