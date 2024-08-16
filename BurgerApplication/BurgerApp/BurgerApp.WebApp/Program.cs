using BurgerApp.DataAccess.EFImplementations;
using BurgerApp.DataAccess.Implementations;
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using BurgerApp.Dtos.Dto;





//using BurgerApp.Domain;
using BurgerApp.Services;
using BurgerApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Register Services


#endregion
#region Register Repositories
builder.Services.AddTransient<IRepository<Order>, EFOrderRepository>();
builder.Services.AddTransient<IRepository<Burger>, EFBurgerRepository>();
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

app.Run();
