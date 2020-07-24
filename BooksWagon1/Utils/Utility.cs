using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Net;
using System.Net.Mail;
using static BooksWagon1.Base.BooksWagonBase;

namespace BooksWagon1.Utils
{
    public class Utility
    {
        public enum Browser
        {
            FIREFOX,CHROME
        }

        public static void SendEmail(string email, string pass)
        {
            MailMessage mail = new MailMessage();
            string fromEmail = email;
            string password = pass;
            string ToEmail = "sidthakur258@gmail.com";
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

        public static string TakeScreenshot(IWebDriver driver, string testStatus)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + testStatus + ".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}