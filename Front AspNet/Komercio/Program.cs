var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<Komercio.Services.IAuthService, Komercio.Services.AuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:8443/");
})

    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        // Pra não dar erro de ssl por enquanto, arrumar isso depois fabio do futuro
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
    });

builder.Services.AddHttpClient<Komercio.Services.IRelatoriosService, Komercio.Services.RelatoriosService>(client =>
{
    // A URL base é a mesma, já que ambos consultam o mesmo Backend Go
    client.BaseAddress = new Uri("https://localhost:8443/");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // Ignora erro de SSL (Necessário se o certificado do Go for autoassinado)
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
});



// Add services to the container.
builder.Services.AddControllersWithViews();



//configurar os cookies no navegador
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "Komercio.Session";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";

        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//Primeiro vejo se o mano pode
app.UseAuthentication();

//Depois eu libero ele
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
