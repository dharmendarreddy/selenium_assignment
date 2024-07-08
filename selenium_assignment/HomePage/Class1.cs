using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;



namespace MakeMyTrip.HomePage 

{
    [TestFixture]
    public class Class1:BaseClass
    {
        [Test]
        public void SearchOneWayFlightFromDelhiToMumbai()
        {
            //  IWebDriver driver = new ChromeDriver();
            // driver.Manage().Window.Maximize();


            // driver.Navigate().GoToUrl("https://www.makemytrip.com/");


        
           
        


            Thread.Sleep(100);
            driver.FindElement(By.Id("fromCity")).Click();
            driver.FindElement(By.XPath("//p[contains(text(),'New Delhi, India')]")).Click();
            driver.FindElement(By.Id("toCity")).Click();
            driver.FindElement(By.XPath("//p[contains(text(),'Mumbai, India')]")).Click();
            string fromDate = DateTime.Now.AddDays(1).ToString("ddd MMM dd yyyy");
            string toDate = DateTime.Now.AddDays(8).ToString("ddd MMM dd yyyy");

            driver.FindElement(By.XPath("//div[@aria-label='" + fromDate + "']")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Return')]")).Click();
            driver.FindElement(By.XPath("//div[@aria-label='" + toDate + "']")).Click();



            

            

   
            
            
            IWebElement searchButton = driver.FindElement(By.XPath("//a[normalize-space()='Search']"));
            searchButton.Click();



             Thread.Sleep(5000);

             // Verify search results page loaded
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Title.Contains("Search Results"));

             // Close the browser
             
        }





    }

   
}