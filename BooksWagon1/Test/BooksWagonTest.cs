using Bookswagon.ExcelReader;
using Bookswagon.Pages;
using BooksWagon1.Base;
using BooksWagon1.Pages;
using NUnit.Framework;

namespace Bookswagon.Test
{
   public class BooksWagonTest :BooksWagonBase

    {
        Credentials credentials = new Credentials();
       
        [Test,Order(1)]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin(credentials.userName, credentials.pass);
            string title = driver.Title;
            Assert.AreEqual(credentials.title, title);
            //driver.Quit();
        }

        [Test,Order(2)]
        public void HomePageTest()
        {
            Homepage home = new Homepage(driver);
            home.SearchItem();
        }

        [Test,Order(3)]
        public void LogoutTest()
        {
            Login login = new Login(driver);
            login.Logout();

        }

    }
}
