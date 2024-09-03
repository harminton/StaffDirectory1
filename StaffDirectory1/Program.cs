using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using StaffDirectory1.Areas.Identity.Data;
using StaffDirectory1.Models;
using static System.Formats.Asn1.AsnWriter;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StaffContextConnection") ?? throw new InvalidOperationException("Connection string 'StaffContextConnection' not found.");

builder.Services.AddDbContext<StaffContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<StaffUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StaffContext>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StaffContext>().AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccesDenied";


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope)())
        {
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Employee", "Customer" };
}


app.Run();
