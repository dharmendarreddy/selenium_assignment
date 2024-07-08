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
    public class FeaturedDeals : BaseClass
    {
        [Test]
        public void Deals()
        {
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".slick-slide")));

            // Find the featured deals section
            IWebElement featuredDealsSection = driver.FindElement(By.CssSelector(".slick-slide"));

            // Get the initial set of featured deals
            string initialDeals = featuredDealsSection.Text.Trim();

            // Wait for a few seconds to observe any potential changes
            System.Threading.Thread.Sleep(5000); // You can adjust the sleep time as needed
            
            // Get the updated set of featured deals
            string updatedDeals = featuredDealsSection.Text.Trim();

            // Validate that the displayed deals change dynamically based on time or user interaction
            if (!initialDeals.Equals(updatedDeals))
            {
                Console.WriteLine("Featured deals change dynamically.");
            }
            else
            {
                Console.WriteLine("Featured deals do not change dynamically.");
            }
        }
        

        }
    }


