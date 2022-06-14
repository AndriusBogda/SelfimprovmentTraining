using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;

namespace SeleniumTrainingCenter.PageObjects
{
    public class CartPage : BasePage, ICartPage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public CartPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public bool AreThreeItemsAdded()
        {
            var FADED_TSHIRT = "[alt='Faded Short Sleeve T-shirts']";
            var BLOUSE = "[alt='Blouse']";
            var PRINTED_DRESS = "[alt='Printed Dress']";

            if (!DoesElementExist(FADED_TSHIRT))
            {
                return false;
            }
            if (!DoesElementExist(BLOUSE))
            {
                return false;
            }
            if (!DoesElementExist(PRINTED_DRESS))
            {
                return false;
            }

            return true;
        }
    }
}
