using FINSCOPE.Models;
using Microsoft.EntityFrameworkCore;
using FINSCOPE.Data;
using Microsoft.AspNetCore.Identity;
//using FINSCOPE.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FINSCOPEContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FINSCOPEContext") ?? throw new InvalidOperationException("Connection string 'FINSCOPEContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
