using BlazamNews.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Diagnostics;
using MudBlazor.Services;
using BlazamNews.Pages.API;
using ApplicationNews;


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
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMudServices();
        builder.Services.AddMudBlazorSnackbar();
        builder.Services.AddSingleton<WeatherForecastService>();
       
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

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        
        app.Run();
    }
}