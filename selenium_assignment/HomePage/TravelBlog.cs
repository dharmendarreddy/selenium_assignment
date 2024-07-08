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
    public class TravelBlog : BaseClass
    {
        [Test]
        public void travelling()
        {
            
                 // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("menu_TravelBlog")));

            // Access Travel Blog section
            IWebElement travelBlogMenu = driver.FindElement(By.Id("menu_TravelBlog"));
            travelBlogMenu.Click();

            // Wait for blog page to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".tab-list")));

            // Verify dynamic content (latest travel tips or articles) is loaded
            IWebElement tabList = driver.FindElement(By.CssSelector(".tab-list"));
            if (tabList.Displayed)
            {
                Console.WriteLine("Travel blog section is loaded with dynamic content.");
            }
            else
            {
                Console.WriteLine("Travel blog section is not loaded with dynamic content.");
            }

            // Click on different categories or articles (example: clicking on first category)
            IWebElement firstCategory = driver.FindElement(By.CssSelector(".tab-list li:nth-of-type(1)"));
            firstCategory.Click();

            // Wait for content to update dynamically
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".tab-content")));

            // Validate that clicking on different categories or articles updates the content dynamically
            IWebElement tabContent = driver.FindElement(By.CssSelector(".tab-content"));
            if (tabContent.Displayed)
            {
                Console.WriteLine("Content updates dynamically when clicking on different categories/articles.");
            }
            else
            {
                Console.WriteLine("Content does not update dynamically when clicking on different categories/articles.");
            }
        }
      
        }
    }

