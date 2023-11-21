using Project.Client.Infrastructure;
using Project.Shared.Categories;
using System.Net.Http.Json;

namespace Project.Client.Pages.News.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PublicClient publicClient;
        private const string endpoint = "api/category";

        public CategoryService(PublicClient publicClient)
        {
            this.publicClient = publicClient;
        }
        public async Task<CategoryResponse.GetIndex> GetIndexAsync(CategoryRequest.GetIndex request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<CategoryResponse.GetIndex>($"{endpoint}");
            return response;
        }
    }
}
