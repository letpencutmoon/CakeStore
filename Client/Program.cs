global using CakeStore.Shared.Model;
global using CakeStore.Shared;
global using System.Net.Http.Json;
global using CakeStore.Client.Service.CakeService;
using CakeStore.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICakeService,CakeService>();

await builder.Build().RunAsync();
