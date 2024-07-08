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
    public class Handling : BaseClass
    {
        [Test]
        public void ajax()
    {
               // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find and click on the Flights tab
            IWebElement flightsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("header_tab_flights")));
            flightsTab.Click();

            // Wait for the flight search form to be visible
            IWebElement fromCityInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fromCity")));
            IWebElement toCityInput = driver.FindElement(By.Id("toCity"));

            // Enter "Delhi" in From city field
            fromCityInput.SendKeys("Delhi");

            // Select the first option from the auto-complete dropdown
            IWebElement fromCityOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)")));
            fromCityOption.Click();

            // Enter "Mumbai" in To city field
            toCityInput.SendKeys("Mumbai");

            // Select the first option from the auto-complete dropdown
            IWebElement toCityOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)")));
            toCityOption.Click();

            // Click on Departure date field
            IWebElement departureDateField = driver.FindElement(By.Id("departure"));
            departureDateField.Click();

            // Select a date from the date picker (e.g., next month's 15th)
            IWebElement specificDate = driver.FindElement(By.XPath("//div[@aria-label='15']"));
            specificDate.Click();

            // Click on Search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".primaryBtn"));
            searchButton.Click();

            // Wait for flight search results to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".fli-list")));

            // Now interact with the flight search results (e.g., get the count of search results)
            var flightResults = driver.FindElements(By.CssSelector(".fli-list .fli-list-item"));
            Console.WriteLine($"Number of flights found: {flightResults.Count}");
        }
             

        }

    }

