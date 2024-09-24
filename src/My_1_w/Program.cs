using Microsoft.EntityFrameworkCore;
using My_1_w.Application.Core.Entities;
using My_1_w.Application.Core.Interfaces;
using My_1_w.Configuration;
using My_1_w.infrastructure.Data;
using My_1_w.Interfaces;
using My_1_w.Services;

var builder = WebApplication.CreateBuilder(args);
My_1_w.infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);//здесь    
//по сути в другом проекте подключаем наши завсимости и регистрируем наш dbContext

// Add services to the container.
builder.Services.AddControllersWithViews();

//ioc
builder.Services.AddCoreServices();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));//<--пустые скобки для того,чтобы любой тип залетал
builder.Services.AddScoped<ICatalogItemViewModelService,CatalogItemViewModelService>();

var app = builder.Build();//<----место,где создаётся веб-приложение---WebApplication
app.Logger.LogInformation("App created...");

app.Logger.LogInformation("Database migraion running...");//это код для запуска базы данных миграции
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var catalogContext = scopedProvider.GetRequiredService<CatalogContext>();//здесь будет запускаться миграция
        if (catalogContext.Database.IsSqlServer())
        {
            catalogContext.Database.Migrate();
        }
        await CatalogContextSeed.SeedAsync(catalogContext, app.Logger);//<--это на вырост
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred adding migrations to Databse.");
    }

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
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Logger.LogDebug("Starting the app...");
app.Run();
