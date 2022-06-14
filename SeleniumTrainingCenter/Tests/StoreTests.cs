using SeleniumTrainingCenter.PageObjects;
using SeleniumTrainingCenter.InfoObjects;
using SeleniumTrainingCenter.InfoObjects.Enums;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTrainingCenter.Tests.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SeleniumTrainingCenter.Tests
{
    [TestFixture(Description = "Automationpractice store tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/AndriusBogda/SeleniumTrainingCenter")]
    [TestClass]
    public class StoreTests : BaseTest
    {
        private readonly string _storeLoginURL = @"http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string _wishlist_url = @"http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";

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

            var loginPage = new LoginPage(Driver, _storeLoginURL);
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
            var loginPage = new LoginPage(Driver, _storeLoginURL);
            var loggedIn = loginPage.Login(user);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(loggedIn.DoesElementExist(LOGGEDIN_MESSAGE), "Did not log in to the account page");
        }

        // Need to remove all wishlists before running
        [Test]
        public void TestAddToAutoWishlist()
        {
            var store_url = @"http://automationpractice.com/index.php?id_category=3&controller=category";

            var loginPage = new LoginPage(Driver, _storeLoginURL);
            loginPage.Login(user);
            var wishlists = new WishlistPage(Driver, _wishlist_url);
            if (wishlists.AreThereAnyWishlists())
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(false, "There already is a wishlist created");
            }
            else
            {
                var store = new StorePage(Driver, store_url);
                store.AddItemToWishlist();
                wishlists = new WishlistPage(Driver, _wishlist_url);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "A wishlist was not created");
            }
        }

        [Test]
        public void TestAddToWishlist()
        {
            var store_url = @"http://automationpractice.com/index.php?id_category=3&controller=category";

            var loginPage = new LoginPage(Driver, _storeLoginURL);
            loginPage.Login(user);
            var wishlists = new WishlistPage(Driver, _wishlist_url);
            if (wishlists.AreThereAnyWishlists())
            {
                var store = new StorePage(Driver, store_url);
                store.AddItemToWishlist();
                wishlists = new WishlistPage(Driver, _wishlist_url);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "Did not find find a wishlist");
            }
            else
            {
                wishlists.AddNewWishlist("newWishlist");

                var store = new StorePage(Driver, store_url);
                store.AddItemToWishlist();
                wishlists = new WishlistPage(Driver, _wishlist_url);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(wishlists.AreThereAnyWishlists(), "did not find a wishlist");
            }
        }

        [Test]
        public void TestAddToCart()//[alt='Faded Short Sleeve T-shirts']
        {
            var store_url = @"http://automationpractice.com/index.php?id_category=3&controller=category";
            var cart_url = @"http://automationpractice.com/index.php?controller=order";

            var loginPage = new LoginPage(Driver, _storeLoginURL);
            loginPage.Login(user);
            var store = new StorePage(Driver, store_url);
            store.AddThreeItemsToCart();
            var cart = new CartPage(Driver, cart_url);
            cart.RefreshPage();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(cart.AreThreeItemsAdded(), "could not find the default items in the cart page");
        }
    }
}
