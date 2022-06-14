using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;

namespace SeleniumTrainingCenter.PageObjects
{
    public class WishlistPage : BasePage, IWishListPage
    {
        public WishlistPage(IWebDriver driver) : base(driver)
        {
        }

        public WishlistPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public void AddNewWishlist(string wishlistName)
        {
            var WISHLIST_NAME_INPUT = By.CssSelector("#name");
            var WISHLIST_CREATE_BUTTON = By.CssSelector("#submitWishlist");

            GetElement(WISHLIST_NAME_INPUT).SendKeys(wishlistName);
            GetElement(WISHLIST_CREATE_BUTTON).Click();
        }

        public bool AreThereAnyWishlists()
        {
            var WISHLIST_TABLE = "#block-history";

            return base.DoesElementExist(WISHLIST_TABLE);
        }
    }
}
