using Datos.modelos;
using Microsoft.EntityFrameworkCore;
using Negocio;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddTransient<IUnitOfWork>(option => new UnitOfWork(new BDEmpresaContext(new DbContextOptionsBuilder<BDEmpresaContext>().UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer")).Options), configuration.GetConnectionString("ConnectionSqlServer")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
