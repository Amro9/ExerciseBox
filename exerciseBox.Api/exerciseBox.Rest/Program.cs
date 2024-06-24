using exerciseBox.Infrastructur;
using exerciseBox.Application.Abtraction;
using QuestPDF.Infrastructure;
using exerciseBox.Rest;

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
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // make the session cookie essential
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
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

app.UseSession();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<CustomMiddleWare>();

app.MapControllers();

app.Run();
