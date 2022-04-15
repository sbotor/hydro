using Hydro.Api.Config;
using Hydro.Api.Filters;
using Hydro.Api.Services;
using Hydro.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var dbDir = Environment.CurrentDirectory;
    var dbPath = Path.Combine(dbDir, "hydro.db");
    options.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddAutoMapper(typeof(DrinkProfile));

builder.Services.AddScoped<DrinkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
    db?.Database.EnsureDeleted();
    db?.Database.EnsureCreated();
}

app.Run();
