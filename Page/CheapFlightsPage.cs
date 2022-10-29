using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class CheapFlightsPage : BasePage
    {
        private const string pageUrl = "https://www.zigzag.lt/pigus-skrydziai/";
        private IWebElement inputTravelTo => Driver.FindElement(By.Id("data_to"));
        private IWebElement buttonCheapTravelSearch => Driver.FindElement(By.CssSelector("#container > div.container-fluid > div.row.mb-4 > div.col-md-12.col-lg-8 > div > form > div > div:nth-child(6) > button"));
        private IWebElement messageTicketsNotFound => Driver.FindElement(By.CssSelector("#flights-container > div > div:nth-child(2)"));

        public CheapFlightsPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }
        }

        public void WriteToInputTravelTo(string text)
        {
            Driver.SwitchTo().Frame(1);
            inputTravelTo.Clear();
            inputTravelTo.SendKeys(text);
        }

        public void DoubleClickOnCheapTravelSearchButton()
        {
            Actions action = new Actions(Driver);
            action.DoubleClick(buttonCheapTravelSearch);
            action.Build().Perform();
        }

        public void VerifyNotFoundMessage(string text)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementExists(By.CssSelector("#flights-container > div > div:nth-child(2)")));

            Assert.IsTrue(messageTicketsNotFound.Text.Contains(text), "message is wrong");
        }
    }
}
