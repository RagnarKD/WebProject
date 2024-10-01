using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;
using WebProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:TranslationConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICSVService, CSVService>();

var app = builder.Build();


app.MapDefaultControllerRoute();

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<DataContext>();

SeedData.SeedDatabase(context, new CSVService(), File.OpenRead(Path.Combine(Environment.CurrentDirectory, @"Model", "sentences_en-fo.strict.csv")));

app.Run();
