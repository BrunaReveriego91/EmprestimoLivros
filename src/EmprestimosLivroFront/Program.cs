using Blazored.LocalStorage;
using EmprestimosLivroFront;
using EmprestimosLivroFront.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();

builder.Services.AddTransient<MiddlewareHandler>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<AuthProvider>());



builder.Services.AddHttpClient("TechChallenge", (config) =>
{    
    config.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    config.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<MiddlewareHandler>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();


