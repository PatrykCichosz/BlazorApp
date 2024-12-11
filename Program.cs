using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MMAApp;
using MMAApp.Services;
using System.Net.Http;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<MMAService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<FightService>();
builder.Services.AddScoped(sp => new HttpClient());
var app = builder.Build();

builder.Services.AddScoped<MMAService>();
builder.Services.AddScoped<FightService>();

builder.RootComponents.Add<App>("#app");

await builder.Build().RunAsync();
