using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Pages
{
   public class Login 
    {
        public IWebDriver driver;


        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtEmail']")]
        public IWebElement username;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtPassword")]
        public IWebElement pass;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_btnLogin")]
        public IWebElement loginbutton;

        public void BookwagonLogin(string email,string password)
        {
            Thread.Sleep(5000);
            username.SendKeys(email);
            Thread.Sleep(5000);
            pass.SendKeys(password);
            Thread.Sleep(5000);
            loginbutton.Click();
            Thread.Sleep(5000);
        }
    }
}
