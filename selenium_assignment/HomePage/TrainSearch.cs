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
    public class TrainSearch : BaseClass
    {
        [Test]
        public void trains()
        {
          
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("trainIcon")));

            // Click on Trains icon
            IWebElement trainsIcon = driver.FindElement(By.Id("trainIcon"));
            trainsIcon.Click();

            // Wait for train search form to be visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fromCity")));

            // Enter "Mumbai" in From city field
            IWebElement fromCityInput = driver.FindElement(By.Id("fromCity"));
            fromCityInput.SendKeys("Mumbai");

            // Select the first option from the auto-complete dropdown
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-autosuggest__suggestions-list")));
            IWebElement fromCityOption = driver.FindElement(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)"));
            fromCityOption.Click();

            // Enter "Delhi" in To city field
            IWebElement toCityInput = driver.FindElement(By.Id("toCity"));
            toCityInput.SendKeys("Delhi");

            // Select the first option from the auto-complete dropdown
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-autosuggest__suggestions-list")));
            IWebElement toCityOption = driver.FindElement(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)"));
            toCityOption.Click();

            // Click on Departure date field
            IWebElement departureDateField = driver.FindElement(By.Id("departure"));
            departureDateField.Click();

            // Select a specific date (e.g., 1st of next month)
            IWebElement specificDate = driver.FindElement(By.XPath("//div[@aria-label='1']"));
            specificDate.Click();

            // Click on Search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".primaryBtn"));
            searchButton.Click();

            // Wait for search results to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".train-listing")));

            // Verify that train options and seat availability are displayed
            IWebElement trainList = driver.FindElement(By.CssSelector(".train-listing"));
            if (trainList.Displayed)
            {
                Console.WriteLine("Train options and seat availability are displayed.");
            }
            else
            {
                Console.WriteLine("Train options and seat availability are not displayed.");
            }
        }
       
        }
    }

