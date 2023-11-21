using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Project.Domain.Conditions;

namespace IntegrationTest.ConditionApiTest
{
    
    public class ConditionTest : PlaywrightTest
    {
        private IAPIRequestContext Request = null;



        [Test]
        public async Task GetConditionsById()
        {
            var response = await Request.GetAsync("https://localhost:7274/api/Condition/1");
           
            Assert.AreEqual(200, response.Status);

            var responseData = await response.JsonAsync<Condition>();

            Assert.AreEqual(1, responseData.Id);
            Assert.AreEqual("Staar", responseData.Name);


        }




        [SetUp]
        public async Task SetUpApiTesting()
        {
            await CreateApiContext();
        }

        private async Task CreateApiContext()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://localhost:7274/"
            });
        }

        [TearDown]
        public async Task TearDownApiTesting()
        {
            await Request.DisposeAsync();
        }


    }
}
