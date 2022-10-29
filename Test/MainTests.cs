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
        [TestCase("TestName", "869999999","", "TestQuestion", "Laukas yra privalomas.",
            TestName = "ClientMessageEmailTestWithoutEmail")]
        [TestCase("TestName", "869999999", "WrongEmail", "TestQuestion", "El. paštas įvestas neteisingai.",
            TestName = "ClientMessageEmailTestWithWrongEmail")]
        public static void ClientMessageEmailTest(
            string textName, string textNumber, string textEmail, string textQuestion, string errorMessage )
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.ClickOnAcceptCookiesButton();
            homepagePage.WriteToInputYourName(textName);
            homepagePage.WriteToInputYourPhone(textNumber);
            homepagePage.WriteToInputYourEmail(textEmail);
            homepagePage.WriteToInputYourQuestion(textQuestion);
            homepagePage.ClickOnSendMessageButton();
            homepagePage.EmailMessageErrorVerify(errorMessage);
        }
        [Test]
        public static void FromHomepageToContactsTest()
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.ClickOnAcceptCookiesButton();
            homepagePage.ClickOnContactButton();
            contactsPage.WorkTimeVerify("I-V 10.00-17.00");
        }
        [Test]
        public static void CheapFlightsNoFlightsFound()
        {
            cheapFlightsPage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.ClickOnAcceptCookiesButton();
            cheapFlightsPage.WriteToInputTravelTo("Kaunas");
            cheapFlightsPage.DoubleClickOnCheapTravelSearchButton();
            cheapFlightsPage.VerifyNotFoundMessage("Atsiprašome");
        }
        [Test]
        public static void SearchingForFlightsAlertMessage()
        {
            homepagePage.NavigateToPage();
            homepagePage.ClickOnNotificationButtonCancel();
            homepagePage.ClickOnAcceptCookiesButton();
            homepagePage.ClickOnFlightsButton();
            homepagePage.ClickOnSearchForFlightsButton();
            homepagePage.AlertTextVerify("Įveskite visą paieškai būtiną informaciją!");
            homepagePage.AlertMessageAcceptance();

        }

    }
}
