using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Application;
using Infrastructure;
using BlazorBootstrap;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//DI
builder.Services.addApplication();
builder.Services.addInfrastructure();

builder.Services.AddStackExchangeRedisCache(options => {
	options.Configuration = builder.Configuration.GetConnectionString("Redis");
	options.InstanceName = "BlazorDemo_";
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

