using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Project.Client.Infrastructure;
using Project.Shared.News;
using Project.Shared.Categories;
using Project.Client.Files;
using Project.Shared.Doctors;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Project.Client.Auth;
using Project.Client.Pages.News.Services;
using Project.Client.Pages.AboutUs;
using Project.Shared.Companies;
using Project.Client.Pages.Contact;
using Project.Client.Service;

namespace Project.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("AuthenticatedServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                   .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                   .CreateClient("AuthenticatedServerAPI"));

            builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]); // 👈
            }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IStorageService, AzureBlobStorageService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<ICompanyService, ContactService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}