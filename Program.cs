using System.Security.Claims;
using Hand_In_1_Simas_DNP.Authentication;
using Hand_In_1_Simas_DNP.Entities.Models;
using Hand_In_1_Simas_DNP.Services;
using Hand_In_1_Simas_DNP.Services.Impls;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped<JsonContext>();
builder.Services.AddScoped<ForumContainer>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<IUserService, InMemoryUserService>();



// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", a => a.RequireAuthenticatedUser().RequireClaim("IsLoggedIn", "true"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();