using Microsoft.EntityFrameworkCore;
using Omnific.Model;
using Omnific.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFantasyCharacterService, FantasyCharacterService>();
//builder.Services.AddScoped<IFantasyAnimalService, FantasyAnimalService>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("OmnificConnectionString");

builder.Services.AddDbContext<OmnificContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();