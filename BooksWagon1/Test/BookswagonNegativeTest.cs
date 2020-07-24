using Bookswagon.Pages;
using BooksWagon1.Base;
using NUnit.Framework;
using static BooksWagon1.Utils.Utility;

namespace BooksWagon1.Test
{
    [TestFixture]
    [Parallelizable]
   public class BookswagonNegativeTest : BooksWagonBase
    {
        public BookswagonNegativeTest(): base(Browser.FIREFOX)
        {

        }

        [Test]
        public void NegativeLoginTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin("userName", "pass");
        }

        [OneTimeTearDown]
        public void CLoseBrowser()
        {
            driver.Quit();
        }
    }
}
