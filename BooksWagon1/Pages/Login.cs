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

        [FindsBy(How = How.XPath, Using = "//div[@class='ac-container']//li[1]//a[1]")]
        public IWebElement validation;

        [FindsBy(How = How.XPath, Using = "//img[@id='ctl00_imglogo']")]
        public IWebElement home; 

        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_phBody_SignIn_reEmail']")]
        public IWebElement wrongName;




        public void BookwagonLogin(string email,string password)
        {
            username.SendKeys(email);
            Thread.Sleep(5000);
            pass.SendKeys(password);
            Thread.Sleep(5000);
            loginbutton.Click();
            Thread.Sleep(5000);
        }

        public void Logout()
        {
            home.Click();
            Thread.Sleep(1000);
            menu.Click();
            Thread.Sleep(5000);
            logout.Click();
        }


    public IWebElement Validate(string type)
        {
            if (type.Equals("login"))
            {
                return validation;
            }
            else if (type.Equals("login"))
            {
                return loginbutton;
            }
            return wrongName;
        }
    }
}
