using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.Web;
using Portfolio.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API Base URL — read from appsettings or fallback to localhost for Docker dev
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:7241";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
builder.Services.AddScoped<PortfolioApiService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var host = builder.Build();

await host.RunAsync();
