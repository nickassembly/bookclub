using Blazored.SessionStorage;
using Blazored.Toast;
using Bookclub.Brokers.API;
using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Core.Interfaces;
using Bookclub.Data;
using Bookclub.Configurations;
using Bookclub.Services;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Services.Users;
using Bookclub.Views.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RESTFulSense.Clients;
using System;
using System.Net.Http;

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

            services.AddScoped<IApiBroker, ApiBroker>();
            services.AddScoped<ILogger, Logger<LoggingBroker>>();
            services.AddScoped<ILoggingBroker, LoggingBroker>();
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookViewService, BookViewService>();
            
            services.AddScoped<IDotnetToJavascript, DotnetToJavascript>();
            services.AddScoped<AddressProvider>();

            services.AddBlazoredToast();

            services.AddBlazoredSessionStorage();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            AddHttpClient(services);
           
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

        private void AddHttpClient(IServiceCollection services)
        {
            services.AddHttpClient<IRESTFulApiFactoryClient, RESTFulApiFactoryClient>(client =>
            {
                LocalConfigurations localConfigurations = Configuration.Get<LocalConfigurations>();
                string apiUrl = localConfigurations.ApiConfigurations.Url;
                client.BaseAddress = new Uri(apiUrl);

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
