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
	public class HotelSearch : BaseClass
	{
		[Test]
	
		public void SearchHotel()
		{
			Thread.Sleep(3000);
			driver.FindElement(By.XPath("//li[@class='menu_Hotels']//span[@data-cy='item-wrapper']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@data-cy=\"city\"]")).Click();
			Thread.Sleep(1000);
			driver.FindElement(By.XPath("(//li[@role=\"option\"])[4]")).Click();


            string fromDate = DateTime.Now.AddDays(5).ToString("ddd MMM dd yyyy");
            string toDate = DateTime.Now.AddDays(7).ToString("ddd MMM dd yyyy");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find and click on the "More" tab
            IWebElement moreTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("//div[@aria-label='Sat Jun 29 2024']")));
            moreTab.Click();

            driver.FindElement(By.XPath("//div[@aria-label='Sat Jun 29 2024']")).Click();
            
            driver.FindElement(By.XPath("(//div[@aria-label='Mon Jul 01 2024'])[2]")).Click();
			Thread.Sleep(4000);
            driver.FindElement(By.XPath("//div[@class='`makeFlex flexOne spaceBetween']")).Click(); 
            Thread.Sleep(4000);
            //search 
            driver.FindElement(By.XPath("//button[@id='hsw_search_button']")).Click();
        }

    }
}
