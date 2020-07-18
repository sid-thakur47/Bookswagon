using Bookswagon.ExcelReader;
using Bookswagon.Pages;
using BooksWagon1.Base;
using NUnit.Framework;

namespace Bookswagon.Test
{
   public class LoginTest :BooksWagonBase

    {

        Credentials credentials = new Credentials();

        [Test]
            public void BooksWagonTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin(credentials.userName,credentials.pass);
            string title=  driver.Title;
            Assert.AreEqual(credentials.title, title);
            driver.Quit();
        }

    }
}
