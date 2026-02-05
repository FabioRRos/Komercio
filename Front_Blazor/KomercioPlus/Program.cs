using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KomercioPlus;
using KomercioPlus.Service;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var urlApi = new Uri("https://localhost:8443/");
//var urlApi = new Uri("https://68.211.112.109:8443/");



builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = urlApi
});

builder.Services.AddScoped<ICaixaService, CaixaService>();
builder.Services.AddScoped<IMovimentacaoCaixaService, MovimentacaoCaixaService>();




await builder.Build().RunAsync();
