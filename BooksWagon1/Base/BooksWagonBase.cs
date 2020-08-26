//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using BooksWagon1.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using static BooksWagon1.Utils.Utility;

namespace BooksWagon1.Base
{
    [TestFixture]
    public class BooksWagonBase
    {

        public static ExtentReports extent = ExtentReport.ReportManager.GetInstance();
        public  IWebDriver driver;
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ExtentTest test;
        public static int count = 1;
        private Browser _browser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class
        /// </summary>
        /// <param name="browser">initialize browser type</param>
        public BooksWagonBase(Browser browser)
        {
            _browser = browser;
        }

        /// <summary>
        /// Initilize browser before all the test
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            ChooseBrowser(_browser);
        }

        /// <summary>
        /// Takes screenshot and generate report after each test
        /// </summary>
        [TearDown]
        public void Close()        
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    string path = Utility.TakeScreenshot(driver,TestContext.CurrentContext.Test.Name);
                    test.Log(Status.Fail, "Test Failed");
                    test.AddScreenCaptureFromPath(path);
                    test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    string path = Utility.TakeScreenshot(driver,TestContext.CurrentContext.Test.Name);
                    test.Log(Status.Pass, "Test Sucessful");
                    test.AddScreenCaptureFromPath(path);
                    test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            extent.Flush();
        }

        /// <summary>
        /// Choose browser
        /// </summary>
        /// <param name="browser">type of browser</param>
        private void ChooseBrowser(Browser browser)
        {
            if (browser == Browser.CHROME)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                log.Info("Navigating to Login page");
                driver.Url = "https://www.bookswagon.com/login";
            }
            else
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                log.Info("Navigating to Login page");
                driver.Url = "https://www.bookswagon.com/login";
            }
        }
    }
}
