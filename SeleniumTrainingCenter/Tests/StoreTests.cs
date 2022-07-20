using SeleniumTrainingCenter.PageObjects;
using SeleniumTrainingCenter.InfoObjects;
using SeleniumTrainingCenter.InfoObjects.Enums;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTrainingCenter.Tests.Bases;
using SeleniumTrainingCenter.Providers;

namespace SeleniumTrainingCenter.Tests
{
    [TestFixture(Description = "Automationpractice store tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/AndriusBogda/SelfimprovmentTraining")]
    [TestClass]
    public class StoreTests : BaseTest
    {
        private static readonly string _storeLoginURL = @"http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string _wishlist_url = @"http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        private readonly string _store_url = @"http://automationpractice.com/index.php?id_category=3&controller=category";
        private readonly string cart_url = @"http://automationpractice.com/index.php?controller=order";

        private string LOGGEDIN_MESSAGE = "p.info-account";

        private Person user;
        private UserAddress address;

        [OneTimeSetUp]
        public void SetupInfo()
        {
            user = new Person
                        (
                            Titles.Mr,
                            Configuration["fName"],
                            Configuration["lName"],
                            Configuration["email"],
                            Configuration["password"],
                            new DateOnly(2001, 03, 17)
                        );

            address = new UserAddress
                        (
                            Configuration["fName"],
                            Configuration["lName"],
                            Configuration["address"],
                            Configuration["city"],
                            "Alaska",
                            "12312",
                            "United States",
                            Configuration["phone"]
                        );
        }

        [Test]
        public void TestRegister()
        {
            var ACCOUNT_ALREADY_CREATED = "#create_account_error";
            var loginPage = PageProvider.LoginPage;
            loginPage.Load(_storeLoginURL);

            try
            {
                AssertLocation(_storeLoginURL);
            }
            catch
            {
                loginPage.Load(_storeLoginURL);
                loginPage.RefreshPage();
            }

            var registerPage = loginPage.Register(user);
            
            if (registerPage.DoesElementExist(ACCOUNT_ALREADY_CREATED))
            {
                        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true, "could not procceed to the register page");
            }
            else
            {
                var registeredUserPage = registerPage.Register(user, address);
                
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(registeredUserPage.DoesElementExist(LOGGEDIN_MESSAGE), "Could not register");
            }
        }

        [Test]
        public void TestLogin()
        {
            var loginPage = PageProvider.LoginPage;
            loginPage.Load(_storeLoginURL);

            try
            {
                AssertLocation(_storeLoginURL);
            }
            catch
            {
                loginPage.Load(_storeLoginURL);
                loginPage.RefreshPage();
            }

            var loggedIn = loginPage.Login(user);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(loggedIn.DoesElementExist(LOGGEDIN_MESSAGE), "Did not log in to the account page");
        }

        // Need to remove all wishlists before running
        [Test]
        public void TestAddToAutoWishlist()
        {
            var loginPage = PageProvider.LoginPage;
            loginPage.Load(_storeLoginURL);

            try
            {
                AssertLocation(_storeLoginURL);
            }
            catch
            {
                loginPage.Load(_storeLoginURL);
                loginPage.RefreshPage();
            }

            loginPage.Login(user);
            var wishlists = PageProvider.WishlistPage;
            wishlists.Load(_wishlist_url);

            try
            {
                AssertLocation(_wishlist_url);
            }
            catch
            {
                wishlists.Load(_wishlist_url);
                wishlists.RefreshPage();
            }

            if (wishlists.AreThereAnyWishlists())
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(false, "There already is a wishlist created");
            }
            else
            {
                var store = PageProvider.StorePage;
                store.Load(_store_url);

                try
                {
                    AssertLocation(_store_url);
                }
                catch
                {
                    store.Load(_store_url);
                    store.RefreshPage();
                }

                store.AddItemToWishlist();
                wishlists = PageProvider.WishlistPage;
                wishlists.Load(_wishlist_url);

                try
                {
                    AssertLocation(_wishlist_url);
                }
                catch
                {
                    wishlists.Load(_wishlist_url);
                    wishlists.RefreshPage();
                }

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "A wishlist was not created");
            }
        }

        [Test]
        public void TestAddToWishlist()
        {
            var loginPage = PageProvider.LoginPage;
            loginPage.Load(_storeLoginURL);

            try
            {
                AssertLocation(_storeLoginURL);
            }
            catch
            {
                loginPage.Load(_storeLoginURL);
                loginPage.RefreshPage();
            }

            loginPage.Login(user);
            var wishlists = PageProvider.WishlistPage;
            wishlists.Load(_wishlist_url);

            if (wishlists.AreThereAnyWishlists())
            {
                var store = PageProvider.StorePage;
                store.Load(_store_url);

                try
                {
                    AssertLocation(_store_url);
                }
                catch
                {
                    store.Load(_store_url);
                    store.RefreshPage();
                }

                store.AddItemToWishlist();
                wishlists = PageProvider.WishlistPage;
                wishlists.Load(_wishlist_url);

                try
                {
                    AssertLocation(_wishlist_url);
                }
                catch
                {
                    wishlists.Load(_wishlist_url);
                    wishlists.RefreshPage();
                }

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "Did not find find a wishlist");
            }
            else
            {
                wishlists.AddNewWishlist("newWishlist");

                var store = PageProvider.StorePage;
                store.Load(_store_url);

                try
                {
                    AssertLocation(_store_url);
                }
                catch
                {
                    store.Load(_store_url);
                    store.RefreshPage();
                }

                store.AddItemToWishlist();
                wishlists = PageProvider.WishlistPage;
                wishlists.Load(_wishlist_url);

                try
                {
                    AssertLocation(_wishlist_url);
                }
                catch
                {
                    wishlists.Load(_wishlist_url);
                    wishlists.RefreshPage();
                }

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "did not find a wishlist");
            }
        }

        [Test]
        public void TestAddToCart()//[alt='Faded Short Sleeve T-shirts']
        {
            var loginPage = PageProvider.LoginPage;
            loginPage.Load(_storeLoginURL);

            try
            {
                AssertLocation(_storeLoginURL);
            }
            catch
            {
                loginPage.Load(_storeLoginURL);
                loginPage.RefreshPage();
            }

            loginPage.Login(user);
            var store = PageProvider.StorePage;
            store.Load(_store_url);

            try
            {
                AssertLocation(_store_url);
            }
            catch
            {
                store.Load(_store_url);
                store.RefreshPage();
            }

            store.AddThreeItemsToCart();
            var cart = PageProvider.CartPage;
            cart.Load(cart_url);

            try
            {
                AssertLocation(cart_url);
            }
            catch
            {
                cart.Load(cart_url);
                cart.RefreshPage();
            }
            //cart.RefreshPage();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(cart.AreThreeItemsAdded(), "could not find the default items in the cart page");
        }
    }
}
