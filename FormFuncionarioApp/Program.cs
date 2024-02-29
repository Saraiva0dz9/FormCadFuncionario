using FormFuncionario.Data;
using FormFuncionario.Services.FuncionarioCadDb;
using FormFuncionario.Services.Requisicao;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IRequisicaoService, RequisicaoService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//Syncfusion License
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(configuration["SyncfusionKey"]);

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
