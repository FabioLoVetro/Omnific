using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Omnific.Model;
using Omnific.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFantasyCharacterService, FantasyCharacterService>();
builder.Services.AddScoped<IFantasyAnimalService, FantasyAnimalService>();
builder.Services.AddScoped<ILogService, LogService>();


builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("OmnificConnectionString");

if (builder.Environment.IsProduction() ||
    builder.Environment.IsDevelopment())
{
    // real database
    builder.Services.AddDbContext<OmnificContext>(option => option.UseMySql(
        connectionString, ServerVersion.AutoDetect(connectionString)));

}
else
{
    //if (builder.Environment.EnvironmentName == "Testing")
    // in test environment use a fresh in-memory DB
    builder.Services.AddDbContext<OmnificContext>(option =>
        option.UseInMemoryDatabase("OmnificDb"));
}


builder.Services.AddEndpointsApiExplorer();
//added options in builder.Services.AddSwaggerGen()
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//Authentication scheme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction() ||
    app.Environment.IsDevelopment() ||
    app.Environment.EnvironmentName == "Testing")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();