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
    public class RecommendedExperiences : BaseClass
    {
        [Test]
        public void experience()
        {
            // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".recommendation-section")));

            // Find the recommended experiences section
            IWebElement recommendedExperiencesSection = driver.FindElement(By.CssSelector(".recommendation-section"));

            // Get the initial set of recommended experiences
            string initialExperiences = recommendedExperiencesSection.Text.Trim();

            // Find all experience cards
            var experienceCards = recommendedExperiencesSection.FindElements(By.CssSelector(".experience-card"));

            // Click on each experience card and verify dynamic update
            foreach (var experienceCard in experienceCards)
            {
                // Click on the experience card
                experienceCard.Click();

                // Wait for content to update dynamically
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(experienceCard));

                // Get the updated set of recommended experiences
                string updatedExperiences = recommendedExperiencesSection.Text.Trim();

                // Validate that the displayed experiences change dynamically
                if (!initialExperiences.Equals(updatedExperiences))
                {
                    Console.WriteLine($"Recommended experiences change dynamically after clicking on '{experienceCard.Text}'.");
                }
                else
                {
                    Console.WriteLine($"Recommended experiences do not change dynamically after clicking on '{experienceCard.Text}'.");
                }

                // Navigate back to the recommended experiences section
                driver.Navigate().Back();

                // Re-find the recommended experiences section element
                recommendedExperiencesSection = driver.FindElement(By.CssSelector(".recommendation-section"));
            }
        
          

        }
    }
}
