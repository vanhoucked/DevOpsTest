using Project.Client.Extensions;
using Project.Client.Infrastructure;
using Project.Shared.News;
using System.Net.Http.Json;

namespace Project.Client.Pages.News.Services
{
    public class NewsService : INewsService
    {
        private readonly PublicClient publicClient;
        private readonly HttpClient authenticatedClient;
        private const string endpoint = "api/news";

        public NewsService(HttpClient httpClient, PublicClient publicClient)
        {
            this.publicClient = publicClient;
            authenticatedClient = httpClient;
        }
        public async Task<NewsResponse.GetIndex> GetIndexAsync(NewsRequest.GetIndex request)
        {
            var queryParameters = request.GetQueryString();
            var response = await publicClient.Client.GetFromJsonAsync<NewsResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }
        public async Task<NewsResponse.GetDetail> GetDetailAsync(NewsRequest.GetDetail request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<NewsResponse.GetDetail>($"{endpoint}/{request.NewsId}");
            return response;
        }

        public async Task<NewsResponse.Create> CreateAsync(NewsRequest.Create request)
        {
            var response = await publicClient.Client.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<NewsResponse.Create>();
        }

        public async Task DeleteAsync(NewsRequest.Delete request)
        {
            await publicClient.Client.DeleteAsync($"{endpoint}/{request.NewsId}");
        }

        public async Task<NewsResponse.Edit> EditAsync(NewsRequest.Edit request)
        {
            var response = await publicClient.Client.PutAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<NewsResponse.Edit>();
        }
    }
}
