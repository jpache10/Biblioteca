using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Biblioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Agregando servicios al contenedor

#region configuración de conexión de base de datos
var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase") ?? "Data Source=BibliotecaDatabase.db";
builder.Services.AddSqlite<SqlDatabaseBibliotecaContext>(connectionString);
#endregion


builder.Services.AddControllersWithViews();


#endregion

var app = builder.Build();

#region Agregando configuraciones 

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
