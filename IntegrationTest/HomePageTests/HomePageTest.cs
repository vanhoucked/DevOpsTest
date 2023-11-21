using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;



namespace IntegrationTest.HomePageTests
{
    [Parallelizable(ParallelScope.Self)]
    public class HomePageTest : PageTest
    {

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync($"https://localhost:7274/");
        }


        [Test]
        public async Task HomePageLoadsTest()
        {
           


            await Page.WaitForTimeoutAsync(3000);

            await Expect(Page.Locator("data-test-id=tester")).ToBeVisibleAsync();
            
            /*await page.ClickAsync("text=Nieuws");*/
            
        }
    }
}
