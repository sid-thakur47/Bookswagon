﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace BooksWagon1.Base
{
   public class BooksWagonBase
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void Initilize()
        {
            driver = new FirefoxDriver();

            //Using implicitly wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            //Enter the url
            driver.Url = "https://www.bookswagon.com/login";
        }

        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(5000);
            driver.Quit();

        }
    }
}
