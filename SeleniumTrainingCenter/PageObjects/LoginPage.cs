using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects
{
    public class LoginPage : BasePage, ILoginPage
    {
        private By EMAIL_INPUT = By.CssSelector("#email");
        private By PASSWORD_INPUT = By.CssSelector("#passwd");
        private By LOGIN_BUTTON = By.CssSelector("#SubmitLogin");

        private By EMAIL_CREATE_INPUT = By.CssSelector("#email_create");
        private By CREATEACCOUNT_BUTTON = By.CssSelector("#SubmitCreate");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public LoginPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public ILoginPage Login(Person person)
        {
            GetElement(EMAIL_INPUT).SendKeys(person.Email);
            GetElement(PASSWORD_INPUT).SendKeys(person.Password);
            GetElement(LOGIN_BUTTON).Click();

            return this;
        }

        public IRegisterPage Register(Person person)
        {
            GetElement(EMAIL_CREATE_INPUT).SendKeys(person.Email);
            GetElement(CREATEACCOUNT_BUTTON).Click();
;
            return new RegisterPage(this._driver);
        }
    }
}
