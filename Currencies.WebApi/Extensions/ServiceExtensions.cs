using Currencies.BLL.IServices;
using Currencies.BLL.MappingProfile;
using Currencies.BLL.Services;
using Currencies.DAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Currencies.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurrenciesContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("CurrenciesDBConnection"))
        );

            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IUserService, UserService>();

            services.AddMemoryCache();
        }
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CurrencyProfile>();
                cfg.AddProfile<UserProfile>();
            },
            Assembly.GetExecutingAssembly());
        }

        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    string secretKey = configuration["Token:SecretJWTKey"];
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curriences",
                    Description = "Service that displays the current exchange rate"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = @"Enter 'Bearer' [space] and then your token in the text input below. <br/><b>Example:</b> 'Bearer 12345abcdef'",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                });
            });
        }
    }
}
