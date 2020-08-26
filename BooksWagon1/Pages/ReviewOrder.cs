//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace BooksWagon1.Pages
{
    /// <summary>
    /// Stores all web elements 
    /// </summary>
    public class ReviewOrder
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewOrder"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public ReviewOrder(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//textarea[@name='ctl00$cpBody$ShoppingCart$lvCart$txtGiftMessage']")]
        public IWebElement message;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$ShoppingCart$lvCart$savecontinue']")]
        public IWebElement saveAndContinue;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Review your Order')]")]
        public IWebElement validation;

        /// <summary>
        /// review the book order 
        /// </summary>
        public void OrderReview()
        {
            message.SendKeys("Happy Birthday");
            Thread.Sleep(1000);
            saveAndContinue.Click();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// validate order review
        /// </summary>
        public IWebElement Validate()
        {
            return validation;
        }
    }
}
