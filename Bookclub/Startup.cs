using Blazored.SessionStorage;
using Blazored.Toast;
using Bookclub.Core.Interfaces;
using Bookclub.Data;
using Bookclub.Services.BookViews;
using Bookclub.Views.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using Bookclub.Core.Services.Books;
using Bookclub.Services.Users;

namespace Bookclub
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookViewService, BookViewService>();

            services.AddScoped<AddressProvider>();

            services.AddBlazoredToast();

            services.AddBlazoredSessionStorage();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddSingleton<HttpClient>();
            services.AddHttpContextAccessor();
            AddRootDirectory(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private static void AddRootDirectory(IServiceCollection services)
        {
            services.AddRazorPages(OptionsBuilderConfigurationExtensions =>
            {
                OptionsBuilderConfigurationExtensions.RootDirectory = "/Views/Pages";
            });
        }
    }
}
