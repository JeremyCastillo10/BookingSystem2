
using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using BookingSystem.Client;
using BookingSystem.Client.Auth;
using BookingSystem.Client.Repositorios;
using BookingSystem.Server.Models;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BookingSystem.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
//builder.Services.AddSingleton<AuthenticationStateProvider, MyAuthenticationStateProvider>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BookingSystem.ServerAPI"));
builder.Services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
builder.Services.AddScoped<IProfesionalRepositorio, ProfesionalRepositorio>();
builder.Services.AddScoped<IProfesionalDetalleRepositorio, ProfesionalDetalleRepositorio>();
builder.Services.AddScoped<ICitaRepositorio, CitaRepositorio>();


builder.Services.AddApiAuthorization();
builder.Services.AddMudServices();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
