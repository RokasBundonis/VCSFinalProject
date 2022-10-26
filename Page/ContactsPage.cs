using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class ContactsPage : BasePage
    {
        private const string pageUrl = "https://www.zigzag.lt/kontaktai/";
        private IWebElement textWorkTime => Driver.FindElement(By.CssSelector("body > div.site-container > div.site-inner > div > main > article > div > div:nth-child(3) > div:nth-child(2)"));
        public ContactsPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageUrl)
            {
                Driver.Url = pageUrl;
            }
        }

        public void WorkTimeVerify(string text)
        {
            Assert.IsTrue(textWorkTime.Text.Contains(text), "Work time is wrong");
        }
    }
}
