using OpenQA.Selenium;
using SeleniumTrainingCenter.PageObjects.Interfaces;
using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects
{
    public class MyAccountPage : BasePage, IMyAccountPage
    {
        private By WOMENCLOTHING_HREF = By.CssSelector("a.sf-with-ul[Title='Women']");

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }
        public MyAccountPage(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public IWishListPage OpenWishlists()
        {
            var WISHLIST_HREF = By.CssSelector("a[title='My wishlists']");

            return new WishlistPage(_driver, GetElement(WISHLIST_HREF).GetAttribute("href"));
        }

        public IStorePage OpenWomenClothing()
        {
            return new StorePage(_driver, GetElement(WOMENCLOTHING_HREF).GetAttribute("href"));
        }
    }
}
