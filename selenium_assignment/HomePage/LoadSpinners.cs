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
    public class LoadSpinners : BaseClass
    {
        [Test]
        public void spinners()
        {
             // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find and click on the Hotels tab
            IWebElement hotelsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("header_tab_hotels")));
            hotelsTab.Click();

            // Wait for the hotel search form to be visible
            IWebElement cityInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("city")));
            cityInput.SendKeys("Goa");

            // Select the first option from the auto-complete dropdown
            IWebElement goaOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)")));
            goaOption.Click();

            // Click on the Search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".primaryBtn"));
            searchButton.Click();

            // Wait for the loading spinner to disappear
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".mmBackdrop")));

            // Now interact with the hotel listings (e.g., get the count of hotels)
            var hotelResults = driver.FindElements(By.CssSelector(".hotelCardListing"));
            Console.WriteLine($"Number of hotels found in Goa: {hotelResults.Count}");
        }
             
        }
    }

