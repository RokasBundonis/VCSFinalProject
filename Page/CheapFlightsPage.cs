using OpenQA.Selenium;
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
        private IWebElement buttonCheapTravelSearch => Driver.FindElement(By.ClassName("btn.btn-success.btn-block.btn-search"));

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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("data_to")));
        //IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
        //js.ExecuteScript("document.getElementById('data_to').value='Kaunas'");
        //inputTravelTo.Click();
            inputTravelTo.Clear();
            inputTravelTo.SendKeys(text);
        }

        public void ClickOnCheapTravelSearchButton()
        {
            buttonCheapTravelSearch.Click();
        }
    }
}
