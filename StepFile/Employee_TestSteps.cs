using CRUD_Test.Common;
using CRUD_Test.Page;
using NUnit.Framework;
using RestSharp;
using System;
using System.Data;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace CRUD_Test.StepFile
{
    [Binding]
    public class Employee_TestSteps
    {
        
        int response;
        string message;
        Employee_TestPage page;


      
        [Given(@"the user is a valid user")]
        public void GivenTheUserIsAValidUser()
        {

            try
            {
                page = new Employee_TestPage();
                page.setReq();
            }
            catch(Exception ex)
            {
                throw ex;

            }

        }

     
        [When(@"the user request for '(.*)' the user details")]
        public void WhenTheUserRequestForTheUserDetails(string p0)
        {
            try {

                 page.GetRequest(p0);
                


            }
            catch(Exception ex)
            { 
            
            }
        }





        [Then(@"the user details should be returned with status code '(.*)'")]
        public void ThenTheUserDetailsShouldBeReturnedWithStatusCode(int p0)
        {
            try
            {
                response = page.GetResponse();
                Assert.AreEqual(p0, response);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [When(@"the request for '(.*)' the user details with Id '(.*)'")]
        public void WhenTheRequestForTheUserDetailsWithId(string p0, int p1)
        {
            try {
                page.GetRequestParam(p0,p1);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        [Then(@"the user details should be verified with status code '(.*)'")]
        public void ThenTheUserDetailsShouldBeVerifiedWithStatusCode(int p0, Table table)
        {
            try
            {
               DataTable data = CommonMethod.ToDataTable(table);
               page.VerifyRequestDetails(data);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [When(@"the request for '(.*)' the user details with details")]
        public void WhenTheRequestForTheUserDetailsWithDetails(string p0, Table table)
        {
            try
            {
                string json = table.Rows[0]["Data"];
                page.CreateUser(p0,json);

            }catch(Exception ex)
            {
                throw ex;

            }
        }

        [Then(@"the user details should be returned with success message")]
        public void ThenTheUserDetailsShouldBeReturnedWithSuccessMessage(Table table)
        {
            try
            {
                string msg= table.Rows[0]["Message"];
                message = page.GetResponseMessage();
                Assert.AreEqual(msg, message);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




    }
}
