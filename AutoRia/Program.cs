using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities;
using AutoRia.Helpers;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("AzureDb");

// Add services to the container.
builder.Services.AddControllersWithViews();

// configure dependencies
builder.Services.AddDbContext<CarDbContext>(opts => opts.UseSqlServer(connStr));

//builder.Services.AddDefaultIdentity<User>(options =>
//    {
//        options.SignIn.RequireConfirmedAccount = true;
//        options.Password.RequireDigit = true;

//    }).AddEntityFrameworkStores<ShopSPUDbContext>();

builder.Services.AddIdentity<User, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddEntityFrameworkStores<CarDbContext>();

// add FluentValidator with validation classes
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// seed admin user
using (IServiceScope scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // seed roles
    SeedExtensions.SeedRoles(serviceProvider).Wait();

    // seed admin
    SeedExtensions.SeedAdmin(serviceProvider).Wait();
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
app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
