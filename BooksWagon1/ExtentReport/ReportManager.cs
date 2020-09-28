//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;

namespace BooksWagon1.ExtentReport
{
    /// <summary>
    /// Create extent object 
    /// </summary>
    public class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        /// <summary>
        /// to get instance of extentreport class
        /// </summary>
        /// <returns>extent instance</returns>
        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string reportPath = @"C:\Users\sidth\source\repos\BooksWagon\BooksWagon1\ExtentReport\Report.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                string hostname = Dns.GetHostName();
                extent.AddSystemInfo("OS", "Windows 10");
                extent.AddSystemInfo("Host Name", hostname);
                extent.AddSystemInfo("Browser", "FireFox");
                extent.AddSystemInfo("Environment", "QA");
            }
            return extent;
        }
    }
}


