using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            #region Repo
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
                ServiceLifetime.Scoped);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });
            services.AddScoped<IUser, UserRepo>();
            #endregion
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Set your desired password requirements here
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6; // Set your desired minimum length
                options.Password.RequiredUniqueChars = 0; // Set your desired number of unique characters
            });
            return services;
        }
    }
}
