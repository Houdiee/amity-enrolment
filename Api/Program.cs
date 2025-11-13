using Api;
using Api.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();
string jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new Exception("JWT_SECRET_KEY cannot be null");
string frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? throw new Exception("FRONTEND_URL cannot be null");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ApiDbContext>(options =>
{
    _ = options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_URL"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };
});

builder.Services.AddScoped<TokenService>(provider =>
{
    return new TokenService(jwtSecretKey);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
          .WithOrigins(frontendUrl)
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
