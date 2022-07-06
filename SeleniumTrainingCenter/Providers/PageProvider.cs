using SeleniumTrainingCenter.PageObjects.Interfaces;
using SeleniumTrainingCenter.PageObjects;
using OpenQA.Selenium;

namespace SeleniumTrainingCenter.Providers
{
    public class PageProvider
    {
        //should I make them all IPage or the exact type?
        private IPage _BasePage;
        private ICartPage _CartPage;
        private ILoginPage _LoginPage;
        private IMyAccountPage _MyAccountPage;
        private IRegisterPage _RegisterPage;
        private IStorePage _StorePage;
        private IWishListPage _WishlistPage;

        // should I return IPage or exact type?
        public IPage BasePage => _BasePage;
        public ICartPage CartPage => _CartPage;
        public ILoginPage LoginPage => _LoginPage;
        public IMyAccountPage MyAccountPage => _MyAccountPage;
        public IRegisterPage RegisterPage => _RegisterPage;
        public IStorePage StorePage => _StorePage;
        public IWishListPage WishlistPage => _WishlistPage;

        public PageProvider(IWebDriver driver)
        {
            _BasePage = new BasePage(driver);
            _CartPage = new CartPage(driver);
            _LoginPage = new LoginPage(driver);
            _MyAccountPage = new MyAccountPage(driver);
            _RegisterPage = new RegisterPage(driver);
            _StorePage = new StorePage(driver);
            _WishlistPage = new WishlistPage(driver);
        }
    }
}
