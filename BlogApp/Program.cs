using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddMvcLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var AllCultures = new List<CultureInfo>
{
   new CultureInfo("tr-TR"),
   new CultureInfo("en-US"),
   new CultureInfo("fr-FR")
};

var defaultCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SupportedCultures = AllCultures;
    options.SupportedUICultures = AllCultures;
    options.DefaultRequestCulture = defaultCulture;
});


builder.Services.AddDbContext<BlogDbContext>(opt=>
opt.UseSqlServer("Server=.;Database=BlogDb;Integrated Security=True;TrustServerCertificate=true"));

var app = builder.Build();

app.UseRequestLocalization(options =>
{
    options.SupportedCultures = AllCultures;
    options.SupportedUICultures = AllCultures;
    options.DefaultRequestCulture = defaultCulture;
});

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

app.Run();
