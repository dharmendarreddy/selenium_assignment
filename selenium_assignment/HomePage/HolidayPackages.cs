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
    public class HolidayPackages : BaseClass
    {
        [Test]
        public void holidays()
        {
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("header_tab_holidays")));

            // Click on Holidays tab
            IWebElement holidaysTab = driver.FindElement(By.Id("header_tab_holidays"));
            holidaysTab.Click();

            // Wait for holiday search form to be visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("holiday_destination_typeahead")));

            // Enter destination (e.g., "Goa") in the search box
            IWebElement destinationInput = driver.FindElement(By.Id("holiday_destination_typeahead"));
            destinationInput.SendKeys("Goa");

            // Wait for auto-complete suggestions and select the desired destination
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-autosuggest__suggestions-list")));

            IWebElement goaOption = driver.FindElement(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)"));
            goaOption.Click();

            // Wait for date fields and enter date range
            IWebElement fromDateField = driver.FindElement(By.Id("fromDate"));
            fromDateField.Clear();
            fromDateField.SendKeys("2024-07-23"); // Replace with your desired start date

            IWebElement toDateField = driver.FindElement(By.Id("toDate"));
            toDateField.Clear();
            toDateField.SendKeys("2024-07-30"); // Replace with your desired end date

            // Click on Search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".hsw_search_button"));
            searchButton.Click();

            // Wait for search results to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-listing-container")));

            // Verify that holiday packages with dynamic content are displayed correctly
            IWebElement packagesContainer = driver.FindElement(By.CssSelector(".react-listing-container"));
            if (packagesContainer.Displayed)
            {
                Console.WriteLine("Holiday packages are displayed correctly.");
            }
            else
            {
                Console.WriteLine("Holiday packages are not displayed correctly.");
            }
        }
       
    }
}
             
        
