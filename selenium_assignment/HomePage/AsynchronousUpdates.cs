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
using OpenQA.Selenium.Interactions;

namespace MakeMyTrip.HomePage
{
    [TestFixture]
    public class AsynchronousUpdates : BaseClass
    {
        [Test]
        public void Updates()
        {
                 // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Scroll down to the Trending Destinations section
            IWebElement trendingDestinationsSection = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".trending-container")));

            // Use Actions class to scroll to the element
            Actions actions = new Actions(driver);
            actions.MoveToElement(trendingDestinationsSection);
            actions.Perform();

            // Wait for animations to complete (assuming there's a specific animation class or delay)
            System.Threading.Thread.Sleep(2000); // Adjust the sleep time as needed based on your observations
            
            // Verify the content of the Trending Destinations section
            IWebElement trendingDestinationsTitle = trendingDestinationsSection.FindElement(By.CssSelector(".trending-title"));
            string titleText = trendingDestinationsTitle.Text.Trim();
            Console.WriteLine($"Trending Destinations Title: {titleText}");

            // Optionally, interact further with the content as needed
            // Example: Get the list of trending destinations
            var trendingDestinations = trendingDestinationsSection.FindElements(By.CssSelector(".trending-card .trending-text a"));
            foreach (var destination in trendingDestinations)
            {
                Console.WriteLine($"Trending Destination: {destination.Text}");
            }
        }
             
        }
    }
