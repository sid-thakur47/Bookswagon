//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Bookswagon.ExcelReader;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Pages
{
    /// <summary>
    /// Stores all web elements of login page
    /// </summary>
    public class Login
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtEmail']")]
        public IWebElement username;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtPassword")]
        public IWebElement pass;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_btnLogin")]
        public IWebElement loginbutton;

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]
        public IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//span[@class='login-bg sprite usermenu-bg']")]
        public IWebElement menu;

        [FindsBy(How = How.XPath, Using = "//div[@class='ac-container']//li[1]//a[1]")]
        public IWebElement validation;

        [FindsBy(How = How.XPath, Using = "//img[@id='ctl00_imglogo']")]
        public IWebElement home;

        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_phBody_SignIn_reEmail']")]
        public IWebElement wrongName;

        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_phBody_SignIn_rfvPassword']")]
        public IWebElement passRequired;

        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_phBody_SignIn_rfvEmail']")]
        public IWebElement emailRequired;

        [FindsBy(How = How.XPath, Using = "//label[@id='ctl00_phBody_SignIn_lblmsg']")]
        public IWebElement wrongPass;

        /// <summary>
        /// To login into Bookwagon application
        /// </summary>
        public void BookwagonLogin(string email, string password)
        {
            username.SendKeys(email);
            Thread.Sleep(5000);
            pass.SendKeys(password);
            Thread.Sleep(5000);
            loginbutton.Click();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// To logout from Bookwagon application
        /// </summary>
        public void Logout()
        {
            home.Click();
            Thread.Sleep(1000);
            menu.Click();
            Thread.Sleep(5000);
            logout.Click();
        }

        /// <summary>
        /// To validate login page
        /// </summary>
        public IWebElement Validate(string type)
        {
            if (type.Equals("login"))
            {
                return validation;
            }
            else if (type.Equals("logout"))
            {
                return loginbutton;
            }
            return wrongName;
        }

        public string NegativeValidate(string type)
        {
            if (type.Equals("wrongName"))
            {
                return wrongName.Text;
            }
            else if (type.Equals("emptyPass"))
            {
                return passRequired.Text;
            }
            else if (type.Equals("emptyEmail"))
            {
                return emailRequired.Text;
            }
            else if (type.Equals("wrongPass"))
            {
                return wrongPass.Text;
            }
            return null;
        }
    }
}
