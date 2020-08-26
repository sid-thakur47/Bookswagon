//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using System;
using System.Net;
using System.Net.Mail;

namespace BooksWagon1.Utils
{
    /// <summary>
    /// to keep all required functionality at one place
    /// </summary>
    public class Utility
    {
        public enum Browser
        {
            FIREFOX,CHROME
        }

        /// <summary>
        /// to send extent report through mail
        /// </summary>
        /// <param name="pass">password of email account</param>
        public static void SendEmail(string pass)
        {
            MailMessage mail = new MailMessage();
            string fromEmail = "sidthakur6433@gmail.com";
            string password = pass;
            string ToEmail = "sidthakur258@gmail.com";
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "Please check results for current test run";
            mail.To.Add(ToEmail);
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(@"C:\Users\Shivani\source\repos\BooksWagon\BooksWagon1\ExtentReport\index.html"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true
            };
            smtp.Send(mail);
        }

        /// <summary>
        /// To take screnshot after every test
        /// </summary>
        /// <param name="driver">to control the web page</param>
        /// <param name="testStatus"> status of the test</param>
        /// <returns></returns>
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