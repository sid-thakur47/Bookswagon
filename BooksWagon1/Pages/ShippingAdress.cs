using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace BooksWagon1.Pages
{
    public class ShippingAdress
    {
        readonly string name = ConfigurationManager.AppSettings["userName"];
        readonly string addr = ConfigurationManager.AppSettings["address"];
        readonly string state = ConfigurationManager.AppSettings["state"];
        readonly string city = ConfigurationManager.AppSettings["city"];
        readonly string pin = ConfigurationManager.AppSettings["pinCode"];
        readonly string mobileNumber = ConfigurationManager.AppSettings["phoneNumber"];
        public IWebDriver driver;

        public ShippingAdress(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

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
        

        public ShippingAdress(IWebElement addCity)
        {
            this.addCity = addCity;
        }

        public IWebElement Validate()
        {
            return validation;
        }

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
