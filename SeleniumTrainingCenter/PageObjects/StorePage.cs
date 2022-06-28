using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;

namespace SeleniumTrainingCenter.PageObjects
{
    public class StorePage : BasePage, IStorePage
    {
        private By ADD_TO_CART_CLOTHINGONE = By.XPath("//a[@data-id-product='1'][descendant::span]");
        private By ADD_TO_CART_CLOTHINGTWO = By.XPath("//a[@data-id-product='2'][descendant::span]");
        private By ADD_TO_CART_CLOTHINGTHREE = By.XPath("//a[@data-id-product='3'][descendant::span]");

        public StorePage(IWebDriver driver) : base(driver)
        {
        }

        public StorePage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public IStorePage AddItemToWishlist()
        {
            var WISHLIST_HREF = By.XPath("//*[contains(text(),'Add to Wishlist')]");
            GetElement(WISHLIST_HREF).Click();

            return this;
        }

        public IStorePage AddThreeItemsToCart()
        {
            GetElement(ADD_TO_CART_CLOTHINGONE).Click();
            GetElement(ADD_TO_CART_CLOTHINGTWO).Click();
            GetElement(ADD_TO_CART_CLOTHINGTHREE).Click();

            return this;
        }
    }
}
