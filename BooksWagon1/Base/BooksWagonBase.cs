using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace BooksWagon1.Base
{
    public class BooksWagonBase
    {
        public static ExtentReports extent = ExtentReport.ReportManager.GetInstance();
        public static IWebDriver driver;
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ExtentTest test;
        public static int count = 1;


        [OneTimeSetUp]
        public void Initilize()
        {
            driver = new ChromeDriver();
            //Using implicitly wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Maximizing the window
            driver.Manage().Window.Maximize();
            log.Info("Navigating to Login page");
            //Enter the url
            driver.Url = "https://www.bookswagon.com/login";
        }



        public static string TakeScreenshot(string testStatus)
        {
            count++;
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = path.Substring(0, path.LastIndexOf("bin"))+"Screenshots\\" +testStatus+ ".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }

        public static void SendEmail(string email,string pass)
        {
            MailMessage mail = new MailMessage();
            String fromEmail = email;
            String password = pass;
            String ToEmail = "sidthakur258@gmail.com";
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(ToEmail);
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(@"C:\Users\Shivani\source\repos\BooksWagon\BooksWagon1\ExtentReport\index.html"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


        [TearDown]
        public void Close()        
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = TakeScreenshot("FailedTest" + count);
                test.AddScreenCaptureFromPath(path);
                test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string path = TakeScreenshot("PassTest" + count);
                test.AddScreenCaptureFromPath(path);
                test.Pass(MarkupHelper.CreateLabel("Test Pass", ExtentColor.Green));
            }
            log.Info("Closing  browser");
            Thread.Sleep(5000);
            extent.Flush();
        }
    }
}
