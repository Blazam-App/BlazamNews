using BlazamNews.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Diagnostics;
using MudBlazor.Services;
using BlazamNews.Pages.API;
using ApplicationNews;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlazamNews;


internal class Program
{
    public static IConfiguration? Configuration { get; private set; }
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        Configuration = builder.Configuration;
        NewsDbContext.ConnectionString = Configuration.GetConnectionString("DbConnectionString");
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMudServices(configuration =>

        {
            configuration.SnackbarConfiguration.PreventDuplicates = false;
            configuration.SnackbarConfiguration.MaxDisplayedSnackbars = 20;
            configuration.SnackbarConfiguration.HideTransitionDuration = 150;
            configuration.SnackbarConfiguration.ShowTransitionDuration = 150;

        }
        );
        builder.Services.AddMudBlazorSnackbar();
        builder.Services.AddScoped<AppAuthenticationStateProvider>();
        //Set up authentication and api token authentication
        builder.Services.Configure<CookiePolicyOptions>(options =>
        {

            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        builder.Services.AddAuthentication(
            CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(AppAuthenticationStateProvider.ApplyAuthenticationCookieOptions());

        //var factory = new NewsDatabaseContextFactory(options.Options);
        //builder.Services.AddSingleton<NewsDatabaseContextFactory>(factory);
        builder.Services.AddDbContextFactory<NewsDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });

        app.Run();
    }
}