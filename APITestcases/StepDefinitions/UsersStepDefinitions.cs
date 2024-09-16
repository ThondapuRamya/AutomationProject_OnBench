using System;
using System.Net;
using APITestcases.Pages;
using NUnit.Framework;
using Reqnroll;

namespace APITestcases.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        [Given("Create a GET request to get all users with page value as (.*)")]
        public void GivenCreateAGETRequestToGetAllUsers(string pageValue)
        {
            Assert.That(UsersPage.GetListOfUsers(pageValue).StatusCode, Is.EqualTo(HttpStatusCode.OK), "Get list of user end point failed" );
        }

        [Then("Validate users list displayed in given range (.*) and (.*)")]
        public void ThenValidateUsersListDisplayed(int startingRange, int endingRange)
        {
            Assert.That(UsersPage.ValidateGetListOfUsers(startingRange,endingRange), Is.EqualTo(true), "The number of records displayed is not as expected");
        }

        [Given("Create resource")]
        public void GivenCreateAResource()
        {
            Assert.That(UsersPage.CreateResource().StatusCode, Is.EqualTo(HttpStatusCode.Created), "The create user api request failed");
        }

        [Then("Validate Resource is created or not")]
        public void ThenValidateResourceCreatedOrNot()
        {
            Assert.That(UsersPage.ValidateCreateRequestResponse(), Is.EqualTo(true), "The created resource is not updated in system correctly");
        }
    }
}
