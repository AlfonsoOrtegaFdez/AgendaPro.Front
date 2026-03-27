using AgendaFisio.Front;
using AgendaFisio.Front.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<AuthHeaderHandler>();

builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthHeaderHandler>();
    handler.InnerHandler = new HttpClientHandler();

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(apiBaseUrl!)
    };
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AgendaApiService>();
builder.Services.AddScoped<ProfesionalesApiService>();
builder.Services.AddScoped<PacientesApiService>();
builder.Services.AddScoped<CitasApiService>();

await builder.Build().RunAsync();