using Microsoft.AspNetCore.Components.Forms;

namespace Project.Client.Files
{
    public class AzureBlobStorageService : IStorageService
    {
        private readonly HttpClient client;
        public static long MaxFileSize => 1024 * 1024 * 10;

        public AzureBlobStorageService(HttpClient client)
        {
            this.client = client;
        }

        public async Task UploadImage(string sas, IBrowserFile file)
        {
            var content = new StreamContent(file.OpenReadStream(MaxFileSize));
            content.Headers.Add("x-ms-blob-type", "BlockBlob");
            content.Headers.Add("Content-Type", file.ContentType);
            var response = await client.PutAsync(sas, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
