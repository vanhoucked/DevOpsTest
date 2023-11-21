using Microsoft.AspNetCore.Components.Forms;

namespace Project.Client.Files
{
    public interface IStorageService
    {
        Task UploadImage(string sas, IBrowserFile file);
    }
}
