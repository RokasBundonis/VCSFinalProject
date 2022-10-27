using FinalProject.Drivers;
using FinalProject.Tools;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Page;

namespace FinalProject.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        protected static HomepagePage homepagePage;
        protected static ContactsPage contactsPage;
        protected static CheapFlightsPage cheapFlightsPage;
        

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            driver = CustomDriver.GetChromeDriver();
            homepagePage = new HomepagePage(driver);
            contactsPage = new ContactsPage(driver);
            cheapFlightsPage = new CheapFlightsPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
