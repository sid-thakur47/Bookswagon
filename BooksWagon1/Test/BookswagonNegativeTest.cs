//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Bookswagon.Pages;
using BooksWagon1.Base;
using NUnit.Framework;
using System.Configuration;
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
        readonly string email = ConfigurationManager.AppSettings["email"]; 
        readonly string wrongPassword = ConfigurationManager.AppSettings["wrongpass"];
        readonly string invalidEmail = ConfigurationManager.AppSettings["emailValidation"];
        readonly string required = ConfigurationManager.AppSettings["required"];
        readonly string wrongPass = ConfigurationManager.AppSettings["wrongpassValidation"];

        [Test,Order(1)]
        public void WrongUserNameTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin("userName", wrongPassword);
            Assert.AreEqual(invalidEmail, login.NegativeValidate("wrongName"));
        }

        [Test, Order(2)]
        public void EmptyUserNameTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin("", wrongPassword);
            Assert.AreEqual(required, login.NegativeValidate("emptyEmail"));
        }

        [Test, Order(3)]
        public void EmptyPasswordTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin(email, "");
            Assert.AreEqual(required, login.NegativeValidate("emptyPass"));
        }

        [Test, Order(4)]
        public void WrongPasswordTest()
        {
            Login login = new Login(driver);
            login.BookwagonLogin(email, wrongPassword);
            Assert.AreEqual(wrongPass, login.NegativeValidate("wrongPass"));  
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
