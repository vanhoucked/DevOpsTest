using Microsoft.AspNetCore.Components;
using Project.Shared.Categories;
using Project.Shared.News;

namespace Project.Client.Pages.News.Public
{
    public partial class Index
    {
        private List<NewsDto.Index> newsArticles = new();
        private string searchTerm = "";
        [Inject] public INewsService NewsService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var request = new NewsRequest.GetIndex();
            var response = await NewsService.GetIndexAsync(request);
            newsArticles = response.News;
        }
        async Task HandleSearch()
        {

        }
    }
}
