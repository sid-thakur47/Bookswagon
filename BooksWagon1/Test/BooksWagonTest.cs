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
        Credentials credentials = new Credentials();

        [Test, Order(1)]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin(credentials.userName, credentials.pass);
            Assert.IsTrue(login.Validate("login").Displayed);
        }

        [Test, Order(2)]
        public void HomePageTest()
        {
            log.Info("Starting Homepage Test");
            Homepage home = new Homepage(driver);
            home.SearchItem("cobain");
            Assert.IsTrue(home.Validate().Displayed);
        }

        [Test, Order(3)]
        public void PlaceOrderTest()
        {
            log.Info("Placing order");
            PlaceOrder order = new PlaceOrder(driver);
            order.OrderBook();
            Thread.Sleep(6000);
        }

        [Test, Order(4)]
        public void CartCheckoutTest()

        {
            log.Info("Adding shipping details");
            ShippingAdress cart = new ShippingAdress(driver);
            Assert.IsTrue(cart.Validate().Displayed);
            cart.AddShippingDetails("siddhesh", "ulwe", "India", "Maharashtra", "panvel", "410206", "8097155154");
        }

        [Test, Order(5)]
        public void ReviewOrderTest()
        {
            log.Info("Checking order");
            ReviewOrder order = new ReviewOrder(driver);
            Assert.IsTrue( order.Validate().Displayed);
            order.OrderReview();
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            log.Info("Sign out from bookswagon");
            Login login = new Login(driver);
            login.Logout();
            Assert.IsTrue(login.Validate("logout").Displayed);
        }

        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
           // SendEmail("sidthakur6433@gmail.com", credentials.ePass);
        }
    }
}
