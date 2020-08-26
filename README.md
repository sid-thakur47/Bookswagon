## Project Title

Bookswagon Website Automation


## Description

* The project is to automate Bookswagon.com which is e-commerce website for buying books

## Prerequisites

* Visual Studio 2019  
* Chrome Browser  
* Firefox Browser
* Internet Connection

## Technology Used

* C#

## Frameworks

* .Net Framework  
* Nunit  
* Selenium  
* Data Driven  

## Design Pattern

* Page Object Model

## Packages

* DotNetSeleniumExtras.PageObjects- For Page object Model  
* ExtentReports- To generate Test Reports   
* NUnit- To define test cases, assertion  
* NUnit3Adapter- Running test cases in Visual Studio  
* Selenium.WebDriver- .Net Binding for selenium webdriver API  
* Selenium.WebDriver.ChromeDriver- Driver for Google Chrome  
* Selenium.Firefox.WebDriver-Driver for Firefox browser
* DNSClient- In this project it is uesd to get Host name
* Log4Net-Logging Test steps to log file
* ExcelDataReader.DataSet-Extension for reading microsoft excel files
* Newtonsoft.Json-To access data from json file
* Microsoft.Office.Interop.Excel- Assembly necessary for to do Microsoft office interop

## Test scenario covered

  #First- Positive scenario of buying book
  
* Login to Bookswagon application  
* Navigates to Home page  
* Search any book  
* Select the book 
* Place the order
* Add shipping address 
* Review the placed order
* Navigates to homepage  
* Log out from application  

 #Second- Negative test 
 
* Try to Login with wrong username
* Try to Login with empty username
* Try to Login with wrong passowrd
* Try to Login with empty password
  

## Running the tests

* Navigate to tool bar and Click on Test  
* Click on run all Test

## Author

* Siddhesh Thakur