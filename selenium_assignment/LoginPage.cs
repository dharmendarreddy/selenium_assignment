using MakeMyTrip.HomePage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MakeMyTrip;
[TestFixture]

public class FlightBookingTests
{
    public static IWebDriver driver;

    public void script()
    {
        driver = GetChromeDriver();

    }



    private static ChromeDriver GetChromeDriver()
    {
        ChromeDriver driver = new ChromeDriver();
        return driver;
    }
    /*
        [Test]
        public void TestFlightBooking()
        {


            // Step 1: Navigate to MakeMyTrip homepage
            _driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            _driver.Quit();

        }*/

    /*

        [TestMethod]
        public void SearchOneWayFlightFromDelhiToMumbai()
        {
             _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();


            IWebElement fromCity = _driver.FindElement(By.Id("fromCity"));
            fromCity.SendKeys("Delhi");

            IWebElement toCity = driver.FindElement(By.Id("toCity"));
            toCity.SendKeys("Mumbai");

            // Select  date for departure
            IWebElement departDate = driver.FindElement(By.Id("departure"));
            departDate.SendKeys(DateTime.Now.AddDays(1).ToString("2024-07-20"));

            // Select return date after 7 days
            IWebElement returnDate = driver.FindElement(By.Id("return"));
            returnDate.SendKeys(DateTime.Now.AddDays(8).ToString("2024-07-27"));

            // Click on search button
            IWebElement searchButton = driver.FindElement(By.XPath("//button[@class='primaryBtn font24 latoBold widgetSearchBtn ']"));
            searchButton.Click();


            Thread.Sleep(5000); 

            // Verify search results page loaded
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Title.Contains("Search Results"));

            // Close the browser
            driver.Quit();
        }



        [TestMethod]
        public void SelectAndPrintFilterOptions()
        {
            driver = new ChromeDriver();

            // Navigate to MakeMyTrip homepage and perform search (assuming pre-requisite)
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");


            // Select Non-Stop filter
            IWebElement nonStopCheckbox = driver.FindElement(By.XPath("//label[contains(text(), 'Non Stop')]/input"));
            nonStopCheckbox.Click();

            // Select 1 Stop filter
            IWebElement oneStopCheckbox = driver.FindElement(By.XPath("//label[contains(text(), '1 Stop')]/input"));
            oneStopCheckbox.Click();

            // Count and print total number of Departure flights
            IList<IWebElement> departureFlights = driver.FindElements(By.XPath("//div[@class='splitVw-second ']/div"));
            Console.WriteLine($"Total Departure Flights: {departureFlights.Count}");

            // Count and print total number of Return flights
            IList<IWebElement> returnFlights = driver.FindElements(By.XPath("//div[@class='splitVw-first ']/div"));
            Console.WriteLine($"Total Return Flights: {returnFlights.Count}");

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void SelectTop10FlightOptions()
        {
             driver = new ChromeDriver();

            // Navigate to MakeMyTrip homepage and perform search (assuming pre-requisite)
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");


            // Select top 10 Departure flights
            IList<IWebElement> departureRadioButtons = driver.FindElements(By.XPath("//div[@class='splitVw-second ']/div//input[@type='radio']"));
            for (int i = 0; i < 10 && i < departureRadioButtons.Count; i++)
            {
                departureRadioButtons[i].Click();
            }

            // Select top 10 Return flights
            IList<IWebElement> returnRadioButtons = driver.FindElements(By.XPath("//div[@class='splitVw-first ']/div//input[@type='radio']"));
            for (int i = 0; i < 10 && i < returnRadioButtons.Count; i++)
            {
                returnRadioButtons[i].Click();
            }


            Thread.Sleep(2000); 

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void VerifyFlightPricesAtBottomOfPage()
        {
            driver = new ChromeDriver();

            // Navigate to MakeMyTrip homepage and perform search (assuming pre-requisite)
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");


            // Capture prices for selected Departure flights
            IList<IWebElement> departurePrices = driver.FindElements(By.XPath("//div[@class='splitVw-second ']/div//span[@class='actual-price']"));


            // Capture prices for selected Return flights
            IList<IWebElement> returnPrices = driver.FindElements(By.XPath("//div[@class='splitVw-first ']/div//span[@class='actual-price']"));

            // Close the browser
            driver.Quit();
        }
        [Test]
        public void VerifyTotalAmount()
        {

            // Get the price of the selected Departure flight
            decimal departurePrice = decimal.Parse(driver.FindElement(By.CssSelector("span[data-cy='departurePrice']")).Text.Replace(",", "").Replace("₹", ""));

            // Get the price of the selected Return flight
            decimal returnPrice = decimal.Parse(driver.FindElement(By.CssSelector("span[data-cy='returnPrice']")).Text.Replace(",", "").Replace("₹", ""));

            // Calculate the expected total amount
            decimal expectedTotalAmount = departurePrice + returnPrice;

            // Get the displayed total amount from the page
            decimal displayedTotalAmount = decimal.Parse(driver.FindElement(By.CssSelector("span[data-cy='totalAmount']")).Text.Replace(",", "").Replace("₹", ""));

            // Assertion to verify total amount matches
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(expectedTotalAmount, displayedTotalAmount, "Total amount does not match the sum of departure and return flight prices.");
        }
        [Test]
        public void VerifyFlightOptionsDisplay()
        {
            // Assume we are on the search results page after executing Test Case 2

            // Get the list of displayed Departure flight options
            IList<IWebElement> departureFlightOptions = driver.FindElements(By.CssSelector("li[data-cy='departureListing']"));

            // Get the list of displayed Return flight options
            IList<IWebElement> returnFlightOptions = driver.FindElements(By.CssSelector("li[data-cy='returnListing']"));

            // Assertion to verify flight options are displayed
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(departureFlightOptions.Count, 0, "No Departure flight options found.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(returnFlightOptions.Count, 0, "No Return flight options found.");
        }*/



}
