using exerciseBox.Infrastructur;
using exerciseBox.Application.Abtraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplictaionConfiguration();
builder.Services.AddInfrastructureConfiguration();


//builder.Services.AddSession(options => options.IdleTimeout.Add(TimeSpan.FromMinutes(15)));

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

//app.UseSession();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
