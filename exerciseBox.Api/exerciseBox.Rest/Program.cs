using exerciseBox.Infrastructur;
using exerciseBox.Application.Abtraction;
using QuestPDF.Infrastructure;
using exerciseBox.Rest;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplictaionConfiguration();
builder.Services.AddInfrastructureConfiguration();

// Add a distributed memory cache
builder.Services.AddDistributedMemoryCache();

QuestPDF.Settings.License = LicenseType.Community;

// Configure session state
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(1);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true; // make the session cookie essential
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AuthCookie";
        options.LoginPath = "/api/Authentification/Login";
        options.LogoutPath = "/api/Authentification/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = false;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.None;
    });


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:4200")
                   .AllowCredentials() // Allow credentials to be sent
                   .AllowAnyHeader()
                   .AllowAnyMethod();
                   //.AllowAnyOrigin()
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS before other middlewares that handle HTTP requests
app.UseCors("AllowAllOrigins");

//app.UseSession();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<CustomMiddleWare>();

app.MapControllers();

app.Run();
