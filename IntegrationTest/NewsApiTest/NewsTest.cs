using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Project.Shared.News;
using System.Drawing.Text;
using Project.Domain.News;

namespace IntegrationTest.NewsApiTest
{

    public class ConditionTest 
    {
        private IAPIRequestContext Request = null;
        private HttpClient client;



        [Fact]
        public async Task GetNewsById()
        {

           var response = await Request.GetAsync("https://localhost:7274/api/News/1");

            Assert.AreEqual(200, response.Status);

            var responseData = await response.JsonAsync<NewsArticle>();

            Assert.AreEqual(1, responseData.Id);
            Assert.AreEqual("Nieuw geneesmiddel ontdekt voor Staar", responseData.Title);


        }



        [Fact]
        public async Task PostNews()
        {

            var playwright = await Playwright.CreateAsync();

            var request = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = "https://localhost:7274/",
                IgnoreHTTPSErrors = true,

            });

            var response = await request.PostAsync("api/News", new APIRequestContextOptions()
            {
                DataObject = new
                {
                    news = new
                    {
                        id = 1,
                        title = "Nieuw geneesmiddel ontdekt voor Staar",
                        newsText = "Onderzoekers hebben onlangs een doorbraak gemaakt in de behandeling van staar. Een nieuw geneesmiddel is ontdekt dat de troebeling van de lens in het oog effectief kan verminderen.",
                        image = "https://picsum.photos/350/200",
                        author = new
                        {
                            id = 0,
                            firstName = "Bram",
                            lastName = "Lippens",
                            specialization = "Oogarts",
                            image = ""
                        },
                        category = "Information",
                        datePosted = "01/01/0001"
                    }
                }

               





            });

            var jsonString = await response.JsonAsync();

            Assert.Equals(200, response.Status);


        }


        [SetUp]
        public async Task SetUpApiTesting()
        {
            await CreateApiContext();
            client = new HttpClient();


        }

        private async Task CreateApiContext()
        {

        }

        [TearDown]
        public async Task TearDownApiTesting()
        {
            

        }


    }
}
