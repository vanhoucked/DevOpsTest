using Newtonsoft.Json;
using System.Net.Http.Headers;
using Project.Shared.Emails;


namespace Project.Client.Service
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _client;
        public EmailService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> SendEmail(ContactDto.Detail contact)
        {
            using HttpContent requestBody = new StringContent(JsonConvert.SerializeObject(contact));
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Uri requestUri = new Uri($"/api/contact", UriKind.Relative);
            var response = await _client.PostAsync(requestUri, requestBody).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
