using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects
{
    public class RegisterPage : BasePage, IRegisterPage
    {
        //PERSONAL
        private By FIRSTNAME_INPUT = By.CssSelector("#customer_firstname");
        private By LASTNAME_INPUT = By.CssSelector("#customer_lastname");
        private By EMAIL_INPUT = By.CssSelector("#email");
        private By PASSWORD_INPUT = By.CssSelector("#passwd");

        private By DAYS_SELECT = By.CssSelector("#days");
        private By MONTHS_SELECT = By.CssSelector("#months");
        private By YEARS_SELECT = By.CssSelector("#years");

        //ADDRESS
        private By FIRSTNAME_ADDRESS_INPUT = By.CssSelector("[name=firstname]");
        private By LASTNAME_ADDRESS_INPUT = By.CssSelector("[name=lastname]");
        private By ADDRESS_INPUT = By.CssSelector("#address1");
        private By CITY_INPUT = By.CssSelector("#city");
        private By STATE_SELECT = By.CssSelector("#id_state");
        private By ZIP_INPUT = By.CssSelector("#postcode");
        private By COUNTRY_SELECT = By.CssSelector("#id_country");
        private By PHONE_INPUT = By.CssSelector("#phone_mobile");

        private By REGISTER_BUTTON = By.CssSelector("#submitAccount");

        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }
        public RegisterPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public IRegisterPage Register(Person person, UserAddress userAddress)
        {
            //FILL PERSONAL INFO
            GetElement(FIRSTNAME_INPUT).SendKeys(person.FirstName);
            GetElement(LASTNAME_INPUT).SendKeys(person.LastName);
            GetElement(EMAIL_INPUT).Clear();
            GetElement(EMAIL_INPUT).SendKeys(person.Email);
            GetElement(PASSWORD_INPUT).SendKeys(person.Password);
            new SelectElement(GetElement(DAYS_SELECT)).SelectByValue(person.Birthday.Day.ToString());
            new SelectElement(GetElement(MONTHS_SELECT)).SelectByIndex(person.Birthday.Month);
            new SelectElement(GetElement(YEARS_SELECT)).SelectByValue(person.Birthday.Year.ToString());

            //FILL ADDRESS INFO
            GetElement(FIRSTNAME_ADDRESS_INPUT).SendKeys(userAddress.FirstName);
            GetElement(LASTNAME_ADDRESS_INPUT).SendKeys(userAddress.LastName);
            GetElement(ADDRESS_INPUT).SendKeys(userAddress.Address);
            GetElement(CITY_INPUT).SendKeys(userAddress.City);
            GetElement(ZIP_INPUT).SendKeys(userAddress.PostalCode);
            GetElement(PHONE_INPUT).SendKeys(userAddress.Phone.ToString());
            new SelectElement(GetElement(STATE_SELECT)).SelectByText(userAddress.State);
            new SelectElement(GetElement(COUNTRY_SELECT)).SelectByText(userAddress.Country);

            //GetElement(REGISTER_BUTTON).Click();

            return this;
        }
    }
}
