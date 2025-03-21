using ChecklistAPI.Data;
using Microsoft.EntityFrameworkCore;

var corsLocalhostPolicy = "LocalhostPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChecklistDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: corsLocalhostPolicy,
            policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
    });
}

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ItemRepository>();
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseCors(corsLocalhostPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
