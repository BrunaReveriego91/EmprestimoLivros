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
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
builder.Services.AddScoped<AuthenticationService>(sp => 
    (AuthenticationService) sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient("TechChallenge", (config) =>
{    
    config.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    config.DefaultRequestHeaders.Add("Accept", "application/json");
});


await builder.Build().RunAsync();


