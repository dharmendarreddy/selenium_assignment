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
    public class BusSearch : BaseClass
    {
        [Test]
        public void Bustrip()
        {

            // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("header_tab_bus")));

            // Click on Buses tab
            IWebElement busesTab = driver.FindElement(By.Id("header_tab_bus"));
            busesTab.Click();

            // Wait for bus search form to be visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fromCity")));

            // Enter "Bangalore" in From city field
            IWebElement fromCityInput = driver.FindElement(By.Id("fromCity"));
            fromCityInput.SendKeys("Bangalore");

            // Select the first option from the auto-complete dropdown
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-autosuggest__suggestions-list")));
            IWebElement fromCityOption = driver.FindElement(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)"));
            fromCityOption.Click();

            // Enter "Chennai" in To city field
            IWebElement toCityInput = driver.FindElement(By.Id("toCity"));
            toCityInput.SendKeys("Chennai");

            // Select the first option from the auto-complete dropdown
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".react-autosuggest__suggestions-list")));
            IWebElement toCityOption = driver.FindElement(By.CssSelector(".react-autosuggest__suggestions-list li:nth-of-type(1)"));
            toCityOption.Click();

            // Click on Departure date field for onward journey
            IWebElement onwardDateField = driver.FindElement(By.Id("departure"));
            onwardDateField.Click();

            // Select the next week's date (e.g., 7 days from today)
            IWebElement onwardDate = driver.FindElement(By.XPath("//div[contains(@class, 'DayPicker-Day') and not(contains(@class, 'prev-next'))][7]"));
            onwardDate.Click();

            // Click on Return date field for return journey
            IWebElement returnDateField = driver.FindElement(By.Id("return"));
            returnDateField.Click();

            // Select the date for return journey (e.g., 9 days from today)
            IWebElement returnDate = driver.FindElement(By.XPath("//div[contains(@class, 'DayPicker-Day') and not(contains(@class, 'prev-next'))][9]"));
            returnDate.Click();

            // Click on Search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".primaryBtn"));
            searchButton.Click();

            // Wait for search results to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".bus-item-list")));

            // Verify that bus options are displayed for both onward and return journeys
            IWebElement busItemList = driver.FindElement(By.CssSelector(".bus-item-list"));
            if (busItemList.Displayed)
            {
                Console.WriteLine("Bus options are displayed for both onward and return journeys.");
            }
            else
            {
                Console.WriteLine("Bus options are not displayed for both onward and return journeys.");
            }
            driver.Quit();
        }


    }
    }

