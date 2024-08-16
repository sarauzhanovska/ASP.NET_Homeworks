using BurgerApp.DataAccess;
using BurgerApp.DataAccess.EFImplementations;
using BurgerApp.DataAccess.Implementations;
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using BurgerApp.Services;
using BurgerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BurgerAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BurgerAppConnectionString")));



#region Register Services
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IBurgerService, BurgerService>();
builder.Services.AddTransient<IOrderService, OrderService>();


#endregion
#region Register Repositories
builder.Services.AddTransient<IRepository<Location>, EFLocationRepository>();
builder.Services.AddTransient<IRepository<Burger>, EFBurgerRepository>();
builder.Services.AddTransient<IRepository<Order>, EFOrderRepository>();

#endregion

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

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<BurgerAppDbContext>();
//    context.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS [dbo].[BurgerOrder]");
//}



app.Run();
