using Bookswagon.ExcelReader;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Pages
{
   public class Login 
    {
        public IWebDriver driver;
        Credentials credentials = new Credentials();

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

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]
        public IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//span[@class='login-bg sprite usermenu-bg']")]
        public IWebElement menu;


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

 

        public void Logout()
        {
            menu.Click();
            logout.Click();
        }
    }
}
