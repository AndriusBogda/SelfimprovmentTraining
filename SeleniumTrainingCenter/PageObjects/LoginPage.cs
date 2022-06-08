using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using System;
using SeleniumTrainingCenter.InfoObjects;

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

        public IRegisterPage Register(Person person)
        {
            By EMAIL_INPUT = By.CssSelector("#email_create");
            By CREATEACCOUNT_BUTTON = By.CssSelector("#SubmitCreate");

            GetElement(EMAIL_INPUT).SendKeys(person.Email);
            GetElement(CREATEACCOUNT_BUTTON).Click();
;
            return new RegisterPage(this._driver);
        }
    }
}
