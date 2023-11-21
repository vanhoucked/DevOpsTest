using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Project.Client.Pages.News
{
    public partial class FileManager
    {
        private string selectedImagePath;

        private async void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = await DialogService.Show<FilesDialog>("First Level Dialog", options).Result;
            selectedImagePath = dialog.Data as string ?? string.Empty;
            StateHasChanged();
        }
    }
}
