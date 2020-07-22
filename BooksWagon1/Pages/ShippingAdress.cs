using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Threading;
using System.Threading.Tasks;

namespace BooksWagon1.Pages
{
    public class ShippingAdress
    {
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

        [FindsBy(How = How.XPath, Using = "//select[@name='ctl00$cpBody$ddlNewCountry']")]
        public IWebElement selectCountry;

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

        public string Validate()
        {
            return validation.Text;
        }

        public void AddShippingDetails(string name, string addr, string country, string state, string city, string pin, string mobileNumber)
        {
            recipientName.SendKeys(name);
            Thread.Sleep(1000);
            address.SendKeys(addr);
            Thread.Sleep(1000);
            SelectElement countrySelect = new SelectElement(selectCountry);
            countrySelect.SelectByText(country);
            Thread.Sleep(5000);
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
