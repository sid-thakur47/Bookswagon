using AventStack.ExtentReports;
using Bookswagon.ExcelReader;
using Bookswagon.Pages;
using BooksWagon1.Base;
using BooksWagon1.Pages;
using NUnit.Framework;
using System.Threading;

namespace Bookswagon.Test
{
    public class BooksWagonTest : BooksWagonBase

    {
        public const string LOGIN_VALIDATE = "Personal Settings";
        public const string HOME_VALIDATE = "Refine your Search";
        public const string SHIPPING_VALIDATE = "Shipping Address";
        public const string ORDER_VALIDATE = "Review your Order\r\nView Cart";

        Credentials credentials = new Credentials();

        [Test, Order(1)]
        public void LoginTest()
        {
                Login login = new Login(driver);
                test = extent.CreateTest("Login Test");
                test.Log(Status.Info, "Login Test started");
                login.BookwagonLogin(credentials.userName, credentials.pass);
                Assert.AreEqual(LOGIN_VALIDATE, login.Validate());
        }

        [Test, Order(2)]
        public void HomePageTest()
        {
            test = extent.CreateTest("Homepage Test");
            log.Info("Starting Homepage Test");
            Homepage home = new Homepage(driver);
            home.SearchItem("cobain");
            Assert.AreEqual(HOME_VALIDATE, home.Validate());
        }

        [Test, Order(3)]
        public void PlaceOrderTest()
        {
            test = extent.CreateTest("PlaceOrder Test");
            log.Info("Placing order");
            PlaceOrder order = new PlaceOrder(driver);
            order.OrderBook();
            Thread.Sleep(6000);
        }

        [Test, Order(4)]
        public void CartCheckoutTest()

        {
            test = extent.CreateTest("AddShipping Details Test");
            log.Info("Adding shipping details");
            ShippingAdress cart = new ShippingAdress(driver);
            Assert.AreEqual(SHIPPING_VALIDATE, cart.Validate());
            cart.AddShippingDetails("siddhesh", "ulwe", "India", "Maharashtra", "panvel", "410206", "8097155154");
        }

        [Test, Order(5)]
        public void ReviewOrderTest()
        {
            test = extent.CreateTest("Review Order Test");
            log.Info("Checking order");
            ReviewOrder order = new ReviewOrder(driver);
            Assert.AreEqual(ORDER_VALIDATE, order.Validate());
            order.OrderReview();
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            test = extent.CreateTest("Logout Test");
            log.Info("Sign out from bookswagon");
            Login login = new Login(driver);
            login.Logout();
        }

        [OneTimeTearDown]
        public void close()
        {
            driver.Quit();
            SendEmail("sidthakur6433@gmail.com",credentials.ePass);


        }
    }
}
