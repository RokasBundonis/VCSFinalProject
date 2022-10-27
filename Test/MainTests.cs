using FinalProject.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class MainTests : BaseTest
    {
        [Test]
        public static void ClientMessageWithoutEmailTest()
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.WriteToInputYourName("TestName");
            homepagePage.WriteToInputYourPhone("869999999");
            homepagePage.WriteToInputYourQuestion("TestQuestion");
            homepagePage.ClickOnSendMessageButton();
            homepagePage.EmailMessageErrorVerify("Laukas yra privalomas.");
        }

        [Test]
        public static void ClientMessageWithWrongEmailTest()
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.WriteToInputYourName("TestName");
            homepagePage.WriteToInputYourPhone("869999999");
            homepagePage.WriteToInputYourEmail("WrongEmail");
            homepagePage.WriteToInputYourQuestion("TestQuestion");
            homepagePage.ClickOnSendMessageButton();
            homepagePage.EmailMessageErrorVerify("El. paštas įvestas neteisingai.");
        }
        [Test]
        public static void FromHomepageToContactsTest()
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.ClickOnContactButton();
            contactsPage.WorkTimeVerify("I-V 10.00-17.00");
        }
        [Test]
        public static void CheapFlightsNoFlightsFound()
        {
            cheapFlightsPage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            cheapFlightsPage.WriteToInputTravelTo("Kaunas");
            cheapFlightsPage.DoubleClickOnCheapTravelSearchButton();
            cheapFlightsPage.VerifyNotFoundMessage("Atsiprašome");

        }
    }
}
