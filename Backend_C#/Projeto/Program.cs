using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;


using Projeto.Data;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Projeto.Repository;
using Projeto.Interface;
using Projeto.Service;
var builder = WebApplication.CreateBuilder(args);





builder.Services.AddControllers();
builder.Services.AddOpenApi();


	var connStr  = builder.Configuration.GetConnectionString("ApiBaseUrl");
    builder.Services.AddDbContext<AppDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiBaseUrl"));});


builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<IProduct, ProdutoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();