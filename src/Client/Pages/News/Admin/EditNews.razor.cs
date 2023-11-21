using Microsoft.AspNetCore.Components;
using Project.Shared.Categories;
using Project.Shared.News;

namespace Project.Client.Pages.News.Admin
{
    public partial class EditNews
    {
        [Parameter] public string newsId { get; set; }
        [Inject] private INewsService NewsService { get; set; }
        [Inject] private ICategoryService CategoryService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }

        private List<CategoryDTO.Index> categories;

        protected override async Task OnInitializedAsync()
        {
            var request = new CategoryRequest.GetIndex();
            var response = await CategoryService.GetIndexAsync(request);
            categories = response.Categories;

            var request2 = new NewsRequest.GetDetail();
            request2.NewsId = Convert.ToInt32(newsId);
            var response2 = await NewsService.GetDetailAsync(request2);
            Title = response2.News.Title;
            Category = response2.News.Category;
            Content = response2.News.NewsText;
        }

        private async void OnSubmit()
        {
            var request = new NewsRequest.Edit
            {
                NewsId = Convert.ToInt32(newsId),
                News = new NewsDto.Mutate
                {
                    Image = "",
                    Title = Title,
                    Category = Category,
                    NewsText = Content
                }
            };

            var response = await NewsService.EditAsync(request);
            if (response is not null)
            {
                NavigationManager.NavigateTo("admin/news", forceLoad: true);
            }
        }
    }
}
