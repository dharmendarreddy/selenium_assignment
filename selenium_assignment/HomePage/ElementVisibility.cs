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
    public class ElementVisibility : BaseClass
    {
        [Test]
        public void visible()
        {
             // Wait for page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find and click on the "More" tab
            IWebElement moreTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("moreItem")));
            moreTab.Click();

            // Wait for the dropdown options to be fully visible
            IWebElement moreDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".moreItem .menu_list_container")));

            // Now interact with the dropdown options (e.g., click on a specific option)
            IWebElement dealsOption = moreDropdown.FindElement(By.CssSelector(".menu_list_container .menu_LHS_col ul li:nth-of-type(1)"));
            dealsOption.Click();

            // Example validation: Wait for the deals page to load and check the title
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Deals - MakeMyTrip"));

            Console.WriteLine("Successfully navigated to Deals page.");
        }
             
        }
    }

