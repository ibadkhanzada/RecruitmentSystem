using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Models;
using Microsoft.AspNetCore.Http; // Required for CookieSecurePolicy

var builder = WebApplication.CreateBuilder(args);

// ✅ Add secure cookie configuration
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RecruitmentSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// ✅ Add cookie policy middleware BEFORE authorization
app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
