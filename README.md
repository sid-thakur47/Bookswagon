## Project Title

Myntra Website Automation


## Description

* The project is to automate Myntra.com which is fashion e-commerce application

## Prerequisites

* Visual Studio 2019  
* Chrome Browser  
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
* Newtonsoft.Json-To access data from json file  
* NUnit- To define test cases, assertion  
* NUnit3Adapter- Running test cases in Visual Studio  
* Selenium.WebDriver- .Net Binding for selenium webdriver API  
* Selenium.WebDriver.ChromeDriver- Driver for Google Chrome  
* DNSClient- In this project it is uesd to get Host name
* Log4Net-Logging Test steps to log file

## Test scenario covered

  #First- Normal scenario of buying product
  
* Login to Myntra application  
* Navigates to Home page  
* Hover on Men's section  
* Clicks on Topwear  
* Applies Filter to only display shirts  
* Selects the shirt  
* Adds Shirt to bag  
* Navigates to bag  
* Changes quantity of shirt  
* Clicks on Place order  
* Selects default address  
* Navigates to Payment page  
* Navigates to Home page  
* Log out from application  

 #Second- Buying product during sale
 
* Login to Myntra application  
* Navigates to Home page  
* Clicks on sale Image  
* Clicks on Mens product sale
* Navigates to products list in sale  
* Applies Filter to only display shirts  
* Selects the shirt  
* Adds Shirt to bag  
* Navigates to bag  
* Changes quantity of shirt
* Checks if offer is applied  
* If Offer then clicks on Place order  
* Selects default address  
* Navigates to Payment page  
* Navigates to Home page  
* Log out from application  

## Running the tests

* Navigate to tool bar and Click on Test  
* Click on run all Test

## Author

* Siddhesh Thakur

