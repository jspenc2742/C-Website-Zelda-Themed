using Microsoft.EntityFrameworkCore;
using ZeldaInventoryApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Registering the database context class (SpencerContext) using SQL Server and connection string
builder.Services.AddDbContext<SpencerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpencerContextConnection")));

// Add MVC services to the container (supports multiple controllers and views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Setting default route mapping to Inventory controller Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inventory}/{action=Index}/{id?}");

app.Run();
