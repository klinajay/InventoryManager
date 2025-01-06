using InventoryManager.Components;
using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Data;
using InventoryManager.Repositories;
using InventoryManager.Services;
using InventoryManager.State;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Host.UseSerilog((context , configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductRepositoryService, ProductRepositoryService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryRepositoryService, ProductCategoryRepositoryService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<SupplierRepositoryService, SupplierRepositoryService>();
builder.Services.AddScoped<ApplicationState>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
