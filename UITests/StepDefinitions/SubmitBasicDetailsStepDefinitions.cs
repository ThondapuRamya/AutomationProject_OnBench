using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using UICore.Pages;
using UITests.Providers;


namespace UITests.StepDefinitions
{
    [Binding]
    internal class SubmitBasicDetailsStepDefinitions: BaseTest
    {        
        LoginPage loginPage;
        GetUsersPage getUsersPage;
         BrandsharkHomePage brandSharkHomePage;     
        public SubmitBasicDetailsStepDefinitions(IObjectContainer objectContainer) :base(objectContainer)
        {                           
            loginPage = new LoginPage(driver);
            getUsersPage = new GetUsersPage(driver);
            brandSharkHomePage = new BrandsharkHomePage(driver);
        }
       
        [Given("Launch brandshark application")]
        public void GivenLaunchBrandsharkApplication()
        {
            string url = ConfigurationProvider.applicationDetails.ApplicationUrl;
            loginPage.LaunchUrl(url);
        }

        [When("Click on (.*) link")]
        public void WhenClickOnDesignWebsitesLink(string linkName)
        {
            getUsersPage.ClickOnGivenLink(linkName);
        }

        [When("Click on Visit website button")]
        public void WhenClickOnVisitWebsiteButton()
        {
            getUsersPage.ClickOnVisitWebsite();
        }

        [Then("Validate new window is opened with url contains in it as (.*) and switch To That Window")]
        public void ThenValidateNewWindowIsOpenedWithPageNameBrandshark(string urlText)
        {
            brandSharkHomePage.ValidateNewWindowIsOpenedWithurlContainsAndSwitchToWindow(urlText);
        }

        [Then("Validate Let's get started session is displayed")]
        public void ThenValidateLetsGetStartedSessionIsDisplayed()
        {
            Assert.That(brandSharkHomePage.ValidateLetsGetStartedSessionIsDisplayed(), Is.True, "Lets get started session is not displayed");
        }

        [When("Enter name value as (.*)")]
        public void WhenEnterNameValueAsAbcd(string name)
        {
            brandSharkHomePage.SetName(name);
        }

        [When("Enter Company value as (.*)")]
        public void WhenEnterCompanyValueAsEfgh(string company)
        {
            brandSharkHomePage.SetCompany(company);
        }

        [When("Enter Phone value as (.*)")]
        public void WhenEnterPhoneValueAs(string phone)
        {
            brandSharkHomePage.SetPhone(phone);
        }

        [When("Enter Email value as (.*)")]
        public void WhenEnterEmailValueAsAbcGmail_Com(string email)
        {
            brandSharkHomePage.SetEmail(email);
        }

        [When("Click on submit button and validate Thankyou page is displayed")]
        public void WhenClickOnSubmitButtonAndValidateThankyouPageIsDisplayed()
        {
            brandSharkHomePage.ClickOnSubmit();
        }
    }
}
