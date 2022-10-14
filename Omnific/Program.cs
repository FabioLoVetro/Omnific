using Microsoft.EntityFrameworkCore;
using Omnific.Model;
using Omnific.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<OmnificContext>(option =>
    option.UseInMemoryDatabase("OmnificDB"));

// Configure Swagger/OpenAPI Documentation
// You can learn more on this link: https://aka.ms/aspnetcore/swashbuckle
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
//app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.MapRazorPages();

app.Run();