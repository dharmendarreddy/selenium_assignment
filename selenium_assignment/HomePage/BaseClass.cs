using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Configuration;

using System.IO;
using NUnit.Framework;

namespace MakeMyTrip.HomePage
{
    public class BaseClass
    {
        public static IWebDriver driver;

        [SetUp]
        public void InitScript()

        {



            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://www.makemtrip.com/");

            driver.Manage().Window.Maximize();


        }
        public IWebDriver getDriver()
        {

            return driver;
        }


        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":

                    driver = new EdgeDriver();
                    break;
            }
        }
        [TearDown]
        public void Close()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}