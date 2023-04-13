using Microsoft.EntityFrameworkCore;
using BancoMusica.Models;
using Microsoft.Extensions.DependencyInjection;
using BancoMusica.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BancoMusica.Repositorio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BancoMusicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BancoMusicaContext") ?? throw new InvalidOperationException("Connection string 'BancoMusicaContext' not found.")));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
