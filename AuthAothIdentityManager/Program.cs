using AuthAothIdentityManager.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AddEntityFrameworkStores adds relationship between user, roles and stores for the db context
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt => opt.Password.RequiredLength = 5).AddEntityFrameworkStores<AppDbContext>();
 
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequiredLength = 8;
    option.Password.RequireLowercase = true;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    option.Lockout.MaxFailedAccessAttempts = 2;
});

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
// WARNING: Authentication should always comes before Authorizations in the HTTP request pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
