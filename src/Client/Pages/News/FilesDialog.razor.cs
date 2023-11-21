using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Project.Client.Pages.News
{
    public partial class FilesDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        IList<string> images = new List<string>();
        string selectedimage { get; set; } = default!;

        private void UploadFiles(IReadOnlyList<IBrowserFile> files)
        {
            images.Add("https://oorgarts.blob.core.windows.net/images/boekje.jpeg");
            images.Add("https://oorgarts.blob.core.windows.net/images/artsen.jpeg");
            images.Add("https://oorgarts.blob.core.windows.net/images/boekje.jpeg");
            images.Add("https://oorgarts.blob.core.windows.net/images/boekje.jpeg");
            images.Add("https://oorgarts.blob.core.windows.net/images/boekje.jpeg");
            images.Add("https://oorgarts.blob.core.windows.net/images/boekje.jpeg");
            foreach (var file in files)
            {
                //TODO UPLOAD TO AZURE
            }

        }

        private void SelectImage(string imagepath)
        {
            selectedimage = imagepath;
            Ok();
        }

        private void Ok() => MudDialog.Close(DialogResult.Ok(selectedimage));
    }
}
