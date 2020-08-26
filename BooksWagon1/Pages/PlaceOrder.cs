//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace BooksWagon1.Pages
{
    /// <summary>
    /// Stores all web elements 
    /// </summary>
    public class PlaceOrder
    {

        public const string ORDER_VALIDATE = "Your order details will be sent to this email address.";
        public  IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceOrder"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public PlaceOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        ///web elements 
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement cartFrame;

        [FindsBy(How = How.XPath, Using = "//input[@id='BookCart_lvCart_imgPayment']")]
        public IWebElement placeOrder;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/form[1]/div[3]/div[3]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/a[1]")]
        public IWebElement continueButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your order details will be sent to this email addr')]")]
        public IWebElement validation;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/form[1]/div[4]/div[3]/div[3]/div[2]/div[1]/div[4]/div[5]/a[1]/input[1]")]
        public IWebElement buyNow;

        /// <summary>
        /// To order book from bookswagon 
        /// </summary>
        public void OrderBook()
        {
            buyNow.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(cartFrame);
            Thread.Sleep(5000);
            placeOrder.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            Assert.AreEqual(ORDER_VALIDATE, validation.Text);
            continueButton.Click();
        }
    }
}
