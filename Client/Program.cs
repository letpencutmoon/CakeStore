global using CakeStore.Shared.Model;
global using CakeStore.Shared;
global using System.Net.Http.Json;
global using CakeStore.Client.Service.CakeService;
global using CakeStore.Client.Service.CategoryService;
global using CakeStore.Client.Service.CartService;
global using CakeStore.Client.Service.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using CakeStore.Client.Service.OrderService;
global using CakeStore.Client.Service.AddressService;
global using CakeStore.Client.Service.CakeTypeService;
using CakeStore.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICakeService,CakeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService,CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICakeTypeService, CakeTypeService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


await builder.Build().RunAsync();
