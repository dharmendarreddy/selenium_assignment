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
    public class TrendingDestinations : BaseClass
    {
        [Test]
        public void destination()
        {
            // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".trending-container")));

            // Find the trending destinations section
            IWebElement trendingDestinationsSection = driver.FindElement(By.CssSelector(".trending-container"));

            // Get the initial set of trending destinations
            string initialDestinations = trendingDestinationsSection.Text.Trim();

            // Find all trending destination links
            var destinationLinks = trendingDestinationsSection.FindElements(By.CssSelector(".trending-card .trending-text a"));

            // Click on each destination link and verify dynamic update
            foreach (var destinationLink in destinationLinks)
            {
                // Click on the destination link
                destinationLink.Click();

                // Wait for content to update dynamically
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(destinationLink));

                // Get the updated set of trending destinations
                string updatedDestinations = trendingDestinationsSection.Text.Trim();

                // Validate that the displayed destinations change dynamically
                if (!initialDestinations.Equals(updatedDestinations))
                {
                    Console.WriteLine($"Trending destinations change dynamically after clicking on '{destinationLink.Text}'.");
                }
                else
                {
                    Console.WriteLine($"Trending destinations do not change dynamically after clicking on '{destinationLink.Text}'.");
                }

                // Navigate back to the trending destinations section
                driver.Navigate().Back();

                // Re-find the trending destinations section element
                trendingDestinationsSection = driver.FindElement(By.CssSelector(".trending-container"));
            }
        }
          

        }
    }

