using Microsoft.AspNetCore.Components;
using Project.Shared.News;

namespace Project.Client.Pages.News.Components
{
    public partial class NewsListItem
    {
        [Parameter] public NewsDto.Index NewsArticle { get; set; } = default!;
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;


        private void NavigateToNews()
        {
            NavigationManager.NavigateTo($"nieuws/{NewsArticle.Id}");
        }
    }
}
