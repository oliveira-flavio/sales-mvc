using Microsoft.EntityFrameworkCore;
using sales_mvc.Data;
using sales_mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Conserta problema com data no Postgress com .Net 6
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<sales_mvcContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("sales_mvcContext"), builder => 
    builder.MigrationsAssembly("sales-mvc")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Resolve injeção de dependência SeedingService
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var seedingService = services.GetRequiredService<SeedingService>();
    seedingService.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
