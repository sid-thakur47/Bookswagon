using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void SearchItem()
        {
            search.SendKeys("Cobain" + Keys.Enter);
            Thread.Sleep(2000);
            searchIcon.Click();
        }
    }
}
