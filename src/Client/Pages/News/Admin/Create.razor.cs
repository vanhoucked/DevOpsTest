using Blazored.TextEditor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Project.Client.Files;
using Project.Shared.Categories;
using Project.Shared.News;

namespace Project.Client.Pages.News.Admin
{
    public partial class Create
    {
        private IBrowserFile? image;
        private string selectedImagePath;
        private NewsDto.Mutate newsArticle = new();
        private List<CategoryDTO.Index> categories = new List<CategoryDTO.Index>();
        private BlazoredTextEditor QuillHtml;
        //private string QuillHTMLContent;
        [Inject] public INewsService NewsService { get; set; } = default!;
        [Inject] public IStorageService StorageService { get; set; } = default!;
        [Inject] public ICategoryService CategoryService { get; set; } = default!;
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var request = new CategoryRequest.GetIndex();
            var response = await CategoryService.GetIndexAsync(request);
            categories = response.Categories;
        }

        public async Task CreateNewsArticle()
        {
            newsArticle.NewsText = await QuillHtml.GetHTML();
            newsArticle.Image = "asdasdasd";

            NewsRequest.Create request = new()
            {
                News = newsArticle
            };
            NewsResponse.Create response = await NewsService.CreateAsync(request);
            //await StorageService.UploadImage(response.UploadUri, image!);

            NavigationManager.NavigateTo($"admin/nieuws");
        }

        private async void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = await DialogService.Show<FilesDialog>("First Level Dialog", options).Result;
            selectedImagePath = dialog.Data as string ?? string.Empty;
            await QuillHtml.InsertImage(selectedImagePath);
            StateHasChanged();
        }
    }
}
