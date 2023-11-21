using Microsoft.AspNetCore.Components;
using Project.Shared.News;

namespace Project.Client.Pages.News.Public
{
    public partial class DetailPage
    {
        [Inject] public INewsService NewsService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public int Id { get; set; }

        private NewsDto.Detail News;
        private List<NewsDto.Index> LatestNews;

        protected override async Task OnParametersSetAsync()
        {
            await GetNewsAsync();
            await GetLatestNewsAsync();
        }

        private async Task GetNewsAsync()
        {
            NewsRequest.GetDetail request_detail = new() { NewsId = Id };
            var response = await NewsService.GetDetailAsync(request_detail);
            News = response.News;
        }

        private async Task GetLatestNewsAsync()
        {
            NewsRequest.GetIndex request_index = new() { Amount = 3 };
            var response = await NewsService.GetIndexAsync(request_index);
            LatestNews = response.News;
        }
        private void NavigateToNews()
        {
            NavigationManager.NavigateTo($"nieuws", forceLoad: true);
        }
    }
}
