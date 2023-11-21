using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Project.Shared.Conditions;
using Project.Services.Conditions;
using Project.Shared.Doctors;
using Project.Shared.News;
using Project.Services.Doctors;
using Project.Services.Companies;
using Microsoft.Net.Http.Headers;
using SendGrid.Extensions.DependencyInjection;
using Project.Services.Email;
using Project.Shared.Companies;
using Project.Shared.Emails;
using Project.Persistence.Data;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Project.Services.News;

namespace Project.Server
{
    public class Startup
    {

        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration) 
        {  
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("WebApiDatabase"));
            services.AddDbContext<OogArtsDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
                //options.UseNpgsql(builder.ConnectionString);
            });

            services.AddControllersWithViews();
            //TODO: https://docs.fluentvalidation.net/en/latest/custom-validators.html - implementing SetValidator
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<ConditionDTO.Mutate.Validator>();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Oogarts API", Version = "v1" });
            });

            //AUTHENTICATION AND AUTHORIZATION
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });
            services.AddAuth0AuthenticationClient(config =>
            {
                config.Domain = Configuration["Auth0:Authority"];
                config.ClientId = Configuration["Auth0:ClientId"];
                config.ClientSecret = Configuration["Auth0:ClientSecret"];
            });

            services.AddAuth0ManagementClient().AddManagementAccessToken();

            services.AddRazorPages();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IConditionService, ConditionService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<OogArtsDataInitializer>();
            services.AddSendGrid(opt => opt.ApiKey = Configuration["SendGrid:ApiKey"]);
        }

        /* mss nog data initializer*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OogArtsDbContext dbContext,
            OogArtsDataInitializer dataInitializer)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Oogarts API"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dataInitializer.SeedData();

            //app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            
            app.UseRouting();

            //AUTH AND AUTHOR
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
