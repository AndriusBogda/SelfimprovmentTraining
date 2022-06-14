using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects
{
    public class LoginPage : BasePage, ILoginPage
    {
        public LoginPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public ILoginPage Login(Person person)
        {
            By EMAIL_INPUT = By.CssSelector("#email");
            By PASSWORD_INPUT = By.CssSelector("#passwd");
            By LOGIN_BUTTON = By.CssSelector("#SubmitLogin");

            GetElement(EMAIL_INPUT).SendKeys(person.Email);
            GetElement(PASSWORD_INPUT).SendKeys(person.Password);
            GetElement(LOGIN_BUTTON).Click();

            return this;
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
