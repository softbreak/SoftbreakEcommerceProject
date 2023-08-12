using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Configurations;
using Project.DAL.Context;
using Project.ENTITIES.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBLLServiceContainer();
builder.Services.AddDbContext<MyContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
