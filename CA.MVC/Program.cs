using CA.MVC.Contracts;
using CA.MVC.Services;
using CA.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(o =>
    {
        o.LoginPath = "/User/Login";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<IClient, Client>(c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("API:BaseURL")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCookiePolicy();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
