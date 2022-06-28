using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;

namespace SeleniumTrainingCenter.PageObjects
{
    public class WishlistPage : BasePage, IWishListPage
    {
        private By WISHLIST_NAME_INPUT = By.CssSelector("#name");
        private By WISHLIST_CREATE_BUTTON = By.CssSelector("#submitWishlist");

        private string WISHLIST_TABLE = "#block-history";

        public WishlistPage(IWebDriver driver) : base(driver)
        {
        }

        public WishlistPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public void AddNewWishlist(string wishlistName)
        {
            GetElement(WISHLIST_NAME_INPUT).SendKeys(wishlistName);
            GetElement(WISHLIST_CREATE_BUTTON).Click();
        }

        public bool AreThereAnyWishlists()
        {
            return base.DoesElementExist(WISHLIST_TABLE);
        }
    }
}
