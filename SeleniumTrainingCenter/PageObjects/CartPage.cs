using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;

namespace SeleniumTrainingCenter.PageObjects
{
    public class CartPage : BasePage, ICartPage
    {
        private string FADED_TSHIRT = "[alt='Faded Short Sleeve T-shirts']";
        private string BLOUSE = "[alt='Blouse']";
        private string PRINTED_DRESS = "[alt='Printed Dress']";

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public CartPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public bool AreThreeItemsAdded()
        {
            return
            DoesElementExist(FADED_TSHIRT) &&
            DoesElementExist(BLOUSE) &&
            DoesElementExist(PRINTED_DRESS);
        }
    }
}
