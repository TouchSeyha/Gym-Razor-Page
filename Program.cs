using Gym.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Gym.Models;  // Make sure to include your ApplicationUser
using Microsoft.AspNetCore.Identity.UI; // Add this using directive
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Use ApplicationUser in Identity registration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<GymContext>()
    .AddDefaultTokenProviders();



builder.Services.AddRazorPages();

var app = builder.Build();

// Seed roles and an admin user if you have RoleSeeder in Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRolesAndAdminUserAsync(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
