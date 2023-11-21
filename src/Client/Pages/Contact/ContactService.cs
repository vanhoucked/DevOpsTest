using Azure.Core;
using Project.Client.Extensions;
using Project.Client.Infrastructure;
using Project.Shared.Companies;
using Project.Shared.News;
using System.Net.Http.Json;

namespace Project.Client.Pages.Contact
{
    public class ContactService : ICompanyService
    {
        private readonly PublicClient publicClient;
        private const string endpoint = "/api/company";

        public ContactService(PublicClient client)
        {
            this.publicClient = client;
        }

         async Task<CompanyResponse.GetDetail> ICompanyService.GetDetailAsync()
        {
            var response = await publicClient.Client.GetFromJsonAsync<CompanyResponse.GetDetail>($"{endpoint}");
            return response;
        }
    }
}
