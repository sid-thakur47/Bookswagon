//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Configuration;
using System.Threading;

namespace BooksWagon1.Pages
{
    /// <summary>
    /// Stores all web elements of shipping address page
    /// </summary>
    public class ShippingAdress
    {
        /// <summary>
        /// Read data from config file
        /// </summary>
        readonly string name = ConfigurationManager.AppSettings["userName"];
        readonly string addr = ConfigurationManager.AppSettings["address"];
        readonly string state = ConfigurationManager.AppSettings["state"];
        readonly string city = ConfigurationManager.AppSettings["city"];
        readonly string pin = ConfigurationManager.AppSettings["pinCode"];
        readonly string mobileNumber = ConfigurationManager.AppSettings["phoneNumber"];
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingAdress"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public ShippingAdress(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$txtNewRecipientName']")]
        public IWebElement recipientName;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='ctl00$cpBody$txtNewAddress']")]
        public IWebElement address;

        [FindsBy(How = How.XPath, Using = "//select[@name='ctl00$cpBody$ddlNewState']")]
        public IWebElement selectState;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$txtNewPincode']")]
        public IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$txtNewMobile']")]
        public IWebElement mobile;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$txtNewCity']")]
        public IWebElement addCity;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$cpBody$imgSaveNew']")]
        public IWebElement saveAndContinue;

        [FindsBy(How = How.XPath, Using = "//div[@class='title']")]
        public IWebElement validation;
        
        /// <summary>
        /// Validate shipping address page
        /// </summary>
        /// <returns>web element for title of page</returns>
        public IWebElement Validate()
        {
            return validation;
        }

        /// <summary>
        /// add shipping details of the user
        /// </summary>
        public void AddShippingDetails()
        {
            recipientName.SendKeys(name);
            Thread.Sleep(1000);
            address.SendKeys(addr);
            Thread.Sleep(1000);
            SelectElement state1 = new SelectElement(selectState);
            state1.SelectByText(state);
            Thread.Sleep(5000);
            addCity.SendKeys(city);
            Thread.Sleep(5000);
            pinCode.SendKeys(pin);
            Thread.Sleep(5000);
            mobile.SendKeys(mobileNumber);
            Thread.Sleep(5000);
            saveAndContinue.Click();
        } 
    }
}
