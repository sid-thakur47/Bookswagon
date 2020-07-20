using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace BooksWagon1.Pages
{
    public class PlaceOrder
    {
        public  IWebDriver driver;
        public PlaceOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/form[1]/div[4]/div[3]/div[3]/div[2]/div[1]/div[4]/div[5]/a[1]/input[1]")]
        public IWebElement buyNow;

        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement cartFrame;

        [FindsBy(How = How.XPath, Using = "//input[@id='BookCart_lvCart_imgPayment']")]
        public IWebElement placeOrder;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/form[1]/div[3]/div[3]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/a[1]")]
        public IWebElement continueButton;

        public void OrderBook()
        {
            Thread.Sleep(10000);
            buyNow.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(cartFrame);
            Thread.Sleep(5000);
            placeOrder.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            continueButton.Click();
        }
    }
}
