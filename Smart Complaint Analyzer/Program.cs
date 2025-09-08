using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Smart_Complaint_Analyzer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ModelApiService>(client =>
{
    client.BaseAddress = new Uri("http://127.0.0.1:8000/");
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
// builder.Services.AddScoped<ModelApiService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
