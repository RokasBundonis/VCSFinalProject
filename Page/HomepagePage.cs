using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class HomepagePage : BasePage
    {
        private const string pageUrl = "https://www.zigzag.lt/";
        private IWebElement inputYourName => Driver.FindElement(By.Name("your-name"));
        private IWebElement inputYourPhone => Driver.FindElement(By.Name("phone-number"));
        private IWebElement inputYourEmail => Driver.FindElement(By.Name("your-email"));
        private IWebElement inputYourQuestion => Driver.FindElement(By.Name("your-message"));
        private IWebElement buttonNotificationCancel => Driver.FindElement(By.Id("onesignal-slidedown-cancel-button"));
        private IWebElement buttonAcceptCookies => Driver.FindElement(By.CssSelector("body > div.cc_banner-wrapper > div > a"));
        private IWebElement buttonFlights => Driver.FindElement(By.CssSelector("#mf-nav > li:nth-child(3)"));
        private IWebElement buttonSearchForFlights => Driver.FindElement(By.Id("fl-submit"));
        private IWebElement buttonContacts => Driver.FindElement(By.CssSelector("#menu-main > li:nth-child(9) > a > span"));
        private IWebElement buttonSendMessage => Driver.FindElement(By.XPath("//*[@id=\"wpcf7-f15025-o1\"]/form/p[1]/input"));
        private IWebElement errorMessage => Driver.FindElement(By.ClassName("wpcf7-not-valid-tip"));
        

        public HomepagePage(IWebDriver webDriver) : base(webDriver) { }


        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }
        }

        public void ClickOnAcceptCookiesButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementExists(By.CssSelector("body > div.cc_banner-wrapper > div > a")));

            if (buttonAcceptCookies != null)
            {
                buttonAcceptCookies.Click();
            }
        }
        public void ClickOnNotificationButtonCancel()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementExists(By.Id("onesignal-slidedown-cancel-button")));

            if (buttonNotificationCancel != null)
            {
                buttonNotificationCancel.Click();
            }
        }

        public void ClickOnSendMessageButton()
        {
            buttonSendMessage.Click();
        }
        public void ClickOnContactButton()
        {
            buttonContacts.Click();
        }
        public void ClickOnFlightsButton()
        {
            buttonFlights.Click();
        }

        public void ClickOnSearchForFlightsButton()
        {
            buttonSearchForFlights.Click();
        }

        public void WriteToInputYourName(string yourName)
        {
            inputYourName.Clear();
            inputYourName.SendKeys(yourName);
        }
        public void WriteToInputYourPhone(string yourPhone)
        {

            inputYourPhone.Clear();
            inputYourPhone.SendKeys(yourPhone);
        }
        public void WriteToInputYourEmail(string yourEmail)
        {   
            inputYourEmail.Clear();
            inputYourEmail.SendKeys(yourEmail);
        }
        public void WriteToInputYourQuestion(string yourQuestion)
        {   
            inputYourQuestion.Clear();
            inputYourQuestion.SendKeys(yourQuestion);
        }
        public void AlertTextVerify(string alertText)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            
            Assert.AreEqual(alert.Text, alertText);
            
        }         
        public void AlertMessageAcceptance()
        {
            IAlert alert = Driver.SwitchTo().Alert();

            alert.Accept();
            
        }
        public void EmailMessageErrorVerify(string expectedErorrMessage)
        {
            Assert.AreEqual(expectedErorrMessage, errorMessage.Text, "Error message is wrong");
        }



    }
}