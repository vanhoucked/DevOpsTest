using Microsoft.AspNetCore.Components;
using MudBlazor;
using Project.Shared.News;
using static MudBlazor.Icons;

namespace Project.Client.Pages.News.Admin
{
    public partial class OverviewNews
    {
        [Inject] public INewsService NewsService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private NewsDto.Index selectedItem1 = null;

        private List<NewsDto.Index> News;

        protected override async Task OnInitializedAsync()
        {
            var request = new NewsRequest.GetIndex();
            request.SearchTerm = searchString1;
            var response = await NewsService.GetIndexAsync(request);
            News = response.News;
        }

        private bool FilterFunc1(NewsDto.Index element) => FilterFunc(element, searchString1);

        private bool FilterFunc(NewsDto.Index element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.Author.FirstName} {element.Author.LastName}".Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.Id}".Contains(searchString))
                return true;
            return false;
        }
        private void NavigateToCreate()
        {
            NavigationManager.NavigateTo($"admin/create-nieuws");
        }
        private void Edit(int id)
        {
            NavigationManager.NavigateTo($"/admin/edit-nieuws/{id}");
        }
        private async void Delete(int id)
        {
            var request = new NewsRequest.Delete
            {
                NewsId = Convert.ToInt32(id)
            };
            await NewsService.DeleteAsync(request);
            //TODO: ask better ways?
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
    }
}
