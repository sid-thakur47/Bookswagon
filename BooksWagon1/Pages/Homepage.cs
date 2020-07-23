using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace BooksWagon1.Pages
{
    public class Homepage
    {
        public Homepage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_txtSearch")]
        public IWebElement search;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_TopSearch1_Button1']")]
        public IWebElement searchIcon;

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Refine your Search')]")]
        public  IWebElement validation;

        [FindsBy(How = How.XPath, Using = "//img[@id='ctl00_imglogo']")]
        public IWebElement home;


        public void SearchItem(String bookName)
        {
            home.Click();
            Thread.Sleep(10000);
            search.SendKeys(bookName);
            Thread.Sleep(2000);
            searchIcon.Click();
            Thread.Sleep(50000);
        }

        public IWebElement Validate()
        {
            return validation;
        }
    }
}
