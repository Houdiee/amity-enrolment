using Api;
using Api.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();
string jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new Exception("JWT_SECRET_KEY cannot be null");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddOpenApi();

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
