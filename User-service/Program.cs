using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using User_service.Application;
using User_service.Infrastructure;
using User_service.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddScoped<ILoginRegisterService, LoginRegisterService>();
builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccessTokenService, AccessTokenService>();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Disabling default mapping of claims to context. Allows searching based on JwtRegisteredClaimNames.
        options.MapInboundClaims = false;

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer =
                Environment.GetEnvironmentVariable("JWT_MICROSERVICE")
                ?? throw new Exception("Jwt microservice endpoint not found"),
            ValidAudience =
                Environment.GetEnvironmentVariable("USER_MICROSERVICE")
                ?? throw new Exception("User microservice endpoint not found"),
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    Environment.GetEnvironmentVariable("ACCESS_TOKEN_SECRET_KEY")
                        ?? throw new Exception("Access token secret key not set")
                )
            ),
        };
    });

builder
    .Services.AddAuthorizationBuilder()
    // Checks if access token's subject is the same as the requested user in the route.
    .AddPolicy(
        "SpecificUser",
        policy =>
            policy.RequireAssertion(context =>
            {
                var subject = context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                var routeUserId = (context.Resource as HttpContext)
                    ?.Request.RouteValues["userUuid"]
                    ?.ToString();

                foreach (var claim in context.User.Claims)
                {
                    Console.WriteLine("TYPE: " + claim.Type + ", VALUE: " + claim.Value);
                }

                return subject == routeUserId;
            })
    );

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
