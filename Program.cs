using WebApplication1;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Modules;
using WebApplication1.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.IRepository;
using WebApplication1.Repository;
//using ProductApi.Data;
//using ProductApi.Data.Interfaces;
//using ProductApi.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with a real or in-memory database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));  // Assuming you're using SQL Server
// Register the repository interface and its implementation
builder.Services.AddScoped<IUserRepo, UserRepo>();
var app = builder.Build();
// Apply any pending migrations at runtime
// Optional: Apply migrations (to ensure your database schema is updated)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();  // Apply any pending migrations
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
